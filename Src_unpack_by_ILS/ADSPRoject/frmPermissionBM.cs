using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ADSPRoject;

public class frmPermissionBM : Form
{
	private IContainer components = null;

	private Label label1;

	private TextBox txtToken;

	private Button button1;

	private DataGridView gvData;

	private Label label2;

	private NumericUpDown numLimit;

	public frmPermissionBM()
	{
		InitializeComponent<ComponentResourceManager, Label, TextBox, Button, DataGridView, NumericUpDown, object, EventArgs, int, Icon>();
	}

	private void button1_Click<T0, T1>(T0 sender, T1 e)
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
	private void InitializeComponent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>()
	{
		T0 val = (T0)new System.ComponentModel.ComponentResourceManager(typeof(ADSPRoject.frmPermissionBM));
		this.label1 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtToken = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.button1 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.gvData = (System.Windows.Forms.DataGridView)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridView));
		this.label2 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.numLimit = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		((System.ComponentModel.ISupportInitialize)this.gvData).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numLimit).BeginInit();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(12, 15);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(73, 13);
		this.label1.TabIndex = 0;
		this.label1.Text = "Token EAAG:";
		this.txtToken.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtToken.Location = new System.Drawing.Point(91, 12);
		this.txtToken.Name = "txtToken";
		this.txtToken.Size = new System.Drawing.Size(708, 20);
		this.txtToken.TabIndex = 1;
		this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.button1.Location = new System.Drawing.Point(950, 10);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(75, 23);
		this.button1.TabIndex = 2;
		this.button1.Text = "Load";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.gvData.AllowUserToAddRows = false;
		this.gvData.AllowUserToDeleteRows = false;
		this.gvData.AllowUserToOrderColumns = true;
		this.gvData.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		this.gvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.gvData.Location = new System.Drawing.Point(15, 39);
		this.gvData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.gvData.Name = "gvData";
		this.gvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.gvData.Size = new System.Drawing.Size(1010, 475);
		this.gvData.TabIndex = 4;
		this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(805, 15);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(31, 13);
		this.label2.TabIndex = 5;
		this.label2.Text = "Limit:";
		this.numLimit.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.numLimit.Location = new System.Drawing.Point(842, 13);
		this.numLimit.Maximum = new decimal((int[])(object)new T8[4]
		{
			(T8)1410065407,
			(T8)2,
			default(T8),
			default(T8)
		});
		this.numLimit.Name = "numLimit";
		this.numLimit.Size = new System.Drawing.Size(102, 20);
		this.numLimit.TabIndex = 7;
		this.numLimit.Value = new decimal((int[])(object)new T8[4]
		{
			(T8)2500,
			default(T8),
			default(T8),
			default(T8)
		});
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1037, 527);
		base.Controls.Add(this.numLimit);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.gvData);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.txtToken);
		base.Controls.Add(this.label1);
		base.Icon = (System.Drawing.Icon)(T9)((System.Resources.ResourceManager)val).GetObject("$this.Icon");
		base.Name = "frmPermissionBM";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Phân quyền TKQC Business Manager";
		((System.ComponentModel.ISupportInitialize)this.gvData).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numLimit).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
