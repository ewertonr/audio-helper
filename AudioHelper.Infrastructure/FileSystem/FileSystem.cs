using System.IO;

namespace AudioHelper.Infrastructure.FileSystem
{
	public class FileSystem : IFileSystemWrapper
	{
		public void CreateDirectory(string path) => Directory.CreateDirectory(path);

		public string DirectoryName(string filePath) => new FileInfo(filePath).Directory.FullName;

		public string[] ReadAllLines(string path) => File.ReadAllLines(path);
	}
}
