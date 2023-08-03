using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ADSPRoject.BinGen;
using ADSPRoject.Data;
using CreditCardValidator;

namespace ADSPRoject;

public class frmCart : Form
{
	private Random rnd = (Random)Activator.CreateInstance(typeof(Random));

	private IContainer components = null;

	private DataGridView gvCC;

	private StatusStrip statusStrip1;

	private ToolStripStatusLabel toolStripStatusLabel1;

	private ToolStripStatusLabel lbTotal;

	private Button button1;

	private ComboBox ccbCateCard;

	private Button button3;

	private Label label1;

	private TextBox txtBingen;

	private Button button2;

	private Label label2;

	private NumericUpDown numQuantity;

	private Label label3;

	private NumericUpDown numUpBin;

	public frmCart()
	{
		InitializeComponent<ComponentResourceManager, DataGridView, StatusStrip, ToolStripStatusLabel, Button, ComboBox, Label, TextBox, NumericUpDown, object, DataGridViewColumnEventArgs, bool, ContextMenu, MenuItem, MouseEventArgs, ToolStripItem, EventArgs, int, Exception, List<CreditCardEntity>, List<GroupCreditCard>.Enumerator, string, double, char, decimal, Icon>();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gvCC_MouseClick<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_000e: Expected O, but got I4
		T0 val = (T0)(((MouseEventArgs)e).Button == MouseButtons.Right);
		if (val != null)
		{
			gvCC.ClearSelection();
			T1 val2 = (T1)Activator.CreateInstance(typeof(ContextMenu));
			T2 item = (T2)new MenuItem("Paste Number|Exp_month|Exp_year|Security", (EventHandler)pasteCCEvent<T2, int, string, T0, List<CreditCardEntity>, char, T3, EventArgs>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Paste Number|Exp_month|Exp_year|Security x10", (EventHandler)pasteCCEvent<T2, int, string, T0, List<CreditCardEntity>, char, T3, EventArgs>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Random sort", (EventHandler)randomSortEvent<string, List<CreditCardEntity>, T3, EventArgs, Guid>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			T2 item2 = (T2)new MenuItem("Xóa toàn bộ", deleteAllCCEvent);
			((Menu)val2).MenuItems.Add((MenuItem)item2);
			((ContextMenu)val2).Show((Control)gvCC, new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y));
		}
	}

