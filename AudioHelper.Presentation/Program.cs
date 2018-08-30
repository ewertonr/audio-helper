using AudioHelper.Domain;
using AudioHelper.Infrastructure.FileSystem;
using System;

namespace AudioHelper.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
			try
			{
				var factory = new SongFactory(new FileSystem());
				factory.ReadFileAndGenerateSongs(@"C:\test_aud\musics.txt", @"C:\test_aud\vou_pro_sereno.mp3");

				Console.WriteLine("Hello World!");
				Console.ReadKey();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.ReadKey();
			}
        }
    }
}
