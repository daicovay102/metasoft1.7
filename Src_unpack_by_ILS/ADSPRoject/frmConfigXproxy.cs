using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ADSPRoject.Data;

namespace ADSPRoject;

public class frmConfigXproxy : Form
{
	private frmMain frmMain;

	private IContainer components = null;

	private Label label1;

	private TextBox txtXproxyIP;

	private Label label2;

	private TextBox txtProxyList;

	private Button button1;

	private Button button2;

	private RadioButton rbHttpProxy;

	private RadioButton rbSocksV5;

	private RadioButton rbHttpIPv6;

	private RadioButton rbSocksIPV6;

	private Label label3;

	private NumericUpDown numChangeIP;

	public frmConfigXproxy(frmMain frmMainForm)
	{
		InitializeComponent<ComponentResourceManager, Label, TextBox, Button, RadioButton, NumericUpDown, object, EventArgs, bool, string, int, decimal, List<XProxy>, Icon, List<XProxy>.Enumerator>();
		frmMain = frmMainForm;
	}

	private void button1_Click<T0, T1, T2, T3, T4, T5, T6>(T4 sender, T5 e)
	{
		//IL_0023: Expected O, but got I4
		//IL_005c: Expected O, but got I4
		//IL_006d: Expected O, but got I4
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00ce: Expected O, but got I4
		//IL_00df: Expected O, but got I4
		//IL_00f0: Expected O, but got I4
		//IL_0101: Expected O, but got I4
		frmMain.setting.XproxyIP = txtXproxyIP.Text;
		T0 val = (T0)(frmMain.setting.XproxyList == null);
		if (val != null)
		{
			frmMain.setting.XproxyList = (List<XProxy>)Activator.CreateInstance(typeof(T6));
		}
		frmMain.setting.XproxyList.Clear();
		T1[] lines = (T1[])(object)txtProxyList.Lines;
		T2 val2 = (T2)0;
		while ((nint)val2 < lines.Length)
		{
			T1 val3 = (T1)((object[])(object)lines)[(object)val2];
			T0 val4 = (T0)(!string.IsNullOrWhiteSpace((string)val3));
			if (val4 != null)
			{
				frmMain.setting.XproxyList.Add(new XProxy
				{
					Proxy = ((string)val3).Trim(),
					IsUsed = false,
					CountDown = int.Parse(((decimal)(T3)numChangeIP.Value).ToString())
				});
			}
			val2 = (T2)(val2 + 1);
		}
		T0 val5 = (T0)rbHttpProxy.Checked;
		if (val5 == null)
		{
			T0 val6 = (T0)rbSocksV5.Checked;
			if (val6 == null)
			{
				T0 val7 = (T0)rbHttpIPv6.Checked;
				if (val7 == null)
				{
					T0 val8 = (T0)rbSocksIPV6.Checked;
					if (val8 != null)
					{
						frmMain.setting.TypeXProxy = 3;
					}
				}
				else
				{
					frmMain.setting.TypeXProxy = 2;
				}
			}
			else
			{
				frmMain.setting.TypeXProxy = 1;
			}
		}
		else
		{
			frmMain.setting.TypeXProxy = 0;
		}
		frmMain.settingSaving();
		Close();
	}

	private void button2_Click<T0, T1>(T0 sender, T1 e)
	{
		Close();
	}