	private void randomSortEvent<T0, T1, T2, T3, T4>(T2 sender, T3 e)
	{
		T0 name = (T0)ccbCateCard.Text;
		T1 source = frmMain.listCreditCardEntity<int, bool, T1, T0>(name);
		source = (T1)((IEnumerable<CreditCardEntity>)source).OrderBy((Func<CreditCardEntity, T4>)(object)(Func<CreditCardEntity, Guid>)((CreditCardEntity a) => (T4)Guid.NewGuid())).ToList();
		loadCC<int, Exception>();
		frmMain.cartSaving();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pasteCCEvent<T0, T1, T2, T3, T4, T5, T6, T7>(T6 sender, T7 e)
	{
		//IL_0009: Expected O, but got I4
		//IL_001c: Expected O, but got I4
		//IL_0023: Expected O, but got I4
		//IL_0058: Expected O, but got I4
		//IL_005f: Expected O, but got I4
		//IL_006e: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		//IL_0083: Expected O, but got I4
		//IL_011e: Expected O, but got I4
		//IL_0135: Expected I4, but got O
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected O, but got Unknown
		//IL_01b8: Expected O, but got I4
		//IL_01da: Expected O, but got I4
		//IL_01fd: Expected O, but got I4
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_025f: Expected O, but got I4
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Expected O, but got Unknown
		T0 val = (T0)((sender is T0) ? sender : null);
		T1 val2 = (T1)1;
		T3 val3 = (T3)((MenuItem)val).Text.Equals("Paste Number|Exp_month|Exp_year|Security x10");
		if (val3 != null)
		{
			val2 = (T1)10;
		}
		T2 val4 = (T2)Clipboard.GetText();
		T2[] array = (T2[])(object)((string)val4).Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
		CreditCardEntity creditCardEntity = null;
		T2 name = (T2)ccbCateCard.Text;
		T4 val5 = frmMain.listCreditCardEntity<T1, T3, T4, T2>(name);
		T1 val6 = (T1)1;
		T3 val7 = (T3)(val5 != null);
		if (val7 != null)
		{
			val6 = (T1)(((List<CreditCardEntity>)val5).Count + 1);
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
				T3 val13 = (T3)(!string.IsNullOrEmpty((string)val12) && ((string)val12).Contains("|"));
				if (val13 != null)
				{
					creditCardEntity = new CreditCardEntity();
					creditCardEntity.Row = (int)val6;
					val6 = (T1)(val6 + 1);
					creditCardEntity.Card_Number = ((string)val12).Split((char[])(object)new T5[1] { (T5)124 })[0];
					creditCardEntity.Exp_Month = ((string)val12).Split((char[])(object)new T5[1] { (T5)124 })[1];
					creditCardEntity.Exp_Year = ((string)val12).Split((char[])(object)new T5[1] { (T5)124 })[2];
					creditCardEntity.Card_Security = ((string)val12).Split((char[])(object)new T5[1] { (T5)124 })[3];
					T3 val14 = (T3)(creditCardEntity.Exp_Year.Length > 2);
					if (val14 != null)
					{
						creditCardEntity.Exp_Year = System.Runtime.CompilerServices.Unsafe.As<T5, char>(ref (T5)creditCardEntity.Exp_Year[creditCardEntity.Exp_Year.Length - 2]).ToString() + System.Runtime.CompilerServices.Unsafe.As<T5, char>(ref (T5)creditCardEntity.Exp_Year[creditCardEntity.Exp_Year.Length - 1]);
					}
					creditCardEntity.Status = frmMain.STATUS.Ready.ToString();
					creditCardEntity.UID = "";
					creditCardEntity.int_random = rnd.Next(1, 99999);
					((List<CreditCardEntity>)val5).Add(creditCardEntity);
				}
				val10 = (T1)(val10 + 1);
			}
			val8 = (T1)(val8 + 1);
		}
		loadCC<T1, Exception>();
		frmMain.cartSaving();
	}

	private void loadCC<T0, T1>()
	{
		//IL_003f: Expected O, but got I4
		try
		{
			gvCC.DataSource = null;
			gvCC.DataSource = frmMain.listCreditCardEntity<T0, bool, List<CreditCardEntity>, string>(ccbCateCard.Text);
			lbTotal.Text = System.Runtime.CompilerServices.Unsafe.As<T0, int>(ref (T0)gvCC.Rows.Count).ToString();
		}
		catch (Exception ex)
		{
			frmMain.errorMessage(ex.Message);
		}
	}

	private void deleteAllCCEvent<T0, T1>(T0 sender, T1 e)
	{
		gvCC.DataSource = null;
		frmMain.listCreditCardEntity<int, bool, List<CreditCardEntity>, string>(ccbCateCard.Text).Clear();
		frmMain.cartSaving();
	}

	private void button1_Click<T0, T1, T2, T3>(T0 sender, T1 e)
	{
		loadCC<T2, T3>();
	}

