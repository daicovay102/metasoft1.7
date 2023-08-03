using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ADSPRoject.Data;
using ADSPRoject.Properties;
using Data;
using Newtonsoft.Json;

namespace ADSPRoject;

public class frmModule : Form
{
	private frmMain frmMain;

	private List<int> listIndexUID;

	private List<ModuleSaved> listModuleSaved = (List<ModuleSaved>)Activator.CreateInstance(typeof(List<ModuleSaved>));

	private int indexModule = 0;

	public List<FBFlow> listModuleSelected = (List<FBFlow>)Activator.CreateInstance(typeof(List<FBFlow>));

	private Random rnd = (Random)Activator.CreateInstance(typeof(Random));

	private IContainer components = null;

	private TextBox txtUID;

	private Label label1;

	private GroupBox groupBox1;

	private Button btnSave;

	private Button btnCancel;

	private SplitContainer splitContainer1;

	private ListBox lbModuleFacebook;

	private ListBox lbModuleSelected;

	private Button btnModuleSetup;

	private Button btnDeleteModule;

	private Button btnModuleDown;

	private Button btnModuleUp;

	private Button button1;

	private TabControl tabModule;

	private TabPage tabFacebook;

	private TabPage tabTiktok;

	private ListBox lbModuleTiktok;

	private TabPage tabShopee;

	private ListBox lbModuleShopee;

	private TabPage tabFacebookApi;

	private ListBox lbModuleFacebookApi;

	private Label label2;

	private ComboBox ccbModuleSaved;

	private Button button4;

	private Button button5;

