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

public class frmSedding : Form
{
	public enum KEY_LIVE_STREAM
	{
		GO_LINK,
		LIKE,
		SEDDING
	}

	public List<SeddingList> commentlist = (List<SeddingList>)Activator.CreateInstance(typeof(List<SeddingList>));

	public static List<LiveStreamSedding> listLiveStreamSedding = (List<LiveStreamSedding>)Activator.CreateInstance(typeof(List<LiveStreamSedding>));

	private frmMain frmMain;

	private Random rnd = (Random)Activator.CreateInstance(typeof(Random));

	private int txtIdComment = 0;

	private List<ThreadAutoSedding> listThread = (List<ThreadAutoSedding>)Activator.CreateInstance(typeof(List<ThreadAutoSedding>));

	private bool isAutoRandomSedding = false;

	private int delayAutoRandomSedding = 10;

	private IContainer components = null;

	private TextBox txtLinkLiveStream;

	private Label label1;

	private Button button1;

	private Label label2;

	private NumericUpDown numDelayLiveStream;

	private Button button2;

	private Label label3;

	private Button button4;

	private FlowLayoutPanel flowLayout;

	private Button button3;

	private NumericUpDown numRandomAuto;

	private Label label4;

	private Button button5;

	public frmSedding(frmMain frm)
	{
		InitializeComponent<ComponentResourceManager, TextBox, Label, Button, NumericUpDown, FlowLayoutPanel, object, EventArgs, int, decimal, bool, Icon, List<ThreadAutoSedding>.Enumerator, FormClosingEventArgs, Exception, List<SeddingList>>();
		frmMain = frm;
		listLiveStreamSedding.Clear();
	}

	private void button1_Click<T0, T1>(T0 sender, T1 e)
	{
		listLiveStreamSedding.Add(new LiveStreamSedding
		{
			Id = frmMain.RandomString<string, int, char>(15),
			Key = KEY_LIVE_STREAM.GO_LINK,
			Value = txtLinkLiveStream.Text,
			isRandom = false
		});
	}