	private void frmCart_Load<T0, T1>(T0 sender, T1 e)
	{
		loadCate<List<GroupCreditCard>.Enumerator, bool>();
		numQuantity.Value = frmMain.setting.FormCard.numQuantity;
		numUpBin.Value = frmMain.setting.FormCard.numUpBin;
		txtBingen.Text = frmMain.setting.FormCard.txtBingen;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void loadCate<T0, T1>()
	{
		//IL_0081: Expected O, but got I4
		ccbCateCard.Items.Clear();
		T0 enumerator = (T0)frmMain.groupCreditCard.GetEnumerator();
		try
		{
			while (((List<GroupCreditCard>.Enumerator*)(&enumerator))->MoveNext())
			{
				GroupCreditCard current = ((List<GroupCreditCard>.Enumerator*)(&enumerator))->Current;
				ccbCateCard.Items.Add(current.Name);
			}
		}
		finally
		{
			((IDisposable)(*(List<GroupCreditCard>.Enumerator*)(&enumerator))).Dispose();
		}
		ccbCateCard.Items.Add("+Thêm mục mới");
		T1 val = (T1)(ccbCateCard.Items.Count > 0);
		if (val != null)
		{
			ccbCateCard.SelectedIndex = 0;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ccbCateCard_SelectedIndexChanged<T0, T1, T2, T3, T4, T5, T6>(T1 sender, T2 e)
	{
		//IL_0020: Expected O, but got I4
		//IL_0046: Expected O, but got I4
		T0 val = (T0)(ccbCateCard.SelectedIndex == ccbCateCard.Items.Count - 1);
		if (val != null)
		{
			frmFolder frmFolder2 = new frmFolder("", isNew: true, "Thư mục thẻ");
			frmFolder2.ShowDialog();
			T0 val2 = (T0)(frmFolder2.isSave == 1);
			if (val2 != null)
			{
				frmMain.groupCreditCard.Add(new GroupCreditCard
				{
					Name = frmFolder2.newName,
					listCreditCardEntity = (List<CreditCardEntity>)Activator.CreateInstance(typeof(T3))
				});
				frmMain.cartSaving();
				loadCate<T4, T0>();
			}
		}
		else
		{
			loadCC<T5, T6>();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void button3_Click<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_0029: Expected O, but got I4
		//IL_005a: Expected O, but got I4
		//IL_0097: Expected O, but got I4
		//IL_009e: Expected O, but got I4
		//IL_00a1: Expected O, but got I4
		//IL_00af: Expected I4, but got O
		//IL_00c6: Expected O, but got I4
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		//IL_00e0: Expected O, but got I4
		//IL_0101: Expected I4, but got O
		frmFolder frmFolder2 = new frmFolder(ccbCateCard.Text, isNew: false, "Thư mục thẻ");
		frmFolder2.ShowDialog();
		T0 val = (T0)(frmFolder2.isSave == 1);
		if (val != null)
		{
			T1 enumerator = (T1)frmMain.groupCreditCard.GetEnumerator();
			try
			{
				while (((List<GroupCreditCard>.Enumerator*)(&enumerator))->MoveNext())
				{
					GroupCreditCard current = ((List<GroupCreditCard>.Enumerator*)(&enumerator))->Current;
					T0 val2 = (T0)current.Name.Equals(ccbCateCard.Text);
					if (val2 != null)
					{
						current.Name = frmFolder2.newName;
						break;
					}
				}
			}
			finally
			{
				((IDisposable)(*(List<GroupCreditCard>.Enumerator*)(&enumerator))).Dispose();
			}
			frmMain.cartSaving();
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
					T0 val6 = (T0)((nint)val5 < frmMain.groupCreditCard.Count);
					if (val6 == null)
					{
						break;
					}
					T0 val7 = (T0)frmMain.groupCreditCard[(int)val5].Name.Equals(ccbCateCard.Text);
					if (val7 == null)
					{
						val5 = (T2)(val5 + 1);
						continue;
					}
					val4 = val5;
					break;
				}
				gvCC.ClearSelection();
				frmMain.groupCreditCard.RemoveAt((int)val4);
				frmMain.cartSaving();
			}
		}
		loadCate<T1, T0>();
	}

	private void gvCC_ColumnAdded<T0, T1>(T0 sender, T1 e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void button2_Click<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T7 sender, T8 e)
	{
		//IL_006e: Expected O, but got I4
		//IL_0077: Expected O, but got I4
		//IL_007a: Expected O, but got I4
		//IL_00a3: Expected O, but got I4
		//IL_00b8: Expected O, but got F8
		//IL_00be: Expected O, but got I4
		//IL_00cb: Expected O, but got I4
		//IL_00ce: Expected O, but got I4
		//IL_00dd: Expected I4, but got O
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		//IL_016c: Expected O, but got I4
		//IL_018e: Expected O, but got I4
		//IL_01b1: Expected O, but got I4
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Expected O, but got Unknown
		//IL_0238: Expected O, but got I4
		//IL_023f: Expected O, but got I4
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Expected O, but got Unknown
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		//IL_026b: Expected O, but got I4
		try
		{
			frmMain.setting.FormCard.txtBingen = frmMain.setting.FormCard.txtBingen.Replace(";", "|").Replace(",", "|").Replace(".", "|");
			T0 name = (T0)ccbCateCard.Text;
			T1 val = (T1)frmMain.setting.FormCard.numQuantity;
			T2 val2 = frmMain.listCreditCardEntity<T1, T4, T2, T0>(name);
			T1 val3 = (T1)1;
			T1 val4 = (T1)0;
			while (true)
			{
				T4 val5 = (T4)(val4 < val);
				if (val5 == null)
				{
					break;
				}
				T0[] array = (T0[])(object)frmMain.setting.FormCard.txtBingen.Split((char[])(object)new T5[1] { (T5)124 });
				T1 val6 = (T1)0;
				while ((nint)val6 < array.Length)
				{
					T0 s = (T0)((object[])(object)array)[(object)val6];
					T3 val7 = (T3)double.Parse((string)s);
					T4 val8 = (T4)(val2 != null);
					if (val8 != null)
					{
						val3 = (T1)(((List<CreditCardEntity>)val2).Count + 1);
					}
					T1 val9 = (T1)0;
					CreditCardEntity creditCardEntity = new CreditCardEntity();
					creditCardEntity.Row = (int)val3;
					val3 = (T1)(val3 + 1);
					T0 cardGen = BinGen2Class.getCardGen<T1, T0, CreditCardDetector, T4, Regex, DateTime, T5, T7>((T0)((double*)(&val7))->ToString());
					creditCardEntity.Card_Number = ((string)cardGen).Split((char[])(object)new T5[1] { (T5)124 })[0];
					creditCardEntity.Exp_Month = ((string)cardGen).Split((char[])(object)new T5[1] { (T5)124 })[1];
					creditCardEntity.Exp_Year = ((string)cardGen).Split((char[])(object)new T5[1] { (T5)124 })[2];
					creditCardEntity.Card_Security = ((string)cardGen).Split((char[])(object)new T5[1] { (T5)124 })[3];
					T4 val10 = (T4)(creditCardEntity.Exp_Year.Length > 2);
					if (val10 != null)
					{
						creditCardEntity.Exp_Year = System.Runtime.CompilerServices.Unsafe.As<T5, char>(ref (T5)creditCardEntity.Exp_Year[creditCardEntity.Exp_Year.Length - 2]).ToString() + System.Runtime.CompilerServices.Unsafe.As<T5, char>(ref (T5)creditCardEntity.Exp_Year[creditCardEntity.Exp_Year.Length - 1]);
					}
					creditCardEntity.Status = frmMain.STATUS.Ready.ToString();
					creditCardEntity.UID = "";
					creditCardEntity.int_random = rnd.Next(1, 99999);
					((List<CreditCardEntity>)val2).Add(creditCardEntity);
					val9 = (T1)(val9 + 1);
					T4 val11 = (T4)(frmMain.setting.FormCard.numUpBin > 0 && (nint)val9 >= frmMain.setting.FormCard.numUpBin);
					if (val11 != null)
					{
						val9 = (T1)0;
						val7 = (T3)(val7 + 1.0);
					}
					val6 = (T1)(val6 + 1);
				}
				val4 = (T1)(val4 + 1);
			}
			loadCC<T1, T6>();
			frmMain.cartSaving();
		}
		catch (Exception ex)
		{
			frmMain.errorMessage((T0)ex.Message);
		}
	}

	private void numQuantity_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		frmMain.setting.FormCard.numQuantity = int.Parse(((decimal)(T0)numQuantity.Value).ToString());
		frmMain.settingSaving();
	}

	private void txtBingen_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		frmMain.setting.FormCard.txtBingen = txtBingen.Text;
		frmMain.settingSaving();
	}

