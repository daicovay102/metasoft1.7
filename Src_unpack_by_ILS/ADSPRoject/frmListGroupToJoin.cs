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

public class frmListGroupToJoin : Form
{
	public enum STATUS
	{
		Ready,
		Processing,
		Joined,
		lỗi
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<DataGridViewRow, bool> _003C_003E9__4_0;

		public static Func<DataGridViewRow, int> _003C_003E9__4_1;

		public static Func<DataGridViewRow, bool> _003C_003E9__5_0;

		public static Func<DataGridViewRow, int> _003C_003E9__5_1;

		public static Func<DataGridViewRow, bool> _003C_003E9__6_0;

		public static Func<DataGridViewRow, int> _003C_003E9__6_1;

		public static Func<DataGridViewRow, bool> _003C_003E9__7_0;

		public static Func<DataGridViewRow, int> _003C_003E9__7_1;

		public static Func<ListGroupEntity, bool> _003C_003E9__9_0;

		public static Func<ListGroupEntity, bool> _003C_003E9__9_1;

		public static Func<ListGroupEntity, bool> _003C_003E9__9_2;

		internal T0 _003CstatusReadyEvent_003Eb__4_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CstatusReadyEvent_003Eb__4_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CstatuslỗiEvent_003Eb__5_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CstatuslỗiEvent_003Eb__5_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CstatusJoinedEvent_003Eb__6_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CstatusJoinedEvent_003Eb__6_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CdeleteEvent_003Eb__7_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CdeleteEvent_003Eb__7_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CloadGridview_003Eb__9_0<T0>(ListGroupEntity a)
		{
			//IL_001b: Expected O, but got I4
			return (T0)a.Status.Equals(STATUS.Ready.ToString());
		}

		internal T0 _003CloadGridview_003Eb__9_1<T0>(ListGroupEntity a)
		{
			//IL_001b: Expected O, but got I4
			return (T0)a.Status.Equals(STATUS.Joined.ToString());
		}

		internal T0 _003CloadGridview_003Eb__9_2<T0>(ListGroupEntity a)
		{
			//IL_001b: Expected O, but got I4
			return (T0)a.Status.Equals(STATUS.lỗi.ToString());
		}
	}

	private frmMain frmMain;

	private IContainer components = null;

	private DataGridView gvData;

	private TextBox txtSearch;

	private Button button5;

	private StatusStrip statusStrip1;

	private ToolStripStatusLabel toolStripStatusLabel2;

	private ToolStripStatusLabel lbTotal;

	private ToolStripStatusLabel toolStripStatusLabel4;

	private ToolStripStatusLabel lbReady;

	private ToolStripStatusLabel toolStripStatusLabel1;

	private ToolStripStatusLabel lbJoined;

	private ToolStripStatusLabel toolStripStatusLabel3;

	private ToolStripStatusLabel lblỗi;