	private void numDelayLiveStream_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		frmMain.setting.numDelayLiveStream = int.Parse(((decimal)(T0)numDelayLiveStream.Value).ToString());
		frmMain.settingSaving();
	}

	private void button2_Click<T0, T1>(T0 sender, T1 e)
	{
		listLiveStreamSedding.Add(new LiveStreamSedding
		{
			Id = frmMain.RandomString<string, int, char>(15),
			Key = KEY_LIVE_STREAM.LIKE,
			Value = "",
			isRandom = false
		});
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void frmLiveStream_Load<T0, T1, T2, T3, T4>(T2 sender, T3 e)
	{
		//IL_003b: Expected O, but got I4
		txtLinkLiveStream.Text = frmMain.setting.txtLinkLiveStream;
		numDelayLiveStream.Value = frmMain.setting.numDelayLiveStream;
		try
		{
			T0 val = (T0)File.Exists("seddinglist.json");
			if (val != null)
			{
				commentlist = (List<SeddingList>)JsonConvert.DeserializeObject<T4>(File.ReadAllText("seddinglist.json"));
			}
			loadCommentList<int, T0, Panel, Button, NumericUpDown, TextBox, string>();
		}
		catch (Exception ex)
		{
			frmMain.errorMessage(ex.Message);
		}
	}

	private void button4_Click<T0, T1, T2, T3>(T2 sender, T3 e)
	{
		//IL_000f: Expected O, but got I4
		//IL_0046: Expected O, but got I4
		//IL_004e: Expected O, but got I4
		//IL_0062: Expected I4, but got O
		//IL_0078: Expected I4, but got O
		T1 val = (T1)(commentlist.Count > 0);
		if (val == null)
		{
			txtIdComment = 0;
		}
		else
		{
			txtIdComment = commentlist.Last().ID + 1;
		}
		T0 val2 = (T0)(flowLayout.Controls.Count - 1);
		T1 val3 = (T1)((nint)val2 >= 0);
		if (val3 != null)
		{
			_ = flowLayout.Controls[(int)val2].Top + flowLayout.Controls[(int)val2].Height + 5;
		}
		commentlist.Add(new SeddingList
		{
			ID = txtIdComment,
			Text = ""
		});
		addControlSedding<Panel, Button, NumericUpDown, TextBox, string>(txtIdComment.ToString(), "");
		saveCommentList();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void addControlSedding<T0, T1, T2, T3, T4>(T4 txtIdComment, T4 strComment)
	{
		T0 val = (T0)Activator.CreateInstance(typeof(Panel));
		((Control)val).Name = "plSedding_" + (string)txtIdComment;
		((Control)val).Width = flowLayout.Width - 40;
		((Control)val).Height = 85;
		((Panel)val).BorderStyle = BorderStyle.FixedSingle;
		((Control)val).Left = 5;
		T1 val2 = (T1)Activator.CreateInstance(typeof(Button));
		((Control)val2).Name = "btnSedding_" + (string)txtIdComment;
		((Control)val2).Height = 80;
		((Control)val2).Width = 80;
		((Control)val2).Text = "Sedding";
		((Control)val2).Click += btnSedding_Click<T1, int, T0, T3, T4, object, EventArgs, char>;
		((Control)val).Controls.Add((Control)val2);
		T1 val3 = (T1)Activator.CreateInstance(typeof(Button));
		((Control)val3).Name = "btnAutoSedding_" + (string)txtIdComment;
		((Control)val3).Height = 60;
		((Control)val3).Width = 80;
		((Control)val3).Text = "START Auto Sedding";
		((Control)val3).BackColor = Color.LightSkyBlue;
		((Control)val3).Left = ((Control)val2).Left + ((Control)val2).Width;
		((Control)val3).Click += btnAutoSedding2_Click<T1, T4, T0, T3, T2, Thread, bool, decimal, object, EventArgs, char>;
		((Control)val).Controls.Add((Control)val3);
		T2 val4 = (T2)Activator.CreateInstance(typeof(NumericUpDown));
		((Control)val4).Name = "numDelay_" + (string)txtIdComment;
		((Control)val4).Height = 50;
		((Control)val4).Width = 80;
		((NumericUpDown)val4).Maximum = 9999999m;
		((NumericUpDown)val4).Value = 10m;
		((Control)val4).Left = ((Control)val2).Left + ((Control)val2).Width;
		((Control)val4).Top = ((Control)val3).Top + ((Control)val3).Height;
		((Control)val).Controls.Add((Control)val4);
		T1 val5 = (T1)Activator.CreateInstance(typeof(Button));
		((Control)val5).Name = "btnRemoveComment_" + (string)txtIdComment;
		((Control)val5).Height = 80;
		((Control)val5).Width = 20;
		((Control)val5).Text = "x";
		((Control)val5).Left = ((Control)val3).Left + ((Control)val3).Width;
		((Control)val5).Click += btnRemoveComment_Click<bool, T1, int, T0, object, EventArgs, char>;
		((Control)val).Controls.Add((Control)val5);
		T3 val6 = (T3)Activator.CreateInstance(typeof(TextBox));
		((Control)val6).Name = "txtComment_" + (string)txtIdComment;
		((Control)val6).TextChanged += txtComment_TextChanged<T3, int, List<SeddingList>.Enumerator, bool, object, EventArgs, char>;
		((TextBoxBase)val6).Multiline = true;
		((Control)val6).Height = 80;
		((Control)val6).Text = (string)strComment;
		((TextBox)val6).ScrollBars = ScrollBars.Both;
		((Control)val6).Left = ((Control)val5).Left + ((Control)val5).Width;
		((Control)val6).Width = ((Control)val).Width - 50;
		((TextBoxBase)val6).MaxLength = 99999999;
		((Control)val).Controls.Add((Control)val6);
		flowLayout.Controls.Add((Control)val);
	}

	private void loadCommentList<T0, T1, T2, T3, T4, T5, T6>()
	{
		//IL_0002: Expected O, but got I4
		//IL_001a: Expected O, but got I4
		//IL_0022: Expected O, but got I4
		//IL_0036: Expected I4, but got O
		//IL_004c: Expected I4, but got O
		//IL_0062: Expected I4, but got O
		//IL_0069: Expected O, but got I4
		//IL_007c: Expected I4, but got O
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_009a: Expected O, but got I4
		T0 val = (T0)0;
		while (true)
		{
			T1 val2 = (T1)((nint)val < commentlist.Count);
			if (val2 != null)
			{
				T0 val3 = (T0)(flowLayout.Controls.Count - 1);
				T1 val4 = (T1)((nint)val3 >= 0);
				if (val4 != null)
				{
					_ = flowLayout.Controls[(int)val3].Top + flowLayout.Controls[(int)val3].Height + 5;
				}
				addControlSedding<T2, T3, T4, T5, T6>((T6)System.Runtime.CompilerServices.Unsafe.As<T0, int>(ref (T0)commentlist[(int)val].ID).ToString(), (T6)commentlist[(int)val].Text);
				val = (T0)(val + 1);
				continue;
			}
			break;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void btnSedding_Click<T0, T1, T2, T3, T4, T5, T6, T7>(T5 sender, T6 e)
	{
		//IL_0025: Expected O, but got I4
		//IL_0090: Expected O, but got I4
		T0 val = (T0)((sender is T0) ? sender : null);
		T1 val2 = (T1)int.Parse(((Control)val).Name.Split((char[])(object)new T7[1] { (T7)95 })[1]);
		Control obj = flowLayout.Controls.Find("plSedding_" + *(int*)(&val2), searchAllChildren: true)[0];
		T2 val3 = (T2)((obj is T2) ? obj : null);
		Control obj2 = ((Control)val3).Controls.Find("txtComment_" + *(int*)(&val2), searchAllChildren: true)[0];
		T3 val4 = (T3)((obj2 is T3) ? obj2 : null);
		T4 value = (T4)((Control)val4).Text;
		listLiveStreamSedding.Add(new LiveStreamSedding
		{
			Id = (string)frmMain.RandomString<T4, T1, T7>((T1)15),
			Key = KEY_LIVE_STREAM.SEDDING,
			Value = value,
			isRandom = false
		});
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void btnAutoSedding2_Click<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T8 sender, T9 e)
	{
		//IL_0058: Expected O, but got I4
		T0 val = (T0)((sender is T0) ? sender : null);
		T1 val2 = (T1)((Control)val).Name.Split((char[])(object)new T10[1] { (T10)95 })[1];
		Control obj = flowLayout.Controls.Find("plSedding_" + (string)val2, searchAllChildren: true)[0];
		T2 val3 = (T2)((obj is T2) ? obj : null);
		T6 val4 = (T6)((Control)val).Text.Equals("START Auto Sedding");
		if (val4 != null)
		{
			((Control)val).Text = "STOP Auto Sedding";
			((Control)val).BackColor = Color.Red;
		}
		else
		{
			((Control)val).Text = "START Auto Sedding";
			((Control)val).BackColor = Color.LightSkyBlue;
		}
		Control obj2 = ((Control)val3).Controls.Find("txtComment_" + (string)val2, searchAllChildren: true)[0];
		T3 val5 = (T3)((obj2 is T3) ? obj2 : null);
		Control obj3 = ((Control)val3).Controls.Find("numDelay_" + (string)val2, searchAllChildren: true)[0];
		T4 val6 = (T4)((obj3 is T4) ? obj3 : null);
		T1[] parameter = new T1[3]
		{
			val2,
			(T1)((Control)val5).Text,
			(T1)((decimal)(T7)((NumericUpDown)val6).Value).ToString()
		};
		T5 val7 = (T5)new Thread((ParameterizedThreadStart)autoSedding2<T1, int, List<ThreadAutoSedding>, T6, T8>);
		((Thread)val7).Start((object)parameter);
	}

	private void autoSedding2<T0, T1, T2, T3, T4>(T4 obj)
	{
		//IL_0023: Expected O, but got I4
		//IL_0054: Expected O, but got I4
		//IL_007a: Expected I4, but got O
		//IL_008b: Expected O, but got I4
		//IL_00c4: Expected I4, but got O
		T0[] array = (T0[])(object)(string[])obj;
		string id = (string)((object[])(object)array)[0];
		T0 textSedding = (T0)((object[])(object)array)[1];
		T1 val = (T1)int.Parse((string)((object[])(object)array)[2]);
		T2 val2 = (T2)((IEnumerable<ThreadAutoSedding>)listThread).Where((Func<ThreadAutoSedding, bool>)((ThreadAutoSedding a) => (T3)a.Id.Equals(id))).ToList();
		T3 val3 = (T3)(val2 != null && ((List<ThreadAutoSedding>)val2).Count > 0);
		if (val3 != null)
		{
			ThreadAutoSedding threadAutoSedding = ((IEnumerable<ThreadAutoSedding>)val2).First();
			threadAutoSedding.isRunning = !threadAutoSedding.isRunning;
			threadAutoSedding.Delay = (int)val;
			threadAutoSedding.TextSedding = (string)textSedding;
			T3 val4 = (T3)threadAutoSedding.isRunning;
			if (val4 != null)
			{
				new Thread(threadAutoSedding.runThread<T3>).Start();
			}
		}
		else
		{
			ThreadAutoSedding threadAutoSedding = new ThreadAutoSedding();
			threadAutoSedding.Id = id;
			threadAutoSedding.Delay = (int)val;
			threadAutoSedding.isRunning = true;
			threadAutoSedding.TextSedding = (string)textSedding;
			listThread.Add(threadAutoSedding);
			new Thread(threadAutoSedding.runThread<T3>).Start();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void btnRemoveComment_Click<T0, T1, T2, T3, T4, T5, T6>(T4 sender, T5 e)
	{
		//IL_000f: Expected O, but got I4
		//IL_003a: Expected O, but got I4
		//IL_0079: Expected O, but got I4
		//IL_0088: Expected I4, but got O
		//IL_0092: Expected O, but got I4
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		//IL_00ad: Expected O, but got I4
		//IL_00c0: Expected I4, but got O
		T0 val = (T0)(frmMain.questioniMessage<DialogResult, string>("Are you sure?") == DialogResult.Yes);
		if (val == null)
		{
			return;
		}
		T1 val2 = (T1)((sender is T1) ? sender : null);
		T2 val3 = (T2)int.Parse(((Control)val2).Name.Split((char[])(object)new T6[1] { (T6)95 })[1]);
		Control obj = flowLayout.Controls.Find("plSedding_" + *(int*)(&val3), searchAllChildren: true)[0];
		T3 value = (T3)((obj is T3) ? obj : null);
		flowLayout.Controls.Remove((Control)value);
		T2 val4 = (T2)0;
		while (true)
		{
			T0 val5 = (T0)((nint)val4 < commentlist.Count);
			if (val5 == null)
			{
				break;
			}
			T0 val6 = (T0)(commentlist[(int)val4].ID == (nint)val3);
			if (val6 == null)
			{
				val4 = (T2)(val4 + 1);
				continue;
			}
			commentlist.RemoveAt((int)val4);
			break;
		}
		saveCommentList();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void saveCommentList()
	{
		File.WriteAllText("SeddingList.json", JsonConvert.SerializeObject((object)commentlist));
	}

	private unsafe void txtComment_TextChanged<T0, T1, T2, T3, T4, T5, T6>(T4 sender, T5 e)
	{
		//IL_0025: Expected O, but got I4
		//IL_0047: Expected O, but got I4
		T0 val = (T0)((sender is T0) ? sender : null);
		T1 val2 = (T1)int.Parse(((Control)val).Name.Split((char[])(object)new T6[1] { (T6)95 })[1]);
		T2 enumerator = (T2)commentlist.GetEnumerator();
		try
		{
			while (((List<SeddingList>.Enumerator*)(&enumerator))->MoveNext())
			{
				SeddingList current = ((List<SeddingList>.Enumerator*)(&enumerator))->Current;
				T3 val3 = (T3)(current.ID == (nint)val2);
				if (val3 != null)
				{
					current.Text = ((Control)val).Text;
					break;
				}
			}
		}
		finally
		{
			((IDisposable)(*(List<SeddingList>.Enumerator*)(&enumerator))).Dispose();
		}
		saveCommentList();
	}

	private void btnRemoveComment2_Click<T0, T1>(T0 sender, T1 e)
	{
		flowLayout.Controls.RemoveAt(3);
	}

	private void txtLinkLiveStream_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		frmMain.setting.txtLinkLiveStream = txtLinkLiveStream.Text;
		frmMain.settingSaving();
	}

	private unsafe void frmSedding_FormClosing<T0, T1, T2>(T1 sender, T2 e)
	{
		listLiveStreamSedding.Clear();
		T0 enumerator = (T0)listThread.GetEnumerator();
		try
		{
			while (((List<ThreadAutoSedding>.Enumerator*)(&enumerator))->MoveNext())
			{
				ThreadAutoSedding current = ((List<ThreadAutoSedding>.Enumerator*)(&enumerator))->Current;
				current.isRunning = false;
			}
		}
		finally
		{
			((IDisposable)(*(List<ThreadAutoSedding>.Enumerator*)(&enumerator))).Dispose();
		}
		listThread.Clear();
	}

	private void button3_Click<T0, T1>(T0 sender, T1 e)
	{
		listLiveStreamSedding.Clear();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void button5_Click<T0, T1, T2, T3>(T2 sender, T3 e)
	{
		//IL_0055: Expected O, but got I4
		isAutoRandomSedding = !isAutoRandomSedding;
		delayAutoRandomSedding = int.Parse(((decimal)(T0)numRandomAuto.Value).ToString());
		button5.Text = "START Random Sedding";
		button5.BackColor = Color.LightSkyBlue;
		T1 val = (T1)isAutoRandomSedding;
		if (val != null)
		{
			button5.BackColor = Color.Red;
			button5.Text = "STOP Random Sedding";
			new Thread(autoRandomSedding<T1>).Start();
		}
	}

	private void autoRandomSedding<T0>()
	{
		//IL_0074: Expected O, but got I4
		while (true)
		{
			T0 val = (T0)isAutoRandomSedding;
			if (val != null)
			{
				listLiveStreamSedding.Add(new LiveStreamSedding
				{
					Id = frmMain.RandomString<string, int, char>(15),
					Key = KEY_LIVE_STREAM.SEDDING,
					Value = commentlist[rnd.Next(0, commentlist.Count - 1)].Text,
					isRandom = false
				});
				Thread.Sleep(delayAutoRandomSedding * 1000);
				continue;
			}
			break;
		}
	}

	private void numRandomAuto_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		delayAutoRandomSedding = int.Parse(((decimal)(T0)numRandomAuto.Value).ToString());
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
		T0 val = (T0)new System.ComponentModel.ComponentResourceManager(typeof(ADSPRoject.frmSedding));
		this.txtLinkLiveStream = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label1 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.button1 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.label2 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.numDelayLiveStream = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.button2 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.label3 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.button4 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.flowLayout = (System.Windows.Forms.FlowLayoutPanel)System.Activator.CreateInstance(typeof(System.Windows.Forms.FlowLayoutPanel));
		this.button3 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.numRandomAuto = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label4 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.button5 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		((System.ComponentModel.ISupportInitialize)this.numDelayLiveStream).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numRandomAuto).BeginInit();
		base.SuspendLayout();
		this.txtLinkLiveStream.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtLinkLiveStream.Location = new System.Drawing.Point(118, 33);
		this.txtLinkLiveStream.Name = "txtLinkLiveStream";
		this.txtLinkLiveStream.Size = new System.Drawing.Size(823, 20);
		this.txtLinkLiveStream.TabIndex = 0;
		this.txtLinkLiveStream.TextChanged += new System.EventHandler(txtLinkLiveStream_TextChanged);
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(14, 36);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(103, 13);
		this.label1.TabIndex = 1;
		this.label1.Text = "Link live stream:";
		this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.button1.Location = new System.Drawing.Point(948, 31);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(87, 23);
		this.button1.TabIndex = 2;
		this.button1.Text = "Go";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(14, 9);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(92, 13);
		this.label2.TabIndex = 3;
		this.label2.Text = "Delay request:";
		this.numDelayLiveStream.Location = new System.Drawing.Point(118, 7);
		this.numDelayLiveStream.Maximum = new decimal((int[])(object)new T8[4]
		{
			(T8)1316134911,
			(T8)2328,
			default(T8),
			default(T8)
		});
		this.numDelayLiveStream.Name = "numDelayLiveStream";
		this.numDelayLiveStream.Size = new System.Drawing.Size(140, 20);
		this.numDelayLiveStream.TabIndex = 4;
		this.numDelayLiveStream.ValueChanged += new System.EventHandler(numDelayLiveStream_ValueChanged<T9, T6, T7>);
		this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.button2.Location = new System.Drawing.Point(372, 59);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(87, 23);
		this.button2.TabIndex = 5;
		this.button2.Text = "Like";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click);
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(265, 9);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(13, 13);
		this.label3.TabIndex = 9;
		this.label3.Text = "s";
		this.button4.Location = new System.Drawing.Point(17, 59);
		this.button4.Name = "button4";
		this.button4.Size = new System.Drawing.Size(240, 23);
		this.button4.TabIndex = 14;
		this.button4.Text = "+ Add Sedding";
		this.button4.UseVisualStyleBackColor = true;
		this.button4.Click += new System.EventHandler(button4_Click<T8, T10, T6, T7>);
		this.flowLayout.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.flowLayout.AutoScroll = true;
		this.flowLayout.BackColor = System.Drawing.SystemColors.Window;
		this.flowLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
		this.flowLayout.Location = new System.Drawing.Point(17, 88);
		this.flowLayout.Name = "flowLayout";
		this.flowLayout.Size = new System.Drawing.Size(924, 415);
		this.flowLayout.TabIndex = 17;
		this.flowLayout.WrapContents = false;
		this.button3.Location = new System.Drawing.Point(948, 88);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(94, 59);
		this.button3.TabIndex = 18;
		this.button3.Text = "Clear";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(button3_Click);
		this.numRandomAuto.Location = new System.Drawing.Point(992, 186);
		this.numRandomAuto.Maximum = new decimal((int[])(object)new T8[4]
		{
			(T8)1316134911,
			(T8)2328,
			default(T8),
			default(T8)
		});
		this.numRandomAuto.Name = "numRandomAuto";
		this.numRandomAuto.Size = new System.Drawing.Size(51, 20);
		this.numRandomAuto.TabIndex = 20;
		this.numRandomAuto.Value = new decimal((int[])(object)new T8[4]
		{
			(T8)10,
			default(T8),
			default(T8),
			default(T8)
		});
		this.numRandomAuto.ValueChanged += new System.EventHandler(numRandomAuto_ValueChanged<T9, T6, T7>);
		this.label4.AutoSize = true;
		this.label4.Location = new System.Drawing.Point(945, 188);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(40, 13);
		this.label4.TabIndex = 19;
		this.label4.Text = "Delay";
		this.button5.BackColor = System.Drawing.Color.LightSkyBlue;
		this.button5.Location = new System.Drawing.Point(948, 212);
		this.button5.Name = "button5";
		this.button5.Size = new System.Drawing.Size(94, 59);
		this.button5.TabIndex = 21;
		this.button5.Text = "START Random Sedding";
		this.button5.UseVisualStyleBackColor = false;
		this.button5.Click += new System.EventHandler(button5_Click<T9, T10, T6, T7>);
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(1050, 515);
		base.Controls.Add(this.button5);
		base.Controls.Add(this.numRandomAuto);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.button3);
		base.Controls.Add(this.flowLayout);
		base.Controls.Add(this.button4);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.numDelayLiveStream);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.txtLinkLiveStream);
		this.Font = new System.Drawing.Font("Verdana", 8f);
		base.Icon = (System.Drawing.Icon)(T11)((System.Resources.ResourceManager)val).GetObject("$this.Icon");
		base.Name = "frmSedding";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Live Stream Control";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(frmSedding_FormClosing<T12, T6, T13>);
		base.Load += new System.EventHandler(frmLiveStream_Load<T10, T14, T6, T7, T15>);
		((System.ComponentModel.ISupportInitialize)this.numDelayLiveStream).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numRandomAuto).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
