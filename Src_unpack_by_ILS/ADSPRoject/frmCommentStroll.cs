using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ADSPRoject;

public class frmCommentStroll : Form
{
	private frmMain frmMain;

	private IContainer components = null;

	private Button btnCancel;

	private Button btnSave;

	private Label label1;

	private FlowLayoutPanel flowLayout;

	private ComboBox ccbCateComment;

	private Button button3;

	private Button button1;

	private Button button2;

	public frmCommentStroll(frmMain main)
	{
		InitializeComponent<ComponentResourceManager, Button, Label, FlowLayoutPanel, ComboBox, object, EventArgs, string, List<CommentStroll>, List<CommentStroll>.Enumerator, bool, List<CategoryComment>.Enumerator, Panel, TextBox, NumericUpDown, CheckBox, int, Icon>();
		frmMain = main;
	}

	private void frmCommentStroll_Load<T0, T1>(T0 sender, T1 e)
	{
		loadCommbobox<List<CategoryComment>.Enumerator, bool>();
	}

	private unsafe void loadCommbobox<T0, T1>()
	{
		//IL_006a: Expected O, but got I4
		ccbCateComment.Items.Clear();
		T0 enumerator = (T0)frmMain.listCommentStroll.GetEnumerator();
		try
		{
			while (((List<CategoryComment>.Enumerator*)(&enumerator))->MoveNext())
			{
				CategoryComment current = ((List<CategoryComment>.Enumerator*)(&enumerator))->Current;
				ccbCateComment.Items.Add(current.Name);
			}
		}
		finally
		{
			((IDisposable)(*(List<CategoryComment>.Enumerator*)(&enumerator))).Dispose();
		}
		T1 val = (T1)(ccbCateComment.Items.Count > 0);
		if (val != null)
		{
			ccbCateComment.SelectedIndex = 0;
		}
	}

	private void btnCancel_Click<T0, T1>(T0 sender, T1 e)
	{
		Close();
	}

	private void btnSave_Click<T0, T1>(T0 sender, T1 e)
	{
	}

