using System;
using CodingChallange1_800Application.CommandLine.Interfaces;
using CodingChallange1_800Application.Services.Factories;
using CodingChallange1_800Application.Services.Interfaces;

namespace CodingChallange1_800Application.Main
{
    public class WorkFlowManager
    {
        private readonly IParser<IArgumentsValues> _commandLineParser;
        private readonly IFileSystem _fileSystem;
        private readonly IConsoleService _consoleService;
        public WorkFlowManager(IFactory factory)
        {
            _commandLineParser = factory.CommandLineParser;
            _fileSystem = factory.FileSystem;
            _consoleService = factory.ConsoleService;

        }
        public void Run(string[] args)
        {
            _commandLineParser.ReadArgs(args);

            if (_commandLineParser.UsageShouldBeDisplayed)
            {
                ShowHelp(_commandLineParser.Usage);
                return;
            }
            Run(_commandLineParser.Parse());
        }
        private void Run(IArgumentsValues arguments)
        {
            IInputFactory inputRunner = new InputFactory(arguments.InputFile)
                .WithFileSystem(_fileSystem)
                .WithConsoleService(_consoleService);

            var inputContent = inputRunner.InputReader().Read();
            var dictionaryRunner = new InputFactory(arguments.DictionaryFile)
                .WithFileSystem(_fileSystem)
                .WithConsoleService(_consoleService);
            var dicitonaryInput = dictionaryRunner.InputReader().Read();
            //var processor = new Processor(inputContent, dicitonaryInput);
            //var result = processor.Process();
            //Display(result); display or save the result in some file
        }
        private static void ShowHelp(string usage)
        {
            Console.Write(usage);
        }
    }
}