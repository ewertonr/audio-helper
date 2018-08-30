using System.IO;

namespace AudioHelper.Infrastructure.FileSystem
{
	public interface IFileSystemWrapper
    {
		void CreateDirectory(string path);

		string DirectoryName(string filePath);

		string[] ReadAllLines(string path);

		FileStream FileWriter(string path);
	}
}
