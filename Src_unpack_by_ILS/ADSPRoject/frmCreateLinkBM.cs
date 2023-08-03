using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ADSPRoject;

public class frmCreateLinkBM : Form
{
	private IContainer components = null;

	private NumericUpDown numThread;

	private Label label2;

	private NumericUpDown numDelayReceiptBM;

	private Label label16;

	private Label lbTotal;

	private Label label4;

	private TextBox txtlỗi;

	private TextBox txtSuccess;

	private Button button1;

	private Label lblỗi;

	private Label label3;

	private Label lbSuccess;

	private Label label1;

	private TextBox txtLinkBM;

	public frmCreateLinkBM()
	{
		InitializeComponent<ComponentResourceManager, NumericUpDown, Label, TextBox, Button, int, Icon>();
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
	private void InitializeComponent<T0, T1, T2, T3, T4, T5, T6>()
	{
		T0 val = (T0)new System.ComponentModel.ComponentResourceManager(typeof(ADSPRoject.frmCreateLinkBM));
		this.numThread = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label2 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.numDelayReceiptBM = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label16 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.lbTotal = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.label4 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtlỗi = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.txtSuccess = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.button1 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.lblỗi = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.label3 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.lbSuccess = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.label1 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtLinkBM = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		((System.ComponentModel.ISupportInitialize)this.numThread).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numDelayReceiptBM).BeginInit();
		base.SuspendLayout();
		this.numThread.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.numThread.Location = new System.Drawing.Point(249, 528);
		this.numThread.Margin = new System.Windows.Forms.Padding(4);
		this.numThread.Maximum = new decimal((int[])(object)new T5[4]
		{
			(T5)9999999,
			default(T5),
			default(T5),
			default(T5)
		});
		this.numThread.Name = "numThread";
		this.numThread.Size = new System.Drawing.Size(84, 22);
		this.numThread.TabIndex = 70;
		this.numThread.Value = new decimal((int[])(object)new T5[4]
		{
			(T5)1,
			default(T5),
			default(T5),
			default(T5)
		});
		this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(188, 530);
		this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(54, 16);
		this.label2.TabIndex = 69;
		this.label2.Text = "Thread:";
		this.numDelayReceiptBM.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.numDelayReceiptBM.Location = new System.Drawing.Point(412, 528);
		this.numDelayReceiptBM.Margin = new System.Windows.Forms.Padding(4);
		this.numDelayReceiptBM.Maximum = new decimal((int[])(object)new T5[4]
		{
			(T5)9999999,
			default(T5),
			default(T5),
			default(T5)
		});
		this.numDelayReceiptBM.Name = "numDelayReceiptBM";
		this.numDelayReceiptBM.Size = new System.Drawing.Size(84, 22);
		this.numDelayReceiptBM.TabIndex = 68;
		this.label16.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.label16.AutoSize = true;
		this.label16.Location = new System.Drawing.Point(351, 530);
		this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label16.Name = "label16";
		this.label16.Size = new System.Drawing.Size(46, 16);
		this.label16.TabIndex = 67;
		this.label16.Text = "Delay:";
		this.lbTotal.AutoSize = true;
		this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lbTotal.ForeColor = System.Drawing.Color.Black;
		this.lbTotal.Location = new System.Drawing.Point(88, 13);
		this.lbTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.lbTotal.Name = "lbTotal";
		this.lbTotal.Size = new System.Drawing.Size(17, 17);
		this.lbTotal.TabIndex = 66;
		this.lbTotal.Text = "0";
		this.label4.AutoSize = true;
		this.label4.Location = new System.Drawing.Point(16, 13);
		this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(65, 16);
		this.label4.TabIndex = 65;
		this.label4.Text = "Tổng link:";
		this.txtlỗi.Location = new System.Drawing.Point(309, 375);
		this.txtlỗi.Margin = new System.Windows.Forms.Padding(4);
		this.txtlỗi.Multiline = true;
		this.txtlỗi.Name = "txtlỗi";
		this.txtlỗi.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		this.txtlỗi.Size = new System.Drawing.Size(293, 142);
		this.txtlỗi.TabIndex = 64;
		this.txtSuccess.Location = new System.Drawing.Point(16, 375);
		this.txtSuccess.Margin = new System.Windows.Forms.Padding(4);
		this.txtSuccess.Multiline = true;
		this.txtSuccess.Name = "txtSuccess";
		this.txtSuccess.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		this.txtSuccess.Size = new System.Drawing.Size(284, 142);
		this.txtSuccess.TabIndex = 63;
		this.button1.Location = new System.Drawing.Point(504, 524);
		this.button1.Margin = new System.Windows.Forms.Padding(4);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(100, 28);
		this.button1.TabIndex = 62;
		this.button1.Text = "Nhận Link";
		this.button1.UseVisualStyleBackColor = true;
		this.lblỗi.AutoSize = true;
		this.lblỗi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblỗi.ForeColor = System.Drawing.Color.Red;
		this.lblỗi.Location = new System.Drawing.Point(345, 355);
		this.lblỗi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.lblỗi.Name = "lblỗi";
		this.lblỗi.Size = new System.Drawing.Size(17, 17);
		this.lblỗi.TabIndex = 61;
		this.lblỗi.Text = "0";
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(305, 355);
		this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(28, 16);
		this.label3.TabIndex = 60;
		this.label3.Text = "Lỗi:";
		this.lbSuccess.AutoSize = true;
		this.lbSuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lbSuccess.ForeColor = System.Drawing.Color.Blue;
		this.lbSuccess.Location = new System.Drawing.Point(115, 355);
		this.lbSuccess.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.lbSuccess.Name = "lbSuccess";
		this.lbSuccess.Size = new System.Drawing.Size(17, 17);
		this.lbSuccess.TabIndex = 59;
		this.lbSuccess.Text = "0";
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(16, 355);
		this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(81, 16);
		this.label1.TabIndex = 58;
		this.label1.Text = "Thành công:";
		this.txtLinkBM.Location = new System.Drawing.Point(16, 32);
		this.txtLinkBM.Margin = new System.Windows.Forms.Padding(4);
		this.txtLinkBM.Multiline = true;
		this.txtLinkBM.Name = "txtLinkBM";
		this.txtLinkBM.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		this.txtLinkBM.Size = new System.Drawing.Size(587, 319);
		this.txtLinkBM.TabIndex = 57;
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(620, 565);
		base.Controls.Add(this.numThread);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.numDelayReceiptBM);
		base.Controls.Add(this.label16);
		base.Controls.Add(this.lbTotal);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.txtlỗi);
		base.Controls.Add(this.txtSuccess);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.lblỗi);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.lbSuccess);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.txtLinkBM);
		base.Icon = (System.Drawing.Icon)(T6)((System.Resources.ResourceManager)val).GetObject("$this.Icon");
		base.Name = "frmCreateLinkBM";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Tạo link mời BM";
		((System.ComponentModel.ISupportInitialize)this.numThread).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numDelayReceiptBM).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
