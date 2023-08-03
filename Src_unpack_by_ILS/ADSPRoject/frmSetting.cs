using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ADSPRoject.Data;
using ADSPRoject.Server;
using xNet;

namespace ADSPRoject;

public class frmSetting : Form
{
	private frmMain frmMain;

	private IContainer components = null;

	private Label label1;

	private TextBox txtColumnDisplay;

	private TextBox textBox1;

	private TabControl tabControl1;

	private TabPage tabMenu;

	private TabPage tabVoHan;

	private TextBox txtIDTKQCAddCardNolimit;

	private Label label5;

	private DataGridView gvTokenTKQC;

	private TabPage tabPage;

	private DataGridView gvTokenNhanPage;

	private TabPage tabPixel;

	private TextBox txtPixel_Id;

	private Label label3;

	private DataGridView gvTokenPixel;

	private TextBox txtBM_Pixel_ID;

	private Label label6;

	private Button button1;

	private TextBox txtIDTK;

	private Label label7;

	private TabPage tabTokenBM;

	private DataGridView gvBM;

	private TextBox txtIDBMAddCardNolimit;

	private Label label4;

	private ImageList imageList1;

	private TabPage tabPagePartner;

	private TextBox txtPageID_Partner;

	private Label label9;

	private DataGridView gvPagePartner;

	private TextBox txtBMID_PagePartner;

	private Label label8;

	private TextBox txtBMIDTestPagePartner;

	private Label label10;

	private TextBox txtProfile;

	private Label label2;

	private CheckBox cbSaveBackup;

	private TabPage tabPage1;

	private Panel panel1;

	private RadioButton rbOffProfersional;

	private RadioButton rbOnProfersional;

	private Label label11;

	private GroupBox groupBox1;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public frmSetting(frmMain main)
	{
		Control.CheckForIllegalCrossThreadCalls = false;
		InitializeComponent<ComponentResourceManager, Container, Label, TextBox, TabControl, TabPage, DataGridView, Button, CheckBox, Panel, RadioButton, GroupBox, object, EventArgs, bool, ContextMenu, MenuItem, MouseEventArgs, string, int, List<TokenEntity>.Enumerator, char, DataGridViewCellEventArgs, ImageListStreamer, Icon>();
		frmMain = main;
		ResouceControl.RESOUCE_VERSION = "ResouceV2";
		ResouceControl.API_URL = "https://api.meta-soft.tech/";
	}

	private void save()
	{
		frmMain.setting.ColumnDisplay = txtColumnDisplay.Text;
		frmMain.settingSaving();
	}

	private void frmSetting_Load<T0, T1>(T0 sender, T1 e)
	{
		rbOnProfersional.Checked = frmMain.setting.isOnProfersional;
		rbOffProfersional.Checked = !frmMain.setting.isOnProfersional;
		txtColumnDisplay.Text = frmMain.setting.ColumnDisplay;
		txtIDBMAddCardNolimit.Text = frmMain.TokenNolimit.ID_BM;
		txtIDTKQCAddCardNolimit.Text = frmMain.TokenNolimit.ID_TKQC;
		txtPixel_Id.Text = frmMain.setting.Pixel_Id;
		txtBM_Pixel_ID.Text = frmMain.setting.BM_Pixel_ID;
		gvBM.DataSource = frmMain.TokenNolimit.List_TOKEN_BM;
		gvTokenTKQC.DataSource = frmMain.TokenNolimit.List_TOKEN_TKQC;
		gvTokenNhanPage.DataSource = frmMain.setting.List_TOKEN_PAGE;
		gvTokenPixel.DataSource = frmMain.setting.List_TOKEN_PIXEL;
		txtBMID_PagePartner.Text = frmMain.setting.txtBMID_PagePartner;
		txtPageID_Partner.Text = frmMain.setting.txtPageID_Partner;
		txtBMIDTestPagePartner.Text = frmMain.setting.txtBMIDTestPagePartner;
		gvPagePartner.DataSource = frmMain.setting.List_TOKEN_PAGE_PARTNER;
		txtProfile.Text = frmMain.setting.txtProfile;
		cbSaveBackup.Checked = frmMain.setting.cbSaveBackup;
	}

	private void button1_Click<T0, T1>(T0 sender, T1 e)
	{
		save();
		Close();
	}

	private void button2_Click<T0, T1>(T0 sender, T1 e)
	{
		Close();
	}

	private void textBox1_TextChanged<T0, T1>(T0 sender, T1 e)
	{
	}

