using System.Runtime.CompilerServices;
using ADSPRoject.Server;

namespace ADSPRoject.License;

public class User
{
	private static string Token_User = "";

	public static string Email { get; set; }

	public static string Password { get; set; }

	public static string Token { get; set; }

	public static string ExpireDate { get; set; }

	public static bool AdsManager_RollingMatThread { get; set; }

	public static bool AddCardByPro5 { get; set; }

	public static bool Page_Partner { get; set; }

	public static string UserText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			if (!string.IsNullOrWhiteSpace(ExpireDate) && !ExpireDate.ToLower().Equals("null"))
			{
				try
				{
					return "Ngày hết hạn: " + $"{ExpireDate:dd/MM/yyyy}";
				}
				catch
				{
					return "Ngày hết hạn: " + ExpireDate;
				}
			}
			return "[Key PRO vĩnh viễn]";
		}
		set
		{
		}
	}

	public static T0 Get_Token_User<T0>()
	{
		return (T0)Token_User;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Building_User_Token<T0, T1, T2>(T0 strEmail, T0 strPassword)
	{
		Email = (string)strEmail;
		Password = (string)strPassword;
		Token = (string)LocalStateData.Get_Local_State<T0, T1, T2>();
		Token_User = string.Concat((string[])(object)new T0[5]
		{
			(T0)Email,
			(T0)"|",
			(T0)Password,
			(T0)"|",
			(T0)Token
		});
		Token_User = StringCipher.Encrypt(Token_User);
	}
}
