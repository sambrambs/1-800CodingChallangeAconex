using System.IO;
using NUnit.Framework;

namespace CodingChallange1_800Application.Services
{
    [TestFixture]
    public class FileSystemTest : TestBase
    {
        [Test]
        public void FileExistance()
        {
            Assert.AreEqual(SampleFileContent, FileSystem.Read(SampleFilePath), "FileSystem.Read content");
        }
        [Test]
        public void CreatesFiles()
        {
            FileSystem.Create(DestinationFilePath, SampleFileContent);
            Assert.AreEqual(SampleFileContent, File.ReadAllText(DestinationFilePath), "Content of the created file");
        }
    }
}