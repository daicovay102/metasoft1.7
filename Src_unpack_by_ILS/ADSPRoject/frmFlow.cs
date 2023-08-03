using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using ADSPRoject.Data;
using Newtonsoft.Json;

namespace ADSPRoject;

public class frmFlow : Form
{
	public FBFlow flow;

	private int leftControl = 1;

	private IContainer components = null;

	private Button btnCancel;

	private Button btnSave;

	private GroupBox groupControl;

	private Panel plControl;

	public frmFlow(FBFlow flow)
	{
		InitializeComponent<ComponentResourceManager, Button, GroupBox, Panel, object, EventArgs, List<FBFlowField>.Enumerator, bool, TextBox, List<string>, StringReader, string, RichTextBox, NumericUpDown, decimal, CheckBox, ComboBox, Control, StringBuilder, int, Icon>();
		this.flow = flow;
		loadControl<int, List<FBFlowField>.Enumerator, Label, bool, CheckBox, TextBox, string, RichTextBox, NumericUpDown, ComboBox, List<CategoryComment>.Enumerator, List<GroupCreditCard>.Enumerator, StringBuilder>();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void loadControl<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
	{
		//IL_0030: Expected O, but got I4
		//IL_00cd: Expected O, but got I4
		//IL_00eb: Expected O, but got I4
		//IL_0167: Expected O, but got I4
		//IL_01b6: Expected O, but got I4
		//IL_0219: Expected I4, but got O
		//IL_025f: Expected O, but got I4
		//IL_02db: Expected I4, but got O
		//IL_02f0: Expected O, but got I4
		//IL_0333: Expected O, but got I4
		//IL_033e: Expected O, but got I4
		//IL_0353: Expected O, but got I4
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_0376: Expected O, but got Unknown
		//IL_03b2: Expected O, but got I4
		//IL_042e: Expected I4, but got O
		//IL_0474: Expected O, but got I4
		//IL_0492: Expected O, but got I4
		//IL_04fd: Expected I4, but got O
		//IL_0592: Expected O, but got I4
		//IL_05d1: Expected O, but got I4
		//IL_063c: Expected I4, but got O
		//IL_06d1: Expected O, but got I4
		//IL_077f: Expected O, but got I4
		//IL_0818: Expected I4, but got O
		//IL_0848: Expected O, but got I4
		Text = flow.Flow_Name.Replace("_", " ");
		leftControl = 25;
		T0 val = (T0)400;
		T1 enumerator = (T1)flow.Filed.GetEnumerator();
		try
		{
			while (((List<FBFlowField>.Enumerator*)(&enumerator))->MoveNext())
			{
				FBFlowField current = ((List<FBFlowField>.Enumerator*)(&enumerator))->Current;
				T2 val2 = (T2)Activator.CreateInstance(typeof(Label));
				((Control)val2).Top = leftControl;
				((Control)val2).Left = 20;
				((Control)val2).Text = current.key.Replace("_", " ") + ": ";
				((Control)val2).Width = 180;
				plControl.Controls.Add((Control)val2);
				T3 val3 = (T3)(current.type == null);
				if (val3 == null)
				{
					T3 val4 = (T3)(current.type == typeof(T3));
					if (val4 != null)
					{
						T4 val5 = (T4)Activator.CreateInstance(typeof(CheckBox));
						((Control)val5).Name = current.key;
						plControl.Controls.Add((Control)val5);
						((Control)val5).Top = leftControl - 2;
						((Control)val5).Left = ((Control)val2).Left + ((Control)val2).Width;
						((Control)val5).Text = "";
						T3 val6 = (T3)(!string.IsNullOrWhiteSpace(current.value.ToString()));
						if (val6 != null)
						{
							((CheckBox)val5).Checked = bool.Parse(current.value.ToString());
						}
						leftControl = ((Control)val5).Height + ((Control)val5).Top + 10;
						continue;
					}
					T3 val7 = (T3)(current.type == typeof(T6));
					if (val7 != null)
					{
						T5 val8 = (T5)Activator.CreateInstance(typeof(TextBox));
						((Control)val8).Name = current.key;
						plControl.Controls.Add((Control)val8);
						((Control)val8).Left = ((Control)val2).Left + ((Control)val2).Width;
						((Control)val8).Top = leftControl - 2;
						((Control)val8).Width = (int)val;
						((Control)val8).Text = current.value.ToString();
						leftControl = ((Control)val8).Height + ((Control)val8).Top + 10;
						continue;
					}
					T3 val9 = (T3)(current.type == typeof(string[]));
					if (val9 != null)
					{
						T5 val10 = (T5)Activator.CreateInstance(typeof(TextBox));
						((Control)val10).Name = current.key;
						((TextBoxBase)val10).Multiline = true;
						((Control)val10).Height = 80;
						((TextBox)val10).ScrollBars = ScrollBars.Both;
						plControl.Controls.Add((Control)val10);
						((Control)val10).Left = ((Control)val2).Left + ((Control)val2).Width;
						((Control)val10).Top = leftControl - 2;
						((Control)val10).Width = (int)val;
						T3 val11 = (T3)(!string.IsNullOrWhiteSpace(current.value.ToString()));
						if (val11 != null)
						{
							T6[] array = null;
							try
							{
								array = (T6[])(object)(string[])current.value;
							}
							catch (Exception)
							{
							}
							T3 val12 = (T3)(array == null);
							if (val12 != null)
							{
								array = JsonConvert.DeserializeObject<T6[]>(current.value.ToString());
							}
							T3 val13 = (T3)(array != null && array.Length != 0);
							if (val13 != null)
							{
								T6[] array2 = array;
								T0 val14 = (T0)0;
								while ((nint)val14 < array2.Length)
								{
									T6 val15 = (T6)((object[])(object)array2)[(object)val14];
									T3 val16 = (T3)(!string.IsNullOrWhiteSpace((string)val15));
									if (val16 != null)
									{
										((Control)val10).Text = ((Control)val10).Text + (string)val15 + Environment.NewLine;
									}
									val14 = (T0)(val14 + 1);
								}
							}
						}
						leftControl = ((Control)val10).Height + ((Control)val10).Top + 10;
						continue;
					}
					T3 val17 = (T3)(current.type == typeof(T12));
					if (val17 != null)
					{
						T7 val18 = (T7)Activator.CreateInstance(typeof(RichTextBox));
						((Control)val18).Name = current.key;
						((TextBoxBase)val18).Multiline = true;
						((Control)val18).Height = 80;
						((RichTextBox)val18).ScrollBars = RichTextBoxScrollBars.Both;
						plControl.Controls.Add((Control)val18);
						((Control)val18).Left = ((Control)val2).Left + ((Control)val2).Width;
						((Control)val18).Top = leftControl - 2;
						((Control)val18).Width = (int)val;
						((Control)val18).Text = current.value.ToString();
						leftControl = ((Control)val18).Height + ((Control)val18).Top + 10;
						continue;
					}
					T3 val19 = (T3)(current.type == typeof(T0));
					if (val19 == null)
					{
						T3 val20 = (T3)(current.type == typeof(CategoryComment));
						if (val20 != null)
						{
							T9 val21 = (T9)Activator.CreateInstance(typeof(ComboBox));
							((ComboBox)val21).DropDownStyle = ComboBoxStyle.DropDownList;
							((Control)val21).Name = current.key;
							plControl.Controls.Add((Control)val21);
							((Control)val21).Left = ((Control)val2).Left + ((Control)val2).Width;
							((Control)val21).Top = leftControl - 2;
							((Control)val21).Width = (int)val;
							((Control)val21).Text = current.value.ToString();
							leftControl = ((Control)val21).Height + ((Control)val21).Top + 10;
							T10 enumerator2 = (T10)frmMain.listCommentStroll.GetEnumerator();
							try
							{
								while (((List<CategoryComment>.Enumerator*)(&enumerator2))->MoveNext())
								{
									CategoryComment current2 = ((List<CategoryComment>.Enumerator*)(&enumerator2))->Current;
									((ComboBox)val21).Items.Add(current2.Name);
								}
							}
							finally
							{
								((IDisposable)(*(List<CategoryComment>.Enumerator*)(&enumerator2))).Dispose();
							}
							T3 val22 = (T3)(string.IsNullOrWhiteSpace(current.value.ToString()) && ((ComboBox)val21).Items.Count > 0);
							if (val22 != null)
							{
								((ListControl)val21).SelectedIndex = 0;
							}
							else
							{
								((ComboBox)val21).SelectedItem = current.value.ToString();
							}
							continue;
						}
						T3 val23 = (T3)(current.type == typeof(GroupCreditCard));
						if (val23 == null)
						{
							continue;
						}
						T9 val24 = (T9)Activator.CreateInstance(typeof(ComboBox));
						((ComboBox)val24).DropDownStyle = ComboBoxStyle.DropDown;
						((Control)val24).Name = current.key;
						plControl.Controls.Add((Control)val24);
						((Control)val24).Left = ((Control)val2).Left + ((Control)val2).Width;
						((Control)val24).Top = leftControl - 2;
						((Control)val24).Width = (int)val;
						((Control)val24).Text = current.value.ToString();
						leftControl = ((Control)val24).Height + ((Control)val24).Top + 10;
						T11 enumerator3 = (T11)frmMain.groupCreditCard.GetEnumerator();
						try
						{
							while (((List<GroupCreditCard>.Enumerator*)(&enumerator3))->MoveNext())
							{
								GroupCreditCard current3 = ((List<GroupCreditCard>.Enumerator*)(&enumerator3))->Current;
								((ComboBox)val24).Items.Add(current3.Name);
							}
						}
						finally
						{
							((IDisposable)(*(List<GroupCreditCard>.Enumerator*)(&enumerator3))).Dispose();
						}
						T3 val25 = (T3)(string.IsNullOrWhiteSpace(current.value.ToString()) && ((ComboBox)val24).Items.Count > 0);
						if (val25 == null)
						{
							((ComboBox)val24).SelectedItem = current.value.ToString();
						}
						else
						{
							((ListControl)val24).SelectedIndex = 0;
						}
					}
					else
					{
						T8 val26 = (T8)Activator.CreateInstance(typeof(NumericUpDown));
						((Control)val26).Name = current.key;
						((NumericUpDown)val26).Minimum = 0m;
						((NumericUpDown)val26).Maximum = 99999999m;
						plControl.Controls.Add((Control)val26);
						((Control)val26).Left = ((Control)val2).Left + ((Control)val2).Width;
						((Control)val26).Top = leftControl - 2;
						T3 val27 = (T3)(!string.IsNullOrWhiteSpace(current.value.ToString()));
						if (val27 != null)
						{
							((NumericUpDown)val26).Value = int.Parse(current.value.ToString());
						}
						leftControl = ((Control)val26).Height + ((Control)val26).Top + 10;
					}
				}
				else
				{
					T2 val28 = (T2)Activator.CreateInstance(typeof(Label));
					((Control)val28).Name = current.key;
					plControl.Controls.Add((Control)val28);
					((Control)val28).Left = ((Control)val2).Left + ((Control)val2).Width;
					((Control)val28).Top = leftControl - 2;
					((Control)val28).Width = (int)val;
					((Control)val28).Text = "";
					leftControl = ((Control)val28).Height + ((Control)val28).Top + 10;
				}
			}
		}
		finally
		{
			((IDisposable)(*(List<FBFlowField>.Enumerator*)(&enumerator))).Dispose();
		}
	}

	private void btnCancel_Click<T0, T1>(T0 sender, T1 e)
	{
		Close();
	}

	private unsafe void btnSave_Click<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T11 sender, T12 e)
	{
		//IL_0035: Expected O, but got I4
		//IL_0052: Expected O, but got I4
		//IL_00b2: Expected O, but got I4
		//IL_00cf: Expected O, but got I4
		//IL_010a: Expected O, but got I4
		//IL_015a: Expected O, but got I4
		//IL_01b3: Expected O, but got I4
		//IL_01d1: Expected O, but got I4
		//IL_0230: Expected O, but got I4
		//IL_027d: Expected O, but got I4
		//IL_02de: Expected O, but got I4
		T0 enumerator = (T0)flow.Filed.GetEnumerator();
		try
		{
			while (((List<FBFlowField>.Enumerator*)(&enumerator))->MoveNext())
			{
				FBFlowField current = ((List<FBFlowField>.Enumerator*)(&enumerator))->Current;
				T1 val = (T1)(current.type == typeof(T5));
				if (val == null)
				{
					T1 val2 = (T1)(current.type == typeof(string[]));
					if (val2 != null)
					{
						T3 val3 = (T3)Activator.CreateInstance(typeof(T3));
						T2 val4 = (T2)((IEnumerable<T13>)(object)plControl.Controls.Find(current.key, searchAllChildren: false)).First();
						T4 val5 = (T4)new StringReader(((Control)val4).Text);
						try
						{
							T5 val6 = (T5)((TextReader)val5).ReadLine();
							while (true)
							{
								T1 val7 = (T1)(val6 != null);
								if (val7 != null)
								{
									T1 val8 = (T1)(!string.IsNullOrWhiteSpace((string)val6));
									if (val8 != null)
									{
										((List<string>)val3).Add((string)val6);
									}
									val6 = (T5)((TextReader)val5).ReadLine();
									continue;
								}
								break;
							}
						}
						finally
						{
							if (val5 != null)
							{
								((IDisposable)val5).Dispose();
							}
						}
						current.value = ((List<string>)val3).ToArray();
						continue;
					}
					T1 val9 = (T1)(current.type == typeof(T14));
					if (val9 != null)
					{
						T6 val10 = (T6)((IEnumerable<T13>)(object)plControl.Controls.Find(current.key, searchAllChildren: false)).First();
						current.value = ((Control)val10).Text;
						continue;
					}
					T1 val11 = (T1)(current.type == typeof(T15));
					if (val11 != null)
					{
						T7 val12 = (T7)((IEnumerable<T13>)(object)plControl.Controls.Find(current.key, searchAllChildren: false)).First();
						current.value = ((decimal)(T8)((NumericUpDown)val12).Value).ToString();
						continue;
					}
					T1 val13 = (T1)(current.type == typeof(T1));
					if (val13 == null)
					{
						T1 val14 = (T1)(current.type == typeof(CategoryComment));
						if (val14 != null)
						{
							T10 val15 = (T10)((IEnumerable<T13>)(object)plControl.Controls.Find(current.key, searchAllChildren: false)).First();
							current.value = frmMain.listCommentStroll[((ListControl)val15).SelectedIndex].Name;
							continue;
						}
						T1 val16 = (T1)(current.type == typeof(GroupCreditCard));
						if (val16 != null)
						{
							T10 val17 = (T10)((IEnumerable<T13>)(object)plControl.Controls.Find(current.key, searchAllChildren: false)).First();
							T1 val18 = (T1)(((ListControl)val17).SelectedIndex != -1 && frmMain.groupCreditCard[((ListControl)val17).SelectedIndex] != null);
							if (val18 == null)
							{
								current.value = ((Control)val17).Text;
							}
							else
							{
								current.value = frmMain.groupCreditCard[((ListControl)val17).SelectedIndex].Name;
							}
						}
					}
					else
					{
						T9 val19 = (T9)((IEnumerable<T13>)(object)plControl.Controls.Find(current.key, searchAllChildren: false)).First();
						current.value = System.Runtime.CompilerServices.Unsafe.As<T1, bool>(ref (T1)((CheckBox)val19).Checked).ToString();
					}
				}
				else
				{
					T2 val20 = (T2)((IEnumerable<T13>)(object)plControl.Controls.Find(current.key, searchAllChildren: false)).First();
					current.value = ((Control)val20).Text;
				}
			}
		}
		finally
		{
			((IDisposable)(*(List<FBFlowField>.Enumerator*)(&enumerator))).Dispose();
		}
		Close();
	}