	private ImageList imageList1;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public frmModule(frmMain formMain, List<int> listIndexUID)
	{
		InitializeComponent<ComponentResourceManager, Container, TextBox, Label, GroupBox, SplitContainer, TabControl, TabPage, ListBox, Button, ComboBox, bool, object, MouseEventArgs, ImageListStreamer, List<ModuleSaved>.Enumerator, int, EventArgs, string, List<FBFlow>, List<FBFlow>.Enumerator, List<FBFlowField>.Enumerator, DragEventArgs, List<int>.Enumerator, List<FBFlowField>, Icon, Exception, List<ModuleSaved>>();
		frmMain = formMain;
		this.listIndexUID = listIndexUID;
		foreach (FBFlow item in frmMain.moduleFacebook)
		{
			lbModuleFacebook.Items.Add(item.Flow_Name);
		}
		foreach (FBFlow item2 in frmMain.moduleFacebookApi)
		{
			lbModuleFacebookApi.Items.Add(item2.Flow_Name);
		}
		if (listIndexUID.Count == 0)
		{
			txtUID.Text = "Default config";
			txtUID.Enabled = false;
			getModuleDefault<bool, List<FBFlow>.Enumerator, List<FBFlow>>();
		}
		else
		{
			foreach (int item3 in listIndexUID)
			{
				txtUID.Text += $"{frmMain.listFBEntity[item3].UID},";
			}
			if (listIndexUID.Count == 1)
			{
				FBEntity fBEntity = frmMain.listFBEntity[listIndexUID[0]];
				foreach (FBFlow item4 in fBEntity.Flow)
				{
					FBFlow fBFlow = new FBFlow
					{
						Flow_Name = item4.Flow_Name
					};
					foreach (FBFlowField item5 in item4.Filed)
					{
						fBFlow.Filed.Add(new FBFlowField
						{
							key = item5.key,
							type = item5.type,
							value = item5.value
						});
					}
					listModuleSelected.Add(fBFlow);
				}
				if (listModuleSelected == null)
				{
					listModuleSelected = (List<FBFlow>)Activator.CreateInstance(typeof(List<FBFlow>));
				}
				lbModuleSelected.Items.Clear();
				foreach (FBFlow item6 in listModuleSelected)
				{
					lbModuleSelected.Items.Add(item6.Flow_Name);
				}
			}
			else if (frmMain.questioniMessage<DialogResult, string>("Load default config?") == DialogResult.Yes)
			{
				getModuleDefault<bool, List<FBFlow>.Enumerator, List<FBFlow>>();
			}
		}
		if (frmMain.setting.ccbTarget.Equals("Facebook Chrome"))
		{
			tabModule.TabPages.Remove(tabFacebookApi);
		}
		else if (frmMain.setting.ccbTarget.Equals("Facebook API"))
		{
			tabModule.TabPages.Remove(tabFacebook);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void frmConfig_Load<T0, T1, T2, T3, T4, T5>(T2 sender, T3 e)
	{
		//IL_000d: Expected O, but got I4
		//IL_0040: Expected O, but got I4
		try
		{
			T0 val = (T0)File.Exists("modulesaved.json");
			if (val != null)
			{
				listModuleSaved = (List<ModuleSaved>)JsonConvert.DeserializeObject<T4>(File.ReadAllText("modulesaved.json"));
			}
			T0 val2 = (T0)(listModuleSaved == null || listModuleSaved.Count == 0);
			if (val2 != null)
			{
				object obj = Activator.CreateInstance(typeof(T4));
				((List<ModuleSaved>)obj).Add(new ModuleSaved
				{
					Name = "Mặc định",
					listModule = (List<FBFlow>)Activator.CreateInstance(typeof(T5)),
					Category = frmMain.setting.ccbTarget
				});
				listModuleSaved = (List<ModuleSaved>)obj;
				saveModuleSaved();
			}
		}
		catch (Exception ex)
		{
			frmMain.errorMessage(ex.Message);
		}
		loadCate<List<ModuleSaved>.Enumerator, T0, string>("");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void saveModuleSaved()
	{
		File.WriteAllText("modulesaved.json", JsonConvert.SerializeObject((object)listModuleSaved));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void loadCate<T0, T1, T2>(T2 selectItem)
	{
		//IL_004d: Expected O, but got I4
		//IL_00a1: Expected O, but got I4
		ccbModuleSaved.Items.Clear();
		T0 enumerator = (T0)listModuleSaved.GetEnumerator();
		try
		{
			while (((List<ModuleSaved>.Enumerator*)(&enumerator))->MoveNext())
			{
				ModuleSaved current = ((List<ModuleSaved>.Enumerator*)(&enumerator))->Current;
				T1 val = (T1)(!string.IsNullOrWhiteSpace(current.Category) && current.Category.Equals(frmMain.setting.ccbTarget));
				if (val != null)
				{
					ccbModuleSaved.Items.Add(current.Name);
				}
			}
		}
		finally
		{
			((IDisposable)(*(List<ModuleSaved>.Enumerator*)(&enumerator))).Dispose();
		}
		ccbModuleSaved.Items.Add("+Thêm mục mới");
		T1 val2 = (T1)(!string.IsNullOrWhiteSpace((string)selectItem));
		if (val2 != null)
		{
			ccbModuleSaved.SelectedItem = selectItem;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void getModuleDefault<T0, T1, T2>()
	{
		//IL_000c: Expected O, but got I4
		//IL_0032: Expected O, but got I4
		T0 val = (T0)File.Exists("module.json");
		if (val == null)
		{
			return;
		}
		listModuleSelected = (List<FBFlow>)JsonConvert.DeserializeObject<T2>(File.ReadAllText("module.json"));
		T0 val2 = (T0)(listModuleSelected == null);
		if (val2 != null)
		{
			listModuleSelected = (List<FBFlow>)Activator.CreateInstance(typeof(T2));
		}
		lbModuleSelected.Items.Clear();
		T1 enumerator = (T1)listModuleSelected.GetEnumerator();
		try
		{
			while (((List<FBFlow>.Enumerator*)(&enumerator))->MoveNext())
			{
				FBFlow current = ((List<FBFlow>.Enumerator*)(&enumerator))->Current;
				lbModuleSelected.Items.Add(current.Flow_Name);
			}
		}
		finally
		{
			((IDisposable)(*(List<FBFlow>.Enumerator*)(&enumerator))).Dispose();
		}
	}

	private void lbModule_MouseDown<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0037: Expected O, but got I4
		indexModule = lbModuleFacebook.IndexFromPoint(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
		T0 val = (T0)(indexModule >= 0 && ((MouseEventArgs)e).Button == MouseButtons.Left);
		if (val != null)
		{
			lbModuleFacebook.DoDragDrop(lbModuleFacebook.Items[indexModule].ToString(), DragDropEffects.Copy);
		}
	}

	private void lbModuleSelected_SelectedIndexChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0027: Expected O, but got I4
		//IL_0065: Expected O, but got I4
		//IL_0092: Expected O, but got I4
		btnModuleUp.Enabled = true;
		btnModuleDown.Enabled = true;
		T0 val = (T0)(lbModuleSelected.SelectedIndex == 0);
		if (val != null)
		{
			btnModuleUp.Enabled = false;
			btnModuleDown.Enabled = true;
		}
		T0 val2 = (T0)(lbModuleSelected.SelectedIndex >= lbModuleSelected.Items.Count - 1);
		if (val2 != null)
		{
			btnModuleUp.Enabled = true;
			btnModuleDown.Enabled = false;
		}
		selectModuleSelected((T0)0, lbModuleSelected.SelectedIndex);
	}

	public void selectModuleSelected<T0, T1>(T0 isOpenForm, T1 indexModule)
	{
		//IL_0005: Expected O, but got I4
		//IL_0020: Expected I4, but got O
		//IL_002e: Expected O, but got I4
		//IL_0042: Expected I4, but got O
		//IL_0053: Expected O, but got I4
		//IL_0069: Expected I4, but got O
		T0 val = (T0)((nint)indexModule == -1);
		if (val != null)
		{
			return;
		}
		btnModuleSetup.Enabled = false;
		T0 val2 = (T0)(listModuleSelected[(int)indexModule].Filed.Count > 0);
		if (val2 == null)
		{
			return;
		}
		if (isOpenForm != null)
		{
			frmFlow frmFlow2 = new frmFlow(listModuleSelected[(int)indexModule]);
			T0 val3 = (T0)(frmFlow2.ShowDialog() == DialogResult.OK);
			if (val3 != null)
			{
				listModuleSelected[(int)indexModule] = frmFlow2.flow;
			}
		}
		btnModuleSetup.Enabled = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void lbModuleSelected_DragDrop<T0, T1, T2, T3, T4>(T2 sender, T3 e)
	{
		//IL_000a: Expected O, but got I4
		//IL_0018: Expected O, but got I4
		//IL_0056: Expected O, but got I4
		//IL_0072: Expected O, but got I4
		//IL_008b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_01c9: Expected O, but got I4
		//IL_01e1: Expected O, but got I4
		//IL_01ef: Expected O, but got I4
		//IL_01f3: Expected O, but got I4
		//IL_01f9: Expected O, but got I4
		//IL_022d: Expected O, but got I4
		T0 val = (T0)(((DragEventArgs)e).Effect == DragDropEffects.Copy);
		if (val != null)
		{
			T0 val2 = (T0)1;
			string strModule = ((DragEventArgs)e).Data.GetData(typeof(T4)).ToString();
			FBFlow fBFlow = new FBFlow();
			FBFlow fBFlow2 = null;
			T0 val3 = (T0)(tabModule.SelectedTab == tabFacebook);
			if (val3 == null)
			{
				T0 val4 = (T0)(tabModule.SelectedTab == tabTiktok);
				if (val4 == null)
				{
					T0 val5 = (T0)(tabModule.SelectedTab == tabShopee);
					if (val5 == null)
					{
						T0 val6 = (T0)(tabModule.SelectedTab == tabFacebookApi);
						if (val6 != null)
						{
							fBFlow2 = ((IEnumerable<FBFlow>)frmMain.moduleFacebookApi).Where((Func<FBFlow, bool>)((FBFlow a) => (T0)a.Flow_Name.Equals(strModule))).First();
						}
					}
					else
					{
						fBFlow2 = ((IEnumerable<FBFlow>)frmMain.moduleShopee).Where((Func<FBFlow, bool>)((FBFlow a) => (T0)a.Flow_Name.Equals(strModule))).First();
					}
				}
				else
				{
					fBFlow2 = ((IEnumerable<FBFlow>)frmMain.moduleTiktok).Where((Func<FBFlow, bool>)((FBFlow a) => (T0)a.Flow_Name.Equals(strModule))).First();
				}
			}
			else
			{
				fBFlow2 = ((IEnumerable<FBFlow>)frmMain.moduleFacebook).Where((Func<FBFlow, bool>)((FBFlow a) => (T0)a.Flow_Name.Equals(strModule))).First();
			}
			fBFlow.Flow_Name = fBFlow2.Flow_Name.ToString();
			T1 enumerator = (T1)fBFlow2.Filed.GetEnumerator();
			try
			{
				while (((List<FBFlowField>.Enumerator*)(&enumerator))->MoveNext())
				{
					FBFlowField current = ((List<FBFlowField>.Enumerator*)(&enumerator))->Current;
					fBFlow.Filed.Add(new FBFlowField
					{
						key = current.key,
						type = current.type,
						value = current.value
					});
				}
			}
			finally
			{
				((IDisposable)(*(List<FBFlowField>.Enumerator*)(&enumerator))).Dispose();
			}
			T0 val7 = (T0)(fBFlow.Filed.Count > 0);
			if (val7 != null)
			{
				frmFlow frmFlow2 = new frmFlow(fBFlow);
				T0 val8 = (T0)(frmFlow2.ShowDialog() == DialogResult.OK);
				if (val8 != null)
				{
					fBFlow = frmFlow2.flow;
					val2 = (T0)0;
				}
			}
			else
			{
				val2 = (T0)0;
			}
			T0 val9 = (T0)(val2 == null);
			if (val9 != null)
			{
				lbModuleSelected.Items.Add(strModule);
				listModuleSelected.Add(fBFlow);
			}
		}
		else
		{
			T0 val10 = (T0)(((DragEventArgs)e).Effect == DragDropEffects.Move);
			if (val10 != null)
			{
				MessageBox.Show("aa");
			}
		}
	}

	public void setModuleList()
	{
	}

	private void lbModuleSelected_DragEnter<T0, T1, T2, T3>(T1 sender, T2 e)
	{
		//IL_0016: Expected O, but got I4
		T0 val = (T0)((DragEventArgs)e).Data.GetDataPresent(typeof(T3));
		if (val == null)
		{
			((DragEventArgs)e).Effect = DragDropEffects.None;
		}
		else
		{
			((DragEventArgs)e).Effect = DragDropEffects.Copy;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void btnModuleUp_Click<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_000f: Expected O, but got I4
		//IL_0030: Expected O, but got I4
		//IL_003c: Expected O, but got I4
		//IL_0048: Expected I4, but got O
		//IL_0055: Expected I4, but got O
		//IL_0062: Expected I4, but got O
		//IL_00c8: Expected I4, but got O
		T0 val = (T0)(lbModuleSelected.SelectedIndex == -1);
		if (val != null)
		{
			frmMain.errorMessage("Bạn chưa chọn module!");
			return;
		}
		T1 val2 = (T1)(lbModuleSelected.SelectedIndex - 1);
		T1 val3 = (T1)lbModuleSelected.SelectedIndex;
		FBFlow item = listModuleSelected[(int)val3];
		listModuleSelected.RemoveAt((int)val3);
		listModuleSelected.Insert((int)val2, item);
		lbModuleSelected.Items.Clear();
		T2 enumerator = (T2)listModuleSelected.GetEnumerator();
		try
		{
			while (((List<FBFlow>.Enumerator*)(&enumerator))->MoveNext())
			{
				FBFlow current = ((List<FBFlow>.Enumerator*)(&enumerator))->Current;
				lbModuleSelected.Items.Add(current.Flow_Name);
			}
		}
		finally
		{
			((IDisposable)(*(List<FBFlow>.Enumerator*)(&enumerator))).Dispose();
		}
		lbModuleSelected.SelectedIndex = (int)val2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void btnModuleDown_Click<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_000f: Expected O, but got I4
		//IL_0030: Expected O, but got I4
		//IL_003c: Expected O, but got I4
		//IL_0048: Expected I4, but got O
		//IL_0055: Expected I4, but got O
		//IL_0062: Expected I4, but got O
		//IL_00c8: Expected I4, but got O
		T0 val = (T0)(lbModuleSelected.SelectedIndex == -1);
		if (val != null)
		{
			frmMain.errorMessage("Bạn chưa chọn module!");
			return;
		}
		T1 val2 = (T1)(lbModuleSelected.SelectedIndex + 1);
		T1 val3 = (T1)lbModuleSelected.SelectedIndex;
		FBFlow item = listModuleSelected[(int)val3];
		listModuleSelected.RemoveAt((int)val3);
		listModuleSelected.Insert((int)val2, item);
		lbModuleSelected.Items.Clear();
		T2 enumerator = (T2)listModuleSelected.GetEnumerator();
		try
		{
			while (((List<FBFlow>.Enumerator*)(&enumerator))->MoveNext())
			{
				FBFlow current = ((List<FBFlow>.Enumerator*)(&enumerator))->Current;
				lbModuleSelected.Items.Add(current.Flow_Name);
			}
		}
		finally
		{
			((IDisposable)(*(List<FBFlow>.Enumerator*)(&enumerator))).Dispose();
		}
		lbModuleSelected.SelectedIndex = (int)val2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void btnModuleSetup_Click<T0, T1, T2, T3>(T1 sender, T2 e)
	{
		//IL_000f: Expected O, but got I4
		//IL_0031: Expected O, but got I4
		//IL_0031: Expected O, but got I4
		T0 val = (T0)(lbModuleSelected.SelectedIndex == -1);
		if (val != null)
		{
			frmMain.errorMessage("Bạn chưa chọn module!");
		}
		else
		{
			selectModuleSelected((T0)1, (T3)lbModuleSelected.SelectedIndex);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void btnDeleteModule_Click<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_000f: Expected O, but got I4
		//IL_002e: Expected O, but got I4
		//IL_003a: Expected I4, but got O
		//IL_00b6: Expected O, but got I4
		//IL_00c6: Expected I4, but got O
		T0 val = (T0)(lbModuleSelected.SelectedIndex == -1);
		if (val != null)
		{
			frmMain.errorMessage("Bạn chưa chọn module!");
			return;
		}
		T1 val2 = (T1)lbModuleSelected.SelectedIndex;
		listModuleSelected.RemoveAt((int)val2);
		lbModuleSelected.Items.Clear();
		T2 enumerator = (T2)listModuleSelected.GetEnumerator();
		try
		{
			while (((List<FBFlow>.Enumerator*)(&enumerator))->MoveNext())
			{
				FBFlow current = ((List<FBFlow>.Enumerator*)(&enumerator))->Current;
				lbModuleSelected.Items.Add(current.Flow_Name);
			}
		}
		finally
		{
			((IDisposable)(*(List<FBFlow>.Enumerator*)(&enumerator))).Dispose();
		}
		T0 val3 = (T0)((nint)val2 < listModuleSelected.Count && (nint)val2 >= 0 && listModuleSelected.Count > 0);
		if (val3 != null)
		{
			lbModuleSelected.SelectedIndex = (int)val2;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void btnSave_Click<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T6 sender, T7 e)
	{
		//IL_000f: Expected O, but got I4
		//IL_002f: Expected O, but got I4
		//IL_0031: Expected O, but got I4
		//IL_0033: Expected O, but got I4
		//IL_0036: Expected O, but got I4
		//IL_0039: Expected O, but got I4
		//IL_003c: Expected O, but got I4
		//IL_004e: Expected I4, but got O
		//IL_0060: Expected O, but got I4
		//IL_0066: Expected O, but got I4
		//IL_0076: Expected I4, but got O
		//IL_008d: Expected O, but got I4
		//IL_009a: Expected I4, but got O
		//IL_00b1: Expected O, but got I4
		//IL_00be: Expected I4, but got O
		//IL_00d0: Expected O, but got I4
		//IL_00d6: Expected O, but got I4
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Expected O, but got Unknown
		//IL_00f0: Expected O, but got I4
		//IL_011d: Expected O, but got I4
		//IL_012f: Expected I4, but got O
		//IL_0139: Expected O, but got I4
		//IL_014f: Expected I4, but got O
		//IL_0175: Expected I4, but got O
		//IL_0182: Expected O, but got I4
		//IL_0194: Expected I4, but got O
		//IL_0228: Expected I4, but got O
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Expected O, but got Unknown
		//IL_0241: Expected O, but got I4
		//IL_024b: Expected O, but got I4
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected I4, but got Unknown
		//IL_0263: Expected I4, but got Unknown
		//IL_0325: Expected I4, but got O
		//IL_0354: Expected O, but got I4
		//IL_03d8: Expected I4, but got O
		//IL_03e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ea: Expected O, but got Unknown
		//IL_03f2: Expected O, but got I4
		//IL_03fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fe: Expected O, but got Unknown
		//IL_0410: Expected I4, but got O
		//IL_04a4: Expected I4, but got O
		//IL_04b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b6: Expected O, but got Unknown
		//IL_04c7: Expected O, but got I4
		//IL_0509: Expected O, but got I4
		//IL_051b: Expected I4, but got O
		//IL_0525: Expected O, but got I4
		//IL_053b: Expected I4, but got O
		//IL_0561: Expected I4, but got O
		//IL_0619: Expected I4, but got O
		//IL_0669: Expected O, but got I4
		T0 val = (T0)(listIndexUID.Count == 0);
		if (val != null)
		{
			File.WriteAllText("module.json", JsonConvert.SerializeObject((object)listModuleSelected));
			return;
		}
		T0 val2 = (T0)0;
		T1 val3 = (T1)0;
		T1 val4 = (T1)0;
		T1 val5 = (T1)1;
		T1 val6 = (T1)1;
		T1 val7 = (T1)0;
		while (true)
		{
			T0 val8 = (T0)((nint)val7 < listModuleSelected.Count);
			if (val8 == null)
			{
				break;
			}
			T0 val9 = (T0)listModuleSelected[(int)val7].Flow_Name.Equals("Bắt_đầu_Random");
			if (val9 != null)
			{
				val2 = (T0)1;
				val3 = val7;
				val5 = (T1)int.Parse(listModuleSelected[(int)val7].getValue<T6, T8, T0, string>("Số_lần_lặp_lại").ToString());
				val6 = (T1)int.Parse(listModuleSelected[(int)val7].getValue<T6, T8, T0, string>("Delay").ToString());
			}
			T0 val10 = (T0)listModuleSelected[(int)val7].Flow_Name.Equals("Kết_thúc_Random");
			if (val10 != null)
			{
				val2 = (T0)1;
				val4 = val7;
			}
			val7 = (T1)(val7 + 1);
		}
		T0 val11 = val2;
		if (val11 != null)
		{
			T2 enumerator = (T2)listIndexUID.GetEnumerator();
			try
			{
				while (((List<int>.Enumerator*)(&enumerator))->MoveNext())
				{
					T1 val12 = (T1)((List<int>.Enumerator*)(&enumerator))->Current;
					T0 val13 = (T0)(frmMain.listFBEntity[(int)val12].Flow == null);
					if (val13 != null)
					{
						frmMain.listFBEntity[(int)val12].Flow = (List<FBFlow>)Activator.CreateInstance(typeof(T4));
					}
					frmMain.listFBEntity[(int)val12].Flow.Clear();
					T1 val14 = (T1)0;
					while (true)
					{
						T0 val15 = (T0)(val14 < val3);
						if (val15 == null)
						{
							break;
						}
						FBFlow fBFlow = listModuleSelected[(int)val14];
						FBFlow fBFlow2 = new FBFlow();
						fBFlow2.Flow_Name = fBFlow.Flow_Name;
						T3 enumerator2 = (T3)fBFlow.Filed.GetEnumerator();
						try
						{
							while (((List<FBFlowField>.Enumerator*)(&enumerator2))->MoveNext())
							{
								FBFlowField current = ((List<FBFlowField>.Enumerator*)(&enumerator2))->Current;
								fBFlow2.Filed.Add(new FBFlowField
								{
									key = current.key,
									type = current.type,
									value = current.value
								});
							}
						}
						finally
						{
							((IDisposable)(*(List<FBFlowField>.Enumerator*)(&enumerator2))).Dispose();
						}
						frmMain.listFBEntity[(int)val12].Flow.Add(fBFlow2);
						val14 = (T1)(val14 + 1);
					}
					T1 val16 = (T1)0;
					while (true)
					{
						T0 val17 = (T0)(val16 < val5);
						if (val17 == null)
						{
							break;
						}
						T4 range = (T4)listModuleSelected.GetRange(val3 + 1, (object)val4 - (object)val3 - 1);
						range = mdAutoRandom<T1, T0, T4>(range);
						T5 enumerator3 = (T5)((List<FBFlow>)range).GetEnumerator();
						try
						{
							while (((List<FBFlow>.Enumerator*)(&enumerator3))->MoveNext())
							{
								FBFlow current2 = ((List<FBFlow>.Enumerator*)(&enumerator3))->Current;
								FBFlow fBFlow3 = new FBFlow();
								fBFlow3.Flow_Name = current2.Flow_Name;
								Console.WriteLine(fBFlow3.Flow_Name);
								T3 enumerator4 = (T3)current2.Filed.GetEnumerator();
								try
								{
									while (((List<FBFlowField>.Enumerator*)(&enumerator4))->MoveNext())
									{
										FBFlowField current3 = ((List<FBFlowField>.Enumerator*)(&enumerator4))->Current;
										fBFlow3.Filed.Add(new FBFlowField
										{
											key = current3.key,
											type = current3.type,
											value = current3.value
										});
									}
								}
								finally
								{
									((IDisposable)(*(List<FBFlowField>.Enumerator*)(&enumerator4))).Dispose();
								}
								frmMain.listFBEntity[(int)val12].Flow.Add(fBFlow3);
							}
						}
						finally
						{
							((IDisposable)(*(List<FBFlow>.Enumerator*)(&enumerator3))).Dispose();
						}
						T0 val18 = (T0)((nint)val6 > 0);
						if (val18 != null)
						{
							FBFlow fBFlow4 = new FBFlow();
							fBFlow4.Flow_Name = "Delay";
							fBFlow4.Filed = (List<FBFlowField>)Activator.CreateInstance(typeof(T8));
							fBFlow4.Filed.Add(new FBFlowField
							{
								key = "Delay",
								type = typeof(T1),
								value = val6
							});
							frmMain.listFBEntity[(int)val12].Flow.Add(fBFlow4);
						}
						val16 = (T1)(val16 + 1);
					}
					T1 val19 = (T1)(val4 + 1);
					while (true)
					{
						T0 val20 = (T0)((nint)val19 < listModuleSelected.Count);
						if (val20 == null)
						{
							break;
						}
						FBFlow fBFlow5 = listModuleSelected[(int)val19];
						FBFlow fBFlow6 = new FBFlow();
						fBFlow6.Flow_Name = fBFlow5.Flow_Name;
						T3 enumerator5 = (T3)fBFlow5.Filed.GetEnumerator();
						try
						{
							while (((List<FBFlowField>.Enumerator*)(&enumerator5))->MoveNext())
							{
								FBFlowField current4 = ((List<FBFlowField>.Enumerator*)(&enumerator5))->Current;
								fBFlow6.Filed.Add(new FBFlowField
								{
									key = current4.key,
									type = current4.type,
									value = current4.value
								});
							}
						}
						finally
						{
							((IDisposable)(*(List<FBFlowField>.Enumerator*)(&enumerator5))).Dispose();
						}
						frmMain.listFBEntity[(int)val12].Flow.Add(fBFlow6);
						val19 = (T1)(val19 + 1);
					}
				}
			}
			finally
			{
				((IDisposable)(*(List<int>.Enumerator*)(&enumerator))).Dispose();
			}
		}
		else
		{
			T2 enumerator6 = (T2)listIndexUID.GetEnumerator();
			try
			{
				while (((List<int>.Enumerator*)(&enumerator6))->MoveNext())
				{
					T1 val21 = (T1)((List<int>.Enumerator*)(&enumerator6))->Current;
					T0 val22 = (T0)(frmMain.listFBEntity[(int)val21].Flow == null);
					if (val22 != null)
					{
						frmMain.listFBEntity[(int)val21].Flow = (List<FBFlow>)Activator.CreateInstance(typeof(T4));
					}
					frmMain.listFBEntity[(int)val21].Flow.Clear();
					T5 enumerator7 = (T5)listModuleSelected.GetEnumerator();
					try
					{
						while (((List<FBFlow>.Enumerator*)(&enumerator7))->MoveNext())
						{
							FBFlow current5 = ((List<FBFlow>.Enumerator*)(&enumerator7))->Current;
							FBFlow fBFlow7 = new FBFlow();
							fBFlow7.Flow_Name = current5.Flow_Name;
							T3 enumerator8 = (T3)current5.Filed.GetEnumerator();
							try
							{
								while (((List<FBFlowField>.Enumerator*)(&enumerator8))->MoveNext())
								{
									FBFlowField current6 = ((List<FBFlowField>.Enumerator*)(&enumerator8))->Current;
									fBFlow7.Filed.Add(new FBFlowField
									{
										key = current6.key,
										type = current6.type,
										value = current6.value
									});
								}
							}
							finally
							{
								((IDisposable)(*(List<FBFlowField>.Enumerator*)(&enumerator8))).Dispose();
							}
							frmMain.listFBEntity[(int)val21].Flow.Add(fBFlow7);
						}
					}
					finally
					{
						((IDisposable)(*(List<FBFlow>.Enumerator*)(&enumerator7))).Dispose();
					}
				}
			}
			finally
			{
				((IDisposable)(*(List<int>.Enumerator*)(&enumerator6))).Dispose();
			}
		}
		frmMain.fblistSaving<Thread, T0, Exception>((T0)1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void button1_Click<T0, T1, T2, T3, T4, T5, T6, T7>(T5 sender, T6 e)
	{
		//IL_0002: Expected O, but got I4
		//IL_0004: Expected O, but got I4
		//IL_0006: Expected O, but got I4
		//IL_0008: Expected O, but got I4
		//IL_000b: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_0020: Expected I4, but got O
		//IL_0032: Expected O, but got I4
		//IL_0038: Expected O, but got I4
		//IL_0048: Expected I4, but got O
		//IL_005e: Expected O, but got I4
		//IL_006b: Expected I4, but got O
		//IL_0082: Expected O, but got I4
		//IL_008f: Expected I4, but got O
		//IL_00a1: Expected O, but got I4
		//IL_00a7: Expected O, but got I4
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_00c1: Expected O, but got I4
		//IL_00d5: Expected O, but got I4
		//IL_00ec: Expected I4, but got O
		//IL_00f6: Expected O, but got I4
		//IL_010c: Expected I4, but got O
		//IL_0132: Expected I4, but got O
		//IL_013f: Expected O, but got I4
		//IL_0151: Expected I4, but got O
		//IL_01e5: Expected I4, but got O
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Expected O, but got Unknown
		//IL_01fe: Expected O, but got I4
		//IL_0208: Expected O, but got I4
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected I4, but got Unknown
		//IL_0220: Expected I4, but got Unknown
		//IL_02e2: Expected I4, but got O
		//IL_0311: Expected O, but got I4
		//IL_0395: Expected I4, but got O
		//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a7: Expected O, but got Unknown
		//IL_03ae: Expected O, but got I4
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ba: Expected O, but got Unknown
		//IL_03cc: Expected I4, but got O
		//IL_0460: Expected I4, but got O
		//IL_046f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0472: Expected O, but got Unknown
		//IL_0483: Expected O, but got I4
		//IL_048d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0490: Expected O, but got Unknown
		//IL_04a6: Expected O, but got I4
		//IL_04b5: Expected O, but got I4
		//IL_04cc: Expected I4, but got O
		//IL_04d6: Expected O, but got I4
		//IL_04ec: Expected I4, but got O
		//IL_0512: Expected I4, but got O
		//IL_05ca: Expected I4, but got O
		//IL_05f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f8: Expected O, but got Unknown
		//IL_060e: Expected O, but got I4
		//IL_0621: Expected O, but got I4
		T0 val = (T0)0;
		T1 val2 = (T1)0;
		T1 val3 = (T1)0;
		T1 val4 = (T1)0;
		T1 val5 = (T1)0;
		T1 val6 = (T1)0;
		while (true)
		{
			T0 val7 = (T0)((nint)val6 < listModuleSelected.Count);
			if (val7 == null)
			{
				break;
			}
			T0 val8 = (T0)listModuleSelected[(int)val6].Flow_Name.Equals("Bắt_đầu_Random");
			if (val8 != null)
			{
				val = (T0)1;
				val2 = val6;
				val4 = (T1)int.Parse(listModuleSelected[(int)val6].getValue<T5, T7, T0, string>("Số_lần_lặp_lại").ToString());
				val5 = (T1)int.Parse(listModuleSelected[(int)val6].getValue<T5, T7, T0, string>("Delay").ToString());
			}
			T0 val9 = (T0)listModuleSelected[(int)val6].Flow_Name.Equals("Kết_thúc_Random");
			if (val9 != null)
			{
				val = (T0)1;
				val3 = val6;
			}
			val6 = (T1)(val6 + 1);
		}
		T0 val10 = val;
		if (val10 != null)
		{
			T1 val11 = (T1)0;
			while (true)
			{
				T0 val12 = (T0)((nint)val11 < frmMain.listFBEntity.Count);
				if (val12 == null)
				{
					break;
				}
				T0 val13 = (T0)(frmMain.listFBEntity[(int)val11].Flow == null);
				if (val13 != null)
				{
					frmMain.listFBEntity[(int)val11].Flow = (List<FBFlow>)Activator.CreateInstance(typeof(T3));
				}
				frmMain.listFBEntity[(int)val11].Flow.Clear();
				T1 val14 = (T1)0;
				while (true)
				{
					T0 val15 = (T0)(val14 < val2);
					if (val15 == null)
					{
						break;
					}
					FBFlow fBFlow = listModuleSelected[(int)val14];
					FBFlow fBFlow2 = new FBFlow();
					fBFlow2.Flow_Name = fBFlow.Flow_Name;
					T2 enumerator = (T2)fBFlow.Filed.GetEnumerator();
					try
					{
						while (((List<FBFlowField>.Enumerator*)(&enumerator))->MoveNext())
						{
							FBFlowField current = ((List<FBFlowField>.Enumerator*)(&enumerator))->Current;
							fBFlow2.Filed.Add(new FBFlowField
							{
								key = current.key,
								type = current.type,
								value = current.value
							});
						}
					}
					finally
					{
						((IDisposable)(*(List<FBFlowField>.Enumerator*)(&enumerator))).Dispose();
					}
					frmMain.listFBEntity[(int)val11].Flow.Add(fBFlow2);
					val14 = (T1)(val14 + 1);
				}
				T1 val16 = (T1)0;
				while (true)
				{
					T0 val17 = (T0)(val16 < val4);
					if (val17 == null)
					{
						break;
					}
					T3 range = (T3)listModuleSelected.GetRange(val2 + 1, (object)val3 - (object)val2 - 1);
					range = mdAutoRandom<T1, T0, T3>(range);
					T4 enumerator2 = (T4)((List<FBFlow>)range).GetEnumerator();
					try
					{
						while (((List<FBFlow>.Enumerator*)(&enumerator2))->MoveNext())
						{
							FBFlow current2 = ((List<FBFlow>.Enumerator*)(&enumerator2))->Current;
							FBFlow fBFlow3 = new FBFlow();
							fBFlow3.Flow_Name = current2.Flow_Name;
							Console.WriteLine(fBFlow3.Flow_Name);
							T2 enumerator3 = (T2)current2.Filed.GetEnumerator();
							try
							{
								while (((List<FBFlowField>.Enumerator*)(&enumerator3))->MoveNext())
								{
									FBFlowField current3 = ((List<FBFlowField>.Enumerator*)(&enumerator3))->Current;
									fBFlow3.Filed.Add(new FBFlowField
									{
										key = current3.key,
										type = current3.type,
										value = current3.value
									});
								}
							}
							finally
							{
								((IDisposable)(*(List<FBFlowField>.Enumerator*)(&enumerator3))).Dispose();
							}
							frmMain.listFBEntity[(int)val11].Flow.Add(fBFlow3);
						}
					}
					finally
					{
						((IDisposable)(*(List<FBFlow>.Enumerator*)(&enumerator2))).Dispose();
					}
					T0 val18 = (T0)((nint)val5 > 0);
					if (val18 != null)
					{
						FBFlow fBFlow4 = new FBFlow();
						fBFlow4.Flow_Name = "Delay";
						fBFlow4.Filed = (List<FBFlowField>)Activator.CreateInstance(typeof(T7));
						fBFlow4.Filed.Add(new FBFlowField
						{
							key = "Delay",
							type = typeof(T1),
							value = val5
						});
						frmMain.listFBEntity[(int)val11].Flow.Add(fBFlow4);
					}
					val16 = (T1)(val16 + 1);
				}
				T1 val19 = (T1)(val3 + 1);
				while (true)
				{
					T0 val20 = (T0)((nint)val19 < listModuleSelected.Count);
					if (val20 == null)
					{
						break;
					}
					FBFlow fBFlow5 = listModuleSelected[(int)val19];
					FBFlow fBFlow6 = new FBFlow();
					fBFlow6.Flow_Name = fBFlow5.Flow_Name;
					T2 enumerator4 = (T2)fBFlow5.Filed.GetEnumerator();
					try
					{
						while (((List<FBFlowField>.Enumerator*)(&enumerator4))->MoveNext())
						{
							FBFlowField current4 = ((List<FBFlowField>.Enumerator*)(&enumerator4))->Current;
							fBFlow6.Filed.Add(new FBFlowField
							{
								key = current4.key,
								type = current4.type,
								value = current4.value
							});
						}
					}
					finally
					{
						((IDisposable)(*(List<FBFlowField>.Enumerator*)(&enumerator4))).Dispose();
					}
					frmMain.listFBEntity[(int)val11].Flow.Add(fBFlow6);
					val19 = (T1)(val19 + 1);
				}
				val11 = (T1)(val11 + 1);
			}
		}
		else
		{
			T1 val21 = (T1)0;
			while (true)
			{
				T0 val22 = (T0)((nint)val21 < frmMain.listFBEntity.Count);
				if (val22 == null)
				{
					break;
				}
				T0 val23 = (T0)(frmMain.listFBEntity[(int)val21].Flow == null);
				if (val23 != null)
				{
					frmMain.listFBEntity[(int)val21].Flow = (List<FBFlow>)Activator.CreateInstance(typeof(T3));
				}
				frmMain.listFBEntity[(int)val21].Flow.Clear();
				T4 enumerator5 = (T4)listModuleSelected.GetEnumerator();
				try
				{
					while (((List<FBFlow>.Enumerator*)(&enumerator5))->MoveNext())
					{
						FBFlow current5 = ((List<FBFlow>.Enumerator*)(&enumerator5))->Current;
						FBFlow fBFlow7 = new FBFlow();
						fBFlow7.Flow_Name = current5.Flow_Name;
						T2 enumerator6 = (T2)current5.Filed.GetEnumerator();
						try
						{
							while (((List<FBFlowField>.Enumerator*)(&enumerator6))->MoveNext())
							{
								FBFlowField current6 = ((List<FBFlowField>.Enumerator*)(&enumerator6))->Current;
								fBFlow7.Filed.Add(new FBFlowField
								{
									key = current6.key,
									type = current6.type,
									value = current6.value
								});
							}
						}
						finally
						{
							((IDisposable)(*(List<FBFlowField>.Enumerator*)(&enumerator6))).Dispose();
						}
						frmMain.listFBEntity[(int)val21].Flow.Add(fBFlow7);
					}
				}
				finally
				{
					((IDisposable)(*(List<FBFlow>.Enumerator*)(&enumerator5))).Dispose();
				}
				val21 = (T1)(val21 + 1);
			}
		}
		frmMain.fblistSaving<Thread, T0, Exception>((T0)1);
		File.WriteAllText("module.json", JsonConvert.SerializeObject((object)listModuleSelected));
	}

	public T2 mdAutoRandom<T0, T1, T2>(T2 list)
	{
		//IL_0007: Expected O, but got I4
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected I4, but got Unknown
		//IL_001c: Expected O, but got I4
		//IL_0023: Expected I4, but got O
		//IL_002d: Expected I4, but got O
		//IL_0032: Expected I4, but got O
		//IL_003a: Expected I4, but got O
		//IL_003f: Expected O, but got I4
		T0 val = (T0)((List<FBFlow>)list).Count;
		while (true)
		{
			T1 val2 = (T1)((nint)val > 1);
			if (val2 == null)
			{
				break;
			}
			val = (T0)(val - 1);
			T0 val3 = (T0)rnd.Next(val + 1);
			FBFlow value = ((List<FBFlow>)list)[(int)val3];
			((List<FBFlow>)list)[(int)val3] = ((List<FBFlow>)list)[(int)val];
			((List<FBFlow>)list)[(int)val] = value;
		}
		return list;
	}

	private void lbModuleTiktok_MouseDown<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0037: Expected O, but got I4
		indexModule = lbModuleTiktok.IndexFromPoint(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
		T0 val = (T0)(indexModule >= 0 && ((MouseEventArgs)e).Button == MouseButtons.Left);
		if (val != null)
		{
			lbModuleTiktok.DoDragDrop(lbModuleTiktok.Items[indexModule].ToString(), DragDropEffects.Copy);
		}
	}

	private void lbModuleShopee_MouseDown<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0037: Expected O, but got I4
		indexModule = lbModuleShopee.IndexFromPoint(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
		T0 val = (T0)(indexModule >= 0 && ((MouseEventArgs)e).Button == MouseButtons.Left);
		if (val != null)
		{
			lbModuleShopee.DoDragDrop(lbModuleShopee.Items[indexModule].ToString(), DragDropEffects.Copy);
		}
	}

	private void lbModuleFacebookApi_MouseDown<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0037: Expected O, but got I4
		indexModule = lbModuleFacebookApi.IndexFromPoint(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
		T0 val = (T0)(indexModule >= 0 && ((MouseEventArgs)e).Button == MouseButtons.Left);
		if (val != null)
		{
			lbModuleFacebookApi.DoDragDrop(lbModuleFacebookApi.Items[indexModule].ToString(), DragDropEffects.Copy);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void ccbModuleSaved_SelectedIndexChanged<T0, T1, T2, T3, T4, T5, T6>(T3 sender, T4 e)
	{
		//IL_0020: Expected O, but got I4
		//IL_0049: Expected O, but got I4
		T0 val = (T0)(ccbModuleSaved.SelectedIndex == ccbModuleSaved.Items.Count - 1);
		if (val != null)
		{
			frmFolder frmFolder2 = new frmFolder("", isNew: true, "Thư mục module");
			frmFolder2.ShowDialog();
			T0 val2 = (T0)(frmFolder2.isSave == 1);
			if (val2 == null)
			{
				return;
			}
			T1 val3 = (T1)Activator.CreateInstance(typeof(T1));
			T2 enumerator = (T2)listModuleSelected.GetEnumerator();
			try
			{
				while (((List<FBFlow>.Enumerator*)(&enumerator))->MoveNext())
				{
					FBFlow current = ((List<FBFlow>.Enumerator*)(&enumerator))->Current;
					((List<FBFlow>)val3).Add(new FBFlow
					{
						Filed = current.Filed,
						Flow_Name = current.Flow_Name
					});
				}
			}
			finally
			{
				((IDisposable)(*(List<FBFlow>.Enumerator*)(&enumerator))).Dispose();
			}
			listModuleSaved.Add(new ModuleSaved
			{
				Name = frmFolder2.newName,
				listModule = (List<FBFlow>)val3,
				Category = frmMain.setting.ccbTarget
			});
			saveModuleSaved();
			loadCate<T5, T0, T6>((T6)frmFolder2.newName);
		}
		else
		{
			loadModuleSaved<T5, T0, T2>();
		}
	}

	private unsafe void loadModuleSaved<T0, T1, T2>()
	{
		//IL_0048: Expected O, but got I4
		T0 enumerator = (T0)listModuleSaved.GetEnumerator();
		try
		{
			while (((List<ModuleSaved>.Enumerator*)(&enumerator))->MoveNext())
			{
				ModuleSaved current = ((List<ModuleSaved>.Enumerator*)(&enumerator))->Current;
				T1 val = (T1)(current.Name.Equals(ccbModuleSaved.Text) && current.Category.Equals(frmMain.setting.ccbTarget));
				if (val != null)
				{
					listModuleSelected = current.listModule;
					break;
				}
			}
		}
		finally
		{
			((IDisposable)(*(List<ModuleSaved>.Enumerator*)(&enumerator))).Dispose();
		}
		lbModuleSelected.Items.Clear();
		T2 enumerator2 = (T2)listModuleSelected.GetEnumerator();
		try
		{
			while (((List<FBFlow>.Enumerator*)(&enumerator2))->MoveNext())
			{
				FBFlow current2 = ((List<FBFlow>.Enumerator*)(&enumerator2))->Current;
				lbModuleSelected.Items.Add(current2.Flow_Name);
			}
		}
		finally
		{
			((IDisposable)(*(List<FBFlow>.Enumerator*)(&enumerator2))).Dispose();
		}
	}

	private unsafe void button5_Click<T0, T1, T2, T3>(T2 sender, T3 e)
	{
		//IL_0048: Expected O, but got I4
		T0 enumerator = (T0)listModuleSaved.GetEnumerator();
		try
		{
			while (((List<ModuleSaved>.Enumerator*)(&enumerator))->MoveNext())
			{
				ModuleSaved current = ((List<ModuleSaved>.Enumerator*)(&enumerator))->Current;
				T1 val = (T1)(current.Name.Equals(ccbModuleSaved.Text) && current.Category.Equals(frmMain.setting.ccbTarget));
				if (val != null)
				{
					current.listModule = listModuleSelected;
					saveModuleSaved();
					break;
				}
			}
		}
		finally
		{
			((IDisposable)(*(List<ModuleSaved>.Enumerator*)(&enumerator))).Dispose();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void button4_Click<T0, T1, T2, T3, T4, T5>(T3 sender, T4 e)
	{
		//IL_0029: Expected O, but got I4
		//IL_0075: Expected O, but got I4
		//IL_00b6: Expected O, but got I4
		//IL_00c0: Expected O, but got I4
		//IL_00c3: Expected O, but got I4
		//IL_00d2: Expected I4, but got O
		//IL_00f6: Expected I4, but got O
		//IL_010f: Expected O, but got I4
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		//IL_012a: Expected O, but got I4
		//IL_0141: Expected I4, but got O
		frmFolder frmFolder2 = new frmFolder(ccbModuleSaved.Text, isNew: false, "Thư mục module");
		frmFolder2.ShowDialog();
		T0 val = (T0)(frmFolder2.isSave == 1);
		if (val != null)
		{
			T1 enumerator = (T1)listModuleSaved.GetEnumerator();
			try
			{
				while (((List<ModuleSaved>.Enumerator*)(&enumerator))->MoveNext())
				{
					ModuleSaved current = ((List<ModuleSaved>.Enumerator*)(&enumerator))->Current;
					T0 val2 = (T0)(current.Name.Equals(ccbModuleSaved.Text) && current.Category.Equals(frmMain.setting.ccbTarget));
					if (val2 != null)
					{
						current.Name = frmFolder2.newName;
						break;
					}
				}
			}
			finally
			{
				((IDisposable)(*(List<ModuleSaved>.Enumerator*)(&enumerator))).Dispose();
			}
			saveModuleSaved();
		}
		else
		{
			T0 val3 = (T0)(frmFolder2.isSave == 2);
			if (val3 != null)
			{
				T2 val4 = (T2)0;
				T2 val5 = (T2)0;
				while (true)
				{
					T0 val6 = (T0)((nint)val5 < listModuleSaved.Count);
					if (val6 == null)
					{
						break;
					}
					T0 val7 = (T0)(listModuleSaved[(int)val5].Name.Equals(ccbModuleSaved.Text) && listModuleSaved[(int)val5].Category.Equals(frmMain.setting.ccbTarget));
					if (val7 == null)
					{
						val5 = (T2)(val5 + 1);
						continue;
					}
					val4 = val5;
					break;
				}
				listModuleSaved.RemoveAt((int)val4);
				saveModuleSaved();
			}
		}
		loadCate<T1, T0, T5>((T5)"");
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
		T0 val = (T0)new System.ComponentModel.ComponentResourceManager(typeof(ADSPRoject.frmModule));
		this.txtUID = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label1 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.groupBox1 = (System.Windows.Forms.GroupBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.GroupBox));
		this.splitContainer1 = (System.Windows.Forms.SplitContainer)System.Activator.CreateInstance(typeof(System.Windows.Forms.SplitContainer));
		this.tabModule = (System.Windows.Forms.TabControl)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabControl));
		this.tabFacebook = (System.Windows.Forms.TabPage)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabPage));
		this.lbModuleFacebook = (System.Windows.Forms.ListBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.ListBox));
		this.tabFacebookApi = (System.Windows.Forms.TabPage)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabPage));
		this.lbModuleFacebookApi = (System.Windows.Forms.ListBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.ListBox));
		this.imageList1 = new System.Windows.Forms.ImageList(this.components);
		this.button4 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.button5 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.label2 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.ccbModuleSaved = (System.Windows.Forms.ComboBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.ComboBox));
		this.btnModuleSetup = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.btnDeleteModule = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.btnModuleDown = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.btnModuleUp = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.lbModuleSelected = (System.Windows.Forms.ListBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.ListBox));
		this.tabTiktok = (System.Windows.Forms.TabPage)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabPage));
		this.lbModuleTiktok = (System.Windows.Forms.ListBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.ListBox));
		this.tabShopee = (System.Windows.Forms.TabPage)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabPage));
		this.lbModuleShopee = (System.Windows.Forms.ListBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.ListBox));
		this.btnSave = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.btnCancel = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.button1 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.groupBox1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
		this.splitContainer1.Panel1.SuspendLayout();
		this.splitContainer1.Panel2.SuspendLayout();
		this.splitContainer1.SuspendLayout();
		this.tabModule.SuspendLayout();
		this.tabFacebook.SuspendLayout();
		this.tabFacebookApi.SuspendLayout();
		this.tabTiktok.SuspendLayout();
		this.tabShopee.SuspendLayout();
		base.SuspendLayout();
		this.txtUID.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtUID.Location = new System.Drawing.Point(55, 6);
		this.txtUID.Multiline = true;
		this.txtUID.Name = "txtUID";
		this.txtUID.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		this.txtUID.Size = new System.Drawing.Size(1015, 80);
		this.txtUID.TabIndex = 0;
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(14, 40);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(40, 17);
		this.label1.TabIndex = 1;
		this.label1.Text = "UID:";
		this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.groupBox1.Controls.Add(this.splitContainer1);
		this.groupBox1.Location = new System.Drawing.Point(14, 92);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(1057, 380);
		this.groupBox1.TabIndex = 2;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Flow";
		this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainer1.Location = new System.Drawing.Point(3, 20);
		this.splitContainer1.Name = "splitContainer1";
		this.splitContainer1.Panel1.Controls.Add(this.tabModule);
		this.splitContainer1.Panel2.Controls.Add(this.button4);
		this.splitContainer1.Panel2.Controls.Add(this.button5);
		this.splitContainer1.Panel2.Controls.Add(this.label2);
		this.splitContainer1.Panel2.Controls.Add(this.ccbModuleSaved);
		this.splitContainer1.Panel2.Controls.Add(this.btnModuleSetup);
		this.splitContainer1.Panel2.Controls.Add(this.btnDeleteModule);
		this.splitContainer1.Panel2.Controls.Add(this.btnModuleDown);
		this.splitContainer1.Panel2.Controls.Add(this.btnModuleUp);
		this.splitContainer1.Panel2.Controls.Add(this.lbModuleSelected);
		this.splitContainer1.Size = new System.Drawing.Size(1051, 357);
		this.splitContainer1.SplitterDistance = 350;
		this.splitContainer1.SplitterWidth = 5;
		this.splitContainer1.TabIndex = 0;
		this.tabModule.Controls.Add(this.tabFacebook);
		this.tabModule.Controls.Add(this.tabFacebookApi);
		this.tabModule.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tabModule.ImageList = this.imageList1;
		this.tabModule.Location = new System.Drawing.Point(0, 0);
		this.tabModule.Name = "tabModule";
		this.tabModule.SelectedIndex = 0;
		this.tabModule.Size = new System.Drawing.Size(350, 357);
		this.tabModule.TabIndex = 0;
		this.tabFacebook.Controls.Add(this.lbModuleFacebook);
		this.tabFacebook.ImageIndex = 1;
		this.tabFacebook.Location = new System.Drawing.Point(4, 25);
		this.tabFacebook.Name = "tabFacebook";
		this.tabFacebook.Padding = new System.Windows.Forms.Padding(3);
		this.tabFacebook.Size = new System.Drawing.Size(342, 328);
		this.tabFacebook.TabIndex = 0;
		this.tabFacebook.Text = "Chrome";
		this.tabFacebook.UseVisualStyleBackColor = true;
		this.lbModuleFacebook.AllowDrop = true;
		this.lbModuleFacebook.Dock = System.Windows.Forms.DockStyle.Fill;
		this.lbModuleFacebook.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lbModuleFacebook.FormattingEnabled = true;
		this.lbModuleFacebook.ItemHeight = 25;
		this.lbModuleFacebook.Location = new System.Drawing.Point(3, 3);
		this.lbModuleFacebook.Name = "lbModuleFacebook";
		this.lbModuleFacebook.ScrollAlwaysVisible = true;
		this.lbModuleFacebook.Size = new System.Drawing.Size(336, 322);
		this.lbModuleFacebook.TabIndex = 1;
		this.lbModuleFacebook.MouseDown += new System.Windows.Forms.MouseEventHandler(lbModule_MouseDown<T11, T12, T13>);
		this.tabFacebookApi.Controls.Add(this.lbModuleFacebookApi);
		this.tabFacebookApi.ImageIndex = 0;
		this.tabFacebookApi.Location = new System.Drawing.Point(4, 25);
		this.tabFacebookApi.Name = "tabFacebookApi";
		this.tabFacebookApi.Padding = new System.Windows.Forms.Padding(3);
		this.tabFacebookApi.Size = new System.Drawing.Size(342, 328);
		this.tabFacebookApi.TabIndex = 3;
		this.tabFacebookApi.Text = "Facebook API";
		this.tabFacebookApi.UseVisualStyleBackColor = true;
		this.lbModuleFacebookApi.AllowDrop = true;
		this.lbModuleFacebookApi.Dock = System.Windows.Forms.DockStyle.Fill;
		this.lbModuleFacebookApi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lbModuleFacebookApi.FormattingEnabled = true;
		this.lbModuleFacebookApi.ItemHeight = 25;
		this.lbModuleFacebookApi.Location = new System.Drawing.Point(3, 3);
		this.lbModuleFacebookApi.Name = "lbModuleFacebookApi";
		this.lbModuleFacebookApi.ScrollAlwaysVisible = true;
		this.lbModuleFacebookApi.Size = new System.Drawing.Size(336, 322);
		this.lbModuleFacebookApi.TabIndex = 4;
		this.lbModuleFacebookApi.MouseDown += new System.Windows.Forms.MouseEventHandler(lbModuleFacebookApi_MouseDown<T11, T12, T13>);
		this.imageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)(T14)((System.Resources.ResourceManager)val).GetObject("imageList1.ImageStream");
		this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
		this.imageList1.Images.SetKeyName(0, "1458506.ico");
		this.imageList1.Images.SetKeyName(1, "chrome.ico");
		this.button4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f);
		this.button4.Location = new System.Drawing.Point(341, 3);
		this.button4.Name = "button4";
		this.button4.Size = new System.Drawing.Size(37, 27);
		this.button4.TabIndex = 54;
		this.button4.Text = "❁";
		this.button4.UseVisualStyleBackColor = true;
		this.button4.Click += new System.EventHandler(button4_Click<T11, T15, T16, T12, T17, T18>);
		this.button5.BackColor = System.Drawing.SystemColors.Control;
		this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f);
		this.button5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.button5.Location = new System.Drawing.Point(391, 3);
		this.button5.Name = "button5";
		this.button5.Size = new System.Drawing.Size(75, 27);
		this.button5.TabIndex = 53;
		this.button5.Text = "Lưu";
		this.button5.UseVisualStyleBackColor = false;
		this.button5.Click += new System.EventHandler(button5_Click<T15, T11, T12, T17>);
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(3, 11);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(76, 17);
		this.label2.TabIndex = 13;
		this.label2.Text = "Bản mẫu:";
		this.ccbModuleSaved.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ccbModuleSaved.FormattingEnabled = true;
		this.ccbModuleSaved.Location = new System.Drawing.Point(72, 8);
		this.ccbModuleSaved.Name = "ccbModuleSaved";
		this.ccbModuleSaved.Size = new System.Drawing.Size(270, 24);
		this.ccbModuleSaved.TabIndex = 12;
		this.ccbModuleSaved.SelectedIndexChanged += new System.EventHandler(ccbModuleSaved_SelectedIndexChanged<T11, T19, T20, T12, T17, T15, T18>);
		this.btnModuleSetup.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnModuleSetup.Image = ADSPRoject.Properties.Resources.button_setup;
		this.btnModuleSetup.Location = new System.Drawing.Point(602, 165);
		this.btnModuleSetup.Name = "btnModuleSetup";
		this.btnModuleSetup.Size = new System.Drawing.Size(70, 60);
		this.btnModuleSetup.TabIndex = 11;
		this.btnModuleSetup.UseVisualStyleBackColor = true;
		this.btnModuleSetup.Click += new System.EventHandler(btnModuleSetup_Click<T11, T12, T17, T16>);
		this.btnDeleteModule.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnDeleteModule.Image = ADSPRoject.Properties.Resources.button_delete;
		this.btnDeleteModule.Location = new System.Drawing.Point(602, 231);
		this.btnDeleteModule.Name = "btnDeleteModule";
		this.btnDeleteModule.Size = new System.Drawing.Size(70, 60);
		this.btnDeleteModule.TabIndex = 10;
		this.btnDeleteModule.UseVisualStyleBackColor = true;
		this.btnDeleteModule.Click += new System.EventHandler(btnDeleteModule_Click<T11, T16, T20, T12, T17>);
		this.btnModuleDown.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnModuleDown.Image = ADSPRoject.Properties.Resources.button_down;
		this.btnModuleDown.Location = new System.Drawing.Point(602, 99);
		this.btnModuleDown.Name = "btnModuleDown";
		this.btnModuleDown.Size = new System.Drawing.Size(70, 60);
		this.btnModuleDown.TabIndex = 9;
		this.btnModuleDown.UseVisualStyleBackColor = true;
		this.btnModuleDown.Click += new System.EventHandler(btnModuleDown_Click<T11, T16, T20, T12, T17>);
		this.btnModuleUp.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnModuleUp.Image = ADSPRoject.Properties.Resources.button_up;
		this.btnModuleUp.Location = new System.Drawing.Point(602, 33);
		this.btnModuleUp.Name = "btnModuleUp";
		this.btnModuleUp.Size = new System.Drawing.Size(70, 60);
		this.btnModuleUp.TabIndex = 8;
		this.btnModuleUp.UseVisualStyleBackColor = true;
		this.btnModuleUp.Click += new System.EventHandler(btnModuleUp_Click<T11, T16, T20, T12, T17>);
		this.lbModuleSelected.AllowDrop = true;
		this.lbModuleSelected.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.lbModuleSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lbModuleSelected.FormattingEnabled = true;
		this.lbModuleSelected.ItemHeight = 25;
		this.lbModuleSelected.Location = new System.Drawing.Point(3, 33);
		this.lbModuleSelected.Name = "lbModuleSelected";
		this.lbModuleSelected.ScrollAlwaysVisible = true;
		this.lbModuleSelected.Size = new System.Drawing.Size(593, 254);
		this.lbModuleSelected.TabIndex = 2;
		this.lbModuleSelected.SelectedIndexChanged += new System.EventHandler(lbModuleSelected_SelectedIndexChanged<T11, T12, T17>);
		this.lbModuleSelected.DragDrop += new System.Windows.Forms.DragEventHandler(lbModuleSelected_DragDrop<T11, T21, T12, T22, T18>);
		this.lbModuleSelected.DragEnter += new System.Windows.Forms.DragEventHandler(lbModuleSelected_DragEnter<T11, T12, T22, T18>);
		this.tabTiktok.Controls.Add(this.lbModuleTiktok);
		this.tabTiktok.Location = new System.Drawing.Point(4, 22);
		this.tabTiktok.Name = "tabTiktok";
		this.tabTiktok.Padding = new System.Windows.Forms.Padding(3);
		this.tabTiktok.Size = new System.Drawing.Size(342, 335);
		this.tabTiktok.TabIndex = 1;
		this.tabTiktok.Text = "Tiktok";
		this.tabTiktok.UseVisualStyleBackColor = true;
		this.lbModuleTiktok.AllowDrop = true;
		this.lbModuleTiktok.Dock = System.Windows.Forms.DockStyle.Fill;
		this.lbModuleTiktok.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lbModuleTiktok.FormattingEnabled = true;
		this.lbModuleTiktok.ItemHeight = 20;
		this.lbModuleTiktok.Location = new System.Drawing.Point(3, 3);
		this.lbModuleTiktok.Name = "lbModuleTiktok";
		this.lbModuleTiktok.ScrollAlwaysVisible = true;
		this.lbModuleTiktok.Size = new System.Drawing.Size(336, 329);
		this.lbModuleTiktok.TabIndex = 2;
		this.lbModuleTiktok.MouseDown += new System.Windows.Forms.MouseEventHandler(lbModuleTiktok_MouseDown<T11, T12, T13>);
		this.tabShopee.Controls.Add(this.lbModuleShopee);
		this.tabShopee.Location = new System.Drawing.Point(4, 22);
		this.tabShopee.Name = "tabShopee";
		this.tabShopee.Padding = new System.Windows.Forms.Padding(3);
		this.tabShopee.Size = new System.Drawing.Size(342, 335);
		this.tabShopee.TabIndex = 2;
		this.tabShopee.Text = "Shopee";
		this.tabShopee.UseVisualStyleBackColor = true;
		this.lbModuleShopee.AllowDrop = true;
		this.lbModuleShopee.Dock = System.Windows.Forms.DockStyle.Fill;
		this.lbModuleShopee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lbModuleShopee.FormattingEnabled = true;
		this.lbModuleShopee.ItemHeight = 20;
		this.lbModuleShopee.Location = new System.Drawing.Point(3, 3);
		this.lbModuleShopee.Name = "lbModuleShopee";
		this.lbModuleShopee.ScrollAlwaysVisible = true;
		this.lbModuleShopee.Size = new System.Drawing.Size(336, 329);
		this.lbModuleShopee.TabIndex = 3;
		this.lbModuleShopee.MouseDown += new System.Windows.Forms.MouseEventHandler(lbModuleShopee_MouseDown<T11, T12, T13>);
		this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnSave.BackColor = System.Drawing.SystemColors.Highlight;
		this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		this.btnSave.Location = new System.Drawing.Point(885, 478);
		this.btnSave.Name = "btnSave";
		this.btnSave.Size = new System.Drawing.Size(87, 42);
		this.btnSave.TabIndex = 3;
		this.btnSave.Text = "Save";
		this.btnSave.UseVisualStyleBackColor = false;
		this.btnSave.Click += new System.EventHandler(btnSave_Click<T11, T16, T23, T21, T19, T20, T12, T17, T24>);
		this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnCancel.BackColor = System.Drawing.SystemColors.HotTrack;
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		this.btnCancel.Location = new System.Drawing.Point(791, 478);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(87, 42);
		this.btnCancel.TabIndex = 4;
		this.btnCancel.Text = "Cancel";
		this.btnCancel.UseVisualStyleBackColor = false;
		this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.button1.BackColor = System.Drawing.SystemColors.Highlight;
		this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		this.button1.Location = new System.Drawing.Point(980, 478);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(87, 42);
		this.button1.TabIndex = 5;
		this.button1.Text = "Save All";
		this.button1.UseVisualStyleBackColor = false;
		this.button1.Click += new System.EventHandler(button1_Click<T11, T16, T21, T19, T20, T12, T17, T24>);
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(1085, 532);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.btnCancel);
		base.Controls.Add(this.btnSave);
		base.Controls.Add(this.groupBox1);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.txtUID);
		this.Font = new System.Drawing.Font("Verdana", 8f);
		base.Icon = (System.Drawing.Icon)(T25)((System.Resources.ResourceManager)val).GetObject("$this.Icon");
		base.Name = "frmModule";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Config";
		base.Load += new System.EventHandler(frmConfig_Load<T11, T26, T12, T17, T27, T19>);
		this.groupBox1.ResumeLayout(false);
		this.splitContainer1.Panel1.ResumeLayout(false);
		this.splitContainer1.Panel2.ResumeLayout(false);
		this.splitContainer1.Panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
		this.splitContainer1.ResumeLayout(false);
		this.tabModule.ResumeLayout(false);
		this.tabFacebook.ResumeLayout(false);
		this.tabFacebookApi.ResumeLayout(false);
		this.tabTiktok.ResumeLayout(false);
		this.tabShopee.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
