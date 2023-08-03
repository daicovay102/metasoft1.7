using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ADSPRoject;

public class frmCreateBM : Form
{
	private IContainer components = null;

	public frmCreateBM()
	{
		InitializeComponent<ComponentResourceManager, Icon>();
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
	private void InitializeComponent<T0, T1>()
	{
		T0 val = (T0)new System.ComponentModel.ComponentResourceManager(typeof(ADSPRoject.frmCreateBM));
		base.SuspendLayout();
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(416, 193);
		base.Icon = (System.Drawing.Icon)(T1)((System.Resources.ResourceManager)val).GetObject("$this.Icon");
		base.Name = "frmCreateBM";
		this.Text = "frmCreateBM";
		base.ResumeLayout(false);
	}
}
