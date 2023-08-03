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
using Newtonsoft.Json;

namespace ADSPRoject;

public class frmUserBMManager : Form
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public List<UserInBM_Data> dataJson;

		internal void _003CcopyPasteEvent_003Eb__2<T0, T1>(T1 param)
		{
			Clipboard.Clear();
			T0 text = (T0)JsonConvert.SerializeObject((object)dataJson);
			Clipboard.SetText((string)text);
		}
	}

	private frmAdsManager frm;

	private string BM_ID;

	private bool AsignUserToGroup;

	private business_asset_groups asset_groups;

	private UserInBM user = new UserInBM();

	private bool isRunning = false;

	private int intThreadBM = 0;

	private int intDelayBM = 0;

	private int GROUP_ID;

	private bool ShagePage = false;

	private business_asset_groups pageInBM;

	private bool isClassPage = true;

	private string PageInBM_ID;

	private bool DeletePartner;

	private bool DeletePageList;

	private bool RemoveInvitation;

	private IContainer components = null;

	private Button btnReload;

	private DataGridView gvData;

	private Panel panel1;

	private CheckBox cbAsignUserToGroup;

	private ComboBox ccbGroupInBM;

	private NumericUpDown numDelayBM;

	private Label label16;

	private NumericUpDown numThread;

	private Label label2;

	private Button button1;

	private System.Windows.Forms.Timer timer_auto_refesh;

	private Label lbTotal;

	private TextBox txtSearch;

	private Button button2;

	private Label lbRowSelect;

	private ComboBox ccbTypeData;

	private ComboBox ccbPageInBM;

	private CheckBox ccbPageList;

	private Button button3;

	private Panel panel2;

	private RadioButton rbPro5Page;

	private RadioButton rbClassicPage;

	private CheckBox cbDeletePartner;

	private CheckBox ccbDeletePageList;

	private CheckBox cbRemoveInvitation;

	public int intThread { get; set; }

	public frmUserBMManager(frmAdsManager formMain, string BM_ID)
	{
		InitializeComponent<DataGridViewCellStyle, ComponentResourceManager, Container, Button, DataGridView, Panel, CheckBox, RadioButton, ComboBox, NumericUpDown, Label, TextBox, bool, List<UserInBM_Data>.Enumerator, int, object, EventArgs, string, Exception, Dictionary<string, string>, DataGridViewRowStateChangedEventArgs, ContextMenu, MenuItem, MouseEventArgs, List<business_asset_groups_data>.Enumerator, List<business_asset_groups_data>, decimal, Icon>();
		frm = formMain;
		this.BM_ID = BM_ID;
	}

	private void cbAsignUserToGroup_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		AsignUserToGroup = cbAsignUserToGroup.Checked;
		T0 val = (T0)AsignUserToGroup;
		if (val == null)
		{
			cbAsignUserToGroup.ForeColor = SystemColors.Highlight;
			return;
		}
		cbAsignUserToGroup.ForeColor = Color.Red;
		getGroupInBM<T0, List<business_asset_groups_data>.Enumerator, Dictionary<string, string>, string, Exception>();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void getGroupInBM<T0, T1, T2, T3, T4>()
	{
		//IL_0046: Expected O, but got I4
		//IL_00ba: Expected O, but got I4
		ccbGroupInBM.Items.Clear();
		asset_groups = frm.chrome.get_group_in_bm<T2, T3, T4>((T3)BM_ID);
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void btnReload_Click<T0, T1, T2, T3, T4, T5, T6, T7>(T3 sender, T4 e)
	{
		//IL_001b: Expected O, but got I4
		//IL_0051: Expected O, but got I4
		//IL_0063: Expected O, but got I4
		//IL_00c0: Expected O, but got I4
		//IL_0130: Expected O, but got I4
		gvData.DataSource = null;
		T0 val = (T0)(ccbTypeData.SelectedIndex == 0);
		if (val != null)
		{
			user = frm.chrome.getListUserInBM<T5, T0, T6, T7>((T5)BM_ID, (T5)"business_users");
		}
		else
		{
			T0 val2 = (T0)(ccbTypeData.SelectedIndex == 1);
			if (val2 == null)
			{
				T0 val3 = (T0)(ccbTypeData.SelectedIndex == 2);
				if (val3 != null)
				{
					user = frm.chrome.getListUserInBM<T5, T0, T6, T7>((T5)BM_ID, (T5)"pending_users");
				}
			}
			else
			{
				user = frm.chrome.getListPartnerInBM<T5, T0, T2, T1, T6, T7>((T5)BM_ID);
			}
		}
		T0 val4 = (T0)(user != null && user.data != null);
		if (val4 != null)
		{
			T1 enumerator = (T1)user.data.GetEnumerator();
			try
			{
				while (((List<UserInBM_Data>.Enumerator*)(&enumerator))->MoveNext())
				{
					UserInBM_Data current = ((List<UserInBM_Data>.Enumerator*)(&enumerator))->Current;
					current.select = true;
				}
			}
			finally
			{
				((IDisposable)(*(List<UserInBM_Data>.Enumerator*)(&enumerator))).Dispose();
			}
			gvData.DataSource = user.data;
		}
		lbTotal.Text = System.Runtime.CompilerServices.Unsafe.As<T2, int>(ref (T2)gvData.Rows.Count).ToString();
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
			new Thread(thrStart<T0, List<ListStringData>, int, List<UserInBM_Data>, List<UserInBM_Data>.Enumerator, List<ListStringData>.Enumerator, Exception, string, List<object>, Dictionary<string, string>, T1>).Start();
		}
	}

	private unsafe void thrStart<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
	{
		//IL_0002: Expected O, but got I4
		//IL_002e: Expected O, but got I4
		//IL_0047: Expected O, but got I4
		//IL_005c: Expected O, but got I4
		//IL_0074: Expected I4, but got O
		//IL_007b: Expected O, but got I4
		//IL_008d: Expected O, but got I4
		//IL_00a5: Expected I4, but got O
		//IL_00cc: Expected I4, but got O
		//IL_00ec: Expected I4, but got O
		//IL_013d: Expected O, but got I4
		//IL_014f: Expected O, but got I4
		//IL_0206: Expected O, but got I4
		//IL_0230: Expected O, but got I4
		//IL_02ae: Expected O, but got I4
		//IL_02d2: Expected O, but got I4
		//IL_0350: Expected O, but got I4
		//IL_03ec: Expected O, but got I4
		//IL_04c8: Expected O, but got I4
		//IL_0553: Unknown result type (might be due to invalid IL or missing references)
		//IL_0555: Expected O, but got Unknown
		T0 val = (T0)1;
		T0 val2 = (T0)(user != null && user.data != null && user.data.Count > 0);
		if (val2 != null)
		{
			try
			{
				T1 val3 = (T1)Activator.CreateInstance(typeof(T1));
				T2 val4 = (T2)0;
				while (true)
				{
					T0 val5 = (T0)((nint)val4 < user.data.Count);
					if (val5 == null)
					{
						break;
					}
					T0 val6 = (T0)user.data[(int)val4].select;
					if (val6 != null)
					{
						T0 val7 = (T0)(!isRunning);
						if (val7 != null)
						{
							return;
						}
						user.data[(int)val4].message = frmMain.STATUS.Processing.ToString();
						user.data[(int)val4].select = false;
						ListStringData listStringData = new ListStringData();
						listStringData.str1 = user.data[(int)val4].id;
						listStringData.str2 = "";
						((List<ListStringData>)val3).Add(listStringData);
						T0 val8 = (T0)((((List<ListStringData>)val3).Count >= intThreadBM || (nint)val4 == user.data.Count - 1) && ((List<ListStringData>)val3).Count > 0);
						if (val8 != null)
						{
							T3 val9 = (T3)null;
							T0 val10 = (T0)AsignUserToGroup;
							if (val10 != null)
							{
								val = frm.chrome.chi_dinh_user_nhom_tai_san_Promise<T0, T7, T8, T5, T9, T2, T6, T1>((T7)asset_groups.data[GROUP_ID].id, (T7)BM_ID, val3);
								val9 = (T3)user.data.Join((IEnumerable<ListStringData>)val3, (Func<UserInBM_Data, T7>)(object)(Func<UserInBM_Data, string>)((UserInBM_Data a) => (T7)a.id), (Func<ListStringData, T7>)(object)(Func<ListStringData, string>)((ListStringData d) => (T7)d.str1), (UserInBM_Data a, ListStringData d) => a).ToList();
							}
							T0 val11 = (T0)ShagePage;
							if (val11 != null)
							{
								val = frm.chrome.chi_dinh_user_page_Promise<T0, T7, T8, T2, T6, T1, T10>((T7)PageInBM_ID, (T7)BM_ID, val3, (T0)isClassPage);
								val9 = (T3)user.data.Join((IEnumerable<ListStringData>)val3, (Func<UserInBM_Data, T7>)(object)(Func<UserInBM_Data, string>)((UserInBM_Data a) => (T7)a.id), (Func<ListStringData, T7>)(object)(Func<ListStringData, string>)((ListStringData d) => (T7)d.str1), (UserInBM_Data a, ListStringData d) => a).ToList();
							}
							T0 val12 = (T0)DeletePageList;
							if (val12 != null)
							{
								val = frm.chrome.xoa_quyen_page_bm_Promise<T0, T7, T8, T5, T9, T2, T6, T1>((T7)PageInBM_ID, val3, (T0)isClassPage);
								val9 = (T3)user.data.Join((IEnumerable<ListStringData>)val3, (Func<UserInBM_Data, T7>)(object)(Func<UserInBM_Data, string>)((UserInBM_Data a) => (T7)a.id), (Func<ListStringData, T7>)(object)(Func<ListStringData, string>)((ListStringData d) => (T7)d.str1), (UserInBM_Data a, ListStringData d) => a).ToList();
							}
							T0 val13 = (T0)RemoveInvitation;
							if (val13 != null)
							{
								val = frm.chrome.xoa_loi_moi_bm<T0, T7, T8, T5, T9, T2, T6, T1>((T7)BM_ID, val3);
								val9 = (T3)user.data.Join((IEnumerable<ListStringData>)val3, (Func<UserInBM_Data, T7>)(object)(Func<UserInBM_Data, string>)((UserInBM_Data a) => (T7)a.id), (Func<ListStringData, T7>)(object)(Func<ListStringData, string>)((ListStringData d) => (T7)d.str1), (UserInBM_Data a, ListStringData d) => a).ToList();
							}
							T0 val14 = (T0)DeletePartner;
							if (val14 != null)
							{
								val = frm.chrome.xoa_doi_tac_bm<T0, T7, T8, T5, T9, T2, T6, T1>((T7)BM_ID, val3);
								val9 = (T3)user.data.Join((IEnumerable<ListStringData>)val3, (Func<UserInBM_Data, T7>)(object)(Func<UserInBM_Data, string>)((UserInBM_Data a) => (T7)a.id), (Func<ListStringData, T7>)(object)(Func<ListStringData, string>)((ListStringData d) => (T7)d.str1), (UserInBM_Data a, ListStringData d) => a).ToList();
							}
							T0 val15 = val;
							if (val15 != null)
							{
								T4 enumerator = (T4)((List<UserInBM_Data>)val9).GetEnumerator();
								try
								{
									while (((List<UserInBM_Data>.Enumerator*)(&enumerator))->MoveNext())
									{
										UserInBM_Data current = ((List<UserInBM_Data>.Enumerator*)(&enumerator))->Current;
										T5 enumerator2 = (T5)((List<ListStringData>)val3).GetEnumerator();
										try
										{
											while (((List<ListStringData>.Enumerator*)(&enumerator2))->MoveNext())
											{
												ListStringData current2 = ((List<ListStringData>.Enumerator*)(&enumerator2))->Current;
												T0 val16 = (T0)current.id.Equals(current2.str1);
												if (val16 != null)
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
									((IDisposable)(*(List<UserInBM_Data>.Enumerator*)(&enumerator))).Dispose();
								}
							}
							else
							{
								T4 enumerator3 = (T4)((List<UserInBM_Data>)val9).GetEnumerator();
								try
								{
									while (((List<UserInBM_Data>.Enumerator*)(&enumerator3))->MoveNext())
									{
										UserInBM_Data current3 = ((List<UserInBM_Data>.Enumerator*)(&enumerator3))->Current;
										current3.message = frmMain.STATUS.lỗi.ToString();
									}
								}
								finally
								{
									((IDisposable)(*(List<UserInBM_Data>.Enumerator*)(&enumerator3))).Dispose();
								}
							}
							((List<ListStringData>)val3).Clear();
							Thread.Sleep(intDelayBM);
						}
					}
					val4 = (T2)(val4 + 1);
				}
			}
			catch (Exception ex)
			{
				frmMain.errorMessage((T7)ex.Message);
			}
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

	private void numThread_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		intThreadBM = int.Parse(((decimal)(T0)numThread.Value).ToString());
	}

	private void numDelayBM_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		intDelayBM = int.Parse(((decimal)(T0)numDelayBM.Value).ToString());
	}

	private void ccbGroupInBM_SelectedIndexChanged<T0, T1>(T0 sender, T1 e)
	{
		GROUP_ID = ccbGroupInBM.SelectedIndex;
	}

	private void button2_Click<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_001e: Expected O, but got I4
		//IL_0034: Expected I4, but got O
		//IL_0047: Expected I4, but got O
		//IL_0064: Expected I4, but got O
		//IL_008a: Expected I4, but got O
		//IL_00a7: Expected I4, but got O
		//IL_00cd: Expected I4, but got O
		//IL_00ea: Expected I4, but got O
		//IL_010d: Expected I4, but got O
		//IL_012a: Expected I4, but got O
		//IL_0150: Expected I4, but got O
		//IL_016d: Expected I4, but got O
		//IL_0181: Expected O, but got I4
		//IL_0195: Expected I4, but got O
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Expected O, but got Unknown
		//IL_01b3: Expected O, but got I4
		gvData.ClearSelection();
		T0 value = (T0)txtSearch.Text.ToLower();
		T1 val = (T1)0;
		while (true)
		{
			T2 val2 = (T2)((nint)val < user.data.Count);
			if (val2 != null)
			{
				T2 val3 = (T2)((user.data[(int)val] != null && !string.IsNullOrWhiteSpace(user.data[(int)val].id) && user.data[(int)val].id.ToLower().Contains((string)value)) || (!string.IsNullOrWhiteSpace(user.data[(int)val].last_name) && user.data[(int)val].last_name.ToLower().Contains((string)value)) || (!string.IsNullOrWhiteSpace(user.data[(int)val].first_name) && user.data[(int)val].first_name.ToLower().Contains((string)value)) || (!string.IsNullOrWhiteSpace(user.data[(int)val].message) && user.data[(int)val].message.ToLower().Contains((string)value)) || (!string.IsNullOrWhiteSpace(user.data[(int)val].role) && user.data[(int)val].role.ToLower().Contains((string)value)));
				if (val3 != null)
				{
					gvData.Rows[(int)val].Selected = true;
				}
				val = (T1)(val + 1);
				continue;
			}
			break;
		}
	}

	private void gvData_RowStateChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0017: Expected O, but got I4
		lbRowSelect.Text = System.Runtime.CompilerServices.Unsafe.As<T0, int>(ref (T0)gvData.SelectedRows.Count).ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gvData_MouseClick<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_000e: Expected O, but got I4
		T0 val = (T0)(((MouseEventArgs)e).Button == MouseButtons.Right);
		if (val != null)
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(ContextMenu));
			T2 item = (T2)new MenuItem("Tick dòng", (EventHandler)selectUnselectEvent<T2, T0, List<DataGridViewRow>, int, T3, EventArgs, DataGridViewRow>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Bỏ tick dòng", (EventHandler)selectUnselectEvent<T2, T0, List<DataGridViewRow>, int, T3, EventArgs, DataGridViewRow>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("===============");
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Copy json", (EventHandler)copyPasteEvent<T2, T0, List<DataGridViewRow>, Thread, int, Exception, T3, EventArgs, List<UserInBM_Data>, DataGridViewRow>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Paste json", (EventHandler)copyPasteEvent<T2, T0, List<DataGridViewRow>, Thread, int, Exception, T3, EventArgs, List<UserInBM_Data>, DataGridViewRow>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("===============");
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Clear", (EventHandler)copyPasteEvent<T2, T0, List<DataGridViewRow>, Thread, int, Exception, T3, EventArgs, List<UserInBM_Data>, DataGridViewRow>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			((ContextMenu)val2).Show((Control)gvData, new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void copyPasteEvent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T6 sender, T7 e)
	{
		//IL_001a: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_00b2: Expected O, but got I4
		//IL_00cd: Expected I4, but got O
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_00ec: Expected O, but got I4
		//IL_012a: Expected O, but got I4
		//IL_0144: Expected O, but got I4
		//IL_01b6: Expected O, but got I4
		//IL_01c5: Expected O, but got I4
		//IL_01db: Expected I4, but got O
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Expected O, but got Unknown
		//IL_01f5: Expected O, but got I4
		//IL_0228: Expected O, but got I4
		//IL_0247: Expected O, but got I4
		try
		{
			T0 val = (T0)sender;
			T1 val2 = (T1)((MenuItem)val).Text.Equals("Copy json");
			if (val2 != null)
			{
				_003C_003Ec__DisplayClass26_0 _003C_003Ec__DisplayClass26_ = new _003C_003Ec__DisplayClass26_0();
				_003C_003Ec__DisplayClass26_.dataJson = (List<UserInBM_Data>)Activator.CreateInstance(typeof(T8));
				T2 val3 = (T2)gvData.SelectedRows.Cast<T9>().Where((Func<T9, bool>)(object)(Func<DataGridViewRow, bool>)((T9 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T9, T4>)(object)(Func<DataGridViewRow, int>)((T9 row) => (T4)((DataGridViewBand)row).Index))
					.ToList();
				T1 val4 = (T1)(((List<DataGridViewRow>)val3).Count > 0);
				if (val4 != null)
				{
					T4 val5 = (T4)(((List<DataGridViewRow>)val3).Count - 1);
					while (true)
					{
						T1 val6 = (T1)((nint)val5 >= 0);
						if (val6 == null)
						{
							break;
						}
						_003C_003Ec__DisplayClass26_.dataJson.Add(user.data[((List<DataGridViewRow>)val3)[(int)val5].Index]);
						val5 = (T4)(val5 - 1);
					}
				}
				T3 val7 = (T3)new Thread((ParameterizedThreadStart)_003C_003Ec__DisplayClass26_._003CcopyPasteEvent_003Eb__2<string, T6>);
				((Thread)val7).SetApartmentState(ApartmentState.STA);
				((Thread)val7).Start();
				return;
			}
			T1 val8 = (T1)((MenuItem)val).Text.Equals("Paste json");
			if (val8 == null)
			{
				T1 val9 = (T1)((MenuItem)val).Text.Equals("Clear");
				if (val9 == null)
				{
					return;
				}
				T2 val10 = (T2)gvData.SelectedRows.Cast<T9>().Where((Func<T9, bool>)(object)(Func<DataGridViewRow, bool>)((T9 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T9, T4>)(object)(Func<DataGridViewRow, int>)((T9 row) => (T4)((DataGridViewBand)row).Index))
					.ToList();
				T1 val11 = (T1)(((List<DataGridViewRow>)val10).Count > 0);
				if (val11 != null)
				{
					T4 val12 = (T4)(((List<DataGridViewRow>)val10).Count - 1);
					while (true)
					{
						T1 val13 = (T1)((nint)val12 >= 0);
						if (val13 == null)
						{
							break;
						}
						user.data.RemoveAt(((List<DataGridViewRow>)val10)[(int)val12].Index);
						val12 = (T4)(val12 - 1);
					}
				}
				T3 val14 = (T3)new Thread((ParameterizedThreadStart)delegate
				{
					//IL_0039: Expected O, but got I4
					gvData.DataSource = null;
					gvData.DataSource = user.data;
					lbTotal.Text = System.Runtime.CompilerServices.Unsafe.As<T4, int>(ref (T4)gvData.Rows.Count).ToString();
				});
				((Thread)val14).SetApartmentState(ApartmentState.STA);
				((Thread)val14).Start();
			}
			else
			{
				T1 val15 = (T1)(user == null);
				if (val15 != null)
				{
					user = new UserInBM();
				}
				T1 val16 = (T1)(user.data == null);
				if (val16 != null)
				{
					user.data = (List<UserInBM_Data>)Activator.CreateInstance(typeof(T8));
				}
				T3 val17 = (T3)new Thread((ParameterizedThreadStart)_003CcopyPasteEvent_003Eb__26_3<string, T1, T8, T4, T6>);
				((Thread)val17).SetApartmentState(ApartmentState.STA);
				((Thread)val17).Start();
			}
		}
		catch (Exception ex)
		{
			frmMain.errorMessage(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void selectUnselectEvent<T0, T1, T2, T3, T4, T5, T6>(T4 sender, T5 e)
	{
		//IL_0019: Expected O, but got I4
		//IL_008a: Expected O, but got I4
		//IL_009c: Expected O, but got I4
		//IL_00b2: Expected I4, but got O
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected O, but got Unknown
		//IL_00d2: Expected O, but got I4
		//IL_0143: Expected O, but got I4
		//IL_0150: Expected O, but got I4
		//IL_0165: Expected I4, but got O
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Expected O, but got Unknown
		//IL_0185: Expected O, but got I4
		T0 val = (T0)sender;
		T1 val2 = (T1)((MenuItem)val).Text.Equals("Tick dòng");
		if (val2 == null)
		{
			T2 val3 = (T2)gvData.SelectedRows.Cast<T6>().Where((Func<T6, bool>)(object)(Func<DataGridViewRow, bool>)((T6 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T6, T3>)(object)(Func<DataGridViewRow, int>)((T6 row) => (T3)((DataGridViewBand)row).Index))
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
					user.data[((List<DataGridViewRow>)val3)[(int)val5].Index].select = false;
					val5 = (T3)(val5 - 1);
				}
			}
		}
		else
		{
			T2 val7 = (T2)gvData.SelectedRows.Cast<T6>().Where((Func<T6, bool>)(object)(Func<DataGridViewRow, bool>)((T6 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T6, T3>)(object)(Func<DataGridViewRow, int>)((T6 row) => (T3)((DataGridViewBand)row).Index))
				.ToList();
			T1 val8 = (T1)(((List<DataGridViewRow>)val7).Count > 0);
			if (val8 != null)
			{
				T3 val9 = (T3)(((List<DataGridViewRow>)val7).Count - 1);
				while (true)
				{
					T1 val10 = (T1)((nint)val9 >= 0);
					if (val10 == null)
					{
						break;
					}
					user.data[((List<DataGridViewRow>)val7)[(int)val9].Index].select = true;
					val9 = (T3)(val9 - 1);
				}
			}
		}
		gvData.Refresh();
	}

	private void frmUserBMManager_Load<T0, T1>(T0 sender, T1 e)
	{
		ccbTypeData.SelectedIndex = 0;
	}

	private void ccbPageList_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		ShagePage = ccbPageList.Checked;
		T0 val = (T0)ShagePage;
		if (val != null)
		{
			ccbPageList.ForeColor = Color.Red;
			ccbDeletePageList.Checked = false;
		}
		else
		{
			ccbPageList.ForeColor = SystemColors.Highlight;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void getPageInBM<T0, T1, T2, T3, T4, T5>()
	{
		//IL_0046: Expected O, but got I4
		//IL_00ba: Expected O, but got I4
		ccbPageInBM.Items.Clear();
		pageInBM = frm.chrome.get_page_in_bm<T2, T0, T3, T4, T5>((T2)BM_ID);
		T0 val = (T0)(pageInBM != null && pageInBM.data != null);
		if (val != null)
		{
			T1 enumerator = (T1)pageInBM.data.GetEnumerator();
			try
			{
				while (((List<business_asset_groups_data>.Enumerator*)(&enumerator))->MoveNext())
				{
					business_asset_groups_data current = ((List<business_asset_groups_data>.Enumerator*)(&enumerator))->Current;
					ccbPageInBM.Items.Add(current.id + " " + current.name);
				}
			}
			finally
			{
				((IDisposable)(*(List<business_asset_groups_data>.Enumerator*)(&enumerator))).Dispose();
			}
		}
		T0 val2 = (T0)(ccbPageInBM.Items.Count > 0);
		if (val2 != null)
		{
			ccbPageInBM.SelectedIndex = 0;
		}
	}

	private void button3_Click<T0, T1, T2, T3, T4, T5, T6, T7>(T0 sender, T1 e)
	{
		getPageInBM<T2, T3, T4, T5, T6, T7>();
	}

	private void rbClassicPage_CheckedChanged<T0, T1>(T0 sender, T1 e)
	{
		isClassPage = rbClassicPage.Checked;
	}

	private void rbPro5Page_CheckedChanged<T0, T1>(T0 sender, T1 e)
	{
		isClassPage = rbClassicPage.Checked;
	}

	private void ccbPageInBM_SelectedIndexChanged<T0, T1>(T0 sender, T1 e)
	{
		PageInBM_ID = ccbPageInBM.Text;
	}

	private void ccbPageInBM_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		PageInBM_ID = ccbPageInBM.Text;
	}

	private void cbDeletePartner_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		DeletePartner = cbDeletePartner.Checked;
		T0 val = (T0)DeletePartner;
		if (val == null)
		{
			cbDeletePartner.ForeColor = SystemColors.Highlight;
		}
		else
		{
			cbDeletePartner.ForeColor = Color.Red;
		}
	}

	private void ccbDeletePageList_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		DeletePageList = ccbDeletePageList.Checked;
		T0 val = (T0)DeletePageList;
		if (val != null)
		{
			ccbDeletePageList.ForeColor = Color.Red;
			ccbPageList.Checked = false;
		}
		else
		{
			ccbDeletePageList.ForeColor = SystemColors.Highlight;
		}
	}

	private void cbRemoveInvitation_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		RemoveInvitation = cbRemoveInvitation.Checked;
		T0 val = (T0)RemoveInvitation;
		if (val != null)
		{
			cbRemoveInvitation.ForeColor = Color.Red;
		}
		else
		{
			cbRemoveInvitation.ForeColor = SystemColors.Highlight;
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
	private void InitializeComponent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27>()
	{
		this.components = (System.ComponentModel.IContainer)System.Activator.CreateInstance(typeof(System.ComponentModel.Container));
		T0 val = (T0)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridViewCellStyle));
		T0 val2 = (T0)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridViewCellStyle));
		T0 val3 = (T0)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridViewCellStyle));
		T1 val4 = (T1)new System.ComponentModel.ComponentResourceManager(typeof(ADSPRoject.frmUserBMManager));
		this.btnReload = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.gvData = (System.Windows.Forms.DataGridView)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridView));
		this.panel1 = (System.Windows.Forms.Panel)System.Activator.CreateInstance(typeof(System.Windows.Forms.Panel));
		this.cbRemoveInvitation = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.ccbDeletePageList = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbDeletePartner = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.panel2 = (System.Windows.Forms.Panel)System.Activator.CreateInstance(typeof(System.Windows.Forms.Panel));
		this.rbPro5Page = (System.Windows.Forms.RadioButton)System.Activator.CreateInstance(typeof(System.Windows.Forms.RadioButton));
		this.rbClassicPage = (System.Windows.Forms.RadioButton)System.Activator.CreateInstance(typeof(System.Windows.Forms.RadioButton));
		this.button3 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.ccbPageInBM = (System.Windows.Forms.ComboBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.ComboBox));
		this.ccbPageList = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.numDelayBM = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label16 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.numThread = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label2 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.button1 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.ccbGroupInBM = (System.Windows.Forms.ComboBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.ComboBox));
		this.cbAsignUserToGroup = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.timer_auto_refesh = new System.Windows.Forms.Timer(this.components);
		this.lbTotal = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtSearch = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.button2 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.lbRowSelect = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.ccbTypeData = (System.Windows.Forms.ComboBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.ComboBox));
		((System.ComponentModel.ISupportInitialize)this.gvData).BeginInit();
		this.panel1.SuspendLayout();
		this.panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.numDelayBM).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numThread).BeginInit();
		base.SuspendLayout();
		this.btnReload.Location = new System.Drawing.Point(368, 13);
		this.btnReload.Margin = new System.Windows.Forms.Padding(4);
		this.btnReload.Name = "btnReload";
		this.btnReload.Size = new System.Drawing.Size(100, 28);
		this.btnReload.TabIndex = 0;
		this.btnReload.Text = "Reload";
		this.btnReload.UseVisualStyleBackColor = true;
		this.btnReload.Click += new System.EventHandler(btnReload_Click<T12, T13, T14, T15, T16, T17, T18, T19>);
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
		this.gvData.Location = new System.Drawing.Point(16, 86);
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
		this.gvData.Size = new System.Drawing.Size(452, 600);
		this.gvData.TabIndex = 4;
		this.gvData.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(gvData_RowStateChanged<T14, T15, T20>);
		this.gvData.MouseClick += new System.Windows.Forms.MouseEventHandler(gvData_MouseClick<T12, T21, T22, T15, T23>);
		this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.panel1.Controls.Add(this.cbRemoveInvitation);
		this.panel1.Controls.Add(this.ccbDeletePageList);
		this.panel1.Controls.Add(this.cbDeletePartner);
		this.panel1.Controls.Add(this.panel2);
		this.panel1.Controls.Add(this.button3);
		this.panel1.Controls.Add(this.ccbPageInBM);
		this.panel1.Controls.Add(this.ccbPageList);
		this.panel1.Controls.Add(this.numDelayBM);
		this.panel1.Controls.Add(this.label16);
		this.panel1.Controls.Add(this.numThread);
		this.panel1.Controls.Add(this.label2);
		this.panel1.Controls.Add(this.button1);
		this.panel1.Controls.Add(this.ccbGroupInBM);
		this.panel1.Controls.Add(this.cbAsignUserToGroup);
		this.panel1.Location = new System.Drawing.Point(476, 52);
		this.panel1.Margin = new System.Windows.Forms.Padding(4);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(545, 635);
		this.panel1.TabIndex = 5;
		this.cbRemoveInvitation.AutoSize = true;
		this.cbRemoveInvitation.Location = new System.Drawing.Point(131, 106);
		this.cbRemoveInvitation.Margin = new System.Windows.Forms.Padding(4);
		this.cbRemoveInvitation.Name = "cbRemoveInvitation";
		this.cbRemoveInvitation.Size = new System.Drawing.Size(95, 20);
		this.cbRemoveInvitation.TabIndex = 65;
		this.cbRemoveInvitation.Text = "Xóa lời mời";
		this.cbRemoveInvitation.UseVisualStyleBackColor = true;
		this.cbRemoveInvitation.CheckedChanged += new System.EventHandler(cbRemoveInvitation_CheckedChanged<T12, T15, T16>);
		this.ccbDeletePageList.AutoSize = true;
		this.ccbDeletePageList.Location = new System.Drawing.Point(106, 38);
		this.ccbDeletePageList.Margin = new System.Windows.Forms.Padding(4);
		this.ccbDeletePageList.Name = "ccbDeletePageList";
		this.ccbDeletePageList.Size = new System.Drawing.Size(111, 20);
		this.ccbDeletePageList.TabIndex = 64;
		this.ccbDeletePageList.Text = "Thu hồi page:";
		this.ccbDeletePageList.UseVisualStyleBackColor = true;
		this.ccbDeletePageList.CheckedChanged += new System.EventHandler(ccbDeletePageList_CheckedChanged<T12, T15, T16>);
		this.cbDeletePartner.AutoSize = true;
		this.cbDeletePartner.Location = new System.Drawing.Point(4, 106);
		this.cbDeletePartner.Margin = new System.Windows.Forms.Padding(4);
		this.cbDeletePartner.Name = "cbDeletePartner";
		this.cbDeletePartner.Size = new System.Drawing.Size(119, 20);
		this.cbDeletePartner.TabIndex = 63;
		this.cbDeletePartner.Text = "Xóa đối tác BM";
		this.cbDeletePartner.UseVisualStyleBackColor = true;
		this.cbDeletePartner.CheckedChanged += new System.EventHandler(cbDeletePartner_CheckedChanged<T12, T15, T16>);
		this.panel2.Controls.Add(this.rbPro5Page);
		this.panel2.Controls.Add(this.rbClassicPage);
		this.panel2.Location = new System.Drawing.Point(187, 67);
		this.panel2.Name = "panel2";
		this.panel2.Size = new System.Drawing.Size(251, 30);
		this.panel2.TabIndex = 62;
		this.rbPro5Page.AutoSize = true;
		this.rbPro5Page.Location = new System.Drawing.Point(112, 3);
		this.rbPro5Page.Name = "rbPro5Page";
		this.rbPro5Page.Size = new System.Drawing.Size(56, 20);
		this.rbPro5Page.TabIndex = 61;
		this.rbPro5Page.Text = "Pro5";
		this.rbPro5Page.UseVisualStyleBackColor = true;
		this.rbPro5Page.CheckedChanged += new System.EventHandler(rbPro5Page_CheckedChanged);
		this.rbClassicPage.AutoSize = true;
		this.rbClassicPage.Checked = true;
		this.rbClassicPage.Location = new System.Drawing.Point(3, 3);
		this.rbClassicPage.Name = "rbClassicPage";
		this.rbClassicPage.Size = new System.Drawing.Size(104, 20);
		this.rbClassicPage.TabIndex = 60;
		this.rbClassicPage.TabStop = true;
		this.rbClassicPage.Text = "Page thường";
		this.rbClassicPage.UseVisualStyleBackColor = true;
		this.rbClassicPage.CheckedChanged += new System.EventHandler(rbClassicPage_CheckedChanged);
		this.button3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.button3.Location = new System.Drawing.Point(466, 36);
		this.button3.Margin = new System.Windows.Forms.Padding(4);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(74, 28);
		this.button3.TabIndex = 11;
		this.button3.Text = "Reload";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(button3_Click<T15, T16, T12, T24, T17, T18, T25, T19>);
		this.ccbPageInBM.FormattingEnabled = true;
		this.ccbPageInBM.Location = new System.Drawing.Point(225, 36);
		this.ccbPageInBM.Margin = new System.Windows.Forms.Padding(4);
		this.ccbPageInBM.Name = "ccbPageInBM";
		this.ccbPageInBM.Size = new System.Drawing.Size(233, 24);
		this.ccbPageInBM.TabIndex = 59;
		this.ccbPageInBM.SelectedIndexChanged += new System.EventHandler(ccbPageInBM_SelectedIndexChanged);
		this.ccbPageInBM.TextChanged += new System.EventHandler(ccbPageInBM_TextChanged);
		this.ccbPageList.AutoSize = true;
		this.ccbPageList.Location = new System.Drawing.Point(4, 38);
		this.ccbPageList.Margin = new System.Windows.Forms.Padding(4);
		this.ccbPageList.Name = "ccbPageList";
		this.ccbPageList.Size = new System.Drawing.Size(103, 20);
		this.ccbPageList.TabIndex = 58;
		this.ccbPageList.Text = "Share page:";
		this.ccbPageList.UseVisualStyleBackColor = true;
		this.ccbPageList.CheckedChanged += new System.EventHandler(ccbPageList_CheckedChanged<T12, T15, T16>);
		this.numDelayBM.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.numDelayBM.Location = new System.Drawing.Point(359, 601);
		this.numDelayBM.Margin = new System.Windows.Forms.Padding(4);
		this.numDelayBM.Name = "numDelayBM";
		this.numDelayBM.Size = new System.Drawing.Size(84, 22);
		this.numDelayBM.TabIndex = 57;
		this.numDelayBM.Value = new decimal((int[])(object)new T14[4]
		{
			(T14)1,
			default(T14),
			default(T14),
			default(T14)
		});
		this.numDelayBM.ValueChanged += new System.EventHandler(numDelayBM_ValueChanged<T26, T15, T16>);
		this.label16.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.label16.AutoSize = true;
		this.label16.Location = new System.Drawing.Point(297, 603);
		this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label16.Name = "label16";
		this.label16.Size = new System.Drawing.Size(46, 16);
		this.label16.TabIndex = 56;
		this.label16.Text = "Delay:";
		this.numThread.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.numThread.Location = new System.Drawing.Point(205, 601);
		this.numThread.Margin = new System.Windows.Forms.Padding(4);
		this.numThread.Maximum = new decimal((int[])(object)new T14[4]
		{
			(T14)276447231,
			(T14)23283,
			default(T14),
			default(T14)
		});
		this.numThread.Name = "numThread";
		this.numThread.Size = new System.Drawing.Size(84, 22);
		this.numThread.TabIndex = 55;
		this.numThread.Value = new decimal((int[])(object)new T14[4]
		{
			(T14)1,
			default(T14),
			default(T14),
			default(T14)
		});
		this.numThread.ValueChanged += new System.EventHandler(numThread_ValueChanged<T26, T15, T16>);
		this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(144, 603);
		this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(47, 16);
		this.label2.TabIndex = 54;
		this.label2.Text = "Luồng:";
		this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.button1.BackColor = System.Drawing.Color.DodgerBlue;
		this.button1.Location = new System.Drawing.Point(441, 566);
		this.button1.Margin = new System.Windows.Forms.Padding(4);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(100, 65);
		this.button1.TabIndex = 53;
		this.button1.Text = "START";
		this.button1.UseVisualStyleBackColor = false;
		this.button1.Click += new System.EventHandler(button1_Click<T12, T15, T16>);
		this.ccbGroupInBM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ccbGroupInBM.FormattingEnabled = true;
		this.ccbGroupInBM.Location = new System.Drawing.Point(187, 4);
		this.ccbGroupInBM.Margin = new System.Windows.Forms.Padding(4);
		this.ccbGroupInBM.Name = "ccbGroupInBM";
		this.ccbGroupInBM.Size = new System.Drawing.Size(353, 24);
		this.ccbGroupInBM.TabIndex = 5;
		this.ccbGroupInBM.SelectedIndexChanged += new System.EventHandler(ccbGroupInBM_SelectedIndexChanged);
		this.cbAsignUserToGroup.AutoSize = true;
		this.cbAsignUserToGroup.Location = new System.Drawing.Point(4, 6);
		this.cbAsignUserToGroup.Margin = new System.Windows.Forms.Padding(4);
		this.cbAsignUserToGroup.Name = "cbAsignUserToGroup";
		this.cbAsignUserToGroup.Size = new System.Drawing.Size(157, 20);
		this.cbAsignUserToGroup.TabIndex = 0;
		this.cbAsignUserToGroup.Text = "Chỉ định nhóm tài sản:";
		this.cbAsignUserToGroup.UseVisualStyleBackColor = true;
		this.cbAsignUserToGroup.CheckedChanged += new System.EventHandler(cbAsignUserToGroup_CheckedChanged<T12, T15, T16>);
		this.timer_auto_refesh.Interval = 1000;
		this.timer_auto_refesh.Tick += new System.EventHandler(timer_auto_refesh_Tick<T12, T15, T16>);
		this.lbTotal.AutoSize = true;
		this.lbTotal.Location = new System.Drawing.Point(488, 19);
		this.lbTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.lbTotal.Name = "lbTotal";
		this.lbTotal.Size = new System.Drawing.Size(14, 16);
		this.lbTotal.TabIndex = 6;
		this.lbTotal.Text = "0";
		this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtSearch.Location = new System.Drawing.Point(12, 56);
		this.txtSearch.Name = "txtSearch";
		this.txtSearch.Size = new System.Drawing.Size(349, 22);
		this.txtSearch.TabIndex = 7;
		this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.button2.Location = new System.Drawing.Point(368, 53);
		this.button2.Margin = new System.Windows.Forms.Padding(4);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(100, 28);
		this.button2.TabIndex = 8;
		this.button2.Text = "Search";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click<T17, T14, T12, T15, T16>);
		this.lbRowSelect.AutoSize = true;
		this.lbRowSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lbRowSelect.Location = new System.Drawing.Point(23, 94);
		this.lbRowSelect.Name = "lbRowSelect";
		this.lbRowSelect.Size = new System.Drawing.Size(15, 16);
		this.lbRowSelect.TabIndex = 9;
		this.lbRowSelect.Text = "0";
		this.ccbTypeData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ccbTypeData.FormattingEnabled = true;
		this.ccbTypeData.Items.AddRange((object[])(object)new T15[3]
		{
			(T15)"Người dùng trong BM",
			(T15)"Đối tác",
			(T15)"Lời mời"
		});
		this.ccbTypeData.Location = new System.Drawing.Point(16, 16);
		this.ccbTypeData.Name = "ccbTypeData";
		this.ccbTypeData.Size = new System.Drawing.Size(345, 24);
		this.ccbTypeData.TabIndex = 10;
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1037, 702);
		base.Controls.Add(this.ccbTypeData);
		base.Controls.Add(this.lbRowSelect);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.txtSearch);
		base.Controls.Add(this.lbTotal);
		base.Controls.Add(this.panel1);
		base.Controls.Add(this.gvData);
		base.Controls.Add(this.btnReload);
		base.Icon = (System.Drawing.Icon)(T27)((System.Resources.ResourceManager)val4).GetObject("$this.Icon");
		base.Margin = new System.Windows.Forms.Padding(4);
		base.Name = "frmUserBMManager";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Quản lý User trong BM";
		base.Load += new System.EventHandler(frmUserBMManager_Load);
		((System.ComponentModel.ISupportInitialize)this.gvData).EndInit();
		this.panel1.ResumeLayout(false);
		this.panel1.PerformLayout();
		this.panel2.ResumeLayout(false);
		this.panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.numDelayBM).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numThread).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
