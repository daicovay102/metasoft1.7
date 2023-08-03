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
using Newtonsoft.Json;

namespace ADSPRoject;

public class frmGroup : Form
{
	private List<GroupFB> listGroupFB = (List<GroupFB>)Activator.CreateInstance(typeof(List<GroupFB>));

	private int folderCheckedIndex = 0;

	private string FileNameFBList;

	private IContainer components = null;

	private DataGridView gvData;

	private SplitContainer splitContainer1;

	private CheckedListBox cbListFolder;

	private Panel panel2;

	private Panel panel1;

	private GroupBox groupBox1;

	private GroupBox groupBox2;

	private Panel panel3;

	private GroupBox groupBox3;

	private TextBox textBox1;

	private Button button1;

	private Panel panel5;

	private Panel panel4;

	private ProgressBar progressBar1;

	private System.Windows.Forms.Timer timer_process;

	private Button button2;

	private Button button3;

	public frmGroup()
	{
		Control.CheckForIllegalCrossThreadCalls = false;
		InitializeComponent<ComponentResourceManager, Container, DataGridView, SplitContainer, Panel, GroupBox, Button, TextBox, CheckedListBox, ProgressBar, object, DataGridViewCellEventArgs, bool, ContextMenu, MenuItem, MouseEventArgs, int, EventArgs, CheckState, Exception, ItemCheckEventArgs, List<GroupFBEntity>, Icon>();
	}

