using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ADSPRoject.Properties;
using ADSPRoject.Server;

namespace ADSPRoject;

public class frmLogin : Form
{
	private IContainer components = null;

	private Label label1;

	private Label label2;

	private TextBox txtEmail;

	private TextBox txtPassword;

	private CheckBox cbLoginSave;

	private Button button1;

	private Button button2;

	private Label label3;

	private Label label4;

	private LinkLabel linkLabel1;

	private LinkLabel linkLabel2;

	private Label label5;

	private PictureBox pictureBox2;

	public frmLogin()
	{
		InitializeComponent<ComponentResourceManager, Label, TextBox, CheckBox, Button, LinkLabel, PictureBox, int, object, MouseEventArgs, EventArgs, LinkLabelLinkClickedEventArgs, Icon, bool, FormClosingEventArgs, string, Exception, char>();
	}

	public void AppExit()
	{
		Application.Exit();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void button1_Click<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0038: Expected I4, but got O
		T0 val = ResouceControl.login<T0, HttpWebRequest, string, HttpWebResponse, StreamWriter, StreamReader, bool, Exception, Dictionary<string, string>>(txtEmail.Text, txtPassword.Text);
		T0 val2 = val;
		switch ((int)val2)
		{
		case 0:
			frmMain.errorMessage("Tài khoản của bạn đã bị Ban!");
			AppExit();
			break;
		case 1:
			licOk();
			break;
		case 2:
			frmMain.errorMessage("Sai thông tin tài khoản!");
			break;
		case 3:
			ResouceControl.UpdateTokenUser<bool, HttpWebRequest, string, HttpWebResponse, StreamWriter, StreamReader, Exception>();
			licOk();
			break;
		case 4:
			AppExit();
			break;
		}
	}

	private void licOk()
	{
		try
		{
			saveLic<string, bool, Exception>();
			frmMain.isLogined = true;
			Hide();
			frmMain frmMain2 = new frmMain();
			frmMain2.ShowDialog();
		}
		catch
		{
		}
	}

	private void button2_Click<T0, T1>(T0 sender, T1 e)
	{
		AppExit();
	}