	private unsafe void frmConfigXproxy_Load<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_0037: Expected O, but got I4
		//IL_009b: Expected O, but got I4
		//IL_00b4: Expected I4, but got O
		txtXproxyIP.Text = frmMain.setting.XproxyIP;
		T0 val = (T0)(frmMain.setting.XproxyList != null && frmMain.setting.XproxyList.Count > 0);
		if (val != null)
		{
			T1 enumerator = (T1)frmMain.setting.XproxyList.GetEnumerator();
			try
			{
				while (((List<XProxy>.Enumerator*)(&enumerator))->MoveNext())
				{
					XProxy current = ((List<XProxy>.Enumerator*)(&enumerator))->Current;
					TextBox textBox = txtProxyList;
					textBox.Text = textBox.Text + current.Proxy + Environment.NewLine;
				}
			}
			finally
			{
				((IDisposable)(*(List<XProxy>.Enumerator*)(&enumerator))).Dispose();
			}
		}
		T2 val2 = (T2)frmMain.setting.TypeXProxy;
		T2 val3 = val2;
		switch ((int)val3)
		{
		case 0:
			rbHttpProxy.Checked = true;
			break;
		case 1:
			rbSocksV5.Checked = true;
			break;
		case 2:
			rbHttpIPv6.Checked = true;
			break;
		case 3:
			rbSocksIPV6.Checked = true;
			break;
		}
	}

	private void rbHttpProxy_CheckedChanged<T0, T1>(T0 sender, T1 e)
	{
	}

	private void txtXproxyIP_TextChanged<T0, T1>(T0 sender, T1 e)
	{
	}

	private void txtProxyList_TextChanged<T0, T1>(T0 sender, T1 e)
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
	private void InitializeComponent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
	{
		T0 val = (T0)new System.ComponentModel.ComponentResourceManager(typeof(ADSPRoject.frmConfigXproxy));
		this.label1 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtXproxyIP = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label2 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtProxyList = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.button1 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.button2 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.rbHttpProxy = (System.Windows.Forms.RadioButton)System.Activator.CreateInstance(typeof(System.Windows.Forms.RadioButton));
		this.rbSocksV5 = (System.Windows.Forms.RadioButton)System.Activator.CreateInstance(typeof(System.Windows.Forms.RadioButton));
		this.rbHttpIPv6 = (System.Windows.Forms.RadioButton)System.Activator.CreateInstance(typeof(System.Windows.Forms.RadioButton));
		this.rbSocksIPV6 = (System.Windows.Forms.RadioButton)System.Activator.CreateInstance(typeof(System.Windows.Forms.RadioButton));
		this.label3 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.numChangeIP = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		((System.ComponentModel.ISupportInitialize)this.numChangeIP).BeginInit();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(8, 40);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(55, 18);
		this.label1.TabIndex = 0;
		this.label1.Text = "Server:";
		this.txtXproxyIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtXproxyIP.Location = new System.Drawing.Point(79, 37);
		this.txtXproxyIP.Name = "txtXproxyIP";
		this.txtXproxyIP.Size = new System.Drawing.Size(495, 24);
		this.txtXproxyIP.TabIndex = 1;
		this.txtXproxyIP.TextChanged += new System.EventHandler(txtXproxyIP_TextChanged);
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.Location = new System.Drawing.Point(14, 67);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(50, 18);
		this.label2.TabIndex = 2;
		this.label2.Text = "Proxy:";
		this.txtProxyList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtProxyList.Location = new System.Drawing.Point(79, 67);
		this.txtProxyList.Multiline = true;
		this.txtProxyList.Name = "txtProxyList";
		this.txtProxyList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtProxyList.Size = new System.Drawing.Size(401, 109);
		this.txtProxyList.TabIndex = 3;
		this.txtProxyList.TextChanged += new System.EventHandler(txtProxyList_TextChanged);
		this.button1.Location = new System.Drawing.Point(488, 182);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(87, 23);
		this.button1.TabIndex = 4;
		this.button1.Text = "Save";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click<T8, T9, T10, T11, T6, T7, T12>);
		this.button2.Location = new System.Drawing.Point(393, 182);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(87, 23);
		this.button2.TabIndex = 5;
		this.button2.Text = "Cancel";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click);
		this.rbHttpProxy.AutoSize = true;
		this.rbHttpProxy.Checked = true;
		this.rbHttpProxy.Location = new System.Drawing.Point(79, 12);
		this.rbHttpProxy.Name = "rbHttpProxy";
		this.rbHttpProxy.Size = new System.Drawing.Size(91, 17);
		this.rbHttpProxy.TabIndex = 6;
		this.rbHttpProxy.TabStop = true;
		this.rbHttpProxy.Text = "HTTP proxy";
		this.rbHttpProxy.UseVisualStyleBackColor = true;
		this.rbHttpProxy.CheckedChanged += new System.EventHandler(rbHttpProxy_CheckedChanged);
		this.rbSocksV5.AutoSize = true;
		this.rbSocksV5.Location = new System.Drawing.Point(182, 12);
		this.rbSocksV5.Name = "rbSocksV5";
		this.rbSocksV5.Size = new System.Drawing.Size(83, 17);
		this.rbSocksV5.TabIndex = 7;
		this.rbSocksV5.TabStop = true;
		this.rbSocksV5.Text = "SOCKs v5";
		this.rbSocksV5.UseVisualStyleBackColor = true;
		this.rbHttpIPv6.AutoSize = true;
		this.rbHttpIPv6.Location = new System.Drawing.Point(275, 12);
		this.rbHttpIPv6.Name = "rbHttpIPv6";
		this.rbHttpIPv6.Size = new System.Drawing.Size(84, 17);
		this.rbHttpIPv6.TabIndex = 8;
		this.rbHttpIPv6.TabStop = true;
		this.rbHttpIPv6.Text = "HTTP IPv6";
		this.rbHttpIPv6.UseVisualStyleBackColor = true;
		this.rbSocksIPV6.AutoSize = true;
		this.rbSocksIPV6.Location = new System.Drawing.Point(374, 12);
		this.rbSocksIPV6.Name = "rbSocksIPV6";
		this.rbSocksIPV6.Size = new System.Drawing.Size(95, 17);
		this.rbSocksIPV6.TabIndex = 9;
		this.rbSocksIPV6.TabStop = true;
		this.rbSocksIPV6.Text = "SOCKs IPv6";
		this.rbSocksIPV6.UseVisualStyleBackColor = true;
		this.label3.AutoSize = true;
		this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label3.Location = new System.Drawing.Point(483, 70);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(79, 18);
		this.label3.TabIndex = 10;
		this.label3.Text = "Chrome/IP";
		this.numChangeIP.Location = new System.Drawing.Point(486, 91);
		this.numChangeIP.Maximum = new decimal((int[])(object)new T10[4]
		{
			(T10)99999,
			default(T10),
			default(T10),
			default(T10)
		});
		this.numChangeIP.Name = "numChangeIP";
		this.numChangeIP.Size = new System.Drawing.Size(89, 20);
		this.numChangeIP.TabIndex = 11;
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(589, 216);
		base.Controls.Add(this.numChangeIP);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.rbSocksIPV6);
		base.Controls.Add(this.rbHttpIPv6);
		base.Controls.Add(this.rbSocksV5);
		base.Controls.Add(this.rbHttpProxy);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.txtProxyList);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.txtXproxyIP);
		base.Controls.Add(this.label1);
		this.Font = new System.Drawing.Font("Verdana", 8f);
		base.Icon = (System.Drawing.Icon)(T13)((System.Resources.ResourceManager)val).GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmConfigXproxy";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Config xproxy";
		base.Load += new System.EventHandler(frmConfigXproxy_Load<T8, T14, T10, T6, T7>);
		((System.ComponentModel.ISupportInitialize)this.numChangeIP).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
