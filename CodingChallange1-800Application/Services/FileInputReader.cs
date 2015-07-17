using System;
using System.IO;
using CodingChallange1_800Application.Services.Interfaces;

namespace CodingChallange1_800Application.Services
{
    public class FileInputReader : IInputReader
    {
        private readonly FileInfo _inputFileInfo;
        private readonly IFileSystem _fileSystem;
        public FileInputReader(FileInfo inputFileInfo, IFileSystem fileSystem)
        {
            _inputFileInfo = inputFileInfo;
            _fileSystem = fileSystem;
        }
        public string Read()
        {
            if (_inputFileInfo == null)
                throw new NullReferenceException();
            return _fileSystem.Read(_inputFileInfo.FullName);
        }
    }
}