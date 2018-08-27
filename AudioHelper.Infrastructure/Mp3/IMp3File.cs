using System;

namespace AudioHelper.Infrastructure.Mp3
{
	public interface IMp3File : IDisposable
	{
		TimeSpan CurrentTime { get; }

		TimeSpan TotalTime { get; }

		byte[] RawData { get; }
	}
}
