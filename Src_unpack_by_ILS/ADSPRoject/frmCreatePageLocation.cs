using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ADSPRoject.Data.PageLocations;
using Newtonsoft.Json;

namespace ADSPRoject;

public class frmCreatePageLocation : Form
{
	private frmAdsManager frm;

	private bool isRunning = false;

	private int countSucess = 0;

	private int countlỗi = 0;

	private int current = 0;

	private Random rnd = (Random)Activator.CreateInstance(typeof(Random));

	private List<global_cities> global_cities = (List<global_cities>)Activator.CreateInstance(typeof(List<global_cities>));

	private List<string> listCityUsed = (List<string>)Activator.CreateInstance(typeof(List<string>));

	private string BM_ID;

	private string Page_Id;

	private int Quantity = 0;

	private string CatePage = "";

	private string Phone;

	private int Delay = 0;

	private IContainer components = null;

	private Label label1;

	private Label label2;

	private TextBox txtBMID;

	private TextBox txtPageId;

	private Label label3;

	private NumericUpDown numQuantity;

	private Button button1;

	private TextBox txtCurrentNumber;

	private Label label4;

	private Label label5;

	private Label label6;

	private Label lbSuccess;

	private Label lblỗi;

	private System.Windows.Forms.Timer timer_auto_refesh;

	private TextBox txtCatePage;

	private Label label7;

	private NumericUpDown numDelay;

	private Label label8;

	private TextBox txtPhone;

	private Label label9;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public frmCreatePageLocation(frmAdsManager frm)
	{
		InitializeComponent<ComponentResourceManager, Container, Label, TextBox, NumericUpDown, Button, object, EventArgs, int, decimal, bool, Icon, FormClosingEventArgs>();
		this.frm = frm;
		if (File.Exists("global_cities.json"))
		{
			global_cities = JsonConvert.DeserializeObject<List<global_cities>>(File.ReadAllText("global_cities.json"));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void button1_Click<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0045: Expected O, but got I4
		button1.Text = "START";
		button1.BackColor = Color.DodgerBlue;
		isRunning = !isRunning;
		countSucess = 0;
		countlỗi = 0;
		T0 val = (T0)isRunning;
		if (val != null)
		{
			button1.Text = "STOP";
			button1.BackColor = Color.Red;
			new Thread(thrStart<int, T0, Dictionary<string, string>, string, Exception>).Start();
			timer_auto_refesh.Start();
		}
	}

	public void thrStart<T0, T1, T2, T3, T4>()
	{
		//IL_0002: Expected O, but got I4
		//IL_0013: Expected O, but got I4
		//IL_0062: Expected O, but got I4
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_00b4: Expected O, but got I4
		T0 val = (T0)0;
		while (true)
		{
			T1 val2 = (T1)((nint)val < Quantity);
			if (val2 == null)
			{
				break;
			}
			global_cities randomGlobal_City = getRandomGlobal_City<T1>();
			T1 val3 = (T1)(randomGlobal_City != null);
			if (val3 != null)
			{
				T1 val4 = frm.chrome.tao_page_vi_tri<T1, T2, T3, T4>((T3)Page_Id, (T3)CatePage, (T3)randomGlobal_City.uid, (T3)randomGlobal_City.latitude, (T3)randomGlobal_City.longitude, (T3)randomGlobal_City.text, (T3)Phone, (T3)System.Runtime.CompilerServices.Unsafe.As<T0, int>(ref (T0)rnd.Next(11111111, 88888888)).ToString());
				T1 val5 = val4;
				if (val5 == null)
				{
					countlỗi++;
				}
				else
				{
					countSucess++;
				}
			}
			Thread.Sleep(Delay + 1000);
			val = (T0)(val + 1);
		}
		isRunning = false;
	}

	public global_cities getRandomGlobal_City<T0>()
	{
		//IL_0005: Expected O, but got I4
		//IL_000f: Expected O, but got I4
		global_cities global_cities;
		while (true)
		{
			global_cities = this.global_cities[rnd.Next(0, this.global_cities.Count - 1)];
			T0 val = (T0)(!listCityUsed.Contains(global_cities.uid) && !string.IsNullOrWhiteSpace(global_cities.longitude) && !string.IsNullOrWhiteSpace(global_cities.latitude));
			if (val != null)
			{
				break;
			}
			T0 val2 = (T0)isRunning;
			if (val2 == null)
			{
				return null;
			}
		}
		listCityUsed.Add(global_cities.uid);
		return global_cities;
	}

	private void txtBMID_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		BM_ID = txtBMID.Text;
	}

