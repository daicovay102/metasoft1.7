using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ADSPRoject.Properties;

[CompilerGenerated]
[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.4.0.0")]
internal sealed class Settings : ApplicationSettingsBase
{
	private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());

	public static Settings Default => defaultInstance;

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("proxy:0.0.0.0:0000 | socks5:0.0.0.0:0000 |  ")]
	public string Socks
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (string)this["Socks"];
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			this["Socks"] = value;
		}
	}

	private void SettingChangingEventHandler<T0, T1>(T0 sender, T1 e)
	{
	}

	private void SettingsSavingEventHandler<T0, T1>(T0 sender, T1 e)
	{
	}
}
