using System;
using System.Collections.Generic;

namespace ADSPRoject.Data;

public class TokenNolimit
{
	public List<TokenEntity> List_TOKEN_TKQC = (List<TokenEntity>)Activator.CreateInstance(typeof(List<TokenEntity>));

	public List<TokenEntity> List_TOKEN_BM = (List<TokenEntity>)Activator.CreateInstance(typeof(List<TokenEntity>));

	public string ID_TKQC { get; set; }

	public string ID_BM { get; set; }

	public TokenEntity Get_Token_TKQC<T0, T1>()
	{
		//IL_0004: Expected O, but got I4
		//IL_0012: Expected I4, but got O
		//IL_002d: Expected O, but got I4
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		//IL_0044: Expected O, but got I4
		//IL_0056: Expected I4, but got O
		TokenEntity result = null;
		T0 val = (T0)0;
		while (true)
		{
			T1 val2 = (T1)((nint)val < List_TOKEN_TKQC.Count);
			if (val2 == null)
			{
				break;
			}
			T1 val3 = (T1)List_TOKEN_TKQC[(int)val].Status.Equals(frmMain.STATUS.Live.ToString());
			if (val3 == null)
			{
				val = (T0)(val + 1);
				continue;
			}
			result = List_TOKEN_TKQC[(int)val];
			break;
		}
		return result;
	}

	public TokenEntity Get_Token_BM<T0, T1>()
	{
		//IL_0004: Expected O, but got I4
		//IL_0012: Expected I4, but got O
		//IL_002d: Expected O, but got I4
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		//IL_0044: Expected O, but got I4
		//IL_0056: Expected I4, but got O
		TokenEntity result = null;
		T0 val = (T0)0;
		while (true)
		{
			T1 val2 = (T1)((nint)val < List_TOKEN_BM.Count);
			if (val2 == null)
			{
				break;
			}
			T1 val3 = (T1)List_TOKEN_BM[(int)val].Status.Equals(frmMain.STATUS.Live.ToString());
			if (val3 == null)
			{
				val = (T0)(val + 1);
				continue;
			}
			result = List_TOKEN_BM[(int)val];
			break;
		}
		return result;
	}

	public T0 Set_Status_Token_TKQC<T0, T1, T2>(T2 token, T2 status)
	{
		//IL_0002: Expected O, but got I4
		//IL_0004: Expected O, but got I4
		//IL_0012: Expected I4, but got O
		//IL_001e: Expected O, but got I4
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_0034: Expected O, but got I4
		//IL_0045: Expected I4, but got O
		//IL_004d: Expected O, but got I4
		T0 result = (T0)0;
		T1 val = (T1)0;
		while (true)
		{
			T0 val2 = (T0)((nint)val < List_TOKEN_TKQC.Count);
			if (val2 != null)
			{
				T0 val3 = (T0)List_TOKEN_TKQC[(int)val].Token.Equals((string)token);
				if (val3 == null)
				{
					val = (T1)(val + 1);
					continue;
				}
				List_TOKEN_TKQC[(int)val].Status = (string)status;
				result = (T0)1;
				break;
			}
			break;
		}
		return result;
	}

	public T0 Set_Status_Token_BM<T0, T1, T2>(T2 token, T2 status)
	{
		//IL_0002: Expected O, but got I4
		//IL_0004: Expected O, but got I4
		//IL_0012: Expected I4, but got O
		//IL_001e: Expected O, but got I4
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_0034: Expected O, but got I4
		//IL_0045: Expected I4, but got O
		//IL_004d: Expected O, but got I4
		T0 result = (T0)0;
		T1 val = (T1)0;
		while (true)
		{
			T0 val2 = (T0)((nint)val < List_TOKEN_BM.Count);
			if (val2 == null)
			{
				break;
			}
			T0 val3 = (T0)List_TOKEN_BM[(int)val].Token.Equals((string)token);
			if (val3 == null)
			{
				val = (T1)(val + 1);
				continue;
			}
			List_TOKEN_BM[(int)val].Status = (string)status;
			result = (T0)1;
			break;
		}
		return result;
	}
}