	private void frmFlow_Load<T0, T1>(T0 sender, T1 e)
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
		T0 val = (T0)new System.ComponentModel.ComponentResourceManager(typeof(ADSPRoject.frmFlow));
		this.btnCancel = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.btnSave = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.groupControl = (System.Windows.Forms.GroupBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.GroupBox));
		this.plControl = (System.Windows.Forms.Panel)System.Activator.CreateInstance(typeof(System.Windows.Forms.Panel));
		this.groupControl.SuspendLayout();
		base.SuspendLayout();
		this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnCancel.BackColor = System.Drawing.SystemColors.HotTrack;
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		this.btnCancel.Location = new System.Drawing.Point(478, 514);
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
		this.btnSave.Location = new System.Drawing.Point(572, 514);
		this.btnSave.Name = "btnSave";
		this.btnSave.Size = new System.Drawing.Size(87, 42);
		this.btnSave.TabIndex = 5;
		this.btnSave.Text = "Save";
		this.btnSave.UseVisualStyleBackColor = false;
		this.btnSave.Click += new System.EventHandler(btnSave_Click<T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T4, T5, T17, T18, T19>);
		this.groupControl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.groupControl.Controls.Add(this.plControl);
		this.groupControl.Location = new System.Drawing.Point(14, 12);
		this.groupControl.Name = "groupControl";
		this.groupControl.Size = new System.Drawing.Size(646, 496);
		this.groupControl.TabIndex = 7;
		this.groupControl.TabStop = false;
		this.groupControl.Text = "Field";
		this.plControl.AutoScroll = true;
		this.plControl.Dock = System.Windows.Forms.DockStyle.Fill;
		this.plControl.Location = new System.Drawing.Point(3, 16);
		this.plControl.Name = "plControl";
		this.plControl.Size = new System.Drawing.Size(640, 477);
		this.plControl.TabIndex = 0;
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(674, 568);
		base.Controls.Add(this.groupControl);
		base.Controls.Add(this.btnCancel);
		base.Controls.Add(this.btnSave);
		this.Font = new System.Drawing.Font("Verdana", 8f);
		base.Icon = (System.Drawing.Icon)(T20)((System.Resources.ResourceManager)val).GetObject("$this.Icon");
		base.Name = "frmFlow";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Config";
		base.Load += new System.EventHandler(frmFlow_Load);
		this.groupControl.ResumeLayout(false);
		base.ResumeLayout(false);
	}
}
