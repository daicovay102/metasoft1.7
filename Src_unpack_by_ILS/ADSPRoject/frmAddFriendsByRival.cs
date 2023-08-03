using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Data;

namespace ADSPRoject;

public class frmAddFriendsByRival : Form
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public List<string> listUIDSelected;

		internal T0 _003C_002Ector_003Eb__0<T0>(FBEntity a)
		{
			//IL_0012: Expected O, but got I4
			return (T0)listUIDSelected.Contains(a.UID);
		}
	}

	private List<FBEntity> listFBEntity = (List<FBEntity>)Activator.CreateInstance(typeof(List<FBEntity>));

	private List<string> listUIDSelected;

	private frmMain frmMain;

	private IContainer components = null;

	private DataGridView gvData;

	private Button button1;

	private Button button2;

	private OpenFileDialog openFileDialog1;

	private DataGridViewTextBoxColumn clUID;

	private DataGridViewTextBoxColumn clName;

	private DataGridViewTextBoxColumn clRivalLink;

	private DataGridViewTextBoxColumn clNote;

	public frmAddFriendsByRival(frmMain frmMain, List<string> listUIDSelected)
	{
		_003C_003Ec__DisplayClass3_0 _003C_003Ec__DisplayClass3_ = new _003C_003Ec__DisplayClass3_0();
		_003C_003Ec__DisplayClass3_.listUIDSelected = listUIDSelected;
		base._002Ector();
		InitializeComponent<ComponentResourceManager, DataGridView, DataGridViewTextBoxColumn, Button, OpenFileDialog, DataGridViewColumn, bool, string, StreamReader, int, object, EventArgs, List<string>, Icon>();
		this.frmMain = frmMain;
		this.listUIDSelected = _003C_003Ec__DisplayClass3_.listUIDSelected;
		gvData.AutoGenerateColumns = false;
		listFBEntity = frmMain.listFBEntity.Where(_003C_003Ec__DisplayClass3_._003C_002Ector_003Eb__0<bool>).ToList();
		gvData.DataSource = listFBEntity;
	}

	private void frmAddFriendsByRival_Load<T0, T1>(T0 sender, T1 e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void button1_Click<T0, T1, T2, T3, T4, T5>(T4 sender, T5 e)
	{
		//IL_0020: Expected O, but got I4
		//IL_003c: Expected O, but got I4
		//IL_0050: Expected I4, but got O
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_0086: Expected O, but got I4
		//IL_009a: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_00b8: Expected I4, but got O
		//IL_00d9: Expected O, but got I4
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		//IL_00f9: Expected O, but got I4
		//IL_0117: Expected O, but got I4
		//IL_013a: Expected I4, but got O
		//IL_0162: Expected O, but got I4
		openFileDialog1.Filter = "txt files (*.txt)|*.txt";
		T0 val = (T0)(openFileDialog1.ShowDialog() == DialogResult.OK);
		if (val == null)
		{
			return;
		}
		T1 fileName = (T1)openFileDialog1.FileName;
		T2 val2 = (T2)new StreamReader((string)fileName);
		T3 val3 = (T3)0;
		while (true)
		{
			T0 val4 = (T0)((nint)val3 < gvData.Rows.Count);
			if (val4 != null)
			{
				gvData.Rows[(int)val3].Cells["clRivalLink"].Value = "";
				val3 = (T3)(val3 + 1);
				continue;
			}
			break;
		}
		while (true)
		{
			T1 val5;
			T0 val6 = (T0)((val5 = (T1)((TextReader)val2).ReadLine()) != null);
			if (val6 == null)
			{
				break;
			}
			T0 val7 = (T0)(!string.IsNullOrWhiteSpace((string)val5));
			if (val7 == null)
			{
				continue;
			}
			T3 val8 = (T3)0;
			while (true)
			{
				T0 val9 = (T0)((nint)val8 < gvData.Rows.Count);
				if (val9 == null)
				{
					break;
				}
				T0 val10 = (T0)string.IsNullOrWhiteSpace(gvData.Rows[(int)val8].Cells["clRivalLink"].Value.ToString());
				if (val10 == null)
				{
					val8 = (T3)(val8 + 1);
					continue;
				}
				val5 = (T1)((string)val5).Trim();
				T0 val11 = (T0)(!((string)val5).StartsWith("http"));
				if (val11 != null)
				{
					val5 = (T1)("https://" + (string)val5);
				}
				gvData.Rows[(int)val8].Cells["clRivalLink"].Value = ((string)val5).Trim();
				break;
			}
		}
		((TextReader)val2).Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void button2_Click<T0, T1, T2, T3, T4, T5, T6>(T5 sender, T6 e)
	{
		//IL_0020: Expected O, but got I4
		//IL_003c: Expected O, but got I4
		//IL_0050: Expected I4, but got O
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_0086: Expected O, but got I4
		//IL_00a8: Expected O, but got I4
		//IL_00c4: Expected O, but got I4
		//IL_00ea: Expected O, but got I4
		//IL_0100: Expected O, but got I4
		//IL_010a: Expected O, but got I4
		//IL_010d: Expected O, but got I4
		//IL_0124: Expected I4, but got O
		//IL_0145: Expected O, but got I4
		//IL_015b: Expected I4, but got O
		//IL_0174: Expected I4, but got O
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		//IL_018f: Expected O, but got I4
		//IL_0196: Expected O, but got I4
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01b2: Expected O, but got I4
		openFileDialog1.Filter = "txt files (*.txt)|*.txt";
		T0 val = (T0)(openFileDialog1.ShowDialog() == DialogResult.OK);
		if (val == null)
		{
			return;
		}
		T1 fileName = (T1)openFileDialog1.FileName;
		T2 val2 = (T2)new StreamReader((string)fileName);
		T4 val3 = (T4)0;
		while (true)
		{
			T0 val4 = (T0)((nint)val3 < gvData.Rows.Count);
			if (val4 == null)
			{
				break;
			}
			gvData.Rows[(int)val3].Cells["clRivalLink"].Value = "";
			val3 = (T4)(val3 + 1);
		}
		T3 val5 = (T3)Activator.CreateInstance(typeof(T3));
		while (true)
		{
			T1 val6;
			T0 val7 = (T0)((val6 = (T1)((TextReader)val2).ReadLine()) != null);
			if (val7 == null)
			{
				break;
			}
			T0 val8 = (T0)(!string.IsNullOrWhiteSpace((string)val6));
			if (val8 != null)
			{
				val6 = (T1)((string)val6).Trim();
				T0 val9 = (T0)(!((string)val6).StartsWith("http"));
				if (val9 != null)
				{
					val6 = (T1)("https://" + (string)val6);
				}
				((List<string>)val5).Add((string)val6);
			}
		}
		((TextReader)val2).Close();
		T0 val10 = (T0)(((List<string>)val5).Count > 0);
		if (val10 == null)
		{
			return;
		}
		T4 val11 = (T4)0;
		T4 val12 = (T4)0;
		while (true)
		{
			T0 val13 = (T0)((nint)val12 < gvData.Rows.Count);
			if (val13 == null)
			{
				break;
			}
			T0 val14 = (T0)string.IsNullOrWhiteSpace(gvData.Rows[(int)val12].Cells["clRivalLink"].Value.ToString());
			if (val14 != null)
			{
				gvData.Rows[(int)val12].Cells["clRivalLink"].Value = ((List<string>)val5)[(int)val11];
				val11 = (T4)(val11 + 1);
				T0 val15 = (T0)((nint)val11 >= ((List<string>)val5).Count);
				if (val15 != null)
				{
					val11 = (T4)0;
				}
			}
			val12 = (T4)(val12 + 1);
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
	private void InitializeComponent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
	{
		T0 val = (T0)new System.ComponentModel.ComponentResourceManager(typeof(ADSPRoject.frmAddFriendsByRival));
		this.gvData = (System.Windows.Forms.DataGridView)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridView));
		this.clUID = (System.Windows.Forms.DataGridViewTextBoxColumn)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridViewTextBoxColumn));
		this.clName = (System.Windows.Forms.DataGridViewTextBoxColumn)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridViewTextBoxColumn));
		this.clRivalLink = (System.Windows.Forms.DataGridViewTextBoxColumn)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridViewTextBoxColumn));
		this.clNote = (System.Windows.Forms.DataGridViewTextBoxColumn)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridViewTextBoxColumn));
		this.button1 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.button2 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.openFileDialog1 = (System.Windows.Forms.OpenFileDialog)System.Activator.CreateInstance(typeof(System.Windows.Forms.OpenFileDialog));
		((System.ComponentModel.ISupportInitialize)this.gvData).BeginInit();
		base.SuspendLayout();
		this.gvData.AllowUserToAddRows = false;
		this.gvData.AllowUserToDeleteRows = false;
		this.gvData.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		this.gvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.gvData.Columns.AddRange((System.Windows.Forms.DataGridViewColumn[])(object)new T5[4]
		{
			(T5)this.clUID,
			(T5)this.clName,
			(T5)this.clRivalLink,
			(T5)this.clNote
		});
		this.gvData.Location = new System.Drawing.Point(0, 41);
		this.gvData.Name = "gvData";
		this.gvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.gvData.Size = new System.Drawing.Size(930, 353);
		this.gvData.TabIndex = 1;
		this.clUID.DataPropertyName = "UID";
		this.clUID.HeaderText = "UID";
		this.clUID.Name = "clUID";
		this.clName.DataPropertyName = "Name";
		this.clName.HeaderText = "Name";
		this.clName.Name = "clName";
		this.clRivalLink.DataPropertyName = "RivalLink";
		this.clRivalLink.HeaderText = "RivalLink";
		this.clRivalLink.Name = "clRivalLink";
		this.clNote.DataPropertyName = "Note";
		this.clNote.HeaderText = "Note";
		this.clNote.Name = "clNote";
		this.button1.Location = new System.Drawing.Point(14, 12);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(127, 23);
		this.button1.TabIndex = 3;
		this.button1.Text = "Nhập link 1-1";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click<T6, T7, T8, T9, T10, T11>);
		this.button2.Location = new System.Drawing.Point(148, 12);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(170, 23);
		this.button2.TabIndex = 4;
		this.button2.Text = "Nhập link chia đều các tk";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click<T6, T7, T8, T12, T9, T10, T11>);
		this.openFileDialog1.FileName = "openFileDialog1";
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(930, 396);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.gvData);
		this.Font = new System.Drawing.Font("Verdana", 8f);
		base.Icon = (System.Drawing.Icon)(T13)((System.Resources.ResourceManager)val).GetObject("$this.Icon");
		base.Name = "frmAddFriendsByRival";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Add friends by rival";
		base.Load += new System.EventHandler(frmAddFriendsByRival_Load);
		((System.ComponentModel.ISupportInitialize)this.gvData).EndInit();
		base.ResumeLayout(false);
	}
}