	private void frmGroup_Load<T0, T1>(T0 sender, T1 e)
	{
		loadGroup<string, DirectoryInfo, FileInfo, int>();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void loadGroup<T0, T1, T2, T3>()
	{
		//IL_0031: Expected O, but got I4
		//IL_0037: Expected O, but got I4
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected O, but got Unknown
		cbListFolder.Items.Clear();
		T0 path = (T0)(Application.StartupPath + "\\GroupFB");
		T1 val = (T1)new DirectoryInfo((string)path);
		T2[] files = (T2[])(object)((DirectoryInfo)val).GetFiles();
		T3 val2 = (T3)1;
		T2[] array = files;
		T3 val3 = (T3)0;
		while ((nint)val3 < array.Length)
		{
			T2 val4 = (T2)((object[])(object)array)[(object)val3];
			GroupFB groupFB = new GroupFB();
			groupFB.UID = Path.GetFileNameWithoutExtension(((FileSystemInfo)val4).Name);
			listGroupFB.Add(groupFB);
			cbListFolder.Items.Add(groupFB.UID);
			val2 = (T3)(val2 + 1);
			val3 = (T3)(val3 + 1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void cbListFolder_ItemCheck<T0, T1, T2, T3, T4, T5, T6>(T4 sender, T5 e)
	{
		//IL_0007: Expected O, but got I4
		//IL_0025: Expected O, but got I4
		//IL_002d: Expected O, but got I4
		//IL_003b: Expected I4, but got O
		//IL_004d: Expected O, but got I4
		//IL_005d: Expected I4, but got O
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0076: Expected O, but got I4
		//IL_00db: Expected O, but got I4
		T0 val = (T0)((T1)((ItemCheckEventArgs)e).NewValue).ToString().ToLower().Equals("checked");
		if (val == null)
		{
			return;
		}
		T2 val2 = (T2)0;
		while (true)
		{
			T0 val3 = (T0)((nint)val2 < cbListFolder.Items.Count);
			if (val3 == null)
			{
				break;
			}
			T0 val4 = (T0)(cbListFolder.GetItemChecked((int)val2) && (nint)val2 != ((ItemCheckEventArgs)e).Index);
			if (val4 != null)
			{
				cbListFolder.SetItemChecked((int)val2, value: false);
			}
			val2 = (T2)(val2 + 1);
		}
		folderCheckedIndex = ((ItemCheckEventArgs)e).Index;
		FileNameFBList = $"GroupFB\\{listGroupFB[folderCheckedIndex].UID}.json";
		groupBox1.Text = listGroupFB[folderCheckedIndex].UID;
		try
		{
			T0 val5 = (T0)File.Exists(FileNameFBList);
			if (val5 == null)
			{
				listGroupFB[folderCheckedIndex].listGroupFBEntity.Clear();
				listGroupFB[folderCheckedIndex].listGroupFBEntity = (List<GroupFBEntity>)Activator.CreateInstance(typeof(T6));
			}
			else
			{
				listGroupFB[folderCheckedIndex].listGroupFBEntity = (List<GroupFBEntity>)JsonConvert.DeserializeObject<T6>(File.ReadAllText(FileNameFBList));
			}
			loadData();
		}
		catch (Exception ex)
		{
			frmMain.errorMessage(ex.Message);
		}
	}

	private void loadData()
	{
		gvData.DataSource = null;
		gvData.DataSource = listGroupFB[folderCheckedIndex].listGroupFBEntity;
	}

	private void gvData_CellEndEdit<T0, T1>(T0 sender, T1 e)
	{
		saveGroupFBEntity();
	}

	private void saveGroupFBEntity()
	{
		File.WriteAllText(FileNameFBList, JsonConvert.SerializeObject((object)listGroupFB[folderCheckedIndex].listGroupFBEntity));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gvData_MouseClick<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_000e: Expected O, but got I4
		T0 val = (T0)(((MouseEventArgs)e).Button == MouseButtons.Right);
		if (val != null)
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(ContextMenu));
			T2 val3 = (T2)new MenuItem("Select");
			T2 item = (T2)new MenuItem("Tick all", (EventHandler)checkedAllSelectEvent<List<GroupFBEntity>.Enumerator, T3, EventArgs>);
			((Menu)val3).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("UnTick all", (EventHandler)uncheckAllSelectEvent<List<GroupFBEntity>.Enumerator, T3, EventArgs>);
			((Menu)val3).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("------------");
			((Menu)val3).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Tick", (EventHandler)checkedSelectEvent<List<DataGridViewRow>, T0, int, T3, EventArgs, DataGridViewRow>);
			((Menu)val3).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("UnTick", (EventHandler)uncheckSelectEvent<List<DataGridViewRow>, T0, int, T3, EventArgs, DataGridViewRow>);
			((Menu)val3).MenuItems.Add((MenuItem)item);
			((Menu)val2).MenuItems.Add((MenuItem)val3);
			((ContextMenu)val2).Show((Control)gvData, new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y));
		}
	}

	private unsafe void checkedAllSelectEvent<T0, T1, T2>(T1 sender, T2 e)
	{
		T0 enumerator = (T0)listGroupFB[folderCheckedIndex].listGroupFBEntity.GetEnumerator();
		try
		{
			while (((List<GroupFBEntity>.Enumerator*)(&enumerator))->MoveNext())
			{
				GroupFBEntity current = ((List<GroupFBEntity>.Enumerator*)(&enumerator))->Current;
				current.Select = true;
			}
		}
		finally
		{
			((IDisposable)(*(List<GroupFBEntity>.Enumerator*)(&enumerator))).Dispose();
		}
		gvData.Refresh();
		saveGroupFBEntity();
	}

	private unsafe void uncheckAllSelectEvent<T0, T1, T2>(T1 sender, T2 e)
	{
		T0 enumerator = (T0)listGroupFB[folderCheckedIndex].listGroupFBEntity.GetEnumerator();
		try
		{
			while (((List<GroupFBEntity>.Enumerator*)(&enumerator))->MoveNext())
			{
				GroupFBEntity current = ((List<GroupFBEntity>.Enumerator*)(&enumerator))->Current;
				current.Select = false;
			}
		}
		finally
		{
			((IDisposable)(*(List<GroupFBEntity>.Enumerator*)(&enumerator))).Dispose();
		}
		gvData.Refresh();
		saveGroupFBEntity();
	}

	private void checkedSelectEvent<T0, T1, T2, T3, T4, T5>(T3 sender, T4 e)
	{
		//IL_0068: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		//IL_0093: Expected I4, but got O
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_00af: Expected O, but got I4
		T0 val = (T0)gvData.SelectedRows.Cast<T5>().Where((Func<T5, bool>)(object)(Func<DataGridViewRow, bool>)((T5 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T5, T2>)(object)(Func<DataGridViewRow, int>)((T5 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 != null)
		{
			T2 val3 = (T2)(((List<DataGridViewRow>)val).Count - 1);
			while (true)
			{
				T1 val4 = (T1)((nint)val3 >= 0);
				if (val4 == null)
				{
					break;
				}
				listGroupFB[folderCheckedIndex].listGroupFBEntity[((List<DataGridViewRow>)val)[(int)val3].Index].Select = true;
				val3 = (T2)(val3 - 1);
			}
			gvData.Refresh();
		}
		saveGroupFBEntity();
	}

	private void uncheckSelectEvent<T0, T1, T2, T3, T4, T5>(T3 sender, T4 e)
	{
		//IL_0068: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		//IL_0093: Expected I4, but got O
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_00af: Expected O, but got I4
		T0 val = (T0)gvData.SelectedRows.Cast<T5>().Where((Func<T5, bool>)(object)(Func<DataGridViewRow, bool>)((T5 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T5, T2>)(object)(Func<DataGridViewRow, int>)((T5 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 != null)
		{
			T2 val3 = (T2)(((List<DataGridViewRow>)val).Count - 1);
			while (true)
			{
				T1 val4 = (T1)((nint)val3 >= 0);
				if (val4 == null)
				{
					break;
				}
				listGroupFB[folderCheckedIndex].listGroupFBEntity[((List<DataGridViewRow>)val)[(int)val3].Index].Select = false;
				val3 = (T2)(val3 - 1);
			}
			gvData.Refresh();
		}
		saveGroupFBEntity();
	}

	private void textBox1_TextChanged<T0, T1>(T0 sender, T1 e)
	{
	}

	private void button3_Click<T0, T1, T2, T3>(T2 sender, T3 e)
	{
		//IL_000d: Expected O, but got I4
		//IL_001b: Expected I4, but got O
		//IL_0031: Expected O, but got I4
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_0047: Expected O, but got I4
		//IL_0059: Expected I4, but got O
		cbListFolder.ClearSelected();
		T0 val = (T0)0;
		while (true)
		{
			T1 val2 = (T1)((nint)val < listGroupFB.Count);
			if (val2 != null)
			{
				T1 val3 = (T1)listGroupFB[(int)val].UID.Contains(textBox1.Text);
				if (val3 != null)
				{
					break;
				}
				val = (T0)(val + 1);
				continue;
			}
			return;
		}
		cbListFolder.SetSelected((int)val, value: true);
	}

	private void button1_Click<T0, T1, T2>(T0 sender, T1 e)
	{
		//IL_0017: Expected O, but got I4
		new Thread((ParameterizedThreadStart)uploadAll<T2, List<GroupFB>.Enumerator, List<GroupFBEntity>.Enumerator, T0, List<GroupFBEntity>>).Start((T2)1);
	}

	private void button2_Click<T0, T1, T2>(T0 sender, T1 e)
	{
		//IL_0017: Expected O, but got I4
		new Thread((ParameterizedThreadStart)uploadAll<T2, List<GroupFB>.Enumerator, List<GroupFBEntity>.Enumerator, T0, List<GroupFBEntity>>).Start((T2)0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void uploadAll<T0, T1, T2, T3, T4>(T3 isSelect)
	{
		//IL_0030: Expected O, but got I4
		//IL_006d: Expected O, but got I4
		//IL_00a7: Expected I4, but got O
		progressBar1.Style = ProgressBarStyle.Marquee;
		button1.Enabled = false;
		button2.Enabled = false;
		T0 val = (T0)bool.Parse(isSelect.ToString());
		T1 enumerator = (T1)listGroupFB.GetEnumerator();
		try
		{
			while (((List<GroupFB>.Enumerator*)(&enumerator))->MoveNext())
			{
				GroupFB current = ((List<GroupFB>.Enumerator*)(&enumerator))->Current;
				FileNameFBList = $"GroupFB\\{current.UID}.json";
				T0 val2 = (T0)File.Exists(FileNameFBList);
				if (val2 != null)
				{
					current.listGroupFBEntity = (List<GroupFBEntity>)JsonConvert.DeserializeObject<T4>(File.ReadAllText(FileNameFBList));
					T2 enumerator2 = (T2)current.listGroupFBEntity.GetEnumerator();
					try
					{
						while (((List<GroupFBEntity>.Enumerator*)(&enumerator2))->MoveNext())
						{
							GroupFBEntity current2 = ((List<GroupFBEntity>.Enumerator*)(&enumerator2))->Current;
							current2.Select = (byte)(int)val != 0;
						}
					}
					finally
					{
						((IDisposable)(*(List<GroupFBEntity>.Enumerator*)(&enumerator2))).Dispose();
					}
					File.WriteAllText(FileNameFBList, JsonConvert.SerializeObject((object)current.listGroupFBEntity));
				}
				else
				{
					current.listGroupFBEntity.Clear();
					current.listGroupFBEntity = (List<GroupFBEntity>)Activator.CreateInstance(typeof(T4));
				}
			}
		}
		finally
		{
			((IDisposable)(*(List<GroupFB>.Enumerator*)(&enumerator))).Dispose();
		}
		button1.Enabled = true;
		button2.Enabled = true;
		progressBar1.Style = ProgressBarStyle.Blocks;
		frmMain.infoMessage("Done");
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
	private void InitializeComponent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22>()
	{
		this.components = (System.ComponentModel.IContainer)System.Activator.CreateInstance(typeof(System.ComponentModel.Container));
		T0 val = (T0)new System.ComponentModel.ComponentResourceManager(typeof(ADSPRoject.frmGroup));
		this.gvData = (System.Windows.Forms.DataGridView)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridView));
		this.splitContainer1 = (System.Windows.Forms.SplitContainer)System.Activator.CreateInstance(typeof(System.Windows.Forms.SplitContainer));
		this.panel3 = (System.Windows.Forms.Panel)System.Activator.CreateInstance(typeof(System.Windows.Forms.Panel));
		this.groupBox3 = (System.Windows.Forms.GroupBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.GroupBox));
		this.button3 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.textBox1 = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.panel2 = (System.Windows.Forms.Panel)System.Activator.CreateInstance(typeof(System.Windows.Forms.Panel));
		this.groupBox1 = (System.Windows.Forms.GroupBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.GroupBox));
		this.cbListFolder = (System.Windows.Forms.CheckedListBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckedListBox));
		this.panel1 = (System.Windows.Forms.Panel)System.Activator.CreateInstance(typeof(System.Windows.Forms.Panel));
		this.groupBox2 = (System.Windows.Forms.GroupBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.GroupBox));
		this.button2 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.button1 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.panel5 = (System.Windows.Forms.Panel)System.Activator.CreateInstance(typeof(System.Windows.Forms.Panel));
		this.panel4 = (System.Windows.Forms.Panel)System.Activator.CreateInstance(typeof(System.Windows.Forms.Panel));
		this.progressBar1 = (System.Windows.Forms.ProgressBar)System.Activator.CreateInstance(typeof(System.Windows.Forms.ProgressBar));
		this.timer_process = new System.Windows.Forms.Timer(this.components);
		((System.ComponentModel.ISupportInitialize)this.gvData).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
		this.splitContainer1.Panel1.SuspendLayout();
		this.splitContainer1.Panel2.SuspendLayout();
		this.splitContainer1.SuspendLayout();
		this.panel3.SuspendLayout();
		this.groupBox3.SuspendLayout();
		this.panel2.SuspendLayout();
		this.groupBox1.SuspendLayout();
		this.panel1.SuspendLayout();
		this.groupBox2.SuspendLayout();
		this.panel5.SuspendLayout();
		this.panel4.SuspendLayout();
		base.SuspendLayout();
		this.gvData.AllowUserToAddRows = false;
		this.gvData.AllowUserToDeleteRows = false;
		this.gvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		this.gvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.gvData.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gvData.Location = new System.Drawing.Point(0, 0);
		this.gvData.Name = "gvData";
		this.gvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.gvData.Size = new System.Drawing.Size(729, 440);
		this.gvData.TabIndex = 1;
		this.gvData.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(gvData_CellEndEdit);
		this.gvData.MouseClick += new System.Windows.Forms.MouseEventHandler(gvData_MouseClick<T12, T13, T14, T10, T15>);
		this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainer1.Location = new System.Drawing.Point(0, 0);
		this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.splitContainer1.Name = "splitContainer1";
		this.splitContainer1.Panel1.Controls.Add(this.panel3);
		this.splitContainer1.Panel1.Controls.Add(this.panel2);
		this.splitContainer1.Panel1.Controls.Add(this.panel1);
		this.splitContainer1.Panel2.Controls.Add(this.panel5);
		this.splitContainer1.Panel2.Controls.Add(this.panel4);
		this.splitContainer1.Size = new System.Drawing.Size(933, 450);
		this.splitContainer1.SplitterDistance = 200;
		this.splitContainer1.TabIndex = 2;
		this.panel3.Controls.Add(this.groupBox3);
		this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
		this.panel3.Location = new System.Drawing.Point(0, 153);
		this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.panel3.Name = "panel3";
		this.panel3.Size = new System.Drawing.Size(200, 38);
		this.panel3.TabIndex = 2;
		this.groupBox3.Controls.Add(this.button3);
		this.groupBox3.Controls.Add(this.textBox1);
		this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
		this.groupBox3.Location = new System.Drawing.Point(0, 0);
		this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.groupBox3.Name = "groupBox3";
		this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.groupBox3.Size = new System.Drawing.Size(200, 38);
		this.groupBox3.TabIndex = 11;
		this.groupBox3.TabStop = false;
		this.groupBox3.Text = "Search";
		this.button3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.button3.Location = new System.Drawing.Point(170, 14);
		this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(27, 18);
		this.button3.TabIndex = 11;
		this.button3.Text = "O";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(button3_Click<T16, T12, T10, T17>);
		this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.textBox1.Location = new System.Drawing.Point(6, 14);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(158, 20);
		this.textBox1.TabIndex = 10;
		this.textBox1.TextChanged += new System.EventHandler(textBox1_TextChanged);
		this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.panel2.Controls.Add(this.groupBox1);
		this.panel2.Location = new System.Drawing.Point(3, 196);
		this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.panel2.Name = "panel2";
		this.panel2.Size = new System.Drawing.Size(197, 252);
		this.panel2.TabIndex = 3;
		this.groupBox1.Controls.Add(this.cbListFolder);
		this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.groupBox1.Location = new System.Drawing.Point(0, 0);
		this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.groupBox1.Size = new System.Drawing.Size(197, 252);
		this.groupBox1.TabIndex = 4;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Group";
		this.cbListFolder.Dock = System.Windows.Forms.DockStyle.Fill;
		this.cbListFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 13f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cbListFolder.FormattingEnabled = true;
		this.cbListFolder.Items.AddRange((object[])(object)new T10[5]
		{
			(T10)"fdsaf",
			(T10)"fdsafdas",
			(T10)"fdsaf",
			(T10)"gfdsgfd",
			(T10)"432432"
		});
		this.cbListFolder.Location = new System.Drawing.Point(3, 15);
		this.cbListFolder.Name = "cbListFolder";
		this.cbListFolder.Size = new System.Drawing.Size(191, 235);
		this.cbListFolder.TabIndex = 3;
		this.cbListFolder.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(cbListFolder_ItemCheck<T12, T18, T16, T19, T10, T20, T21>);
		this.panel1.Controls.Add(this.groupBox2);
		this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
		this.panel1.Location = new System.Drawing.Point(0, 0);
		this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(200, 153);
		this.panel1.TabIndex = 1;
		this.groupBox2.Controls.Add(this.button2);
		this.groupBox2.Controls.Add(this.button1);
		this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.groupBox2.Location = new System.Drawing.Point(0, 0);
		this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.groupBox2.Size = new System.Drawing.Size(200, 153);
		this.groupBox2.TabIndex = 11;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "Setting";
		this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.button2.Location = new System.Drawing.Point(12, 46);
		this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(182, 25);
		this.button2.TabIndex = 12;
		this.button2.Text = "Update Untick All";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click<T10, T17, T12>);
		this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.button1.Location = new System.Drawing.Point(12, 17);
		this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(182, 25);
		this.button1.TabIndex = 11;
		this.button1.Text = "Update Tick All";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click<T10, T17, T12>);
		this.panel5.Controls.Add(this.gvData);
		this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
		this.panel5.Location = new System.Drawing.Point(0, 0);
		this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.panel5.Name = "panel5";
		this.panel5.Size = new System.Drawing.Size(729, 440);
		this.panel5.TabIndex = 4;
		this.panel4.Controls.Add(this.progressBar1);
		this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.panel4.Location = new System.Drawing.Point(0, 440);
		this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.panel4.Name = "panel4";
		this.panel4.Size = new System.Drawing.Size(729, 10);
		this.panel4.TabIndex = 3;
		this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.progressBar1.Location = new System.Drawing.Point(0, 2);
		this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.progressBar1.Name = "progressBar1";
		this.progressBar1.Size = new System.Drawing.Size(729, 8);
		this.progressBar1.TabIndex = 2;
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(933, 450);
		base.Controls.Add(this.splitContainer1);
		this.Font = new System.Drawing.Font("Verdana", 8f);
		base.Icon = (System.Drawing.Icon)(T22)((System.Resources.ResourceManager)val).GetObject("$this.Icon");
		base.Name = "frmGroup";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Cài đặt Group";
		base.Load += new System.EventHandler(frmGroup_Load);
		((System.ComponentModel.ISupportInitialize)this.gvData).EndInit();
		this.splitContainer1.Panel1.ResumeLayout(false);
		this.splitContainer1.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
		this.splitContainer1.ResumeLayout(false);
		this.panel3.ResumeLayout(false);
		this.groupBox3.ResumeLayout(false);
		this.groupBox3.PerformLayout();
		this.panel2.ResumeLayout(false);
		this.groupBox1.ResumeLayout(false);
		this.panel1.ResumeLayout(false);
		this.groupBox2.ResumeLayout(false);
		this.panel5.ResumeLayout(false);
		this.panel4.ResumeLayout(false);
		base.ResumeLayout(false);
	}
}
