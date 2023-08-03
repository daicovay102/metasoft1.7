namespace OtpNet;

public interface IKeyProvider
{
	byte[] ComputeHmac(OtpHashMode mode, byte[] data);
}
