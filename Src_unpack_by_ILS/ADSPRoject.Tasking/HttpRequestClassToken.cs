using System;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;

namespace ADSPRoject.Tasking;

public class HttpRequestClassToken
{
	public HttpRequestClassToken()
	{
		ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T0 Get<T0, T1, T2, T3, T4, T5>(T0 url)
	{
		T0 result = (T0)"";
		try
		{
			T1 val = (T1)WebRequest.Create((string)url);
			((WebRequest)val).Headers["sec-fetch-dest"] = "document";
			((WebRequest)val).Headers["sec-fetch-mode"] = "navigate";
			((WebRequest)val).Headers["sec-fetch-site"] = "none";
			((WebRequest)val).Headers["sec-fetch-user"] = "?1";
			((HttpWebRequest)val).UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/97.0.4692.99 Safari/537.36";
			T2 val2 = (T2)((WebRequest)val).GetResponse();
			T3 val3 = (T3)new StreamReader(((WebResponse)val2).GetResponseStream());
			try
			{
				result = (T0)((TextReader)val3).ReadToEnd();
			}
			finally
			{
				if (val3 != null)
				{
					((IDisposable)val3).Dispose();
				}
			}
		}
		catch (WebException ex)
		{
			result = (T0)new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
		}
		catch (Exception ex2)
		{
			Console.Write(ex2.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T0 Post<T0, T1, T2, T3, T4, T5, T6>(T0 url, T0 data)
	{
		T0 result = (T0)"";
		try
		{
			T1 val = (T1)WebRequest.Create((string)url);
			((WebRequest)val).Method = "POST";
			((WebRequest)val).ContentType = "application/x-www-form-urlencoded";
			T3 val2 = (T3)new StreamWriter(((WebRequest)val).GetRequestStream());
			try
			{
				((TextWriter)val2).Write((string)data);
			}
			finally
			{
				if (val2 != null)
				{
					((IDisposable)val2).Dispose();
				}
			}
			T2 val3 = (T2)((WebRequest)val).GetResponse();
			T4 val4 = (T4)new StreamReader(((WebResponse)val3).GetResponseStream());
			try
			{
				result = (T0)((TextReader)val4).ReadToEnd();
			}
			finally
			{
				if (val4 != null)
				{
					((IDisposable)val4).Dispose();
				}
			}
		}
		catch (WebException ex)
		{
			result = (T0)new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
		}
		catch (Exception ex2)
		{
			Console.Write(ex2.Message);
		}
		return result;
	}
}
