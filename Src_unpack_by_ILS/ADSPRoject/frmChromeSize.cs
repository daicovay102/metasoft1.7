using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ADSPRoject.Data;

namespace ADSPRoject;

public class frmChromeSize : Form
{
	private frmMain frmMain;

	private IContainer components = null;

	private TextBox txtName;

	private Label label1;

	private Label label2;

	private TextBox txtSize;

	private Button button1;

	private DataGridView gvData;

	public frmChromeSize(frmMain frm)
	{
		InitializeComponent<ComponentResourceManager, TextBox, Label, Button, DataGridView, object, EventArgs, bool, ContextMenu, MenuItem, MouseEventArgs, Icon>();
		frmMain = frm;
	}

	public void setDefault()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gvData_MouseClick<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_000e: Expected O, but got I4
		T0 val = (T0)(((MouseEventArgs)e).Button == MouseButtons.Right);
		if (val != null)
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(ContextMenu));
			T2 item = (T2)new MenuItem("Delete", (EventHandler)deleteEvent<int, T0, T3, EventArgs>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			((ContextMenu)val2).Show((Control)gvData, new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y));
		}
	}

	private void deleteEvent<T0, T1, T2, T3>(T2 sender, T3 e)
	{
		//IL_0013: Expected O, but got I4
		//IL_0018: Expected O, but got I4
		//IL_001d: Expected O, but got I4
		//IL_003b: Expected I4, but got O
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_004e: Expected O, but got I4
		T0 val = (T0)gvData.Rows.GetRowCount(DataGridViewElementStates.Selected);
		T1 val2 = (T1)((nint)val > 0);
		if (val2 != null)
		{
			T0 val3 = (T0)0;
			while (true)
			{
				T1 val4 = (T1)(val3 < val);
				if (val4 == null)
				{
					break;
				}
				frmMain.chromeSize.RemoveAt(gvData.SelectedRows[(int)val3].Index);
				val3 = (T0)(val3 + 1);
			}
		}
		loadChromeSize();
	}

	private void frmChromeSize_Load<T0, T1>(T0 sender, T1 e)
	{
		loadChromeSize();
	}

	private void loadChromeSize()
	{
		gvData.DataSource = null;
		gvData.DataSource = frmMain.chromeSize;
	}

	private void button1_Click<T0, T1>(T0 sender, T1 e)
	{
		frmMain.chromeSize.Add(new ChromeSizeEntity
		{
			Name = txtName.Text,
			Size = txtSize.Text
		});
		frmMain.chromeSizeSaving<Exception>();
		loadChromeSize();
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
	private void InitializeComponent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
	{
		T0 val = (T0)new System.ComponentModel.ComponentResourceManager(typeof(ADSPRoject.frmChromeSize));
		this.txtName = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label1 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.label2 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtSize = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.button1 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.gvData = (System.Windows.Forms.DataGridView)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridView));
		((System.ComponentModel.ISupportInitialize)this.gvData).BeginInit();
		base.SuspendLayout();
		this.txtName.Location = new System.Drawing.Point(69, 12);
		this.txtName.Name = "txtName";
		this.txtName.Size = new System.Drawing.Size(235, 20);
		this.txtName.TabIndex = 0;
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(14, 15);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(49, 13);
		this.label1.TabIndex = 1;
		this.label1.Text = "Name: ";
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(323, 15);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(40, 13);
		this.label2.TabIndex = 3;
		this.label2.Text = "Size: ";
		this.txtSize.Location = new System.Drawing.Point(369, 12);
		this.txtSize.Name = "txtSize";
		this.txtSize.Size = new System.Drawing.Size(235, 20);
		this.txtSize.TabIndex = 2;
		this.button1.Location = new System.Drawing.Point(611, 10);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(87, 23);
		this.button1.TabIndex = 4;
		this.button1.Text = "Save";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.gvData.AllowUserToAddRows = false;
		this.gvData.AllowUserToDeleteRows = false;
		this.gvData.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		this.gvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.gvData.Location = new System.Drawing.Point(14, 38);
		this.gvData.Name = "gvData";
		this.gvData.ReadOnly = true;
		this.gvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.gvData.Size = new System.Drawing.Size(685, 411);
		this.gvData.TabIndex = 5;
		this.gvData.MouseClick += new System.Windows.Forms.MouseEventHandler(gvData_MouseClick<T7, T8, T9, T5, T10>);
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(713, 461);
		base.Controls.Add(this.gvData);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.txtSize);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.txtName);
		this.Font = new System.Drawing.Font("Verdana", 8f);
		base.Icon = (System.Drawing.Icon)(T11)((System.Resources.ResourceManager)val).GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmChromeSize";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Chrome Size";
		base.Load += new System.EventHandler(frmChromeSize_Load);
		((System.ComponentModel.ISupportInitialize)this.gvData).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
