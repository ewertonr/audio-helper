using AudioHelper.Domain;
using AudioHelper.Infrastructure.FileSystem;
using System;

namespace AudioHelper.Presentation
{
	class Program
	{
		private const int NUMBER_OF_PARAMETERS = 2;

		static void Main(string[] args)
		{
			try
			{
				if (IsValidPaths(args) == false) { throw new Exception("Invalid paths"); }

				var songsDescriptionPath = args[0];
				var mp3FilePath = args[1];

				var factory = new SongFactory(new FileSystem());
				factory.ReadFileAndGenerateSongs($@"{songsDescriptionPath}", $@"{mp3FilePath}");

				Console.ReadKey();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.ReadKey();
			}
		}

		private static bool IsValidPaths(string[] args)
		{
			return args.Length == NUMBER_OF_PARAMETERS
				? true
				: false;
		}
	}
}
