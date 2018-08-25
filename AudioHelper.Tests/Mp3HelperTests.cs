using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace AudioHelper.Tests
{
	[TestClass]
    public class Mp3HelperTests
    {
        [TestMethod]
        public void TestMethod1()
		{
			var mp3Path = @"C:\test_aud\t.mp3";
			var outputPath = Path.ChangeExtension(mp3Path, ".trimmed.mp3");

			Mp3Helper.TrimMp3File(mp3Path, outputPath, TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(2));
        }
    }
}