	private void frmLogin_FormClosing<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_000d: Expected O, but got I4
		T0 val = (T0)(base.DialogResult != DialogResult.OK);
		if (val != null)
		{
			AppExit();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void saveLic<T0, T1, T2>()
	{
		//IL_0013: Expected O, but got I4
		//IL_002c: Expected O, but got I4
		//IL_0071: Expected O, but got I4
		try
		{
			T0 plainText = (T0)("||" + System.Runtime.CompilerServices.Unsafe.As<T1, bool>(ref (T1)cbLoginSave.Checked));
			T1 val = (T1)cbLoginSave.Checked;
			if (val != null)
			{
				plainText = (T0)string.Concat((string[])(object)new T0[5]
				{
					(T0)txtEmail.Text,
					(T0)"|",
					(T0)txtPassword.Text,
					(T0)"|",
					(T0)System.Runtime.CompilerServices.Unsafe.As<T1, bool>(ref (T1)cbLoginSave.Checked).ToString()
				});
			}
			File.WriteAllText("metasoft.lic", StringCipher.Encrypt((string)plainText));
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void frmLogin_Load<T0, T1, T2, T3, T4, T5>(T3 sender, T4 e)
	{
		//IL_002a: Expected O, but got I4
		//IL_005c: Expected O, but got I4
		try
		{
			Text = Text + "\t Version: " + base.ProductVersion;
			T0 val = (T0)File.Exists("metasoft.lic");
			if (val != null)
			{
				T1 cipherText = (T1)File.ReadAllText("metasoft.lic");
				cipherText = (T1)StringCipher.Decrypt((string)cipherText);
				T1[] array = (T1[])(object)((string)cipherText).Split((char[])(object)new T5[1] { (T5)124 });
				T0 val2 = (T0)(array.Count() == 3);
				if (val2 != null)
				{
					txtEmail.Text = (string)((object[])(object)array)[0];
					txtPassword.Text = (string)((object[])(object)array)[1];
					cbLoginSave.Checked = bool.Parse((string)((object[])(object)array)[2]);
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	private void cbLoginSave_MouseClick<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0007: Expected O, but got I4
		//IL_001a: Expected O, but got I4
		Console.WriteLine(System.Runtime.CompilerServices.Unsafe.As<T0, int>(ref (T0)((MouseEventArgs)e).Delta).ToString());
		Console.WriteLine(System.Runtime.CompilerServices.Unsafe.As<T0, int>(ref (T0)((MouseEventArgs)e).Clicks).ToString());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void linkLabel1_LinkClicked<T0, T1>(T0 sender, T1 e)
	{
		Process.Start("https://zalo.me/0983863222");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void linkLabel2_LinkClicked<T0, T1>(T0 sender, T1 e)
	{
		Process.Start("https://www.facebook.com/tiennv799/");
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
		T0 val = (T0)new System.ComponentModel.ComponentResourceManager(typeof(ADSPRoject.frmLogin));
		this.label1 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.label2 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtEmail = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.txtPassword = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.cbLoginSave = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.button1 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.button2 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.label3 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.label4 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.linkLabel1 = (System.Windows.Forms.LinkLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.LinkLabel));
		this.linkLabel2 = (System.Windows.Forms.LinkLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.LinkLabel));
		this.label5 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.pictureBox2 = (System.Windows.Forms.PictureBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.PictureBox));
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(38, 105);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(50, 17);
		this.label1.TabIndex = 0;
		this.label1.Text = "Email:";
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(17, 140);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(78, 17);
		this.label2.TabIndex = 1;
		this.label2.Text = "Mật khẩu:";
		this.txtEmail.Location = new System.Drawing.Point(101, 102);
		this.txtEmail.Name = "txtEmail";
		this.txtEmail.Size = new System.Drawing.Size(372, 24);
		this.txtEmail.TabIndex = 2;
		this.txtPassword.Location = new System.Drawing.Point(101, 137);
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.Size = new System.Drawing.Size(372, 24);
		this.txtPassword.TabIndex = 3;
		this.txtPassword.UseSystemPasswordChar = true;
		this.cbLoginSave.AutoSize = true;
		this.cbLoginSave.Location = new System.Drawing.Point(87, 197);
		this.cbLoginSave.Name = "cbLoginSave";
		this.cbLoginSave.Size = new System.Drawing.Size(127, 21);
		this.cbLoginSave.TabIndex = 4;
		this.cbLoginSave.Text = "Lưu thông tin";
		this.cbLoginSave.UseVisualStyleBackColor = true;
		this.cbLoginSave.MouseClick += new System.Windows.Forms.MouseEventHandler(cbLoginSave_MouseClick<T7, T8, T9>);
		this.button1.Location = new System.Drawing.Point(365, 191);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(108, 30);
		this.button1.TabIndex = 5;
		this.button1.Text = "Đăng nhập";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click<T7, T8, T10>);
		this.button2.Location = new System.Drawing.Point(265, 191);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(94, 30);
		this.button2.TabIndex = 6;
		this.button2.Text = "Hủy";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click);
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(55, 254);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(32, 17);
		this.label3.TabIndex = 7;
		this.label3.Text = "FB:";
		this.label4.AutoSize = true;
		this.label4.Location = new System.Drawing.Point(44, 237);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(44, 17);
		this.label4.TabIndex = 8;
		this.label4.Text = "Zalo:";
		this.linkLabel1.AutoSize = true;
		this.linkLabel1.Location = new System.Drawing.Point(84, 237);
		this.linkLabel1.Name = "linkLabel1";
		this.linkLabel1.Size = new System.Drawing.Size(108, 17);
		this.linkLabel1.TabIndex = 9;
		this.linkLabel1.TabStop = true;
		this.linkLabel1.Text = "0983.863.222";
		this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
		this.linkLabel2.AutoSize = true;
		this.linkLabel2.Location = new System.Drawing.Point(84, 254);
		this.linkLabel2.Name = "linkLabel2";
		this.linkLabel2.Size = new System.Drawing.Size(275, 17);
		this.linkLabel2.TabIndex = 10;
		this.linkLabel2.TabStop = true;
		this.linkLabel2.Text = "https://www.facebook.com/tiennv799";
		this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel2_LinkClicked);
		this.label5.AutoSize = true;
		this.label5.Location = new System.Drawing.Point(44, 224);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(477, 17);
		this.label5.TabIndex = 11;
		this.label5.Text = "-------------------------------------------------------------------";
		this.pictureBox2.Image = ADSPRoject.Properties.Resources.meta_logo;
		this.pictureBox2.Location = new System.Drawing.Point(41, 29);
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.Size = new System.Drawing.Size(290, 49);
		this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox2.TabIndex = 13;
		this.pictureBox2.TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(501, 283);
		base.Controls.Add(this.pictureBox2);
		base.Controls.Add(this.label5);
		base.Controls.Add(this.linkLabel2);
		base.Controls.Add(this.linkLabel1);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.cbLoginSave);
		base.Controls.Add(this.txtPassword);
		base.Controls.Add(this.txtEmail);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		this.Font = new System.Drawing.Font("Verdana", 8f);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Icon = (System.Drawing.Icon)(T12)((System.Resources.ResourceManager)val).GetObject("$this.Icon");
		base.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmLogin";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "METASOFT - www.meta-soft.tech";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(frmLogin_FormClosing<T13, T8, T14>);
		base.Load += new System.EventHandler(frmLogin_Load<T13, T15, T16, T8, T10, T17>);
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
