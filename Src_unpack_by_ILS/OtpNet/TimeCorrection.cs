using System;

namespace OtpNet;

public class TimeCorrection
{
	public static readonly TimeCorrection UncorrectedInstance = new TimeCorrection();

	private readonly TimeSpan timeCorrectionFactor;

	public DateTime CorrectedUtcNow => GetCorrectedTime(DateTime.UtcNow);

	public TimeSpan CorrectionFactor => timeCorrectionFactor;

	private TimeCorrection()
	{
		timeCorrectionFactor = TimeSpan.FromSeconds(0.0);
	}

	public TimeCorrection(DateTime correctUtc)
	{
		timeCorrectionFactor = DateTime.UtcNow - correctUtc;
	}

	public TimeCorrection(DateTime correctTime, DateTime referenceTime)
	{
		timeCorrectionFactor = referenceTime - correctTime;
	}

	public T0 GetCorrectedTime<T0>(T0 referenceTime)
	{
		return (T0)((DateTime)referenceTime - timeCorrectionFactor);
	}
}