	private unsafe void ccbCateComment_SelectedIndexChanged<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		flowLayout.Controls.Clear();
		_ = frmMain.listCommentStroll[ccbCateComment.SelectedIndex].Name;
		T1 listCommentStroll = (T1)frmMain.listCommentStroll[ccbCateComment.SelectedIndex].listCommentStroll;
		T2 enumerator = (T2)((List<CommentStroll>)listCommentStroll).GetEnumerator();
		try
		{
			while (((List<CommentStroll>.Enumerator*)(&enumerator))->MoveNext())
			{
				CommentStroll current = ((List<CommentStroll>.Enumerator*)(&enumerator))->Current;
				addControlSedding<Panel, Button, TextBox, Label, NumericUpDown, CheckBox, T0, int, bool>((T0)current.Id, (T0)current.Comment, (T0)current.Media, current.numMedia, current.randomMedia);
			}
		}
		finally
		{
			((IDisposable)(*(List<CommentStroll>.Enumerator*)(&enumerator))).Dispose();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void addControlSedding<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T6 txtIdComment, T6 strComment, T6 strMedia, T7 intNumMedia, T8 random)
	{
		//IL_02f9: Expected I4, but got O
		//IL_03a0: Expected I4, but got O
		T0 val = (T0)Activator.CreateInstance(typeof(Panel));
		((Control)val).Name = "plSedding_" + (string)txtIdComment;
		((Control)val).Width = flowLayout.Width - 40;
		((Control)val).Height = 250;
		((Panel)val).BorderStyle = BorderStyle.FixedSingle;
		((Control)val).Left = 5;
		T1 val2 = (T1)Activator.CreateInstance(typeof(Button));
		((Control)val2).Name = "btnRemoveComment_" + (string)txtIdComment;
		((Control)val2).Height = 200;
		((Control)val2).Width = 50;
		((Control)val2).Text = "Xóa";
		((Control)val2).Click += btnRemoveComment_Click<T1, T6, T0, T7, T8, object, EventArgs, char, List<CategoryComment>.Enumerator>;
		((Control)val).Controls.Add((Control)val2);
		T2 val3 = (T2)Activator.CreateInstance(typeof(TextBox));
		((Control)val3).Name = "txtComment_" + (string)txtIdComment;
		((Control)val3).TextChanged += txtComment_TextChanged<T2, T6, List<CommentStroll>.Enumerator, T8, object, EventArgs, char>;
		((TextBoxBase)val3).Multiline = true;
		((Control)val3).Height = 200;
		((Control)val3).Text = (string)strComment;
		((TextBox)val3).ScrollBars = ScrollBars.Both;
		((Control)val3).Left = ((Control)val2).Left + ((Control)val2).Width;
		((Control)val3).Width = ((Control)val).Width - 50;
		((TextBoxBase)val3).MaxLength = 99999999;
		((Control)val).Controls.Add((Control)val3);
		T2 val4 = (T2)Activator.CreateInstance(typeof(TextBox));
		((Control)val4).Name = "txtMedia_" + (string)txtIdComment;
		((Control)val4).TextChanged += txtMedia__TextChanged<T2, T6, List<CommentStroll>.Enumerator, T8, object, EventArgs, char>;
		((Control)val4).Height = 25;
		((Control)val4).Text = (string)strMedia;
		((Control)val4).Left = ((Control)val2).Left + ((Control)val2).Width;
		((Control)val4).Top = ((Control)val3).Height + 5;
		((Control)val4).Width = 300;
		((TextBoxBase)val4).MaxLength = 99999999;
		((Control)val).Controls.Add((Control)val4);
		T1 val5 = (T1)Activator.CreateInstance(typeof(Button));
		((Control)val5).Name = "btnMedia_" + (string)txtIdComment;
		((Control)val5).Height = ((Control)val4).Height + 5;
		((Control)val5).Width = 50;
		((Control)val5).Top = ((Control)val3).Height + 3;
		((Control)val5).Text = "Media";
		((Control)val5).Click += btnMedia_Click<T1, T6, FolderBrowserDialog, T8, T0, T2, object, EventArgs, char>;
		((Control)val).Controls.Add((Control)val5);
		T3 val6 = (T3)Activator.CreateInstance(typeof(Label));
		((Control)val6).Name = "lbAmountMedia_" + (string)txtIdComment;
		((Control)val6).Text = "Số lượng: ";
		((Control)val6).Left = ((Control)val4).Left + ((Control)val4).Width;
		((Control)val6).Top = ((Control)val4).Top + 5;
		((Control)val6).Width = 65;
		((Control)val6).Height = ((Control)val4).Height + 5;
		((Control)val).Controls.Add((Control)val6);
		T4 val7 = (T4)Activator.CreateInstance(typeof(NumericUpDown));
		((Control)val7).Name = "numMedia_" + (string)txtIdComment;
		((NumericUpDown)val7).ValueChanged += numMedia_ValueChanged<T4, T6, List<CommentStroll>.Enumerator, T8, decimal, object, EventArgs, char>;
		((NumericUpDown)val7).Value = (int)intNumMedia;
		((NumericUpDown)val7).Minimum = 0m;
		((NumericUpDown)val7).Maximum = 99999999m;
		((Control)val7).Left = ((Control)val6).Left + ((Control)val6).Width;
		((Control)val7).Top = ((Control)val3).Height + 5;
		((Control)val7).Width = 100;
		((Control)val7).Height = ((Control)val4).Height + 5;
		((Control)val).Controls.Add((Control)val7);
		T5 val8 = (T5)Activator.CreateInstance(typeof(CheckBox));
		((Control)val8).Name = "cbMedia_" + (string)txtIdComment;
		((Control)val8).Text = "Random";
		((CheckBox)val8).Checked = (byte)(int)random != 0;
		((CheckBox)val8).CheckedChanged += cbMedia_CheckedChanged<T5, T6, List<CommentStroll>.Enumerator, T8, object, EventArgs, char>;
		((Control)val8).Left = ((Control)val7).Left + ((Control)val7).Width + 20;
		((Control)val8).Top = ((Control)val3).Height + 5;
		((Control)val8).Height = ((Control)val4).Height + 5;
		((Control)val).Controls.Add((Control)val8);
		flowLayout.Controls.Add((Control)val);
	}

