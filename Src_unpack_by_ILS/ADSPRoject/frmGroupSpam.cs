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

namespace ADSPRoject;

public class frmGroupSpam : Form
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

		internal T0 _003C_002Ector_003Eb__0<T0>(GroupsEntity_Data a)
		{
			//IL_0012: Expected O, but got I4
			return (T0)listSelect.Contains(a.id);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public frmGroupSpam _003C_003E4__this;

		public int countThread;

		public ParameterizedThreadStart _003C_003E9__0;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal unsafe void _003CthrStart_003Eb__0<T0, T1, T2, T3, T4, T5>(T4 obj)
		{
			//IL_000c: Expected O, but got I4
			//IL_001d: Expected I4, but got O
			//IL_005c: Expected I4, but got O
			//IL_00b6: Expected I4, but got O
			//IL_00de: Expected I4, but got O
			//IL_0102: Expected O, but got I4
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Expected I4, but got Unknown
			T0 val = (T0)int.Parse(obj.ToString());
			_003C_003E4__this.ListAds[(int)val].message = STATUS.Processing.ToString();
			T1 outMessage = (T1)"";
			T1 strSpamGroup = (T1)_003C_003E4__this.strSpamGroup;
			strSpamGroup = (T1)((string)strSpamGroup).Replace("ten_group", _003C_003E4__this.ListAds[(int)val].name).Replace("ngay_gio", ((DateTime)(T3)DateTime.Now).ToShortDateString());
			strSpamGroup = (T1)((string)strSpamGroup).Replace("\r\n", "\n");
			_003C_003E4__this.frm.chrome.post_bai_group<T2, T5, T1>(out *(string*)(&outMessage), (T1)_003C_003E4__this.ListAds[(int)val].id, (T1)_003C_003E4__this.Background_ID, strSpamGroup);
			_003C_003E4__this.ListAds[(int)val].message = (string)outMessage;
			Thread.Sleep(_003C_003E4__this.Delay * 1000);
			T0 val2 = (T0)countThread;
			countThread = val2 - 1;
		}
	}

	public int intThread = 1;

	private List<GroupsEntity_Data> ListAds = (List<GroupsEntity_Data>)Activator.CreateInstance(typeof(List<GroupsEntity_Data>));

	private frmAdsManager frm;

	public bool isRunning = false;

	private List<string> listBackground = (List<string>)Activator.CreateInstance(typeof(List<string>));

	private string Background_ID;

	private bool SpamGroup;

	private string strSpamGroup;

	private int Delay;

	private IContainer components = null;

	private DataGridView gvData;

	private NumericUpDown numThread;

	private Label label2;

	private Button button1;

	private System.Windows.Forms.Timer timer_auto_refesh;

	private StatusStrip statusStrip1;

	private ToolStripStatusLabel toolStripStatusLabel1;

	private ToolStripStatusLabel lbQuantity;

	private GroupBox groupBox2;

	private CheckBox cbSpamGroup;

	private ComboBox ccbBackground;

	private TextBox txtSpamGroup;

	private Label label3;

	private NumericUpDown numDelay;

	private Label label4;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public frmGroupSpam(List<string> listSelect, frmAdsManager frmCamp)
	{
		_003C_003Ec__DisplayClass4_0 _003C_003Ec__DisplayClass4_ = new _003C_003Ec__DisplayClass4_0();
		_003C_003Ec__DisplayClass4_.listSelect = listSelect;
		base._002Ector();
		InitializeComponent<ComponentResourceManager, Container, DataGridView, NumericUpDown, Label, Button, GroupBox, TextBox, ComboBox, CheckBox, StatusStrip, ToolStripStatusLabel, int, decimal, object, EventArgs, bool, Rectangle, DrawItemEventArgs, MeasureItemEventArgs, string, char, ToolStripItem, Icon, FormClosingEventArgs>();
		frm = frmCamp;
		ListAds = frmCamp.Groups.Where(_003C_003Ec__DisplayClass4_._003C_002Ector_003Eb__0<bool>).ToList();
		gvData.AutoGenerateColumns = false;
		gvData.Columns.Clear();
		GenColumn<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Id", "Id");
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
			new Thread(thrStart<T0, int, Thread, ParameterizedThreadStart>).Start();
		}
	}

	private void thrStart<T0, T1, T2, T3>()
	{
		//IL_001b: Expected O, but got I4
		//IL_002a: Expected O, but got I4
		//IL_0032: Expected O, but got I4
		//IL_006a: Expected O, but got I4
		//IL_00ab: Expected O, but got I4
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected I4, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00c9: Expected O, but got I4
		//IL_00d2: Expected O, but got I4
		_003C_003Ec__DisplayClass9_0 _003C_003Ec__DisplayClass9_ = new _003C_003Ec__DisplayClass9_0();
		_003C_003Ec__DisplayClass9_._003C_003E4__this = this;
		_003C_003Ec__DisplayClass9_.countThread = 0;
		T0 val = (T0)SpamGroup;
		if (val != null)
		{
			_003C_003Ec__DisplayClass9_.countThread = 0;
			T1 val2 = (T1)0;
			while (true)
			{
				T0 val3 = (T0)((nint)val2 < ListAds.Count);
				if (val3 == null)
				{
					break;
				}
				while (true)
				{
					T0 val4 = (T0)(isRunning && _003C_003Ec__DisplayClass9_.countThread >= intThread);
					if (val4 == null)
					{
						break;
					}
					Thread.Sleep(1500);
				}
				T0 val5 = (T0)(!isRunning);
				if (val5 != null)
				{
					break;
				}
				T2 val6 = (T2)new Thread(_003C_003Ec__DisplayClass9_._003CthrStart_003Eb__0<T1, string, T0, DateTime, object, Dictionary<string, string>>);
				((Thread)val6).Start((object)val2);
				T1 val7 = (T1)_003C_003Ec__DisplayClass9_.countThread;
				_003C_003Ec__DisplayClass9_.countThread = val7 + 1;
				val2 = (T1)(val2 + 1);
			}
		}
		while (true)
		{
			T0 val8 = (T0)(isRunning && _003C_003Ec__DisplayClass9_.countThread > 0);
			if (val8 == null)
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

	private void frmPageManager_FormClosing<T0, T1, T2, T3>(T2 sender, T3 e)
	{
		//IL_000f: Expected O, but got I4
		T0 val = (T0)(frm.chrome != null);
		if (val != null)
		{
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].numThreadPage = int.Parse(((decimal)(T1)numThread.Value).ToString());
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].strSpamGroup = txtSpamGroup.Text;
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].DelaySpam = int.Parse(((decimal)(T1)numDelay.Value).ToString());
		}
		frmMain.settingSaving();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void frmPageManager_Load<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_000f: Expected O, but got I4
		//IL_0048: Expected O, but got I4
		//IL_00b4: Expected O, but got I4
		//IL_00bf: Expected I4, but got O
		//IL_00f9: Expected O, but got I4
		//IL_01ae: Expected O, but got I4
		//IL_01b9: Expected I4, but got O
		//IL_01d7: Expected O, but got I4
		//IL_01f1: Expected I4, but got O
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Expected O, but got Unknown
		//IL_020e: Expected O, but got I4
		//IL_0227: Expected O, but got I4
		T0 val = (T0)(frm.chrome != null);
		if (val != null)
		{
			T0 val2 = (T0)(frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].numThreadPage == 0);
			if (val2 != null)
			{
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].numThreadPage = 10;
			}
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
			T2 val5 = (T2)(txtSpamGroup.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].strSpamGroup);
			strSpamGroup = (string)val5;
			NumericUpDown numericUpDown2 = numDelay;
			int delaySpam = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].DelaySpam;
			val3 = (T1)delaySpam;
			Delay = delaySpam;
			numericUpDown2.Value = (int)val3;
		}
		listBackground = (List<string>)(object)((IEnumerable<T2>)(object)Directory.GetFiles("Background_content")).ToList();
		T1 val6 = (T1)0;
		while (true)
		{
			T0 val7 = (T0)((nint)val6 < listBackground.Count);
			if (val7 == null)
			{
				break;
			}
			ccbBackground.Items.Add(listBackground[(int)val6]);
			val6 = (T1)(val6 + 1);
		}
		T0 val8 = (T0)(ccbBackground.Items.Count > 0);
		if (val8 != null)
		{
			ccbBackground.SelectedIndex = 0;
		}
	}

	private void ccbBackground_DrawItem<T0, T1, T2, T3>(T2 sender, T3 e)
	{
		//IL_000d: Expected O, but got I4
		T0 val = (T0)(((DrawItemEventArgs)e).Index != -1);
		if (val != null)
		{
			((DrawItemEventArgs)e).Graphics.DrawImage(Image.FromFile(listBackground[((DrawItemEventArgs)e).Index]), ((Rectangle)(T1)((DrawItemEventArgs)e).Bounds).Left, ((Rectangle)(T1)((DrawItemEventArgs)e).Bounds).Top);
		}
	}

	private void ccbBackground_MeasureItem<T0, T1>(T0 sender, T1 e)
	{
		((MeasureItemEventArgs)e).ItemWidth = 32;
		((MeasureItemEventArgs)e).ItemHeight = 32;
	}

	private void ccbBackground_SelectionChangeCommitted<T0, T1>(T0 sender, T1 e)
	{
	}

	private void ccbBackground_SelectedIndexChanged<T0, T1, T2, T3>(T1 sender, T2 e)
	{
		T0 val = (T0)listBackground[ccbBackground.SelectedIndex];
		val = ((IEnumerable<T0>)(object)((string)val).Split((char[])(object)new T3[1] { (T3)92 })).Last();
		val = ((IEnumerable<T0>)(object)((string)val).Split((char[])(object)new T3[1] { (T3)46 })).First();
		Background_ID = (string)val;
		Console.WriteLine(listBackground[ccbBackground.SelectedIndex]);
	}

	private void cbSpamGroup_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		SpamGroup = cbSpamGroup.Checked;
		T0 val = (T0)SpamGroup;
		if (val == null)
		{
			cbSpamGroup.ForeColor = Color.Black;
		}
		else
		{
			cbSpamGroup.ForeColor = Color.Red;
		}
	}

	private void txtSpamGroup_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		strSpamGroup = txtSpamGroup.Text;
	}

	private void numDelay_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		Delay = int.Parse(((decimal)(T0)numDelay.Value).ToString());
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
	private void InitializeComponent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24>()
	{
		this.components = (System.ComponentModel.IContainer)System.Activator.CreateInstance(typeof(System.ComponentModel.Container));
		T0 val = (T0)new System.ComponentModel.ComponentResourceManager(typeof(ADSPRoject.frmGroupSpam));
		this.gvData = (System.Windows.Forms.DataGridView)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridView));
		this.numThread = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label2 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.button1 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.groupBox2 = (System.Windows.Forms.GroupBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.GroupBox));
		this.numDelay = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label4 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.label3 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtSpamGroup = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.ccbBackground = (System.Windows.Forms.ComboBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.ComboBox));
		this.cbSpamGroup = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.timer_auto_refesh = new System.Windows.Forms.Timer(this.components);
		this.statusStrip1 = (System.Windows.Forms.StatusStrip)System.Activator.CreateInstance(typeof(System.Windows.Forms.StatusStrip));
		this.toolStripStatusLabel1 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.lbQuantity = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		((System.ComponentModel.ISupportInitialize)this.gvData).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numThread).BeginInit();
		this.groupBox2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.numDelay).BeginInit();
		this.statusStrip1.SuspendLayout();
		base.SuspendLayout();
		this.gvData.AllowUserToAddRows = false;
		this.gvData.AllowUserToDeleteRows = false;
		this.gvData.AllowUserToOrderColumns = true;
		this.gvData.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.gvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		this.gvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.gvData.Location = new System.Drawing.Point(12, 13);
		this.gvData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.gvData.Name = "gvData";
		this.gvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.gvData.Size = new System.Drawing.Size(494, 373);
		this.gvData.TabIndex = 5;
		this.numThread.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.numThread.Location = new System.Drawing.Point(767, 367);
		this.numThread.Name = "numThread";
		this.numThread.Size = new System.Drawing.Size(134, 20);
		this.numThread.TabIndex = 39;
		this.numThread.Value = new decimal((int[])(object)new T12[4]
		{
			(T12)1,
			default(T12),
			default(T12),
			default(T12)
		});
		this.numThread.ValueChanged += new System.EventHandler(numThread_ValueChanged<T13, T14, T15>);
		this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(721, 369);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(40, 13);
		this.label2.TabIndex = 38;
		this.label2.Text = "Luồng:";
		this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.button1.BackColor = System.Drawing.Color.DodgerBlue;
		this.button1.Location = new System.Drawing.Point(907, 334);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(75, 53);
		this.button1.TabIndex = 37;
		this.button1.Text = "START";
		this.button1.UseVisualStyleBackColor = false;
		this.button1.Click += new System.EventHandler(button1_Click<T16, T14, T15>);
		this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.groupBox2.Controls.Add(this.numDelay);
		this.groupBox2.Controls.Add(this.label4);
		this.groupBox2.Controls.Add(this.label3);
		this.groupBox2.Controls.Add(this.txtSpamGroup);
		this.groupBox2.Controls.Add(this.ccbBackground);
		this.groupBox2.Controls.Add(this.cbSpamGroup);
		this.groupBox2.Location = new System.Drawing.Point(512, 13);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Size = new System.Drawing.Size(458, 171);
		this.groupBox2.TabIndex = 40;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "Spam group";
		this.numDelay.Location = new System.Drawing.Point(49, 37);
		this.numDelay.Maximum = new decimal((int[])(object)new T12[4]
		{
			(T12)9999999,
			default(T12),
			default(T12),
			default(T12)
		});
		this.numDelay.Name = "numDelay";
		this.numDelay.Size = new System.Drawing.Size(92, 20);
		this.numDelay.TabIndex = 47;
		this.numDelay.ValueChanged += new System.EventHandler(numDelay_ValueChanged<T13, T14, T15>);
		this.label4.AutoSize = true;
		this.label4.Location = new System.Drawing.Point(6, 39);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(37, 13);
		this.label4.TabIndex = 46;
		this.label4.Text = "Delay:";
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(319, 17);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(133, 39);
		this.label3.TabIndex = 45;
		this.label3.Text = "Spint text: {xin chào|hello}\r\nten_group: tên group\r\nngay_gio: ngày giờ hiện tại";
		this.txtSpamGroup.Location = new System.Drawing.Point(6, 61);
		this.txtSpamGroup.Multiline = true;
		this.txtSpamGroup.Name = "txtSpamGroup";
		this.txtSpamGroup.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		this.txtSpamGroup.Size = new System.Drawing.Size(446, 104);
		this.txtSpamGroup.TabIndex = 44;
		this.txtSpamGroup.TextChanged += new System.EventHandler(txtSpamGroup_TextChanged);
		this.ccbBackground.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
		this.ccbBackground.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ccbBackground.FormattingEnabled = true;
		this.ccbBackground.ItemHeight = 32;
		this.ccbBackground.Location = new System.Drawing.Point(147, 17);
		this.ccbBackground.Name = "ccbBackground";
		this.ccbBackground.Size = new System.Drawing.Size(166, 38);
		this.ccbBackground.TabIndex = 43;
		this.ccbBackground.DrawItem += new System.Windows.Forms.DrawItemEventHandler(ccbBackground_DrawItem<T16, T17, T14, T18>);
		this.ccbBackground.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(ccbBackground_MeasureItem);
		this.ccbBackground.SelectedIndexChanged += new System.EventHandler(ccbBackground_SelectedIndexChanged<T20, T14, T15, T21>);
		this.ccbBackground.SelectionChangeCommitted += new System.EventHandler(ccbBackground_SelectionChangeCommitted);
		this.cbSpamGroup.AutoSize = true;
		this.cbSpamGroup.Location = new System.Drawing.Point(6, 19);
		this.cbSpamGroup.Name = "cbSpamGroup";
		this.cbSpamGroup.Size = new System.Drawing.Size(88, 17);
		this.cbSpamGroup.TabIndex = 41;
		this.cbSpamGroup.Text = "Spam groups";
		this.cbSpamGroup.UseVisualStyleBackColor = true;
		this.cbSpamGroup.CheckedChanged += new System.EventHandler(cbSpamGroup_CheckedChanged<T16, T14, T15>);
		this.timer_auto_refesh.Interval = 1000;
		this.timer_auto_refesh.Tick += new System.EventHandler(timer_auto_refesh_Tick<T16, T14, T15>);
		this.statusStrip1.Items.AddRange((System.Windows.Forms.ToolStripItem[])(object)new T22[2]
		{
			(T22)this.toolStripStatusLabel1,
			(T22)this.lbQuantity
		});
		this.statusStrip1.Location = new System.Drawing.Point(0, 390);
		this.statusStrip1.Name = "statusStrip1";
		this.statusStrip1.Size = new System.Drawing.Size(994, 22);
		this.statusStrip1.TabIndex = 41;
		this.statusStrip1.Text = "statusStrip1";
		this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
		this.toolStripStatusLabel1.Size = new System.Drawing.Size(37, 17);
		this.toolStripStatusLabel1.Text = "Tổng:";
		this.lbQuantity.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.lbQuantity.Name = "lbQuantity";
		this.lbQuantity.Size = new System.Drawing.Size(14, 17);
		this.lbQuantity.Text = "0";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(994, 412);
		base.Controls.Add(this.groupBox2);
		base.Controls.Add(this.statusStrip1);
		base.Controls.Add(this.numThread);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.gvData);
		base.Icon = (System.Drawing.Icon)(T23)((System.Resources.ResourceManager)val).GetObject("$this.Icon");
		base.Name = "frmGroupSpam";
		this.Text = "frmPageManager";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(frmPageManager_FormClosing<T16, T13, T14, T24>);
		base.Load += new System.EventHandler(frmPageManager_Load<T16, T12, T20, T14, T15>);
		((System.ComponentModel.ISupportInitialize)this.gvData).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numThread).EndInit();
		this.groupBox2.ResumeLayout(false);
		this.groupBox2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.numDelay).EndInit();
		this.statusStrip1.ResumeLayout(false);
		this.statusStrip1.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
