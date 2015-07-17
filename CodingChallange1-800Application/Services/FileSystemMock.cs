using System.Collections.Generic;
using CodingChallange1_800Application.Services.Interfaces;
using CodingChallange1_800Application.Utils;
using Moq;

namespace CodingChallange1_800Application.Services
{
    public class FileSystemMock : IFileSystem
    {
        private readonly Dictionary<string, string> _fileSystemFiles = new Dictionary<string, string>();
        public virtual string Read(string filePath)
        {
            return _fileSystemFiles.GetValueOrDefault(filePath, "");
        }
        public virtual void Create(string filePath, string content)
        {
            _fileSystemFiles[filePath] = content;
        }
        public static Mock<FileSystemMock> New()
        {
            return new Mock<FileSystemMock> { CallBase = true };
        }
    }
}