	private unsafe void cbMedia_CheckedChanged<T0, T1, T2, T3, T4, T5, T6>(T4 sender, T5 e)
	{
		//IL_0059: Expected O, but got I4
		T0 val = (T0)((sender is T0) ? sender : null);
		T1 value = (T1)((Control)val).Name.Split((char[])(object)new T6[1] { (T6)95 })[1];
		T2 enumerator = (T2)frmMain.listCommentStroll[ccbCateComment.SelectedIndex].listCommentStroll.GetEnumerator();
		try
		{
			while (((List<CommentStroll>.Enumerator*)(&enumerator))->MoveNext())
			{
				CommentStroll current = ((List<CommentStroll>.Enumerator*)(&enumerator))->Current;
				T3 val2 = (T3)current.Id.Equals((string)value);
				if (val2 != null)
				{
					current.randomMedia = ((CheckBox)val).Checked;
					break;
				}
			}
		}
		finally
		{
			((IDisposable)(*(List<CommentStroll>.Enumerator*)(&enumerator))).Dispose();
		}
		frmMain.saveCommentStroll();
	}

	private unsafe void numMedia_ValueChanged<T0, T1, T2, T3, T4, T5, T6, T7>(T5 sender, T6 e)
	{
		//IL_0059: Expected O, but got I4
		T0 val = (T0)((sender is T0) ? sender : null);
		T1 value = (T1)((Control)val).Name.Split((char[])(object)new T7[1] { (T7)95 })[1];
		T2 enumerator = (T2)frmMain.listCommentStroll[ccbCateComment.SelectedIndex].listCommentStroll.GetEnumerator();
		try
		{
			while (((List<CommentStroll>.Enumerator*)(&enumerator))->MoveNext())
			{
				CommentStroll current = ((List<CommentStroll>.Enumerator*)(&enumerator))->Current;
				T3 val2 = (T3)current.Id.Equals((string)value);
				if (val2 != null)
				{
					current.numMedia = int.Parse(((decimal)(T4)((NumericUpDown)val).Value).ToString());
					break;
				}
			}
		}
		finally
		{
			((IDisposable)(*(List<CommentStroll>.Enumerator*)(&enumerator))).Dispose();
		}
		frmMain.saveCommentStroll();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void btnMedia_Click<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T6 sender, T7 e)
	{
		//IL_003b: Expected O, but got I4
		T0 val = (T0)((sender is T0) ? sender : null);
		T1 val2 = (T1)((Control)val).Name.Split((char[])(object)new T8[1] { (T8)95 })[1];
		T2 val3 = (T2)Activator.CreateInstance(typeof(FolderBrowserDialog));
		T3 val4 = (T3)(((CommonDialog)val3).ShowDialog() == DialogResult.OK);
		if (val4 != null)
		{
			Control obj = flowLayout.Controls.Find("plSedding_" + (string)val2, searchAllChildren: true)[0];
			T4 val5 = (T4)((obj is T4) ? obj : null);
			Control obj2 = ((Control)val5).Controls.Find("txtMedia_" + (string)val2, searchAllChildren: true)[0];
			T5 val6 = (T5)((obj2 is T5) ? obj2 : null);
			((Control)val6).Text = ((FolderBrowserDialog)val3).SelectedPath;
		}
	}

	private unsafe void txtMedia__TextChanged<T0, T1, T2, T3, T4, T5, T6>(T4 sender, T5 e)
	{
		//IL_0059: Expected O, but got I4
		T0 val = (T0)((sender is T0) ? sender : null);
		T1 value = (T1)((Control)val).Name.Split((char[])(object)new T6[1] { (T6)95 })[1];
		T2 enumerator = (T2)frmMain.listCommentStroll[ccbCateComment.SelectedIndex].listCommentStroll.GetEnumerator();
		try
		{
			while (((List<CommentStroll>.Enumerator*)(&enumerator))->MoveNext())
			{
				CommentStroll current = ((List<CommentStroll>.Enumerator*)(&enumerator))->Current;
				T3 val2 = (T3)current.Id.Equals((string)value);
				if (val2 != null)
				{
					current.Media = ((Control)val).Text;
					break;
				}
			}
		}
		finally
		{
			((IDisposable)(*(List<CommentStroll>.Enumerator*)(&enumerator))).Dispose();
		}
		frmMain.saveCommentStroll();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void btnRemoveComment_Click<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T5 sender, T6 e)
	{
		//IL_0058: Expected O, but got I4
		//IL_007a: Expected I4, but got O
		//IL_0087: Expected O, but got I4
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_00b3: Expected O, but got I4
		//IL_00d9: Expected I4, but got O
		T0 val = (T0)((sender is T0) ? sender : null);
		T1 val2 = (T1)((Control)val).Name.Split((char[])(object)new T7[1] { (T7)95 })[1];
		Control obj = flowLayout.Controls.Find("plSedding_" + (string)val2, searchAllChildren: true)[0];
		T2 value = (T2)((obj is T2) ? obj : null);
		flowLayout.Controls.Remove((Control)value);
		T3 val3 = (T3)0;
		while (true)
		{
			T4 val4 = (T4)((nint)val3 < frmMain.listCommentStroll[ccbCateComment.SelectedIndex].listCommentStroll.Count);
			if (val4 != null)
			{
				T4 val5 = (T4)frmMain.listCommentStroll[ccbCateComment.SelectedIndex].listCommentStroll[(int)val3].Id.Equals((string)val2);
				if (val5 == null)
				{
					val3 = (T3)(val3 + 1);
					continue;
				}
				frmMain.listCommentStroll[ccbCateComment.SelectedIndex].listCommentStroll.RemoveAt((int)val3);
				break;
			}
			break;
		}
		frmMain.saveCommentStroll();
		loadCommbobox<T8, T4>();
	}