	private void txtPageId_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		Page_Id = txtPageId.Text;
	}

	private void numQuantity_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		Quantity = int.Parse(((decimal)(T0)numQuantity.Value).ToString());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void timer1_Tick<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_004c: Expected O, but got I4
		lblỗi.Text = countlỗi.ToString();
		lbSuccess.Text = countSucess.ToString();
		txtCurrentNumber.Text = current.ToString();
		T0 val = (T0)(!isRunning);
		if (val != null)
		{
			button1.Text = "START";
			button1.BackColor = Color.DodgerBlue;
			timer_auto_refesh.Stop();
			MessageBox.Show("Done!");
		}
	}

	private void txtCatePage_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		CatePage = txtCatePage.Text;
	}

	private void txtPhone_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		Phone = txtPhone.Text;
	}

	private void numDelay_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		Delay = int.Parse(((decimal)(T0)numDelay.Value).ToString());
	}

	private void frmCreatePageLocation_Load<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_000f: Expected O, but got I4
		T0 val = (T0)(frm.chrome != null);
		if (val != null)
		{
			txtBMID.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtBMID_Page_Location;
			txtPageId.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtPageId_Page_Location;
			numQuantity.Value = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].numQuantity_Page_Location;
			txtCatePage.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCatePage_Page_Location;
			txtPhone.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtPhone_Page_Location;
			numDelay.Value = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].numDelay_Page_Location;
		}
	}

	private void frmCreatePageLocation_FormClosing<T0, T1, T2, T3>(T2 sender, T3 e)
	{
		//IL_000f: Expected O, but got I4
		T0 val = (T0)(frm.chrome != null);
		if (val != null)
		{
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtBMID_Page_Location = txtBMID.Text;
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtPageId_Page_Location = txtPageId.Text;
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].numQuantity_Page_Location = int.Parse(((decimal)(T1)numQuantity.Value).ToString());
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCatePage_Page_Location = txtCatePage.Text;
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtPhone_Page_Location = txtPhone.Text;
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].numDelay_Page_Location = int.Parse(((decimal)(T1)numDelay.Value).ToString());
			frmMain.settingSaving();
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
	private void InitializeComponent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
	{
		this.components = (System.ComponentModel.IContainer)System.Activator.CreateInstance(typeof(System.ComponentModel.Container));
		T0 val = (T0)new System.ComponentModel.ComponentResourceManager(typeof(ADSPRoject.frmCreatePageLocation));
		this.label1 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.label2 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtBMID = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.txtPageId = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label3 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.numQuantity = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.button1 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.txtCurrentNumber = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label4 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.label5 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.label6 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.lbSuccess = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.lblỗi = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.timer_auto_refesh = new System.Windows.Forms.Timer(this.components);
		this.txtCatePage = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label7 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.numDelay = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label8 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtPhone = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label9 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		((System.ComponentModel.ISupportInitialize)this.numQuantity).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numDelay).BeginInit();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(12, 9);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(40, 13);
		this.label1.TabIndex = 0;
		this.label1.Text = "BM ID:";
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(270, 9);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(47, 13);
		this.label2.TabIndex = 1;
		this.label2.Text = "Page Id:";
		this.txtBMID.Location = new System.Drawing.Point(58, 6);
		this.txtBMID.Name = "txtBMID";
		this.txtBMID.Size = new System.Drawing.Size(189, 20);
		this.txtBMID.TabIndex = 2;
		this.txtBMID.TextChanged += new System.EventHandler(txtBMID_TextChanged);
		this.txtPageId.Location = new System.Drawing.Point(323, 6);
		this.txtPageId.Name = "txtPageId";
		this.txtPageId.Size = new System.Drawing.Size(172, 20);
		this.txtPageId.TabIndex = 3;
		this.txtPageId.TextChanged += new System.EventHandler(txtPageId_TextChanged);
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(0, 34);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(52, 13);
		this.label3.TabIndex = 4;
		this.label3.Text = "Số lượng:";
		this.numQuantity.Location = new System.Drawing.Point(145, 32);
		this.numQuantity.Maximum = new decimal((int[])(object)new T8[4]
		{
			(T8)1410065407,
			(T8)2,
			default(T8),
			default(T8)
		});
		this.numQuantity.Name = "numQuantity";
		this.numQuantity.Size = new System.Drawing.Size(102, 20);
		this.numQuantity.TabIndex = 5;
		this.numQuantity.ValueChanged += new System.EventHandler(numQuantity_ValueChanged<T9, T6, T7>);
		this.button1.Location = new System.Drawing.Point(418, 75);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(77, 48);
		this.button1.TabIndex = 6;
		this.button1.Text = "Bắt Đầu";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click<T10, T6, T7>);
		this.txtCurrentNumber.Enabled = false;
		this.txtCurrentNumber.Location = new System.Drawing.Point(58, 31);
		this.txtCurrentNumber.Name = "txtCurrentNumber";
		this.txtCurrentNumber.Size = new System.Drawing.Size(63, 20);
		this.txtCurrentNumber.TabIndex = 7;
		this.label4.AutoSize = true;
		this.label4.Location = new System.Drawing.Point(127, 34);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(12, 13);
		this.label4.TabIndex = 8;
		this.label4.Text = "/";
		this.label5.AutoSize = true;
		this.label5.ForeColor = System.Drawing.Color.Blue;
		this.label5.Location = new System.Drawing.Point(9, 90);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(68, 13);
		this.label5.TabIndex = 9;
		this.label5.Text = "Thành công:";
		this.label6.AutoSize = true;
		this.label6.ForeColor = System.Drawing.Color.Red;
		this.label6.Location = new System.Drawing.Point(28, 110);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(49, 13);
		this.label6.TabIndex = 10;
		this.label6.Text = "Thất bại:";
		this.lbSuccess.AutoSize = true;
		this.lbSuccess.ForeColor = System.Drawing.Color.Blue;
		this.lbSuccess.Location = new System.Drawing.Point(83, 90);
		this.lbSuccess.Name = "lbSuccess";
		this.lbSuccess.Size = new System.Drawing.Size(13, 13);
		this.lbSuccess.TabIndex = 11;
		this.lbSuccess.Text = "0";
		this.lblỗi.AutoSize = true;
		this.lblỗi.ForeColor = System.Drawing.Color.Red;
		this.lblỗi.Location = new System.Drawing.Point(83, 110);
		this.lblỗi.Name = "lblỗi";
		this.lblỗi.Size = new System.Drawing.Size(13, 13);
		this.lblỗi.TabIndex = 12;
		this.lblỗi.Text = "0";
		this.timer_auto_refesh.Interval = 1000;
		this.timer_auto_refesh.Tick += new System.EventHandler(timer1_Tick<T10, T6, T7>);
		this.txtCatePage.Location = new System.Drawing.Point(323, 32);
		this.txtCatePage.Name = "txtCatePage";
		this.txtCatePage.Size = new System.Drawing.Size(172, 20);
		this.txtCatePage.TabIndex = 14;
		this.txtCatePage.TextChanged += new System.EventHandler(txtCatePage_TextChanged);
		this.label7.AutoSize = true;
		this.label7.Location = new System.Drawing.Point(260, 35);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(57, 13);
		this.label7.TabIndex = 13;
		this.label7.Text = "Loại page:";
		this.numDelay.Location = new System.Drawing.Point(323, 75);
		this.numDelay.Maximum = new decimal((int[])(object)new T8[4]
		{
			(T8)1410065407,
			(T8)2,
			default(T8),
			default(T8)
		});
		this.numDelay.Name = "numDelay";
		this.numDelay.Size = new System.Drawing.Size(89, 20);
		this.numDelay.TabIndex = 16;
		this.numDelay.Value = new decimal((int[])(object)new T8[4]
		{
			(T8)1,
			default(T8),
			default(T8),
			default(T8)
		});
		this.numDelay.ValueChanged += new System.EventHandler(numDelay_ValueChanged<T9, T6, T7>);
		this.label8.AutoSize = true;
		this.label8.Location = new System.Drawing.Point(280, 77);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(37, 13);
		this.label8.TabIndex = 15;
		this.label8.Text = "Delay:";
		this.txtPhone.Location = new System.Drawing.Point(58, 57);
		this.txtPhone.Name = "txtPhone";
		this.txtPhone.Size = new System.Drawing.Size(189, 20);
		this.txtPhone.TabIndex = 18;
		this.txtPhone.TextChanged += new System.EventHandler(txtPhone_TextChanged);
		this.label9.AutoSize = true;
		this.label9.Location = new System.Drawing.Point(12, 60);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(41, 13);
		this.label9.TabIndex = 17;
		this.label9.Text = "Phone:";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(521, 151);
		base.Controls.Add(this.txtPhone);
		base.Controls.Add(this.label9);
		base.Controls.Add(this.numDelay);
		base.Controls.Add(this.label8);
		base.Controls.Add(this.txtCatePage);
		base.Controls.Add(this.label7);
		base.Controls.Add(this.lblỗi);
		base.Controls.Add(this.lbSuccess);
		base.Controls.Add(this.label6);
		base.Controls.Add(this.label5);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.txtCurrentNumber);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.numQuantity);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.txtPageId);
		base.Controls.Add(this.txtBMID);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Icon = (System.Drawing.Icon)(T11)((System.Resources.ResourceManager)val).GetObject("$this.Icon");
		base.Name = "frmCreatePageLocation";
		this.Text = "frmCreatePageLocation";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(frmCreatePageLocation_FormClosing<T10, T9, T6, T12>);
		base.Load += new System.EventHandler(frmCreatePageLocation_Load<T10, T6, T7>);
		((System.ComponentModel.ISupportInitialize)this.numQuantity).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numDelay).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