	private void numUpBin_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		frmMain.setting.FormCard.numUpBin = int.Parse(((decimal)(T0)numUpBin.Value).ToString());
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
	private void InitializeComponent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25>()
	{
		T0 val = (T0)new System.ComponentModel.ComponentResourceManager(typeof(ADSPRoject.frmCart));
		this.gvCC = (System.Windows.Forms.DataGridView)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridView));
		this.statusStrip1 = (System.Windows.Forms.StatusStrip)System.Activator.CreateInstance(typeof(System.Windows.Forms.StatusStrip));
		this.toolStripStatusLabel1 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.lbTotal = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.button1 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.ccbCateCard = (System.Windows.Forms.ComboBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.ComboBox));
		this.button3 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.label1 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtBingen = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.button2 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.label2 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.numQuantity = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label3 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.numUpBin = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		((System.ComponentModel.ISupportInitialize)this.gvCC).BeginInit();
		this.statusStrip1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.numQuantity).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numUpBin).BeginInit();
		base.SuspendLayout();
		this.gvCC.AllowUserToAddRows = false;
		this.gvCC.AllowUserToDeleteRows = false;
		this.gvCC.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gvCC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		this.gvCC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.gvCC.Location = new System.Drawing.Point(16, 85);
		this.gvCC.Margin = new System.Windows.Forms.Padding(4);
		this.gvCC.Name = "gvCC";
		this.gvCC.ReadOnly = true;
		this.gvCC.RowHeadersWidth = 51;
		this.gvCC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.gvCC.Size = new System.Drawing.Size(1035, 470);
		this.gvCC.TabIndex = 3;
		this.gvCC.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(gvCC_ColumnAdded);
		this.gvCC.MouseClick += new System.Windows.Forms.MouseEventHandler(gvCC_MouseClick<T11, T12, T13, T9, T14>);
		this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
		this.statusStrip1.Items.AddRange((System.Windows.Forms.ToolStripItem[])(object)new T15[2]
		{
			(T15)this.toolStripStatusLabel1,
			(T15)this.lbTotal
		});
		this.statusStrip1.Location = new System.Drawing.Point(0, 572);
		this.statusStrip1.Name = "statusStrip1";
		this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
		this.statusStrip1.Size = new System.Drawing.Size(1067, 26);
		this.statusStrip1.TabIndex = 4;
		this.statusStrip1.Text = "statusStrip1";
		this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
		this.toolStripStatusLabel1.Size = new System.Drawing.Size(46, 20);
		this.toolStripStatusLabel1.Text = "Tổng:";
		this.lbTotal.Name = "lbTotal";
		this.lbTotal.Size = new System.Drawing.Size(17, 20);
		this.lbTotal.Text = "0";
		this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f);
		this.button1.Location = new System.Drawing.Point(352, 12);
		this.button1.Margin = new System.Windows.Forms.Padding(4);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(100, 33);
		this.button1.TabIndex = 5;
		this.button1.Text = "Reload";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click<T9, T16, T17, T18>);
		this.ccbCateCard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ccbCateCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f);
		this.ccbCateCard.FormattingEnabled = true;
		this.ccbCateCard.Location = new System.Drawing.Point(16, 15);
		this.ccbCateCard.Margin = new System.Windows.Forms.Padding(4);
		this.ccbCateCard.Name = "ccbCateCard";
		this.ccbCateCard.Size = new System.Drawing.Size(269, 30);
		this.ccbCateCard.TabIndex = 6;
		this.ccbCateCard.SelectedIndexChanged += new System.EventHandler(ccbCateCard_SelectedIndexChanged<T11, T9, T16, T19, T20, T17, T18>);
		this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f);
		this.button3.Location = new System.Drawing.Point(295, 12);
		this.button3.Margin = new System.Windows.Forms.Padding(4);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(49, 33);
		this.button3.TabIndex = 52;
		this.button3.Text = "❁";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(button3_Click<T11, T20, T17, T9, T16>);
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f);
		this.label1.Location = new System.Drawing.Point(691, 17);
		this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(45, 24);
		this.label1.TabIndex = 53;
		this.label1.Text = "BIN:";
		this.txtBingen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f);
		this.txtBingen.Location = new System.Drawing.Point(747, 14);
		this.txtBingen.Margin = new System.Windows.Forms.Padding(4);
		this.txtBingen.Name = "txtBingen";
		this.txtBingen.Size = new System.Drawing.Size(192, 28);
		this.txtBingen.TabIndex = 54;
		this.txtBingen.TextChanged += new System.EventHandler(txtBingen_TextChanged);
		this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f);
		this.button2.Location = new System.Drawing.Point(949, 10);
		this.button2.Margin = new System.Windows.Forms.Padding(4);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(100, 33);
		this.button2.TabIndex = 55;
		this.button2.Text = "Gen";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click<T21, T17, T19, T22, T11, T23, T18, T9, T16>);
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f);
		this.label2.Location = new System.Drawing.Point(472, 17);
		this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(91, 24);
		this.label2.TabIndex = 56;
		this.label2.Text = "Số lượng:";
		this.numQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f);
		this.numQuantity.Location = new System.Drawing.Point(570, 16);
		this.numQuantity.Maximum = new decimal((int[])(object)new T17[4]
		{
			(T17)999999999,
			default(T17),
			default(T17),
			default(T17)
		});
		this.numQuantity.Name = "numQuantity";
		this.numQuantity.Size = new System.Drawing.Size(114, 28);
		this.numQuantity.TabIndex = 57;
		this.numQuantity.Value = new decimal((int[])(object)new T17[4]
		{
			(T17)1000,
			default(T17),
			default(T17),
			default(T17)
		});
		this.numQuantity.ValueChanged += new System.EventHandler(numQuantity_ValueChanged<T24, T9, T16>);
		this.label3.AutoSize = true;
		this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f);
		this.label3.Location = new System.Drawing.Point(398, 52);
		this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(165, 24);
		this.label3.TabIndex = 58;
		this.label3.Text = "Tăng dần đầu bin:";
		this.numUpBin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f);
		this.numUpBin.Location = new System.Drawing.Point(570, 50);
		this.numUpBin.Maximum = new decimal((int[])(object)new T17[4]
		{
			(T17)999999999,
			default(T17),
			default(T17),
			default(T17)
		});
		this.numUpBin.Name = "numUpBin";
		this.numUpBin.Size = new System.Drawing.Size(114, 28);
		this.numUpBin.TabIndex = 59;
		this.numUpBin.Value = new decimal((int[])(object)new T17[4]
		{
			(T17)20,
			default(T17),
			default(T17),
			default(T17)
		});
		this.numUpBin.ValueChanged += new System.EventHandler(numUpBin_ValueChanged<T24, T9, T16>);
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1067, 598);
		base.Controls.Add(this.numUpBin);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.numQuantity);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.txtBingen);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.button3);
		base.Controls.Add(this.ccbCateCard);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.statusStrip1);
		base.Controls.Add(this.gvCC);
		base.Icon = (System.Drawing.Icon)(T25)((System.Resources.ResourceManager)val).GetObject("$this.Icon");
		base.Margin = new System.Windows.Forms.Padding(4);
		base.Name = "frmCart";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Thẻ ảo";
		base.Load += new System.EventHandler(frmCart_Load);
		((System.ComponentModel.ISupportInitialize)this.gvCC).EndInit();
		this.statusStrip1.ResumeLayout(false);
		this.statusStrip1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.numQuantity).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numUpBin).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
