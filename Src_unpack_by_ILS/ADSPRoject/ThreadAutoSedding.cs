using System;
using System.Threading;
using ADSPRoject.Data;

namespace ADSPRoject;

public class ThreadAutoSedding
{
	public string Id { get; set; }

	public bool isRunning { get; set; }

	public int Delay { get; set; }

	public string TextSedding { get; set; }

	public void runThread<T0>()
	{
		//IL_005c: Expected O, but got I4
		while (true)
		{
			T0 val = (T0)isRunning;
			if (val != null)
			{
				frmSedding.listLiveStreamSedding.Add(new LiveStreamSedding
				{
					Id = frmMain.RandomString<string, int, char>(15),
					Key = frmSedding.KEY_LIVE_STREAM.SEDDING,
					Value = TextSedding,
					isRandom = false
				});
				Console.WriteLine(TextSedding);
				Thread.Sleep(Delay * 1000);
				continue;
			}
			break;
		}
	}
}
