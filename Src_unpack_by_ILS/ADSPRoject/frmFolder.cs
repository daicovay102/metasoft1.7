using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ADSPRoject;

public class frmFolder : Form
{
	public int isSave = 0;

	public string newName = "";

	private IContainer components = null;

	private Label label1;

	private TextBox textBox1;

	private Button button1;

	private Button button2;

	private Button btnDelete;

	public frmFolder(string oldName, bool isNew, string titleForm)
	{
		InitializeComponent<ComponentResourceManager, Label, TextBox, Button, object, EventArgs, bool, Icon>();
		textBox1.Text = oldName;
		Text = titleForm;
		if (isNew)
		{
			btnDelete.Visible = false;
		}
	}

	private void frmFolder_Load<T0, T1>(T0 sender, T1 e)
	{
	}

	private void button2_Click<T0, T1>(T0 sender, T1 e)
	{
		isSave = 0;
		Close();
	}

	private void button1_Click<T0, T1>(T0 sender, T1 e)
	{
		isSave = 1;
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void button3_Click<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_000f: Expected O, but got I4
		T0 val = (T0)(frmMain.questioniMessage<DialogResult, string>("Bạn có muốn xóa thư mục này? Mọi tài khoản sẽ được xóa theo.") == DialogResult.Yes);
		if (val != null)
		{
			isSave = 2;
			Close();
		}
	}

	private void textBox1_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		newName = textBox1.Text;
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
	private void InitializeComponent<T0, T1, T2, T3, T4, T5, T6, T7>()
	{
		T0 val = (T0)new System.ComponentModel.ComponentResourceManager(typeof(ADSPRoject.frmFolder));
		this.label1 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.textBox1 = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.button1 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.button2 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.btnDelete = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(14, 15);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(104, 17);
		this.label1.TabIndex = 0;
		this.label1.Text = "Tên thư mục:";
		this.textBox1.Location = new System.Drawing.Point(124, 12);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(392, 24);
		this.textBox1.TabIndex = 1;
		this.textBox1.TextChanged += new System.EventHandler(textBox1_TextChanged);
		this.button1.Location = new System.Drawing.Point(429, 53);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(87, 23);
		this.button1.TabIndex = 2;
		this.button1.Text = "Save";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.button2.Location = new System.Drawing.Point(335, 53);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(87, 23);
		this.button2.TabIndex = 3;
		this.button2.Text = "Cancel";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click);
		this.btnDelete.Location = new System.Drawing.Point(17, 53);
		this.btnDelete.Name = "btnDelete";
		this.btnDelete.Size = new System.Drawing.Size(87, 23);
		this.btnDelete.TabIndex = 4;
		this.btnDelete.Text = "Delete";
		this.btnDelete.UseVisualStyleBackColor = true;
		this.btnDelete.Click += new System.EventHandler(button3_Click<T6, T4, T5>);
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(531, 97);
		base.Controls.Add(this.btnDelete);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.textBox1);
		base.Controls.Add(this.label1);
		this.Font = new System.Drawing.Font("Verdana", 8f);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Icon = (System.Drawing.Icon)(T7)((System.Resources.ResourceManager)val).GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.Name = "frmFolder";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Thư mục";
		base.Load += new System.EventHandler(frmFolder_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
