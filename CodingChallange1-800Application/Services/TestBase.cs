using CodingChallange1_800Application.Services.Utils;
using NUnit.Framework;

namespace CodingChallange1_800Application.Services
{
    public class TestBase
    {
        protected string SampleFilePath;
        protected FileSystem FileSystem;
        protected string DestinationFilePath;
        protected const string TestDirectory = "FileSystemTest";
        protected const string SampleFileContent = "some content\r\ncoucou\r\n";
        protected const string SampleFileName = "sample.txt";
        [SetUp]
        public void SetUp()
        {
            Safe.ResetTestDirectory(TestDirectory);
            SampleFilePath = Path(SampleFileName);
            Safe.FileCreate(SampleFilePath, SampleFileContent);
            DestinationFilePath = Path(@"newDirectory\copy.txt");
            FileSystem = new FileSystem();
        }
        protected static string Path(string fileName)
        {
            return System.IO.Path.Combine(TestDirectory, fileName);
        }
        protected static string GivenADirectory()
        {
            var directoryPath = System.IO.Path.GetDirectoryName(@"ADirectoryPath\");
            Safe.CreateDirectory(directoryPath);
            return directoryPath;
        }
    }
}