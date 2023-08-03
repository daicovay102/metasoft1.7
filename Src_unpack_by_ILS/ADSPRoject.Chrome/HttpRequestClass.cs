using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace ADSPRoject.Chrome;

public class HttpRequestClass
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetListGroup2<T0, T1, T2, T3, T4, T5, T6>(T1 fbCookie, T1 userAgent)
	{
		T0 val = (T0)WebRequest.Create("https://www.facebook.com/api/graphql");
		((WebRequest)val).Method = "POST";
		T1 s = (T1)"av=100011334314754&__user=100011334314754&__a=1&__dyn=&__csr=&__req=m&__hs=&dpr=1&__ccg=EXCELLENT&__rev=1004768101&__s=&__hsi=&__comet_req=1&fb_dtsg=AQE1ioLzg20yQAM:44:1637309239&jazoest=&lsd=&__spin_r=1004768101&__spin_b=trunk&__spin_t=1637689406&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=GroupsCometLeftRailContainerQuery&variables=%7B%22adminGroupsCount%22%3A3%2C%22memberGroupsCount%22%3A10000%2C%22scale%22%3A1%7D&server_timestamps=true&doc_id=3884641628300421";
		T2[] bytes = (T2[])(object)Encoding.UTF8.GetBytes((string)s);
		((WebRequest)val).ContentType = "application/x-www-form-urlencoded";
		((WebRequest)val).Headers["cookie"] = (string)fbCookie;
		((WebRequest)val).Headers["accept-encoding"] = "gzip, deflate, br";
		((WebRequest)val).Headers["accept-language"] = "vi-VN,vi;q=0.9,en-US;q=0.8,en;q=0.7";
		((WebRequest)val).Headers["origin"] = " https://www.facebook.com";
		((WebRequest)val).Headers["sec-ch-ua-mobile"] = "?0";
		((WebRequest)val).Headers["sec-ch-ua-platform"] = "Windows";
		((WebRequest)val).Headers["sec-fetch-dest"] = "empty";
		((WebRequest)val).Headers["sec-fetch-mode"] = "cors";
		((WebRequest)val).Headers["sec-fetch-site"] = "same-origin";
		((WebRequest)val).Headers["viewport-width"] = "1490";
		((WebRequest)val).Headers["x-fb-friendly-name"] = "GroupsCometLeftRailContainerQuery";
		((WebRequest)val).Headers["sec-ch-ua"] = "\"Not A;Brand\";v=\"99\", \"Chromium\";v=\"96\", \"Microsoft Edge\";v=\"96\"";
		((WebRequest)val).ContentLength = bytes.Length;
		T3 requestStream = (T3)((WebRequest)val).GetRequestStream();
		((Stream)requestStream).Write((byte[])(object)bytes, 0, bytes.Length);
		((Stream)requestStream).Close();
		T4 response = (T4)((WebRequest)val).GetResponse();
		Console.WriteLine(((HttpWebResponse)(T6)response).StatusDescription);
		T3 val2 = (requestStream = (T3)((WebResponse)response).GetResponseStream());
		try
		{
			T5 val3 = (T5)new StreamReader((Stream)requestStream);
			T1 value = (T1)((TextReader)val3).ReadToEnd();
			Console.WriteLine((string)value);
		}
		finally
		{
			if (val2 != null)
			{
				((IDisposable)val2).Dispose();
			}
		}
		((WebResponse)response).Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetListGroup<T0, T1, T2, T3, T4, T5>(T0 fbCookie, T0 userAgent)
	{
		T0 requestUriString = (T0)"https://www.facebook.com/api/graphql/";
		T1 val = (T1)WebRequest.Create((string)requestUriString);
		((WebRequest)val).Headers["cookie"] = (string)fbCookie;
		((WebRequest)val).Headers["accept-encoding"] = "gzip, deflate, br";
		((WebRequest)val).Headers["accept-language"] = "vi-VN,vi;q=0.9,en-US;q=0.8,en;q=0.7";
		((WebRequest)val).Headers["origin"] = " https://www.facebook.com";
		((WebRequest)val).Headers["sec-ch-ua-mobile"] = "?0";
		((WebRequest)val).Headers["sec-ch-ua-platform"] = "Windows";
		((WebRequest)val).Headers["sec-fetch-dest"] = "empty";
		((WebRequest)val).Headers["sec-fetch-mode"] = "cors";
		((WebRequest)val).Headers["sec-fetch-site"] = "same-origin";
		((WebRequest)val).Headers["viewport-width"] = "1490";
		((WebRequest)val).Headers["x-fb-friendly-name"] = "GroupsCometLeftRailContainerQuery";
		((WebRequest)val).Headers["sec-ch-ua"] = "\"Not A;Brand\";v=\"99\", \"Chromium\";v=\"96\", \"Microsoft Edge\";v=\"96\"";
		((HttpWebRequest)val).UserAgent = (string)userAgent;
		((WebRequest)val).Method = "POST";
		T0 s = (T0)"av=100011334314754&__user=100011334314754&__a=1&__dyn=&__csr=&__req=m&__hs=&dpr=1&__ccg=EXCELLENT&__rev=1004768101&__s=&__hsi=&__comet_req=1&fb_dtsg=AQE1ioLzg20yQAM:44:1637309239&jazoest=&lsd=&__spin_r=1004768101&__spin_b=trunk&__spin_t=1637689406&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=GroupsCometLeftRailContainerQuery&variables=%7B%22adminGroupsCount%22%3A3%2C%22memberGroupsCount%22%3A10000%2C%22scale%22%3A1%7D&server_timestamps=true&doc_id=3884641628300421";
		T2[] bytes = (T2[])(object)Encoding.ASCII.GetBytes((string)s);
		((WebRequest)val).ContentLength = bytes.Length;
		T4 requestStream = (T4)((WebRequest)val).GetRequestStream();
		try
		{
			((Stream)requestStream).Write((byte[])(object)bytes, 0, bytes.Length);
		}
		finally
		{
			if (requestStream != null)
			{
				((IDisposable)requestStream).Dispose();
			}
		}
		T3 val2 = (T3)((WebRequest)val).GetResponse();
		T5 val3 = (T5)new StreamReader(((WebResponse)val2).GetResponseStream());
		try
		{
			((TextReader)val3).ReadToEnd();
		}
		finally
		{
			if (val3 != null)
			{
				((IDisposable)val3).Dispose();
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 GetToken<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T0 fbCookie, T0 userAgent)
	{
		//IL_00fe: Expected O, but got I4
		//IL_0108: Expected I4, but got O
		//IL_010e: Expected O, but got I4
		//IL_011c: Expected I4, but got O
		//IL_011e: Expected O, but got I4
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected O, but got Unknown
		//IL_013e: Expected O, but got I4
		//IL_014f: Expected O, but got I4
		//IL_0183: Expected O, but got I4
		T0 requestUriString = (T0)"https://business.facebook.com/business_locations";
		T1 val = (T1)WebRequest.Create((string)requestUriString);
		((WebRequest)val).Headers["cookie"] = (string)fbCookie;
		((WebRequest)val).Headers["sec-fetch-dest"] = "document";
		((WebRequest)val).Headers["sec-fetch-mode"] = "navigate";
		((WebRequest)val).Headers["sec-fetch-site"] = "none";
		((WebRequest)val).Headers["sec-fetch-user"] = "?1";
		((HttpWebRequest)val).UserAgent = (string)userAgent;
		T2 val2 = (T2)((WebRequest)val).GetResponse();
		T0 val3 = (T0)"";
		T3 val4 = (T3)new StreamReader(((WebResponse)val2).GetResponseStream());
		try
		{
			val3 = (T0)((TextReader)val4).ReadToEnd();
		}
		finally
		{
			if (val4 != null)
			{
				((IDisposable)val4).Dispose();
			}
		}
		T0 val5 = (T0)"";
		T0 pattern = (T0)"eaag";
		T0 input = (T0)((string)val3).ToLower();
		T4 enumerator = (T4)Regex.Matches((string)input, (string)pattern).GetEnumerator();
		try
		{
			while (((IEnumerator)enumerator).MoveNext())
			{
				T5 val6 = (T5)((IEnumerator)enumerator).Current;
				T6 val7 = (T6)((Capture)val6).Index;
				while (true)
				{
					T7 val8 = (T7)((nint)val7 < ((string)val3).Length);
					if (val8 == null)
					{
						break;
					}
					T7 val9 = (T7)(((string)val3)[(int)val7] == '"');
					if (val9 != null)
					{
						break;
					}
					val5 = (T0)((string)val5 + System.Runtime.CompilerServices.Unsafe.As<T8, char>(ref (T8)((string)val3)[(int)val7]));
					val7 = (T6)(val7 + 1);
				}
				T7 val10 = (T7)(((string)val5).Length > 20);
				if (val10 == null)
				{
					val5 = (T0)"";
					continue;
				}
				break;
			}
		}
		finally
		{
			T9 val11 = (T9)((enumerator is T9) ? enumerator : null);
			if (val11 != null)
			{
				((IDisposable)val11).Dispose();
			}
		}
		T7 val12 = (T7)string.IsNullOrEmpty((string)val5);
		if (val12 == null)
		{
			return val5;
		}
		return (T0)"Checkpoint";
	}
}
