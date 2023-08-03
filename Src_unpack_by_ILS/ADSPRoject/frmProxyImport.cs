using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ADSPRoject.Data;

namespace ADSPRoject;

public class frmProxyImport : Form
{
	private frmMain frmMain;

	private IContainer components = null;

	private DataGridView gvProxy;

	private TextBox txtProxy;

	private Label label1;

	private Button button1;

	private Button button2;

	private NumericUpDown numDelay;

	private NumericUpDown numThread;

	private Label label2;

	private Label label3;

	private RadioButton rbProxy;

	private RadioButton rbSocks;

	private Button button3;

	private Label lbTotal;

	private CheckBox cbRandom;

	public frmProxyImport(frmMain frm)
	{
		InitializeComponent<ComponentResourceManager, DataGridView, TextBox, Label, Button, NumericUpDown, RadioButton, CheckBox, bool, ContextMenu, MenuItem, object, MouseEventArgs, string, int, EventArgs, List<ProxySocksEntity>, char, decimal, Icon, FormClosingEventArgs>();
		frmMain = frm;
		base.DialogResult = DialogResult.Cancel;
		gvProxy.DataSource = frmMain.proxySetting.listProxy;
		numThread.Value = frmMain.proxySetting.intThread;
		numDelay.Value = frmMain.proxySetting.intDelay;
		rbSocks.Checked = !frmMain.proxySetting.isProxy;
		rbProxy.Checked = frmMain.proxySetting.isProxy;
		cbRandom.Checked = frmMain.proxySetting.isRandom;
		setGv<int>();
	}

	private void setGv<T0>()
	{
		//IL_004e: Expected O, but got I4
		gvProxy.ClearSelection();
		gvProxy.DataSource = null;
		gvProxy.DataSource = frmMain.proxySetting.listProxy;
		lbTotal.Text = System.Runtime.CompilerServices.Unsafe.As<T0, int>(ref (T0)frmMain.proxySetting.listProxy.Count).ToString();
	}

