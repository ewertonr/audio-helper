using NAudio.Wave;
using System;
using System.IO;

namespace AudioHelper
{
	public class Mp3Helper
	{
		public static void TrimMp3File(string inPath, string outPath, TimeSpan? cutFromStart, TimeSpan? cutFromEnd)
		{
			using (var reader = new Mp3FileReader(inPath))
			using (var writer = File.Create(outPath))
			{
				Mp3Frame frame;
				while ((frame = reader.ReadNextFrame()) != null)
				{
					if (reader.CurrentTime >= cutFromStart || !cutFromStart.HasValue)
					{
						if (reader.CurrentTime <= cutFromEnd || !cutFromEnd.HasValue)
						{
							writer.Write(frame.RawData, 0, frame.RawData.Length);
						}
						else
						{
							break;
						}
					}
				}
			}
		}
	}
}
