using CodingChallange1_800Application.CommandLine;
using CodingChallange1_800Application.CommandLine.Interfaces;
using CodingChallange1_800Application.Main;
using CodingChallange1_800Application.Services.Interfaces;
using CodingChallange1_800Application.Services.Utils;

namespace CodingChallange1_800Application.Services.Factories
{
    public class Factory : IFactory
    {
        private readonly Parser<IArgumentsValues> _commandLineParser;
        private readonly IFileSystem _fileSystem;
        private readonly IConsoleService _consoleService;
        public Factory()
        {
            var arguments = new Arguments();
            _commandLineParser = new Parser<IArgumentsValues>(arguments);
            _fileSystem = new FileSystem();
            _consoleService = new ConsoleInputService();
        }
        public IParser<IArgumentsValues> CommandLineParser
        {
            get { return _commandLineParser; }
        }
        public IFileSystem FileSystem
        {
            get { return _fileSystem; }
        }
        public IConsoleService ConsoleService
        {
            get { return _consoleService; }
        }
        internal WorkFlowManager NewWorkflowManager()
        {
            return new WorkFlowManager(this);
        }
    }
}