	private void numThread_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		frmMain.proxySetting.intThread = int.Parse(((decimal)(T0)numThread.Value).ToString());
	}

	private void numDelay_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		frmMain.proxySetting.intDelay = int.Parse(((decimal)(T0)numDelay.Value).ToString());
	}

	private void frmProxyImport_FormClosing<T0, T1>(T0 sender, T1 e)
	{
	}

	private void button3_Click<T0, T1>(T0 sender, T1 e)
	{
		base.DialogResult = DialogResult.OK;
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void button1_Click<T0, T1, T2, T3, T4, T5, T6>(T3 sender, T4 e)
	{
		//IL_0014: Expected O, but got I4
		//IL_0044: Expected O, but got I4
		//IL_0092: Expected O, but got I4
		//IL_0143: Expected O, but got I4
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		T0 val = (T0)(frmMain.proxySetting.listProxy == null);
		if (val != null)
		{
			frmMain.proxySetting.listProxy = (List<ProxySocksEntity>)Activator.CreateInstance(typeof(T5));
		}
		T1[] lines = (T1[])(object)txtProxy.Lines;
		T2 val2 = (T2)0;
		while ((nint)val2 < lines.Length)
		{
			T1 val3 = (T1)((object[])(object)lines)[(object)val2];
			T1 val4 = (T1)((string)val3).Trim().Replace(" ", "").Replace("@", ":");
			T0 val5 = (T0)(((IEnumerable<T1>)(object)((string)val4).Split((char[])(object)new T6[1] { (T6)58 })).Count() == 2);
			if (val5 != null)
			{
				frmMain.proxySetting.listProxy.Add(new ProxySocksEntity
				{
					IP = (string)((IEnumerable<T1>)(object)((string)val4).Split((char[])(object)new T6[1] { (T6)58 })).First(),
					Port = (string)((IEnumerable<T1>)(object)((string)val4).Split((char[])(object)new T6[1] { (T6)58 })).Last(),
					Username = "",
					Password = "",
					Status = frmMain.STATUS.Ready.ToString()
				});
			}
			else
			{
				T0 val6 = (T0)(((IEnumerable<T1>)(object)((string)val4).Split((char[])(object)new T6[1] { (T6)58 })).Count() == 4);
				if (val6 != null)
				{
					frmMain.proxySetting.listProxy.Add(new ProxySocksEntity
					{
						Username = ((string)val4).Split((char[])(object)new T6[1] { (T6)58 })[0],
						Password = ((string)val4).Split((char[])(object)new T6[1] { (T6)58 })[1],
						IP = ((string)val4).Split((char[])(object)new T6[1] { (T6)58 })[2],
						Port = ((string)val4).Split((char[])(object)new T6[1] { (T6)58 })[3],
						Status = frmMain.STATUS.Ready.ToString()
					});
				}
			}
			val2 = (T2)(val2 + 1);
		}
		setGv<T2>();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gvProxy_MouseClick<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_000e: Expected O, but got I4
		T0 val = (T0)(((MouseEventArgs)e).Button == MouseButtons.Right);
		if (val != null)
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(ContextMenu));
			T2 item = (T2)new MenuItem("Xóa dòng", (EventHandler)removeEvent<T2, T0, List<DataGridViewRow>, int, Exception, T3, EventArgs, DataGridViewRow>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Xóa toàn bộ", (EventHandler)removeEvent<T2, T0, List<DataGridViewRow>, int, Exception, T3, EventArgs, DataGridViewRow>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			((ContextMenu)val2).Show((Control)gvProxy, new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void removeEvent<T0, T1, T2, T3, T4, T5, T6, T7>(T5 sender, T6 e)
	{
		//IL_0019: Expected O, but got I4
		//IL_0087: Expected O, but got I4
		//IL_0094: Expected O, but got I4
		//IL_009e: Expected O, but got I4
		//IL_00bb: Expected I4, but got O
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		T0 val = (T0)sender;
		T1 val2 = (T1)((MenuItem)val).Text.Equals("Xóa dòng");
		if (val2 != null)
		{
			T2 val3 = (T2)gvProxy.SelectedRows.Cast<T7>().Where((Func<T7, bool>)(object)(Func<DataGridViewRow, bool>)((T7 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T7, T3>)(object)(Func<DataGridViewRow, int>)((T7 row) => (T3)((DataGridViewBand)row).Index))
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
					try
					{
						frmMain.proxySetting.listProxy.RemoveAt(((List<DataGridViewRow>)val3)[(int)val5].Index);
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.Message);
					}
					val5 = (T3)(val5 - 1);
				}
			}
		}
		else
		{
			frmMain.proxySetting.listProxy.Clear();
		}
		setGv<T3>();
	}

	private void rbProxy_CheckedChanged<T0, T1>(T0 sender, T1 e)
	{
		frmMain.proxySetting.isProxy = rbProxy.Checked;
	}

	private void rbSocks_CheckedChanged<T0, T1>(T0 sender, T1 e)
	{
		frmMain.proxySetting.isProxy = rbProxy.Checked;
	}

	private void cbRandom_CheckedChanged<T0, T1>(T0 sender, T1 e)
	{
		frmMain.proxySetting.isRandom = cbRandom.Checked;
	}

	private void frmProxyImport_Load<T0, T1>(T0 sender, T1 e)
	{
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
	private void InitializeComponent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>()
	{
		T0 val = (T0)new System.ComponentModel.ComponentResourceManager(typeof(ADSPRoject.frmProxyImport));
		this.gvProxy = (System.Windows.Forms.DataGridView)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridView));
		this.txtProxy = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label1 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.button1 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.button2 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.numDelay = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.numThread = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label2 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.label3 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.rbProxy = (System.Windows.Forms.RadioButton)System.Activator.CreateInstance(typeof(System.Windows.Forms.RadioButton));
		this.rbSocks = (System.Windows.Forms.RadioButton)System.Activator.CreateInstance(typeof(System.Windows.Forms.RadioButton));
		this.button3 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.lbTotal = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.cbRandom = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		((System.ComponentModel.ISupportInitialize)this.gvProxy).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numDelay).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numThread).BeginInit();
		base.SuspendLayout();
		this.gvProxy.AllowUserToAddRows = false;
		this.gvProxy.AllowUserToDeleteRows = false;
		this.gvProxy.AllowUserToOrderColumns = true;
		this.gvProxy.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gvProxy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		this.gvProxy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.gvProxy.Location = new System.Drawing.Point(12, 179);
		this.gvProxy.Name = "gvProxy";
		this.gvProxy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.gvProxy.Size = new System.Drawing.Size(625, 197);
		this.gvProxy.TabIndex = 0;
		this.gvProxy.MouseClick += new System.Windows.Forms.MouseEventHandler(gvProxy_MouseClick<T8, T9, T10, T11, T12>);
		this.txtProxy.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtProxy.Location = new System.Drawing.Point(12, 25);
		this.txtProxy.MaxLength = 999999999;
		this.txtProxy.Multiline = true;
		this.txtProxy.Name = "txtProxy";
		this.txtProxy.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		this.txtProxy.Size = new System.Drawing.Size(408, 148);
		this.txtProxy.TabIndex = 1;
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(12, 9);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(298, 13);
		this.label1.TabIndex = 2;
		this.label1.Text = "Danh sách proxy (IP:Port hoặc Username:Password@IP:Port)";
		this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.button1.Location = new System.Drawing.Point(429, 25);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(101, 63);
		this.button1.TabIndex = 3;
		this.button1.Text = "Thêm Toàn Bộ";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click<T8, T13, T14, T11, T15, T16, T17>);
		this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.button2.Location = new System.Drawing.Point(429, 94);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(101, 53);
		this.button2.TabIndex = 4;
		this.button2.Text = "Check Live";
		this.button2.UseVisualStyleBackColor = true;
		this.numDelay.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.numDelay.Location = new System.Drawing.Point(579, 153);
		this.numDelay.Name = "numDelay";
		this.numDelay.Size = new System.Drawing.Size(58, 20);
		this.numDelay.TabIndex = 5;
		this.numDelay.ValueChanged += new System.EventHandler(numDelay_ValueChanged<T18, T11, T15>);
		this.numThread.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.numThread.Location = new System.Drawing.Point(472, 153);
		this.numThread.Name = "numThread";
		this.numThread.Size = new System.Drawing.Size(58, 20);
		this.numThread.TabIndex = 6;
		this.numThread.ValueChanged += new System.EventHandler(numThread_ValueChanged<T18, T11, T15>);
		this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(426, 155);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(40, 13);
		this.label2.TabIndex = 7;
		this.label2.Text = "Luồng:";
		this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(536, 155);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(37, 13);
		this.label3.TabIndex = 8;
		this.label3.Text = "Delay:";
		this.rbProxy.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.rbProxy.AutoSize = true;
		this.rbProxy.Checked = true;
		this.rbProxy.Location = new System.Drawing.Point(412, 382);
		this.rbProxy.Name = "rbProxy";
		this.rbProxy.Size = new System.Drawing.Size(51, 17);
		this.rbProxy.TabIndex = 9;
		this.rbProxy.TabStop = true;
		this.rbProxy.Text = "Proxy";
		this.rbProxy.UseVisualStyleBackColor = true;
		this.rbProxy.CheckedChanged += new System.EventHandler(rbProxy_CheckedChanged);
		this.rbSocks.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.rbSocks.AutoSize = true;
		this.rbSocks.Location = new System.Drawing.Point(469, 382);
		this.rbSocks.Name = "rbSocks";
		this.rbSocks.Size = new System.Drawing.Size(61, 17);
		this.rbSocks.TabIndex = 10;
		this.rbSocks.Text = "Socks5";
		this.rbSocks.UseVisualStyleBackColor = true;
		this.rbSocks.CheckedChanged += new System.EventHandler(rbSocks_CheckedChanged);
		this.button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.button3.Location = new System.Drawing.Point(536, 382);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(101, 41);
		this.button3.TabIndex = 11;
		this.button3.Text = "Gán Proxy";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(button3_Click);
		this.lbTotal.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.lbTotal.AutoSize = true;
		this.lbTotal.Location = new System.Drawing.Point(12, 384);
		this.lbTotal.Name = "lbTotal";
		this.lbTotal.Size = new System.Drawing.Size(13, 13);
		this.lbTotal.TabIndex = 12;
		this.lbTotal.Text = "0";
		this.cbRandom.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.cbRandom.AutoSize = true;
		this.cbRandom.Location = new System.Drawing.Point(412, 405);
		this.cbRandom.Name = "cbRandom";
		this.cbRandom.Size = new System.Drawing.Size(66, 17);
		this.cbRandom.TabIndex = 13;
		this.cbRandom.Text = "Random";
		this.cbRandom.UseVisualStyleBackColor = true;
		this.cbRandom.CheckedChanged += new System.EventHandler(cbRandom_CheckedChanged);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(649, 435);
		base.Controls.Add(this.cbRandom);
		base.Controls.Add(this.lbTotal);
		base.Controls.Add(this.button3);
		base.Controls.Add(this.rbSocks);
		base.Controls.Add(this.rbProxy);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.numThread);
		base.Controls.Add(this.numDelay);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.txtProxy);
		base.Controls.Add(this.gvProxy);
		base.Icon = (System.Drawing.Icon)(T19)((System.Resources.ResourceManager)val).GetObject("$this.Icon");
		base.Name = "frmProxyImport";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Proxy - Socks Import";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(frmProxyImport_FormClosing);
		base.Load += new System.EventHandler(frmProxyImport_Load);
		((System.ComponentModel.ISupportInitialize)this.gvProxy).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numDelay).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numThread).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
