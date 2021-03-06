﻿using AudioHelper.Infrastructure.FileSystem;
using AudioHelper.Infrastructure.Mp3;
using System;

namespace AudioHelper.Domain
{
	public class Song
	{
		private readonly IMp3File mp3File;

		public Song(string mp3Path, int order, string title, TimeSpan start, TimeSpan end)
		{
			this.mp3File = new Mp3File(mp3Path);

			this.End = end == TimeSpan.Zero ? this.mp3File.TotalTime : end;
			this.Start = start;
			this.Title = $"{order} - {title}.mp3";
		}

		private string Title { get; }

		private byte[] RawData => this.mp3File.RawData;

		private TimeSpan CurrentTime => this.mp3File.CurrentTime;

		private TimeSpan End { get; }

		private TimeSpan Start { get; }

		private bool IsInInterval => this.CurrentTime >= this.Start && this.CurrentTime <= this.End;

		public void GenerateMp3(IFileSystemWrapper fileSystem, string path)
		{
			using (var writer = fileSystem.FileWriter($@"{path}\{this.Title}"))
			{
				byte[] frame = null;
				while ((frame = this.RawData) != null)
				{
					if (this.IsInInterval) { writer.Write(frame, 0, frame.Length); }
				}
			}
		}
	}
}
