using AudioHelper.Infrastructure.FileSystem;
using System;
using System.Collections.Generic;

namespace AudioHelper.Domain
{
	public class SongFactory
	{
		private readonly IFileSystemWrapper fileSystem;
		private string mp3FilePath;

		public SongFactory(IFileSystemWrapper fileSystem)
		{
			this.fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
		}

		private readonly ICollection<Song> Songs = new List<Song>();

		public void ReadFile(string path, string mp3FilePath)
		{
			this.mp3FilePath = path;

			var lines = this.fileSystem.ReadAllLines(path);

			for (int i = 0; i < lines.Length; i++)
			{
				var line = lines[i];
				if (string.IsNullOrEmpty(line)) { continue; }

				var order = i + 1;
				var title = this.GetTitle(line);
				var start = this.GetTimeSpan(line);

				var end = i == lines.Length - 1
					? TimeSpan.Zero
					: this.GetTimeSpan(lines[i + 1]);

				var song = new Song(mp3FilePath, order, title, start, end);
				this.Songs.Add(song);
			}
		}

		public void GenerateSongs()
		{
			if (this.Songs.Count == 0) { throw new Exception("Não há nenhuma música para ser gerada. Verifique e tente novamente."); }

			var outputDirectory = $@"{this.fileSystem.DirectoryName(this.mp3FilePath)}\cd\";
			this.fileSystem.CreateDirectory(outputDirectory);

			foreach (var music in this.Songs)
			{
				music.GenerateMp3(outputDirectory);
			}

			this.Songs.Clear();
		}

		private string GetTitle(string line)
		{
			int count = line.IndexOf("- ") + 2;
			return line.Substring(count);
		}

		private TimeSpan GetTimeSpan(string line)
		{
			int count = line.IndexOf(" -");
			var time = line.Substring(0, count);

			return TimeSpan.Parse(time);
		}
	}
}