	private void txtIDTKQCAddCardNolimit_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		frmMain.TokenNolimit.ID_TKQC = txtIDTKQCAddCardNolimit.Text;
		frmMain.saveTokenNolimit();
	}

	private void txtIDBMAddCardNolimit_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		frmMain.TokenNolimit.ID_BM = txtIDBMAddCardNolimit.Text;
		frmMain.saveTokenNolimit();
	}

	private void button4_Click<T0, T1>(T0 sender, T1 e)
	{
	}

	private void button6_Click<T0, T1>(T0 sender, T1 e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gvTokenTKQC_MouseClick<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_000e: Expected O, but got I4
		T0 val = (T0)(((MouseEventArgs)e).Button == MouseButtons.Right);
		if (val != null)
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(ContextMenu));
			T2 item = (T2)new MenuItem("Paste Cookie|Token", (EventHandler)pasteTokenTKQCEvent<string, int, T0, T3, EventArgs, char>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			T2 item2 = (T2)new MenuItem("Xóa toàn bộ", (EventHandler)deleteTokenTKQCEvent<T0, T3, EventArgs, DialogResult, string>);
			((Menu)val2).MenuItems.Add((MenuItem)item2);
			((ContextMenu)val2).Show((Control)gvTokenTKQC, new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pasteTokenTKQCEvent<T0, T1, T2, T3, T4, T5>(T3 sender, T4 e)
	{
		//IL_001d: Expected O, but got I4
		//IL_005e: Expected O, but got I4
		//IL_0137: Expected O, but got I4
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Expected O, but got Unknown
		T0 val = (T0)Clipboard.GetText();
		T0[] array = (T0[])(object)((string)val).Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
		T0[] array2 = array;
		T1 val2 = (T1)0;
		while ((nint)val2 < array2.Length)
		{
			T0 val3 = (T0)((object[])(object)array2)[(object)val2];
			T2 val4 = (T2)(!string.IsNullOrWhiteSpace((string)val3) && ((string)val3).Contains("|") && ((IEnumerable<T0>)(object)((string)val3).Split((char[])(object)new T5[1] { (T5)124 })).Count() == 3);
			if (val4 != null)
			{
				frmMain.TokenNolimit.List_TOKEN_TKQC.Add(new TokenEntity
				{
					UID = ((string)val3).Split((char[])(object)new T5[1] { (T5)124 })[0].Trim(),
					Token = ((string)val3).Split((char[])(object)new T5[1] { (T5)124 })[2].Trim(),
					Cookie = ((string)val3).Split((char[])(object)new T5[1] { (T5)124 })[1].Trim(),
					Status = frmMain.STATUS.Live.ToString()
				});
			}
			else
			{
				T2 val5 = (T2)(!string.IsNullOrWhiteSpace((string)val3) && ((string)val3).Contains("|") && ((IEnumerable<T0>)(object)((string)val3).Split((char[])(object)new T5[1] { (T5)124 })).Count() == 2);
				if (val5 != null)
				{
					frmMain.TokenNolimit.List_TOKEN_TKQC.Add(new TokenEntity
					{
						UID = Regex.Match(((string)val3).Split((char[])(object)new T5[1] { (T5)124 })[0].Trim(), "c_user=(.*?);").Groups[1].Value,
						Token = ((string)val3).Split((char[])(object)new T5[1] { (T5)124 })[1].Trim(),
						Cookie = ((string)val3).Split((char[])(object)new T5[1] { (T5)124 })[0].Trim(),
						Status = frmMain.STATUS.Live.ToString()
					});
				}
			}
			val2 = (T1)(val2 + 1);
		}
		gvTokenTKQC.DataSource = null;
		gvTokenTKQC.DataSource = frmMain.TokenNolimit.List_TOKEN_TKQC;
		frmMain.saveTokenNolimit();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void deleteTokenTKQCEvent<T0, T1, T2, T3, T4>(T1 sender, T2 e)
	{
		//IL_000f: Expected O, but got I4
		T0 val = (T0)((nint)frmMain.questioniMessage<T3, T4>((T4)"Bạn muốn xóa toàn bộ?") == 6);
		if (val != null)
		{
			frmMain.TokenNolimit.List_TOKEN_TKQC.Clear();
			gvTokenTKQC.DataSource = null;
			gvTokenTKQC.DataSource = frmMain.TokenNolimit.List_TOKEN_TKQC;
			frmMain.saveTokenNolimit();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gvBM_MouseClick<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_000e: Expected O, but got I4
		T0 val = (T0)(((MouseEventArgs)e).Button == MouseButtons.Right);
		if (val != null)
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(ContextMenu));
			T2 item = (T2)new MenuItem("Paste Cookie|Token", (EventHandler)pasteTokenBMEvent<string, int, T0, T3, EventArgs, char>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			T2 item2 = (T2)new MenuItem("Xóa toàn bộ", (EventHandler)deleteBMEvent<T0, T3, EventArgs, DialogResult, string>);
			((Menu)val2).MenuItems.Add((MenuItem)item2);
			((ContextMenu)val2).Show((Control)gvBM, new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pasteTokenBMEvent<T0, T1, T2, T3, T4, T5>(T3 sender, T4 e)
	{
		//IL_001d: Expected O, but got I4
		//IL_005e: Expected O, but got I4
		//IL_0137: Expected O, but got I4
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Expected O, but got Unknown
		T0 val = (T0)Clipboard.GetText();
		T0[] array = (T0[])(object)((string)val).Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
		T0[] array2 = array;
		T1 val2 = (T1)0;
		while ((nint)val2 < array2.Length)
		{
			T0 val3 = (T0)((object[])(object)array2)[(object)val2];
			T2 val4 = (T2)(!string.IsNullOrWhiteSpace((string)val3) && ((string)val3).Contains("|") && ((IEnumerable<T0>)(object)((string)val3).Split((char[])(object)new T5[1] { (T5)124 })).Count() == 3);
			if (val4 != null)
			{
				frmMain.TokenNolimit.List_TOKEN_BM.Add(new TokenEntity
				{
					UID = ((string)val3).Split((char[])(object)new T5[1] { (T5)124 })[0].Trim(),
					Token = ((string)val3).Split((char[])(object)new T5[1] { (T5)124 })[2].Trim(),
					Cookie = ((string)val3).Split((char[])(object)new T5[1] { (T5)124 })[1].Trim(),
					Status = frmMain.STATUS.Live.ToString()
				});
			}
			else
			{
				T2 val5 = (T2)(!string.IsNullOrWhiteSpace((string)val3) && ((string)val3).Contains("|") && ((IEnumerable<T0>)(object)((string)val3).Split((char[])(object)new T5[1] { (T5)124 })).Count() == 2);
				if (val5 != null)
				{
					frmMain.TokenNolimit.List_TOKEN_BM.Add(new TokenEntity
					{
						UID = Regex.Match(((string)val3).Split((char[])(object)new T5[1] { (T5)124 })[0].Trim(), "c_user=(.*?);").Groups[1].Value,
						Token = ((string)val3).Split((char[])(object)new T5[1] { (T5)124 })[1].Trim(),
						Cookie = ((string)val3).Split((char[])(object)new T5[1] { (T5)124 })[0].Trim(),
						Status = frmMain.STATUS.Live.ToString()
					});
				}
			}
			val2 = (T1)(val2 + 1);
		}
		gvBM.DataSource = null;
		gvBM.DataSource = frmMain.TokenNolimit.List_TOKEN_BM;
		frmMain.saveTokenNolimit();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void deleteBMEvent<T0, T1, T2, T3, T4>(T1 sender, T2 e)
	{
		//IL_000f: Expected O, but got I4
		T0 val = (T0)((nint)frmMain.questioniMessage<T3, T4>((T4)"Bạn muốn xóa toàn bộ?") == 6);
		if (val != null)
		{
			frmMain.TokenNolimit.List_TOKEN_BM.Clear();
			gvBM.DataSource = null;
			gvBM.DataSource = frmMain.TokenNolimit.List_TOKEN_BM;
			frmMain.saveTokenNolimit();
		}
	}

	private void gvTokenTKQC_CellEndEdit<T0, T1>(T0 sender, T1 e)
	{
		frmMain.saveTokenNolimit();
	}

	private void gvBM_CellEndEdit<T0, T1>(T0 sender, T1 e)
	{
		frmMain.saveTokenNolimit();
	}

	private void txtColumnDisplay_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		save();
	}

	private void txtToken_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		save();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gvTokenNhanPage_MouseClick<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_000e: Expected O, but got I4
		T0 val = (T0)(((MouseEventArgs)e).Button == MouseButtons.Right);
		if (val != null)
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(ContextMenu));
			T2 item = (T2)new MenuItem("Paste UID|Token Cookie|(EEAG)", (EventHandler)pasteTokenPageEvent<string, int, T0, T3, EventArgs, char>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			T2 item2 = (T2)new MenuItem("Xóa toàn bộ", (EventHandler)deleteTokenPageEvent<T0, T3, EventArgs, DialogResult, string>);
			((Menu)val2).MenuItems.Add((MenuItem)item2);
			((ContextMenu)val2).Show((Control)gvTokenNhanPage, new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pasteTokenPageEvent<T0, T1, T2, T3, T4, T5>(T3 sender, T4 e)
	{
		//IL_001d: Expected O, but got I4
		//IL_005e: Expected O, but got I4
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected O, but got Unknown
		T0 val = (T0)Clipboard.GetText();
		T0[] array = (T0[])(object)((string)val).Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
		T0[] array2 = array;
		T1 val2 = (T1)0;
		while ((nint)val2 < array2.Length)
		{
			T0 val3 = (T0)((object[])(object)array2)[(object)val2];
			T2 val4 = (T2)(!string.IsNullOrWhiteSpace((string)val3) && ((string)val3).Contains("|") && ((IEnumerable<T0>)(object)((string)val3).Split((char[])(object)new T5[1] { (T5)124 })).Count() == 3);
			if (val4 != null)
			{
				frmMain.setting.List_TOKEN_PAGE.Add(new TokenEntity
				{
					UID = ((string)val3).Split((char[])(object)new T5[1] { (T5)124 })[0].Trim(),
					Token = ((string)val3).Split((char[])(object)new T5[1] { (T5)124 })[2].Trim(),
					Cookie = ((string)val3).Split((char[])(object)new T5[1] { (T5)124 })[1].Trim(),
					Status = frmMain.STATUS.Live.ToString()
				});
			}
			else
			{
				frmMain.setting.List_TOKEN_PAGE.Add(new TokenEntity
				{
					UID = Regex.Match(((string)val3).Split((char[])(object)new T5[1] { (T5)124 })[0].Trim(), "c_user=(.*?);").Groups[1].Value,
					Token = ((string)val3).Split((char[])(object)new T5[1] { (T5)124 })[1].Trim(),
					Cookie = ((string)val3).Split((char[])(object)new T5[1] { (T5)124 })[0].Trim(),
					Status = frmMain.STATUS.Live.ToString()
				});
			}
			val2 = (T1)(val2 + 1);
		}
		gvTokenNhanPage.DataSource = null;
		gvTokenNhanPage.DataSource = frmMain.setting.List_TOKEN_PAGE;
		frmMain.settingSaving();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void deleteTokenPageEvent<T0, T1, T2, T3, T4>(T1 sender, T2 e)
	{
		//IL_000f: Expected O, but got I4
		T0 val = (T0)((nint)frmMain.questioniMessage<T3, T4>((T4)"Bạn muốn xóa toàn bộ?") == 6);
		if (val != null)
		{
			frmMain.setting.List_TOKEN_PAGE.Clear();
			gvTokenNhanPage.DataSource = null;
			frmMain.settingSaving();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gvTokenPixel_MouseClick<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_000e: Expected O, but got I4
		T0 val = (T0)(((MouseEventArgs)e).Button == MouseButtons.Right);
		if (val != null)
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(ContextMenu));
			T2 item = (T2)new MenuItem("Paste Token EAAd", (EventHandler)pasteTokenPixelEvent<string, int, T0, T3, EventArgs, char>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			T2 item2 = (T2)new MenuItem("Xóa toàn bộ", (EventHandler)deleteTokenPixelEvent<T0, T3, EventArgs, DialogResult, string>);
			((Menu)val2).MenuItems.Add((MenuItem)item2);
			((ContextMenu)val2).Show((Control)gvTokenPixel, new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pasteTokenPixelEvent<T0, T1, T2, T3, T4, T5>(T3 sender, T4 e)
	{
		//IL_001d: Expected O, but got I4
		//IL_003f: Expected O, but got I4
		//IL_005a: Expected O, but got I4
		//IL_0072: Expected O, but got I4
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		T0 val = (T0)Clipboard.GetText();
		T0[] array = (T0[])(object)((string)val).Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
		T0[] array2 = array;
		T1 val2 = (T1)0;
		while ((nint)val2 < array2.Length)
		{
			T0 val3 = (T0)((object[])(object)array2)[(object)val2];
			T0 token = (T0)((string)val3).Trim();
			T2 val4 = (T2)((string)val3).Contains("|");
			if (val4 != null)
			{
				T0[] array3 = (T0[])(object)((string)val3).Split((char[])(object)new T5[1] { (T5)124 });
				T1 val5 = (T1)0;
				while ((nint)val5 < array3.Length)
				{
					T0 val6 = (T0)((object[])(object)array3)[(object)val5];
					T2 val7 = (T2)((string)val6).Contains("EAA");
					if (val7 == null)
					{
						val5 = (T1)(val5 + 1);
						continue;
					}
					token = (T0)((string)val6).Trim();
					break;
				}
			}
			frmMain.setting.List_TOKEN_PIXEL.Add(new TokenEntity
			{
				UID = "",
				Token = (string)token,
				Cookie = "",
				Status = frmMain.STATUS.Live.ToString()
			});
			val2 = (T1)(val2 + 1);
		}
		gvTokenPixel.DataSource = null;
		gvTokenPixel.DataSource = frmMain.setting.List_TOKEN_PIXEL;
		frmMain.settingSaving();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void deleteTokenPixelEvent<T0, T1, T2, T3, T4>(T1 sender, T2 e)
	{
		//IL_000f: Expected O, but got I4
		T0 val = (T0)((nint)frmMain.questioniMessage<T3, T4>((T4)"Bạn muốn xóa toàn bộ?") == 6);
		if (val != null)
		{
			frmMain.setting.List_TOKEN_PIXEL.Clear();
			gvTokenPixel.DataSource = null;
			frmMain.settingSaving();
		}
	}

	private void txtPixel_Id_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		frmMain.setting.Pixel_Id = txtPixel_Id.Text;
		frmMain.settingSaving();
	}

	private void txtBM_Pixel_ID_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		frmMain.setting.BM_Pixel_ID = txtBM_Pixel_ID.Text;
		frmMain.settingSaving();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void button1_Click_1<T0, T1, T2, T3, T4, T5, T6>(T4 sender, T5 e)
	{
		//IL_0002: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0034: Expected O, but got I4
		//IL_0077: Expected O, but got I4
		//IL_00ba: Expected O, but got I4
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		T0 val = (T0)1;
		T1[] array = (T1[])(object)txtIDTK.Text.Split((char[])(object)new T6[1] { (T6)124 });
		T2 val2 = (T2)0;
		while ((nint)val2 < array.Length)
		{
			T1 val3 = (T1)((object[])(object)array)[(object)val2];
			T0 val4 = (T0)(!string.IsNullOrWhiteSpace((string)val3));
			if (val4 != null)
			{
				T3 enumerator = (T3)frmMain.setting.List_TOKEN_PIXEL.GetEnumerator();
				try
				{
					while (((List<TokenEntity>.Enumerator*)(&enumerator))->MoveNext())
					{
						TokenEntity current = ((List<TokenEntity>.Enumerator*)(&enumerator))->Current;
						T0 val5 = (T0)current.Status.Equals(frmMain.STATUS.Live.ToString());
						if (val5 != null)
						{
							T0 val6 = frmMain.apiPixel.Share_Pixel<T0, T2, T1, Exception, HttpRequest>((T1)current.Token, (T1)frmMain.setting.BM_Pixel_ID, (T1)frmMain.setting.Pixel_Id, val3);
							if (val6 == null)
							{
								val = (T0)0;
							}
							break;
						}
					}
				}
				finally
				{
					((IDisposable)(*(List<TokenEntity>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			val2 = (T2)(val2 + 1);
		}
		T0 val7 = val;
		if (val7 != null)
		{
			MessageBox.Show("Share thành công!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		else
		{
			MessageBox.Show("Share lỗi!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void txtIDTK_TextChanged<T0, T1>(T0 sender, T1 e)
	{
	}

	private void txtBMID_PagePartner_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		frmMain.setting.txtBMID_PagePartner = txtBMID_PagePartner.Text;
		frmMain.settingSaving();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void txtPageID_Partner_TextChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		T0 val = (T0)txtPageID_Partner.Text.Replace(",", "|").Replace(".", "|");
		frmMain.setting.txtPageID_Partner = (string)val;
		frmMain.settingSaving();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gvPagePartner_MouseClick<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_000e: Expected O, but got I4
		T0 val = (T0)(((MouseEventArgs)e).Button == MouseButtons.Right);
		if (val != null)
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(ContextMenu));
			T2 item = (T2)new MenuItem("Paste Cookie|Token", (EventHandler)pasteTokenPagePartnerEvent<string, int, T0, Exception, T3, EventArgs, char>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Test share đối tác BM: " + frmMain.setting.txtBMIDTestPagePartner, (EventHandler)testTokenPagePartnerEvent<List<DataGridViewRow>, T0, int, string, T3, EventArgs, DataGridViewRow, char>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			T2 item2 = (T2)new MenuItem("Xóa toàn bộ", (EventHandler)deleteTokenPagePartnerEvent<T0, T3, EventArgs, DialogResult, string>);
			((Menu)val2).MenuItems.Add((MenuItem)item2);
			((ContextMenu)val2).Show((Control)gvPagePartner, new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void testTokenPagePartnerEvent<T0, T1, T2, T3, T4, T5, T6, T7>(T4 sender, T5 e)
	{
		//IL_0068: Expected O, but got I4
		//IL_0070: Expected O, but got I4
		//IL_0072: Expected O, but got I4
		//IL_00ce: Expected O, but got I4
		//IL_00d5: Expected O, but got I4
		//IL_00e7: Expected I4, but got O
		//IL_0101: Expected O, but got I4
		//IL_012c: Expected O, but got I4
		//IL_0141: Expected O, but got I4
		//IL_0174: Expected O, but got I4
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected O, but got Unknown
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Expected O, but got Unknown
		//IL_01d3: Expected O, but got I4
		T0 val = (T0)gvPagePartner.SelectedRows.Cast<T6>().Where((Func<T6, bool>)(object)(Func<DataGridViewRow, bool>)((T6 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T6, T2>)(object)(Func<DataGridViewRow, int>)((T6 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 == null)
		{
			return;
		}
		T2 val3 = (T2)0;
		T2 val4 = (T2)0;
		frmMain.setting.txtBMIDTestPagePartner = frmMain.setting.txtBMIDTestPagePartner.Replace(",", "|").Replace(".", "|");
		T3[] array = (T3[])(object)frmMain.setting.txtBMIDTestPagePartner.Split((char[])(object)new T7[1] { (T7)124 });
		T2 val5 = (T2)(((List<DataGridViewRow>)val).Count - 1);
		while (true)
		{
			T1 val6 = (T1)((nint)val5 >= 0);
			if (val6 == null)
			{
				break;
			}
			val3 = (T2)0;
			TokenEntity tokenEntity = frmMain.setting.List_TOKEN_PAGE_PARTNER[((List<DataGridViewRow>)val)[(int)val5].Index];
			T3 message = (T3)"";
			T3[] array2 = array;
			T2 val7 = (T2)0;
			while ((nint)val7 < array2.Length)
			{
				T3 partner_id = (T3)((object[])(object)array2)[(object)val7];
				T3[] array3 = (T3[])(object)frmMain.setting.txtPageID_Partner.Split((char[])(object)new T7[1] { (T7)124 });
				T2 val8 = (T2)0;
				while ((nint)val8 < array3.Length)
				{
					T3 val9 = (T3)((object[])(object)array3)[(object)val8];
					T1 val10 = (T1)(!string.IsNullOrWhiteSpace((string)val9));
					if (val10 != null)
					{
						T1 val11 = frmMain.tokenPagePartner.Share_Page<T1, T2, T3, Exception, HttpRequest>((T3)tokenEntity.Token, (T3)frmMain.setting.txtBMID_PagePartner, partner_id, val9, (T3)tokenEntity.Cookie, (T1)1, out *(string*)(&message));
						T1 val12 = val11;
						if (val12 != null)
						{
							val3 = (T2)(val3 + 1);
						}
						else
						{
							val4 = (T2)(val4 + 1);
						}
					}
					val8 = (T2)(val8 + 1);
				}
				val7 = (T2)(val7 + 1);
			}
			frmMain.infoMessage((T3)$"Thành công: {val3} lỗi: {val4}");
			val5 = (T2)(val5 - 1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pasteTokenPagePartnerEvent<T0, T1, T2, T3, T4, T5, T6>(T4 sender, T5 e)
	{
		//IL_001e: Expected O, but got I4
		//IL_005f: Expected O, but got I4
		//IL_009d: Expected O, but got I4
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Expected O, but got Unknown
		try
		{
			T0 val = (T0)Clipboard.GetText();
			T0[] array = (T0[])(object)((string)val).Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
			T0[] array2 = array;
			T1 val2 = (T1)0;
			while ((nint)val2 < array2.Length)
			{
				T0 val3 = (T0)((object[])(object)array2)[(object)val2];
				T2 val4 = (T2)(!string.IsNullOrWhiteSpace((string)val3) && ((string)val3).Contains("|") && ((IEnumerable<T0>)(object)((string)val3).Split((char[])(object)new T6[1] { (T6)124 })).Count() == 3);
				if (val4 == null)
				{
					T2 val5 = (T2)(!string.IsNullOrWhiteSpace((string)val3) && ((string)val3).Contains("|") && ((IEnumerable<T0>)(object)((string)val3).Split((char[])(object)new T6[1] { (T6)124 })).Count() == 2);
					if (val5 != null)
					{
						frmMain.setting.List_TOKEN_PAGE_PARTNER.Add(new TokenEntity
						{
							UID = Regex.Match(((string)val3).Split((char[])(object)new T6[1] { (T6)124 })[0].Trim(), "c_user=(.*?);").Groups[1].Value,
							Token = ((string)val3).Split((char[])(object)new T6[1] { (T6)124 })[1].Trim(),
							Cookie = ((string)val3).Split((char[])(object)new T6[1] { (T6)124 })[0].Trim(),
							Status = frmMain.STATUS.Live.ToString()
						});
					}
				}
				else
				{
					frmMain.setting.List_TOKEN_PAGE_PARTNER.Add(new TokenEntity
					{
						UID = ((string)val3).Split((char[])(object)new T6[1] { (T6)124 })[0].Trim(),
						Token = ((string)val3).Split((char[])(object)new T6[1] { (T6)124 })[2].Trim(),
						Cookie = ((string)val3).Split((char[])(object)new T6[1] { (T6)124 })[1].Trim(),
						Status = frmMain.STATUS.Live.ToString()
					});
				}
				val2 = (T1)(val2 + 1);
			}
			gvPagePartner.DataSource = null;
			gvPagePartner.DataSource = frmMain.setting.List_TOKEN_PAGE_PARTNER;
			frmMain.settingSaving();
		}
		catch (Exception ex)
		{
			frmMain.errorMessage((T0)ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void deleteTokenPagePartnerEvent<T0, T1, T2, T3, T4>(T1 sender, T2 e)
	{
		//IL_000f: Expected O, but got I4
		T0 val = (T0)((nint)frmMain.questioniMessage<T3, T4>((T4)"Bạn muốn xóa toàn bộ?") == 6);
		if (val != null)
		{
			frmMain.setting.List_TOKEN_PAGE_PARTNER.Clear();
			gvPagePartner.ClearSelection();
			gvPagePartner.DataSource = null;
			gvPagePartner.DataSource = frmMain.setting.List_TOKEN_PAGE_PARTNER;
			frmMain.settingSaving();
		}
	}

	private void txtBMIDTestPagePartner_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		frmMain.setting.txtBMIDTestPagePartner = txtBMIDTestPagePartner.Text;
		frmMain.settingSaving();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void txtProfile_TextChanged<T0, T1, T2, T3>(T1 sender, T2 e)
	{
		//IL_002a: Expected O, but got I4
		//IL_0044: Expected O, but got I4
		frmMain.setting.txtProfile = txtProfile.Text;
		frmMain.settingSaving();
		T0 val = (T0)string.IsNullOrWhiteSpace(frmMain.setting.txtProfile);
		if (val == null)
		{
			T0 val2 = (T0)((nint)((IEnumerable<T3>)(object)frmMain.setting.txtProfile).Last() != 92);
			if (val2 != null)
			{
				frmMain.setting.txtProfile = frmMain.setting.txtProfile + "\\";
			}
			frmMain.PROFILE_CHROME_UID = frmMain.setting.txtProfile;
		}
		else
		{
			frmMain.PROFILE_CHROME_UID = Application.StartupPath + "\\BROWSER_PROFILE\\";
		}
	}

	private void cbSaveBackup_CheckedChanged<T0, T1>(T0 sender, T1 e)
	{
		frmMain.setting.cbSaveBackup = cbSaveBackup.Checked;
		frmMain.settingSaving();
	}

	private void rbOnProfersional_CheckedChanged<T0, T1>(T0 sender, T1 e)
	{
		frmMain.setting.isOnProfersional = rbOnProfersional.Checked;
		frmMain.settingSaving();
	}

	private void rbOffProfersional_CheckedChanged<T0, T1>(T0 sender, T1 e)
	{
		frmMain.setting.isOnProfersional = rbOnProfersional.Checked;
		frmMain.settingSaving();
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
	private void InitializeComponent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24>()
	{
		this.components = (System.ComponentModel.IContainer)System.Activator.CreateInstance(typeof(System.ComponentModel.Container));
		T0 val = (T0)new System.ComponentModel.ComponentResourceManager(typeof(ADSPRoject.frmSetting));
		this.label1 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtColumnDisplay = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.textBox1 = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.tabControl1 = (System.Windows.Forms.TabControl)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabControl));
		this.tabTokenBM = (System.Windows.Forms.TabPage)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabPage));
		this.gvBM = (System.Windows.Forms.DataGridView)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridView));
		this.txtIDBMAddCardNolimit = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label4 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.tabPixel = (System.Windows.Forms.TabPage)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabPage));
		this.button1 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.txtIDTK = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label7 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtBM_Pixel_ID = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label6 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtPixel_Id = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label3 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.gvTokenPixel = (System.Windows.Forms.DataGridView)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridView));
		this.tabPage = (System.Windows.Forms.TabPage)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabPage));
		this.gvTokenNhanPage = (System.Windows.Forms.DataGridView)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridView));
		this.tabVoHan = (System.Windows.Forms.TabPage)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabPage));
		this.gvTokenTKQC = (System.Windows.Forms.DataGridView)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridView));
		this.label5 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtIDTKQCAddCardNolimit = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.tabPagePartner = (System.Windows.Forms.TabPage)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabPage));
		this.txtBMIDTestPagePartner = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label10 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtPageID_Partner = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label9 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.gvPagePartner = (System.Windows.Forms.DataGridView)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridView));
		this.txtBMID_PagePartner = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label8 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.tabMenu = (System.Windows.Forms.TabPage)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabPage));
		this.cbSaveBackup = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.txtProfile = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label2 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.imageList1 = new System.Windows.Forms.ImageList(this.components);
		this.tabPage1 = (System.Windows.Forms.TabPage)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabPage));
		this.panel1 = (System.Windows.Forms.Panel)System.Activator.CreateInstance(typeof(System.Windows.Forms.Panel));
		this.label11 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.rbOnProfersional = (System.Windows.Forms.RadioButton)System.Activator.CreateInstance(typeof(System.Windows.Forms.RadioButton));
		this.rbOffProfersional = (System.Windows.Forms.RadioButton)System.Activator.CreateInstance(typeof(System.Windows.Forms.RadioButton));
		this.groupBox1 = (System.Windows.Forms.GroupBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.GroupBox));
		this.tabControl1.SuspendLayout();
		this.tabTokenBM.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gvBM).BeginInit();
		this.tabPixel.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gvTokenPixel).BeginInit();
		this.tabPage.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gvTokenNhanPage).BeginInit();
		this.tabVoHan.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gvTokenTKQC).BeginInit();
		this.tabPagePartner.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gvPagePartner).BeginInit();
		this.tabMenu.SuspendLayout();
		this.tabPage1.SuspendLayout();
		this.panel1.SuspendLayout();
		this.groupBox1.SuspendLayout();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(13, 19);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(90, 17);
		this.label1.TabIndex = 0;
		this.label1.Text = "Cột hiện thị";
		this.txtColumnDisplay.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtColumnDisplay.Location = new System.Drawing.Point(109, 16);
		this.txtColumnDisplay.Multiline = true;
		this.txtColumnDisplay.Name = "txtColumnDisplay";
		this.txtColumnDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtColumnDisplay.Size = new System.Drawing.Size(1085, 349);
		this.txtColumnDisplay.TabIndex = 1;
		this.txtColumnDisplay.TextChanged += new System.EventHandler(txtColumnDisplay_TextChanged);
		this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.textBox1.Location = new System.Drawing.Point(109, 371);
		this.textBox1.Multiline = true;
		this.textBox1.Name = "textBox1";
		this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.textBox1.Size = new System.Drawing.Size(1085, 105);
		this.textBox1.TabIndex = 5;
		this.textBox1.Text = ((System.Resources.ResourceManager)val).GetString("textBox1.Text");
		this.textBox1.TextChanged += new System.EventHandler(textBox1_TextChanged);
		this.tabControl1.Controls.Add(this.tabTokenBM);
		this.tabControl1.Controls.Add(this.tabPixel);
		this.tabControl1.Controls.Add(this.tabPage);
		this.tabControl1.Controls.Add(this.tabVoHan);
		this.tabControl1.Controls.Add(this.tabPagePartner);
		this.tabControl1.Controls.Add(this.tabMenu);
		this.tabControl1.Controls.Add(this.tabPage1);
		this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tabControl1.ImageList = this.imageList1;
		this.tabControl1.Location = new System.Drawing.Point(0, 0);
		this.tabControl1.Name = "tabControl1";
		this.tabControl1.SelectedIndex = 0;
		this.tabControl1.Size = new System.Drawing.Size(1210, 583);
		this.tabControl1.TabIndex = 9;
		this.tabTokenBM.Controls.Add(this.gvBM);
		this.tabTokenBM.Controls.Add(this.txtIDBMAddCardNolimit);
		this.tabTokenBM.Controls.Add(this.label4);
		this.tabTokenBM.ImageIndex = 0;
		this.tabTokenBM.Location = new System.Drawing.Point(4, 25);
		this.tabTokenBM.Name = "tabTokenBM";
		this.tabTokenBM.Padding = new System.Windows.Forms.Padding(3);
		this.tabTokenBM.Size = new System.Drawing.Size(944, 455);
		this.tabTokenBM.TabIndex = 5;
		this.tabTokenBM.Text = "Token BM cầm TKQC";
		this.tabTokenBM.UseVisualStyleBackColor = true;
		this.gvBM.AllowUserToAddRows = false;
		this.gvBM.AllowUserToDeleteRows = false;
		this.gvBM.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gvBM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		this.gvBM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.gvBM.Location = new System.Drawing.Point(8, 33);
		this.gvBM.Name = "gvBM";
		this.gvBM.RowHeadersWidth = 51;
		this.gvBM.Size = new System.Drawing.Size(928, 414);
		this.gvBM.TabIndex = 30;
		this.gvBM.MouseClick += new System.Windows.Forms.MouseEventHandler(gvBM_MouseClick<T14, T15, T16, T12, T17>);
		this.txtIDBMAddCardNolimit.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtIDBMAddCardNolimit.Location = new System.Drawing.Point(56, 6);
		this.txtIDBMAddCardNolimit.Name = "txtIDBMAddCardNolimit";
		this.txtIDBMAddCardNolimit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtIDBMAddCardNolimit.Size = new System.Drawing.Size(880, 24);
		this.txtIDBMAddCardNolimit.TabIndex = 28;
		this.txtIDBMAddCardNolimit.TextChanged += new System.EventHandler(txtIDBMAddCardNolimit_TextChanged);
		this.label4.AutoSize = true;
		this.label4.Location = new System.Drawing.Point(8, 9);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(50, 17);
		this.label4.TabIndex = 29;
		this.label4.Text = "ID BM";
		this.tabPixel.Controls.Add(this.button1);
		this.tabPixel.Controls.Add(this.txtIDTK);
		this.tabPixel.Controls.Add(this.label7);
		this.tabPixel.Controls.Add(this.txtBM_Pixel_ID);
		this.tabPixel.Controls.Add(this.label6);
		this.tabPixel.Controls.Add(this.txtPixel_Id);
		this.tabPixel.Controls.Add(this.label3);
		this.tabPixel.Controls.Add(this.gvTokenPixel);
		this.tabPixel.ImageIndex = 0;
		this.tabPixel.Location = new System.Drawing.Point(4, 25);
		this.tabPixel.Name = "tabPixel";
		this.tabPixel.Padding = new System.Windows.Forms.Padding(3);
		this.tabPixel.Size = new System.Drawing.Size(944, 455);
		this.tabPixel.TabIndex = 4;
		this.tabPixel.Text = "Token Pixel";
		this.tabPixel.UseVisualStyleBackColor = true;
		this.button1.Location = new System.Drawing.Point(676, 4);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(97, 23);
		this.button1.TabIndex = 34;
		this.button1.Text = "Test Share";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click_1<T14, T18, T19, T20, T12, T13, T21>);
		this.txtIDTK.Location = new System.Drawing.Point(536, 6);
		this.txtIDTK.Name = "txtIDTK";
		this.txtIDTK.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtIDTK.Size = new System.Drawing.Size(134, 24);
		this.txtIDTK.TabIndex = 32;
		this.txtIDTK.Text = "943150096570548";
		this.txtIDTK.TextChanged += new System.EventHandler(txtIDTK_TextChanged);
		this.label7.AutoSize = true;
		this.label7.Location = new System.Drawing.Point(485, 9);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(54, 17);
		this.label7.TabIndex = 33;
		this.label7.Text = "ID TK:";
		this.txtBM_Pixel_ID.Location = new System.Drawing.Point(69, 6);
		this.txtBM_Pixel_ID.Name = "txtBM_Pixel_ID";
		this.txtBM_Pixel_ID.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtBM_Pixel_ID.Size = new System.Drawing.Size(168, 24);
		this.txtBM_Pixel_ID.TabIndex = 30;
		this.txtBM_Pixel_ID.TextChanged += new System.EventHandler(txtBM_Pixel_ID_TextChanged);
		this.label6.AutoSize = true;
		this.label6.Location = new System.Drawing.Point(16, 9);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(56, 17);
		this.label6.TabIndex = 31;
		this.label6.Text = "BM ID:";
		this.txtPixel_Id.Location = new System.Drawing.Point(307, 6);
		this.txtPixel_Id.Name = "txtPixel_Id";
		this.txtPixel_Id.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtPixel_Id.Size = new System.Drawing.Size(172, 24);
		this.txtPixel_Id.TabIndex = 28;
		this.txtPixel_Id.TextChanged += new System.EventHandler(txtPixel_Id_TextChanged);
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(244, 9);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(66, 17);
		this.label3.TabIndex = 29;
		this.label3.Text = "Pixel ID:";
		this.gvTokenPixel.AllowUserToAddRows = false;
		this.gvTokenPixel.AllowUserToDeleteRows = false;
		this.gvTokenPixel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gvTokenPixel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		this.gvTokenPixel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.gvTokenPixel.Location = new System.Drawing.Point(3, 32);
		this.gvTokenPixel.Name = "gvTokenPixel";
		this.gvTokenPixel.RowHeadersWidth = 51;
		this.gvTokenPixel.Size = new System.Drawing.Size(935, 417);
		this.gvTokenPixel.TabIndex = 27;
		this.gvTokenPixel.MouseClick += new System.Windows.Forms.MouseEventHandler(gvTokenPixel_MouseClick<T14, T15, T16, T12, T17>);
		this.tabPage.Controls.Add(this.gvTokenNhanPage);
		this.tabPage.ImageIndex = 0;
		this.tabPage.Location = new System.Drawing.Point(4, 25);
		this.tabPage.Name = "tabPage";
		this.tabPage.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage.Size = new System.Drawing.Size(944, 455);
		this.tabPage.TabIndex = 3;
		this.tabPage.Text = "Token nhận page";
		this.tabPage.UseVisualStyleBackColor = true;
		this.gvTokenNhanPage.AllowUserToAddRows = false;
		this.gvTokenNhanPage.AllowUserToDeleteRows = false;
		this.gvTokenNhanPage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		this.gvTokenNhanPage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.gvTokenNhanPage.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gvTokenNhanPage.Location = new System.Drawing.Point(3, 3);
		this.gvTokenNhanPage.Name = "gvTokenNhanPage";
		this.gvTokenNhanPage.RowHeadersWidth = 51;
		this.gvTokenNhanPage.Size = new System.Drawing.Size(938, 449);
		this.gvTokenNhanPage.TabIndex = 26;
		this.gvTokenNhanPage.MouseClick += new System.Windows.Forms.MouseEventHandler(gvTokenNhanPage_MouseClick<T14, T15, T16, T12, T17>);
		this.tabVoHan.Controls.Add(this.gvTokenTKQC);
		this.tabVoHan.Controls.Add(this.label5);
		this.tabVoHan.Controls.Add(this.txtIDTKQCAddCardNolimit);
		this.tabVoHan.ImageIndex = 0;
		this.tabVoHan.Location = new System.Drawing.Point(4, 25);
		this.tabVoHan.Name = "tabVoHan";
		this.tabVoHan.Padding = new System.Windows.Forms.Padding(3);
		this.tabVoHan.Size = new System.Drawing.Size(944, 455);
		this.tabVoHan.TabIndex = 0;
		this.tabVoHan.Text = "Token Vô Hạn";
		this.tabVoHan.UseVisualStyleBackColor = true;
		this.gvTokenTKQC.AllowUserToAddRows = false;
		this.gvTokenTKQC.AllowUserToDeleteRows = false;
		this.gvTokenTKQC.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gvTokenTKQC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		this.gvTokenTKQC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.gvTokenTKQC.Location = new System.Drawing.Point(8, 32);
		this.gvTokenTKQC.Name = "gvTokenTKQC";
		this.gvTokenTKQC.RowHeadersWidth = 51;
		this.gvTokenTKQC.Size = new System.Drawing.Size(928, 417);
		this.gvTokenTKQC.TabIndex = 25;
		this.gvTokenTKQC.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(gvTokenTKQC_CellEndEdit);
		this.gvTokenTKQC.MouseClick += new System.Windows.Forms.MouseEventHandler(gvTokenTKQC_MouseClick<T14, T15, T16, T12, T17>);
		this.label5.AutoSize = true;
		this.label5.Location = new System.Drawing.Point(5, 9);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(69, 17);
		this.label5.TabIndex = 12;
		this.label5.Text = "ID TKCQ";
		this.txtIDTKQCAddCardNolimit.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtIDTKQCAddCardNolimit.Location = new System.Drawing.Point(69, 6);
		this.txtIDTKQCAddCardNolimit.Name = "txtIDTKQCAddCardNolimit";
		this.txtIDTKQCAddCardNolimit.Size = new System.Drawing.Size(867, 24);
		this.txtIDTKQCAddCardNolimit.TabIndex = 13;
		this.txtIDTKQCAddCardNolimit.TextChanged += new System.EventHandler(txtIDTKQCAddCardNolimit_TextChanged);
		this.tabPagePartner.Controls.Add(this.txtBMIDTestPagePartner);
		this.tabPagePartner.Controls.Add(this.label10);
		this.tabPagePartner.Controls.Add(this.txtPageID_Partner);
		this.tabPagePartner.Controls.Add(this.label9);
		this.tabPagePartner.Controls.Add(this.gvPagePartner);
		this.tabPagePartner.Controls.Add(this.txtBMID_PagePartner);
		this.tabPagePartner.Controls.Add(this.label8);
		this.tabPagePartner.ImageIndex = 0;
		this.tabPagePartner.Location = new System.Drawing.Point(4, 25);
		this.tabPagePartner.Name = "tabPagePartner";
		this.tabPagePartner.Padding = new System.Windows.Forms.Padding(3);
		this.tabPagePartner.Size = new System.Drawing.Size(944, 455);
		this.tabPagePartner.TabIndex = 6;
		this.tabPagePartner.Text = "Token Share Page Đối Tác";
		this.tabPagePartner.UseVisualStyleBackColor = true;
		this.txtBMIDTestPagePartner.Location = new System.Drawing.Point(662, 7);
		this.txtBMIDTestPagePartner.MaxLength = 999999999;
		this.txtBMIDTestPagePartner.Name = "txtBMIDTestPagePartner";
		this.txtBMIDTestPagePartner.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtBMIDTestPagePartner.Size = new System.Drawing.Size(185, 24);
		this.txtBMIDTestPagePartner.TabIndex = 36;
		this.txtBMIDTestPagePartner.TextChanged += new System.EventHandler(txtBMIDTestPagePartner_TextChanged);
		this.label10.AutoSize = true;
		this.label10.Location = new System.Drawing.Point(599, 10);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(71, 17);
		this.label10.TabIndex = 37;
		this.label10.Text = "BM TEST";
		this.txtPageID_Partner.Location = new System.Drawing.Point(338, 7);
		this.txtPageID_Partner.Name = "txtPageID_Partner";
		this.txtPageID_Partner.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtPageID_Partner.Size = new System.Drawing.Size(205, 24);
		this.txtPageID_Partner.TabIndex = 34;
		this.txtPageID_Partner.TextChanged += new System.EventHandler(txtPageID_Partner_TextChanged<T18, T12, T13>);
		this.label9.AutoSize = true;
		this.label9.Location = new System.Drawing.Point(279, 10);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(62, 17);
		this.label9.TabIndex = 35;
		this.label9.Text = "Page ID";
		this.gvPagePartner.AllowUserToAddRows = false;
		this.gvPagePartner.AllowUserToDeleteRows = false;
		this.gvPagePartner.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gvPagePartner.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		this.gvPagePartner.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.gvPagePartner.Location = new System.Drawing.Point(8, 34);
		this.gvPagePartner.Name = "gvPagePartner";
		this.gvPagePartner.RowHeadersWidth = 51;
		this.gvPagePartner.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.gvPagePartner.Size = new System.Drawing.Size(928, 416);
		this.gvPagePartner.TabIndex = 33;
		this.gvPagePartner.MouseClick += new System.Windows.Forms.MouseEventHandler(gvPagePartner_MouseClick<T14, T15, T16, T12, T17>);
		this.txtBMID_PagePartner.Location = new System.Drawing.Point(56, 7);
		this.txtBMID_PagePartner.Name = "txtBMID_PagePartner";
		this.txtBMID_PagePartner.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtBMID_PagePartner.Size = new System.Drawing.Size(205, 24);
		this.txtBMID_PagePartner.TabIndex = 31;
		this.txtBMID_PagePartner.TextChanged += new System.EventHandler(txtBMID_PagePartner_TextChanged);
		this.label8.AutoSize = true;
		this.label8.Location = new System.Drawing.Point(8, 10);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(50, 17);
		this.label8.TabIndex = 32;
		this.label8.Text = "ID BM";
		this.tabMenu.Controls.Add(this.cbSaveBackup);
		this.tabMenu.Controls.Add(this.txtProfile);
		this.tabMenu.Controls.Add(this.label2);
		this.tabMenu.Controls.Add(this.txtColumnDisplay);
		this.tabMenu.Controls.Add(this.label1);
		this.tabMenu.Controls.Add(this.textBox1);
		this.tabMenu.ImageIndex = 1;
		this.tabMenu.Location = new System.Drawing.Point(4, 25);
		this.tabMenu.Name = "tabMenu";
		this.tabMenu.Padding = new System.Windows.Forms.Padding(3);
		this.tabMenu.Size = new System.Drawing.Size(1202, 554);
		this.tabMenu.TabIndex = 1;
		this.tabMenu.Text = "Menu";
		this.tabMenu.UseVisualStyleBackColor = true;
		this.cbSaveBackup.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.cbSaveBackup.AutoSize = true;
		this.cbSaveBackup.Location = new System.Drawing.Point(109, 482);
		this.cbSaveBackup.Name = "cbSaveBackup";
		this.cbSaveBackup.Size = new System.Drawing.Size(136, 21);
		this.cbSaveBackup.TabIndex = 8;
		this.cbSaveBackup.Text = "Lưu file backup";
		this.cbSaveBackup.UseVisualStyleBackColor = true;
		this.cbSaveBackup.CheckedChanged += new System.EventHandler(cbSaveBackup_CheckedChanged);
		this.txtProfile.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtProfile.Location = new System.Drawing.Point(167, 522);
		this.txtProfile.Name = "txtProfile";
		this.txtProfile.Size = new System.Drawing.Size(946, 24);
		this.txtProfile.TabIndex = 7;
		this.txtProfile.TextChanged += new System.EventHandler(txtProfile_TextChanged<T14, T12, T13, T21>);
		this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(13, 525);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(140, 17);
		this.label2.TabIndex = 6;
		this.label2.Text = "Đường dẫn Profile:";
		this.imageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)(T23)((System.Resources.ResourceManager)val).GetObject("imageList1.ImageStream");
		this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
		this.imageList1.Images.SetKeyName(0, "token-fb.ico");
		this.imageList1.Images.SetKeyName(1, "favicon.ico");
		this.tabPage1.Controls.Add(this.groupBox1);
		this.tabPage1.ImageIndex = 1;
		this.tabPage1.Location = new System.Drawing.Point(4, 25);
		this.tabPage1.Name = "tabPage1";
		this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage1.Size = new System.Drawing.Size(1202, 554);
		this.tabPage1.TabIndex = 7;
		this.tabPage1.Text = "Chức năng nâng cao";
		this.tabPage1.UseVisualStyleBackColor = true;
		this.panel1.Controls.Add(this.rbOffProfersional);
		this.panel1.Controls.Add(this.rbOnProfersional);
		this.panel1.Controls.Add(this.label11);
		this.panel1.Location = new System.Drawing.Point(6, 23);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(306, 50);
		this.panel1.TabIndex = 0;
		this.label11.AutoSize = true;
		this.label11.Location = new System.Drawing.Point(5, 17);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(171, 17);
		this.label11.TabIndex = 0;
		this.label11.Text = "Chế độ chuyên nghiệp:";
		this.rbOnProfersional.AutoSize = true;
		this.rbOnProfersional.Checked = true;
		this.rbOnProfersional.Location = new System.Drawing.Point(173, 15);
		this.rbOnProfersional.Name = "rbOnProfersional";
		this.rbOnProfersional.Size = new System.Drawing.Size(53, 21);
		this.rbOnProfersional.TabIndex = 1;
		this.rbOnProfersional.TabStop = true;
		this.rbOnProfersional.Text = "Bật";
		this.rbOnProfersional.UseVisualStyleBackColor = true;
		this.rbOnProfersional.CheckedChanged += new System.EventHandler(rbOnProfersional_CheckedChanged);
		this.rbOffProfersional.AutoSize = true;
		this.rbOffProfersional.Location = new System.Drawing.Point(232, 15);
		this.rbOffProfersional.Name = "rbOffProfersional";
		this.rbOffProfersional.Size = new System.Drawing.Size(52, 21);
		this.rbOffProfersional.TabIndex = 2;
		this.rbOffProfersional.Text = "Tắt";
		this.rbOffProfersional.UseVisualStyleBackColor = true;
		this.rbOffProfersional.CheckedChanged += new System.EventHandler(rbOffProfersional_CheckedChanged);
		this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.groupBox1.Controls.Add(this.panel1);
		this.groupBox1.Location = new System.Drawing.Point(11, 6);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(1183, 540);
		this.groupBox1.TabIndex = 1;
		this.groupBox1.TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(1210, 583);
		base.Controls.Add(this.tabControl1);
		this.Font = new System.Drawing.Font("Verdana", 8f);
		base.Icon = (System.Drawing.Icon)(T24)((System.Resources.ResourceManager)val).GetObject("$this.Icon");
		base.Name = "frmSetting";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Cài đặt";
		base.Load += new System.EventHandler(frmSetting_Load);
		this.tabControl1.ResumeLayout(false);
		this.tabTokenBM.ResumeLayout(false);
		this.tabTokenBM.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.gvBM).EndInit();
		this.tabPixel.ResumeLayout(false);
		this.tabPixel.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.gvTokenPixel).EndInit();
		this.tabPage.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gvTokenNhanPage).EndInit();
		this.tabVoHan.ResumeLayout(false);
		this.tabVoHan.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.gvTokenTKQC).EndInit();
		this.tabPagePartner.ResumeLayout(false);
		this.tabPagePartner.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.gvPagePartner).EndInit();
		this.tabMenu.ResumeLayout(false);
		this.tabMenu.PerformLayout();
		this.tabPage1.ResumeLayout(false);
		this.panel1.ResumeLayout(false);
		this.panel1.PerformLayout();
		this.groupBox1.ResumeLayout(false);
		base.ResumeLayout(false);
	}
}
