using System;

namespace AudioHelper.Domain.Contract
{
	public interface IMp3File : IDisposable
	{
		TimeSpan CurrentTime { get; }

		TimeSpan TotalTime { get; }

		byte[] RawData { get; }
	}
}
