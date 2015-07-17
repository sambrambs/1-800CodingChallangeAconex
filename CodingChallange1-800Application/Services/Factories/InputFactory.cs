using System.IO;
using CodingChallange1_800Application.Services.Interfaces;

namespace CodingChallange1_800Application.Services.Factories
{
    public class InputFactory : IInputFactory
    {
        private readonly FileInfo _fileInfo;
        private IConsoleService _consoleService;
        private IFileSystem _fileSystem;

        public InputFactory(FileInfo fileInfo)
        {
            _fileInfo = fileInfo;
        }
        
        public InputFactory WithFileSystem(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
            return this;
        }

        public IInputFactory WithConsoleService(IConsoleService consoleService)
        {
            _consoleService = consoleService;
            return this;
        }

        public IInputReader InputReader()
        {
            if (_fileInfo == null)
            {
                return new ConsoleInputReader(_consoleService);
            }
            return new FileInputReader(_fileInfo, _fileSystem);
        }
    }
}