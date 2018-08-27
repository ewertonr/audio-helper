using NAudio.Wave;
using System;

namespace AudioHelper.Infrastructure.Mp3
{
	public class Mp3File : IMp3File
	{
		private readonly Mp3FileReader mp3FileReader;

		public Mp3File(string mp3Path)
		{
			if (string.IsNullOrEmpty(mp3Path)) { throw new ArgumentNullException(nameof(mp3Path)); }

			this.mp3FileReader = new Mp3FileReader(mp3Path);			
		}

		public TimeSpan CurrentTime => this.mp3FileReader.CurrentTime;

		public TimeSpan TotalTime => this.mp3FileReader.TotalTime;

		public byte[] RawData => this.mp3FileReader.ReadNextFrame()?.RawData;

		public void Dispose()
		{
			this.mp3FileReader.Dispose();
		}
	}
}
