using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ADSPRoject.Data;
using ADSPRoject.Server;
using Newtonsoft.Json;

namespace ADSPRoject;

public class frmBMRequestAds : Form
{
	private frmMain frmMain;

	private bool isRunning = false;

	private Random rnd = (Random)Activator.CreateInstance(typeof(Random));

	private IContainer components = null;

	private Label label1;

	private TextBox txtTokenBM;

	private TextBox txtBMId;

	private Label label2;

	private Button button1;

	private Button button2;

	private Button button3;

	public frmBMRequestAds(frmMain frm)
	{
		ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
		InitializeComponent<ComponentResourceManager, Label, TextBox, Button, object, EventArgs, bool, List<pending_client_ad_accounts>.Enumerator, Exception, string, HttpWebRequest, HttpWebResponse, StreamReader, Icon, FormClosingEventArgs>();
		frmMain = frm;
	}

	private void txtTokenBM_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		frmMain.setting.txtTokenBMRequest = txtTokenBM.Text;
		frmMain.settingSaving();
	}

	private void txtBMId_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		frmMain.setting.txtBMIdRequest = txtBMId.Text;
		frmMain.settingSaving();
	}

	private void frmBMRequestAds_Load<T0, T1>(T0 sender, T1 e)
	{
		txtTokenBM.Text = frmMain.setting.txtTokenBMRequest;
		txtBMId.Text = frmMain.setting.txtBMIdRequest;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void button1_Click<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0016: Expected O, but got I4
		isRunning = !isRunning;
		T0 val = (T0)isRunning;
		if (val != null)
		{
			T0 val2 = checkToken<T0, string, HttpWebRequest, HttpWebResponse, StreamReader>();
			if (val2 != null)
			{
				button1.Text = "STOP";
				button1.ForeColor = Color.Red;
				new Thread(thrRequest<List<TKCNEntity>, T0, List<TKCNEntity>.Enumerator, string, HttpWebRequest, HttpWebResponse, StreamReader, Exception>).Start();
			}
			else
			{
				isRunning = false;
				frmMain.errorMessage("Token die!");
			}
		}
		else
		{
			button1.Text = "START";
			button1.ForeColor = Color.Blue;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private T0 checkToken<T0, T1, T2, T3, T4>()
	{
		//IL_0002: Expected O, but got I4
		//IL_0089: Expected O, but got I4
		//IL_008f: Expected O, but got I4
		//IL_0094: Expected O, but got I4
		T0 result = (T0)1;
		try
		{
			T1 requestUriString = (T1)(ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL_V13") + "me?access_token=" + frmMain.setting.txtTokenBMRequest);
			T2 val = (T2)WebRequest.Create((string)requestUriString);
			((WebRequest)val).Method = "GET";
			((WebRequest)val).ContentType = "application/x-www-form-urlencoded";
			T3 val2 = (T3)((WebRequest)val).GetResponse();
			T4 val3 = (T4)new StreamReader(((WebResponse)val2).GetResponseStream());
			T1 val4;
			try
			{
				val4 = (T1)((TextReader)val3).ReadToEnd();
			}
			finally
			{
				if (val3 != null)
				{
					((IDisposable)val3).Dispose();
				}
			}
			T0 val5 = (T0)(!((string)val4).Contains("name"));
			if (val5 != null)
			{
				result = (T0)0;
			}
		}
		catch
		{
			result = (T0)0;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private get_pending_client_ad_accounts pending_client_ad_accounts<T0, T1, T2, T3, T4, T5>()
	{
		//IL_00a4: Expected O, but got I4
		try
		{
			T0 requestUriString = (T0)(ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL_V13") + frmMain.setting.txtBMIdRequest + "/pending_client_ad_accounts?access_token=" + frmMain.setting.txtTokenBMRequest);
			T1 val = (T1)WebRequest.Create((string)requestUriString);
			((WebRequest)val).Method = "GET";
			((WebRequest)val).ContentType = "application/x-www-form-urlencoded";
			T2 val2 = (T2)((WebRequest)val).GetResponse();
			T3 val3 = (T3)new StreamReader(((WebResponse)val2).GetResponseStream());
			T0 val4;
			try
			{
				val4 = (T0)((TextReader)val3).ReadToEnd();
			}
			finally
			{
				if (val3 != null)
				{
					((IDisposable)val3).Dispose();
				}
			}
			get_pending_client_ad_accounts get_pending_client_ad_accounts = JsonConvert.DeserializeObject<get_pending_client_ad_accounts>((string)val4);
			T4 val5 = (T4)(get_pending_client_ad_accounts.data != null && get_pending_client_ad_accounts.data.Count > 0);
			if (val5 != null)
			{
				return get_pending_client_ad_accounts;
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void thrRequest<T0, T1, T2, T3, T4, T5, T6, T7>()
	{
		//IL_003f: Expected O, but got I4
		//IL_0079: Expected O, but got I4
		//IL_008f: Expected O, but got I4
		//IL_00e7: Expected O, but got I4
		while (true)
		{
			T1 val = (T1)isRunning;
			if (val == null)
			{
				break;
			}
			T0 val2 = (T0)((IEnumerable<TKCNEntity>)frmMain.listTKCN).Where((Func<TKCNEntity, bool>)((TKCNEntity a) => (T1)(a.Status == 0))).ToList();
			T1 val3 = (T1)(((List<TKCNEntity>)val2).Count > 0);
			if (val3 != null)
			{
				T2 enumerator = (T2)((List<TKCNEntity>)val2).GetEnumerator();
				try
				{
					while (((List<TKCNEntity>.Enumerator*)(&enumerator))->MoveNext())
					{
						TKCNEntity current = ((List<TKCNEntity>.Enumerator*)(&enumerator))->Current;
						while (true)
						{
							T1 val4 = (T1)isRunning;
							if (val4 == null)
							{
								break;
							}
							get_pending_client_ad_accounts get_pending_client_ad_accounts = pending_client_ad_accounts<T3, T4, T5, T6, T1, T7>();
							T1 val5 = (T1)(get_pending_client_ad_accounts == null || get_pending_client_ad_accounts.data.Count < 2);
							if (val5 != null)
							{
								break;
							}
							Thread.Sleep(5000);
						}
						T1 val6 = RequestTKCN<T1, T3, T4, T5, StreamWriter, T6>((T3)current.Act_Id.Replace("act_", ""));
						if (val6 != null)
						{
							current.Status = 1;
						}
					}
				}
				finally
				{
					((IDisposable)(*(List<TKCNEntity>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			Thread.Sleep(3000);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private T0 RequestTKCN<T0, T1, T2, T3, T4, T5>(T1 act)
	{
		//IL_0002: Expected O, but got I4
		//IL_00e6: Expected O, but got I4
		//IL_00ec: Expected O, but got I4
		//IL_00f1: Expected O, but got I4
		T0 result = (T0)1;
		try
		{
			T1 requestUriString = (T1)string.Concat((string[])(object)new T1[5]
			{
				(T1)ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL_V13"),
				(T1)frmMain.setting.txtBMIdRequest,
				(T1)"/client_ad_accounts?access_token=",
				(T1)frmMain.setting.txtTokenBMRequest,
				(T1)"&__cppo=1"
			});
			T2 val = (T2)WebRequest.Create((string)requestUriString);
			((WebRequest)val).Method = "POST";
			((WebRequest)val).ContentType = "application/x-www-form-urlencoded";
			T1 value = (T1)("_reqName=object%3Abrand%2Fclient_ad_accounts&_reqSrc=AdAccountActions.brands&access_type=AGENCY&adaccount_id=act_" + (string)act + "&locale=en_US&method=post&permitted_roles=%5B%5D&permitted_tasks=%5B%22ADVERTISE%22%2C%22ANALYZE%22%2C%22DRAFT%22%2C%22MANAGE%22%5D&pretty=0&suppress_http_code=1&xref=f313f2a06b7d7ac");
			T4 val2 = (T4)new StreamWriter(((WebRequest)val).GetRequestStream());
			try
			{
				((TextWriter)val2).Write((string)value);
			}
			finally
			{
				if (val2 != null)
				{
					((IDisposable)val2).Dispose();
				}
			}
			T3 val3 = (T3)((WebRequest)val).GetResponse();
			T5 val4 = (T5)new StreamReader(((WebResponse)val3).GetResponseStream());
			T1 val5;
			try
			{
				val5 = (T1)((TextReader)val4).ReadToEnd();
			}
			finally
			{
				if (val4 != null)
				{
					((IDisposable)val4).Dispose();
				}
			}
			T0 val6 = (T0)(!((string)val5).Contains("PENDING"));
			if (val6 != null)
			{
				result = (T0)0;
			}
		}
		catch
		{
			result = (T0)0;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private T0 ChangeNameTKCN<T0, T1, T2, T3, T4, T5, T6>(T1 act)
	{
		//IL_0002: Expected O, but got I4
		//IL_008a: Expected O, but got I4
		//IL_0147: Expected O, but got I4
		//IL_014d: Expected O, but got I4
		//IL_0152: Expected O, but got I4
		T0 result = (T0)1;
		try
		{
			T1 requestUriString = (T1)string.Concat((string[])(object)new T1[6]
			{
				(T1)ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL_V13"),
				(T1)"act_",
				act,
				(T1)"?access_token=",
				(T1)frmMain.setting.txtTokenBMRequest,
				(T1)"&__cppo=1"
			});
			T2 val = (T2)WebRequest.Create((string)requestUriString);
			((WebRequest)val).Method = "POST";
			T1 val2 = (T1)$"{frmMain.setting.txtNameTKCN} {(T6)rnd.Next(1111, 9999)}";
			val2 = (T1)((string)val2).Replace(" ", "%20");
			((WebRequest)val).ContentType = "application/x-www-form-urlencoded";
			T1 value = (T1)string.Concat((string[])(object)new T1[5]
			{
				(T1)"_reqName=adaccount&_reqSrc=AdAccountActions.brands&accountId=",
				act,
				(T1)"&invoicing_emails=%5B%5D&locale=en_US&method=post&name=",
				val2,
				(T1)"&pretty=0&suppress_http_code=1&xref=f270ca9ef26d578"
			});
			T4 val3 = (T4)new StreamWriter(((WebRequest)val).GetRequestStream());
			try
			{
				((TextWriter)val3).Write((string)value);
			}
			finally
			{
				if (val3 != null)
				{
					((IDisposable)val3).Dispose();
				}
			}
			T3 val4 = (T3)((WebRequest)val).GetResponse();
			T5 val5 = (T5)new StreamReader(((WebResponse)val4).GetResponseStream());
			T1 val6;
			try
			{
				val6 = (T1)((TextReader)val5).ReadToEnd();
			}
			finally
			{
				if (val5 != null)
				{
					((IDisposable)val5).Dispose();
				}
			}
			T0 val7 = (T0)(!((string)val6).Contains("PENDING"));
			if (val7 != null)
			{
				result = (T0)0;
			}
		}
		catch
		{
			result = (T0)0;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void button2_Click<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T3 sender, T4 e)
	{
		//IL_0018: Expected O, but got I4
		try
		{
			get_pending_client_ad_accounts get_pending_client_ad_accounts = pending_client_ad_accounts<T5, T6, T7, T8, T0, T2>();
			T0 val = (T0)(get_pending_client_ad_accounts != null && get_pending_client_ad_accounts.data != null);
			if (val != null)
			{
				T1 enumerator = (T1)get_pending_client_ad_accounts.data.GetEnumerator();
				try
				{
					while (((List<pending_client_ad_accounts>.Enumerator*)(&enumerator))->MoveNext())
					{
						pending_client_ad_accounts current = ((List<pending_client_ad_accounts>.Enumerator*)(&enumerator))->Current;
						clearActPending<T0, T5, T6, T7, StreamWriter, T8>((T5)current.id.Replace("act_", ""));
					}
				}
				finally
				{
					((IDisposable)(*(List<pending_client_ad_accounts>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			frmMain.infoMessage((T5)"Done!");
		}
		catch (Exception ex)
		{
			frmMain.errorMessage((T5)ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private T0 clearActPending<T0, T1, T2, T3, T4, T5>(T1 act)
	{
		//IL_0002: Expected O, but got I4
		//IL_00e6: Expected O, but got I4
		//IL_00ec: Expected O, but got I4
		//IL_00f1: Expected O, but got I4
		T0 result = (T0)1;
		try
		{
			T1 requestUriString = (T1)string.Concat((string[])(object)new T1[5]
			{
				(T1)ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL_V13"),
				(T1)frmMain.setting.txtBMIdRequest,
				(T1)"/adaccounts?access_token=",
				(T1)frmMain.setting.txtTokenBMRequest,
				(T1)"&__cppo=1"
			});
			T2 val = (T2)WebRequest.Create((string)requestUriString);
			((WebRequest)val).Method = "POST";
			((WebRequest)val).ContentType = "application/x-www-form-urlencoded";
			T1 value = (T1)("_reqName=object%3Abrand%2Fadaccounts&_reqSrc=AdAccountActions.brands&adaccount_id=act_" + (string)act + "&locale=en_US&method=delete&pretty=0&suppress_http_code=1&xref=f20db5b18b5d954");
			T4 val2 = (T4)new StreamWriter(((WebRequest)val).GetRequestStream());
			try
			{
				((TextWriter)val2).Write((string)value);
			}
			finally
			{
				if (val2 != null)
				{
					((IDisposable)val2).Dispose();
				}
			}
			T3 val3 = (T3)((WebRequest)val).GetResponse();
			T5 val4 = (T5)new StreamReader(((WebResponse)val3).GetResponseStream());
			T1 val5;
			try
			{
				val5 = (T1)((TextReader)val4).ReadToEnd();
			}
			finally
			{
				if (val4 != null)
				{
					((IDisposable)val4).Dispose();
				}
			}
			T0 val6 = (T0)(!((string)val5).Contains("true"));
			if (val6 != null)
			{
				result = (T0)0;
			}
		}
		catch
		{
			result = (T0)0;
		}
		return result;
	}

	private void frmBMRequestAds_FormClosing<T0, T1>(T0 sender, T1 e)
	{
		isRunning = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void button3_Click<T0, T1, T2, T3, T4, T5, T6>(T1 sender, T2 e)
	{
		T0 val = checkToken<T0, T3, T4, T5, T6>();
		if (val != null)
		{
			frmMain.infoMessage((T3)"Token live!");
		}
		else
		{
			frmMain.errorMessage((T3)"Token die!");
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
	private void InitializeComponent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
	{
		T0 val = (T0)new System.ComponentModel.ComponentResourceManager(typeof(ADSPRoject.frmBMRequestAds));
		this.label1 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtTokenBM = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.txtBMId = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label2 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.button1 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.button2 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.button3 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(16, 15);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(41, 13);
		this.label1.TabIndex = 0;
		this.label1.Text = "Token:";
		this.txtTokenBM.Location = new System.Drawing.Point(63, 12);
		this.txtTokenBM.Name = "txtTokenBM";
		this.txtTokenBM.Size = new System.Drawing.Size(314, 20);
		this.txtTokenBM.TabIndex = 1;
		this.txtTokenBM.TextChanged += new System.EventHandler(txtTokenBM_TextChanged);
		this.txtBMId.Location = new System.Drawing.Point(63, 38);
		this.txtBMId.Name = "txtBMId";
		this.txtBMId.Size = new System.Drawing.Size(236, 20);
		this.txtBMId.TabIndex = 3;
		this.txtBMId.TextChanged += new System.EventHandler(txtBMId_TextChanged);
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(16, 41);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(38, 13);
		this.label2.TabIndex = 2;
		this.label2.Text = "BM Id:";
		this.button1.ForeColor = System.Drawing.Color.Blue;
		this.button1.Location = new System.Drawing.Point(383, 107);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(75, 36);
		this.button1.TabIndex = 4;
		this.button1.Text = "START";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click<T6, T4, T5>);
		this.button2.ForeColor = System.Drawing.Color.Blue;
		this.button2.Location = new System.Drawing.Point(19, 107);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(91, 36);
		this.button2.TabIndex = 5;
		this.button2.Text = "Clear Request Pending";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click<T6, T7, T8, T4, T5, T9, T10, T11, T12>);
		this.button3.Location = new System.Drawing.Point(383, 10);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(75, 23);
		this.button3.TabIndex = 6;
		this.button3.Text = "check";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(button3_Click<T6, T4, T5, T9, T10, T11, T12>);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(470, 155);
		base.Controls.Add(this.button3);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.txtBMId);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.txtTokenBM);
		base.Controls.Add(this.label1);
		base.Icon = (System.Drawing.Icon)(T13)((System.Resources.ResourceManager)val).GetObject("$this.Icon");
		base.Name = "frmBMRequestAds";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Business Manager";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(frmBMRequestAds_FormClosing);
		base.Load += new System.EventHandler(frmBMRequestAds_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
