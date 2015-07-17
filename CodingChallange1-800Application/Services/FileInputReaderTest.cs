using System;
using System.IO;
using Moq;
using NUnit.Framework;

namespace CodingChallange1_800Application.Services
{
    [TestFixture]
    public class FileInputReaderTest
    {
        private Mock<FileSystemMock> _fileSystem;
        [SetUp]
        public void SetUp()
        {
            _fileSystem = FileSystemMock.New();
            
        }
        [Test, ExpectedException(typeof(NullReferenceException))]
        public void ThrowsExcpetionWhenFileINfoIsNull()
        {
            var fileReader = new FileInputReader(null, _fileSystem.Object);
            fileReader.Read();
        }
        [Test]
        public void ReadsFromFileIfGiven()
        {
            var inputFileInfo = new FileInfo("validFile");
            var fileReader = new FileInputReader(inputFileInfo, _fileSystem.Object);
            fileReader.Read();
            _fileSystem.Verify(x => x.Read(inputFileInfo.FullName), Times.AtLeastOnce, "Read from file");
        }
    }
}