	private unsafe void txtComment_TextChanged<T0, T1, T2, T3, T4, T5, T6>(T4 sender, T5 e)
	{
		//IL_0059: Expected O, but got I4
		T0 val = (T0)((sender is T0) ? sender : null);
		T1 value = (T1)((Control)val).Name.Split((char[])(object)new T6[1] { (T6)95 })[1];
		T2 enumerator = (T2)frmMain.listCommentStroll[ccbCateComment.SelectedIndex].listCommentStroll.GetEnumerator();
		try
		{
			while (((List<CommentStroll>.Enumerator*)(&enumerator))->MoveNext())
			{
				CommentStroll current = ((List<CommentStroll>.Enumerator*)(&enumerator))->Current;
				T3 val2 = (T3)current.Id.Equals((string)value);
				if (val2 != null)
				{
					current.Comment = ((Control)val).Text;
					break;
				}
			}
		}
		finally
		{
			((IDisposable)(*(List<CommentStroll>.Enumerator*)(&enumerator))).Dispose();
		}
		frmMain.saveCommentStroll();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void button3_Click<T0, T1, T2, T3>(T1 sender, T2 e)
	{
		//IL_0038: Expected O, but got I4
		//IL_0078: Expected O, but got I4
		frmFolder frmFolder2 = new frmFolder(frmMain.listCommentStroll[ccbCateComment.SelectedIndex].Name, isNew: false, "Thư mục");
		frmFolder2.ShowDialog();
		T0 val = (T0)(frmFolder2.isSave == 1);
		if (val != null)
		{
			frmMain.listCommentStroll[ccbCateComment.SelectedIndex].Name = frmFolder2.newName;
			frmMain.saveCommentStroll();
			loadCommbobox<T3, T0>();
			return;
		}
		T0 val2 = (T0)(frmFolder2.isSave == 2);
		if (val2 != null)
		{
			frmMain.listCommentStroll.RemoveAt(ccbCateComment.SelectedIndex);
			frmMain.saveCommentStroll();
			loadCommbobox<T3, T0>();
		}
	}

	private void button2_Click<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T0 sender, T1 e)
	{
		//IL_0018: Expected O, but got I4
		//IL_007a: Expected O, but got I4
		//IL_007a: Expected O, but got I4
		CommentStroll commentStroll = new CommentStroll();
		commentStroll.Comment = "";
		commentStroll.Id = (string)frmMain.RandomString<T8, T9, char>((T9)5);
		commentStroll.numMedia = 0;
		commentStroll.randomMedia = false;
		frmMain.listCommentStroll[ccbCateComment.SelectedIndex].listCommentStroll.Add(commentStroll);
		frmMain.saveCommentStroll();
		addControlSedding<T2, T3, T4, T5, T6, T7, T8, T9, T10>((T8)commentStroll.Id, (T8)commentStroll.Comment, (T8)commentStroll.Media, (T9)commentStroll.numMedia, (T10)commentStroll.randomMedia);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void button1_Click<T0, T1, T2, T3, T4>(T1 sender, T2 e)
	{
		//IL_0023: Expected O, but got I4
		frmFolder frmFolder2 = new frmFolder("", isNew: true, "Thư mục");
		frmFolder2.ShowDialog();
		T0 val = (T0)(frmFolder2.isSave == 1);
		if (val != null)
		{
			frmMain.listCommentStroll.Add(new CategoryComment
			{
				Name = frmFolder2.newName,
				listCommentStroll = (List<CommentStroll>)Activator.CreateInstance(typeof(T3))
			});
			frmMain.saveCommentStroll();
			loadCommbobox<T4, T0>();
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
	private void InitializeComponent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>()
	{
		T0 val = (T0)new System.ComponentModel.ComponentResourceManager(typeof(ADSPRoject.frmCommentStroll));
		this.btnCancel = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.btnSave = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.label1 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.flowLayout = (System.Windows.Forms.FlowLayoutPanel)System.Activator.CreateInstance(typeof(System.Windows.Forms.FlowLayoutPanel));
		this.ccbCateComment = (System.Windows.Forms.ComboBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.ComboBox));
		this.button3 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.button1 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.button2 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		base.SuspendLayout();
		this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnCancel.BackColor = System.Drawing.SystemColors.HotTrack;
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		this.btnCancel.Location = new System.Drawing.Point(1029, 515);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(87, 42);
		this.btnCancel.TabIndex = 6;
		this.btnCancel.Text = "Cancel";
		this.btnCancel.UseVisualStyleBackColor = false;
		this.btnCancel.Click += new System.EventHandler(btnCancel_Click);
		this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnSave.BackColor = System.Drawing.SystemColors.Highlight;
		this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		this.btnSave.Location = new System.Drawing.Point(1123, 515);
		this.btnSave.Name = "btnSave";
		this.btnSave.Size = new System.Drawing.Size(87, 42);
		this.btnSave.TabIndex = 5;
		this.btnSave.Text = "Save";
		this.btnSave.UseVisualStyleBackColor = false;
		this.btnSave.Click += new System.EventHandler(btnSave_Click);
		this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(568, 55);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(264, 17);
		this.label1.TabIndex = 7;
		this.label1.Text = "Hỗ trợ spint text {Xin chào|Hello|Hi}";
		this.flowLayout.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.flowLayout.AutoScroll = true;
		this.flowLayout.BackColor = System.Drawing.SystemColors.Window;
		this.flowLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
		this.flowLayout.Location = new System.Drawing.Point(14, 87);
		this.flowLayout.Name = "flowLayout";
		this.flowLayout.Size = new System.Drawing.Size(1197, 422);
		this.flowLayout.TabIndex = 18;
		this.flowLayout.WrapContents = false;
		this.ccbCateComment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ccbCateComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ccbCateComment.FormattingEnabled = true;
		this.ccbCateComment.Location = new System.Drawing.Point(175, 12);
		this.ccbCateComment.Name = "ccbCateComment";
		this.ccbCateComment.Size = new System.Drawing.Size(342, 30);
		this.ccbCateComment.TabIndex = 19;
		this.ccbCateComment.SelectedIndexChanged += new System.EventHandler(ccbCateComment_SelectedIndexChanged<T7, T8, T9, T5, T6>);
		this.button3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.button3.Location = new System.Drawing.Point(525, 11);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(37, 27);
		this.button3.TabIndex = 51;
		this.button3.Text = "❁";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(button3_Click<T10, T5, T6, T11>);
		this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.button1.Location = new System.Drawing.Point(14, 12);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(154, 30);
		this.button1.TabIndex = 52;
		this.button1.Text = "+ Thêm thư mục";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click<T10, T5, T6, T8, T11>);
		this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.button2.Location = new System.Drawing.Point(14, 44);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(548, 37);
		this.button2.TabIndex = 53;
		this.button2.Text = "+ Thêm Comment";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click<T5, T6, T12, T1, T13, T2, T14, T15, T7, T16, T10>);
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(1225, 569);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.button3);
		base.Controls.Add(this.ccbCateComment);
		base.Controls.Add(this.flowLayout);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.btnCancel);
		base.Controls.Add(this.btnSave);
		this.Font = new System.Drawing.Font("Verdana", 8f);
		base.Icon = (System.Drawing.Icon)(T17)((System.Resources.ResourceManager)val).GetObject("$this.Icon");
		base.Name = "frmCommentStroll";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Comment dạo";
		base.Load += new System.EventHandler(frmCommentStroll_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
