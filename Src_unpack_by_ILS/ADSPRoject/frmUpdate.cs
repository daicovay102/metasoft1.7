using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ADSPRoject;

public class frmUpdate : Form
{
	private IContainer components = null;

	private Label label1;

	private Label label2;

	private Label lbThisVersion;

	private Button button1;

	private Button button2;

	public frmUpdate()
	{
		InitializeComponent<ComponentResourceManager, Label, Button, object, EventArgs, Icon>();
	}

	private void frmUpdate_Load<T0, T1>(T0 sender, T1 e)
	{
		lbThisVersion.Text = base.ProductVersion;
	}

	private void button2_Click<T0, T1>(T0 sender, T1 e)
	{
		base.DialogResult = DialogResult.OK;
	}

	private void button1_Click<T0, T1>(T0 sender, T1 e)
	{
		base.DialogResult = DialogResult.Cancel;
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
	private void InitializeComponent<T0, T1, T2, T3, T4, T5>()
	{
		T0 val = (T0)new System.ComponentModel.ComponentResourceManager(typeof(ADSPRoject.frmUpdate));
		this.label1 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.label2 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.lbThisVersion = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.button1 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.button2 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(12, 9);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(159, 22);
		this.label1.TabIndex = 0;
		this.label1.Text = "Phiên bản hiện tại:";
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.Location = new System.Drawing.Point(12, 44);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(179, 22);
		this.label2.TabIndex = 1;
		this.label2.Text = "Đã có phiên bản mới!";
		this.lbThisVersion.AutoSize = true;
		this.lbThisVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 13f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lbThisVersion.ForeColor = System.Drawing.SystemColors.Highlight;
		this.lbThisVersion.Location = new System.Drawing.Point(177, 9);
		this.lbThisVersion.Name = "lbThisVersion";
		this.lbThisVersion.Size = new System.Drawing.Size(72, 22);
		this.lbThisVersion.TabIndex = 2;
		this.lbThisVersion.Text = "0.0.1.1";
		this.button1.Location = new System.Drawing.Point(316, 79);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(75, 23);
		this.button1.TabIndex = 3;
		this.button1.Text = "Cancel";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.button2.Location = new System.Drawing.Point(235, 79);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(75, 23);
		this.button2.TabIndex = 4;
		this.button2.Text = "Update";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(403, 117);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.lbThisVersion);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Icon = (System.Drawing.Icon)(T5)((System.Resources.ResourceManager)val).GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmUpdate";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Update";
		base.Load += new System.EventHandler(frmUpdate_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