	public frmListGroupToJoin(frmMain frm)
	{
		InitializeComponent<ComponentResourceManager, DataGridView, TextBox, Button, StatusStrip, ToolStripStatusLabel, bool, ContextMenu, MenuItem, object, MouseEventArgs, string, int, EventArgs, ToolStripItem, Icon>();
		frmMain = frm;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gvData_MouseClick<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_000e: Expected O, but got I4
		T0 val = (T0)(((MouseEventArgs)e).Button == MouseButtons.Right);
		if (val != null)
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(ContextMenu));
			T2 item = (T2)new MenuItem("Paste Group ID", (EventHandler)pasteGroupIdEvent<string, int, T0, T3, EventArgs>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Delete", (EventHandler)deleteEvent<T0, List<DataGridViewRow>, int, T3, EventArgs, DataGridViewRow>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			T2 val3 = (T2)new MenuItem("Status");
			item = (T2)new MenuItem(STATUS.Ready.ToString(), (EventHandler)statusReadyEvent<List<DataGridViewRow>, int, T0, T3, EventArgs, DataGridViewRow>);
			((Menu)val3).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem(STATUS.Joined.ToString(), (EventHandler)statusJoinedEvent<List<DataGridViewRow>, int, T0, T3, EventArgs, DataGridViewRow>);
			((Menu)val3).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem(STATUS.lỗi.ToString(), (EventHandler)statuslỗiEvent<List<DataGridViewRow>, int, T0, T3, EventArgs, DataGridViewRow>);
			((Menu)val3).MenuItems.Add((MenuItem)item);
			((Menu)val2).MenuItems.Add((MenuItem)val3);
			((ContextMenu)val2).Show((Control)gvData, new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void statusReadyEvent<T0, T1, T2, T3, T4, T5>(T3 sender, T4 e)
	{
		//IL_0067: Expected O, but got I4
		//IL_007b: Expected I4, but got O
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_00a5: Expected O, but got I4
		T0 val = (T0)gvData.SelectedRows.Cast<T5>().Where((Func<T5, bool>)(object)(Func<DataGridViewRow, bool>)((T5 row) => (T2)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T5, T1>)(object)(Func<DataGridViewRow, int>)((T5 row) => (T1)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count - 1);
		while (true)
		{
			T2 val3 = (T2)((nint)val2 >= 0);
			if (val3 == null)
			{
				break;
			}
			frmMain.listGroupEntity[((List<DataGridViewRow>)val)[(int)val2].Index].Status = STATUS.Ready.ToString();
			val2 = (T1)(val2 - 1);
		}
		frmMain.saveListGroupId();
		loadGridview<T1>();
		frmMain.infoMessage("Done");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void statuslỗiEvent<T0, T1, T2, T3, T4, T5>(T3 sender, T4 e)
	{
		//IL_0067: Expected O, but got I4
		//IL_007b: Expected I4, but got O
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_00a5: Expected O, but got I4
		T0 val = (T0)gvData.SelectedRows.Cast<T5>().Where((Func<T5, bool>)(object)(Func<DataGridViewRow, bool>)((T5 row) => (T2)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T5, T1>)(object)(Func<DataGridViewRow, int>)((T5 row) => (T1)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count - 1);
		while (true)
		{
			T2 val3 = (T2)((nint)val2 >= 0);
			if (val3 == null)
			{
				break;
			}
			frmMain.listGroupEntity[((List<DataGridViewRow>)val)[(int)val2].Index].Status = STATUS.lỗi.ToString();
			val2 = (T1)(val2 - 1);
		}
		frmMain.saveListGroupId();
		loadGridview<T1>();
		frmMain.infoMessage("Done");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void statusJoinedEvent<T0, T1, T2, T3, T4, T5>(T3 sender, T4 e)
	{
		//IL_0067: Expected O, but got I4
		//IL_007b: Expected I4, but got O
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_00a5: Expected O, but got I4
		T0 val = (T0)gvData.SelectedRows.Cast<T5>().Where((Func<T5, bool>)(object)(Func<DataGridViewRow, bool>)((T5 row) => (T2)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T5, T1>)(object)(Func<DataGridViewRow, int>)((T5 row) => (T1)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count - 1);
		while (true)
		{
			T2 val3 = (T2)((nint)val2 >= 0);
			if (val3 == null)
			{
				break;
			}
			frmMain.listGroupEntity[((List<DataGridViewRow>)val)[(int)val2].Index].Status = STATUS.Joined.ToString();
			val2 = (T1)(val2 - 1);
		}
		frmMain.saveListGroupId();
		loadGridview<T1>();
		frmMain.infoMessage("Done");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void deleteEvent<T0, T1, T2, T3, T4, T5>(T3 sender, T4 e)
	{
		//IL_000f: Expected O, but got I4
		//IL_007c: Expected O, but got I4
		//IL_0090: Expected I4, but got O
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00a6: Expected O, but got I4
		T0 val = (T0)(frmMain.questioniMessage<DialogResult, string>("Are you sure?") == DialogResult.Yes);
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
			frmMain.listGroupEntity.RemoveAt(((List<DataGridViewRow>)val2)[(int)val3].Index);
			val3 = (T2)(val3 - 1);
		}
		frmMain.saveListGroupId();
		loadGridview<T2>();
		frmMain.infoMessage("Done");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pasteGroupIdEvent<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_001d: Expected O, but got I4
		//IL_0030: Expected O, but got I4
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		T0 val = (T0)Clipboard.GetText();
		T0[] array = (T0[])(object)((string)val).Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
		T0[] array2 = array;
		T1 val2 = (T1)0;
		while ((nint)val2 < array2.Length)
		{
			T0 val3 = (T0)((object[])(object)array2)[(object)val2];
			T2 val4 = (T2)(!string.IsNullOrWhiteSpace((string)val3));
			if (val4 != null)
			{
				frmMain.listGroupEntity.Add(new ListGroupEntity
				{
					UID = "",
					GroupId = ((string)val3).Trim(),
					Status = STATUS.Ready.ToString()
				});
			}
			val2 = (T1)(val2 + 1);
		}
		frmMain.saveListGroupId();
		loadGridview<T1>();
		frmMain.infoMessage((T0)"Done");
	}

	private void loadGridview<T0>()
	{
		//IL_0039: Expected O, but got I4
		//IL_0080: Expected O, but got I4
		//IL_00c7: Expected O, but got I4
		//IL_010e: Expected O, but got I4
		gvData.DataSource = null;
		gvData.DataSource = frmMain.listGroupEntity;
		lbTotal.Text = System.Runtime.CompilerServices.Unsafe.As<T0, int>(ref (T0)frmMain.listGroupEntity.Count).ToString();
		lbReady.Text = System.Runtime.CompilerServices.Unsafe.As<T0, int>(ref (T0)frmMain.listGroupEntity.Where(_003C_003Ec._003C_003E9._003CloadGridview_003Eb__9_0<bool>).Count()).ToString();
		lbJoined.Text = System.Runtime.CompilerServices.Unsafe.As<T0, int>(ref (T0)frmMain.listGroupEntity.Where(_003C_003Ec._003C_003E9._003CloadGridview_003Eb__9_1<bool>).Count()).ToString();
		lblỗi.Text = System.Runtime.CompilerServices.Unsafe.As<T0, int>(ref (T0)frmMain.listGroupEntity.Where(_003C_003Ec._003C_003E9._003CloadGridview_003Eb__9_2<bool>).Count()).ToString();
	}

	private void frmListGroupToJoin_Load<T0, T1, T2>(T0 sender, T1 e)
	{
		loadGridview<T2>();
	}

	private void button5_Click<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_001e: Expected O, but got I4
		//IL_0034: Expected I4, but got O
		//IL_0057: Expected I4, but got O
		//IL_007a: Expected I4, but got O
		//IL_008e: Expected O, but got I4
		//IL_00a2: Expected I4, but got O
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_00c0: Expected O, but got I4
		T0 value = (T0)txtSearch.Text.ToLower();
		gvData.ClearSelection();
		T1 val = (T1)0;
		while (true)
		{
			T2 val2 = (T2)((nint)val < frmMain.listGroupEntity.Count);
			if (val2 != null)
			{
				T2 val3 = (T2)(frmMain.listGroupEntity[(int)val].UID.ToLower().Contains((string)value) || frmMain.listGroupEntity[(int)val].GroupId.ToLower().Contains((string)value) || frmMain.listGroupEntity[(int)val].Status.ToLower().Contains((string)value));
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
	private void InitializeComponent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
	{
		T0 val = (T0)new System.ComponentModel.ComponentResourceManager(typeof(ADSPRoject.frmListGroupToJoin));
		this.gvData = (System.Windows.Forms.DataGridView)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridView));
		this.txtSearch = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.button5 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.statusStrip1 = (System.Windows.Forms.StatusStrip)System.Activator.CreateInstance(typeof(System.Windows.Forms.StatusStrip));
		this.toolStripStatusLabel2 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.lbTotal = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.toolStripStatusLabel4 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.lbReady = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.toolStripStatusLabel1 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.lbJoined = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.toolStripStatusLabel3 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.lblỗi = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		((System.ComponentModel.ISupportInitialize)this.gvData).BeginInit();
		this.statusStrip1.SuspendLayout();
		base.SuspendLayout();
		this.gvData.AllowUserToAddRows = false;
		this.gvData.AllowUserToDeleteRows = false;
		this.gvData.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		this.gvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.gvData.Location = new System.Drawing.Point(12, 34);
		this.gvData.Name = "gvData";
		this.gvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.gvData.Size = new System.Drawing.Size(909, 396);
		this.gvData.TabIndex = 1;
		this.gvData.MouseClick += new System.Windows.Forms.MouseEventHandler(gvData_MouseClick<T6, T7, T8, T9, T10>);
		this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtSearch.Location = new System.Drawing.Point(12, 10);
		this.txtSearch.Name = "txtSearch";
		this.txtSearch.Size = new System.Drawing.Size(831, 20);
		this.txtSearch.TabIndex = 44;
		this.button5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.button5.Location = new System.Drawing.Point(849, 7);
		this.button5.Name = "button5";
		this.button5.Size = new System.Drawing.Size(72, 23);
		this.button5.TabIndex = 45;
		this.button5.Text = "⊙⊙⊙";
		this.button5.UseVisualStyleBackColor = true;
		this.button5.Click += new System.EventHandler(button5_Click<T11, T12, T6, T9, T13>);
		this.statusStrip1.Items.AddRange((System.Windows.Forms.ToolStripItem[])(object)new T14[8]
		{
			(T14)this.toolStripStatusLabel2,
			(T14)this.lbTotal,
			(T14)this.toolStripStatusLabel4,
			(T14)this.lbReady,
			(T14)this.toolStripStatusLabel1,
			(T14)this.lbJoined,
			(T14)this.toolStripStatusLabel3,
			(T14)this.lblỗi
		});
		this.statusStrip1.Location = new System.Drawing.Point(0, 428);
		this.statusStrip1.Name = "statusStrip1";
		this.statusStrip1.Size = new System.Drawing.Size(933, 22);
		this.statusStrip1.TabIndex = 46;
		this.statusStrip1.Text = "statusStrip1";
		this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
		this.toolStripStatusLabel2.Size = new System.Drawing.Size(35, 17);
		this.toolStripStatusLabel2.Text = "Total:";
		this.lbTotal.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.lbTotal.Name = "lbTotal";
		this.lbTotal.Size = new System.Drawing.Size(14, 17);
		this.lbTotal.Text = "0";
		this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
		this.toolStripStatusLabel4.Size = new System.Drawing.Size(42, 17);
		this.toolStripStatusLabel4.Text = "Ready:";
		this.lbReady.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.lbReady.Name = "lbReady";
		this.lbReady.Size = new System.Drawing.Size(14, 17);
		this.lbReady.Text = "0";
		this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
		this.toolStripStatusLabel1.Size = new System.Drawing.Size(44, 17);
		this.toolStripStatusLabel1.Text = "Joined:";
		this.lbJoined.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.lbJoined.Name = "lbJoined";
		this.lbJoined.Size = new System.Drawing.Size(14, 17);
		this.lbJoined.Text = "0";
		this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
		this.toolStripStatusLabel3.Size = new System.Drawing.Size(28, 17);
		this.toolStripStatusLabel3.Text = "lỗi:";
		this.lblỗi.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.lblỗi.Name = "lblỗi";
		this.lblỗi.Size = new System.Drawing.Size(14, 17);
		this.lblỗi.Text = "0";
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(933, 450);
		base.Controls.Add(this.statusStrip1);
		base.Controls.Add(this.txtSearch);
		base.Controls.Add(this.button5);
		base.Controls.Add(this.gvData);
		this.Font = new System.Drawing.Font("Verdana", 8f);
		base.Icon = (System.Drawing.Icon)(T15)((System.Resources.ResourceManager)val).GetObject("$this.Icon");
		base.Name = "frmListGroupToJoin";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Danh sách nhóm FB";
		base.Load += new System.EventHandler(frmListGroupToJoin_Load<T9, T13, T12>);
		((System.ComponentModel.ISupportInitialize)this.gvData).EndInit();
		this.statusStrip1.ResumeLayout(false);
		this.statusStrip1.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
