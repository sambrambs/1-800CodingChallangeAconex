using System;
using System.IO;
using System.Linq;
using CodingChallange1_800Application.CommandLine.Interfaces;

namespace CodingChallange1_800Application.CommandLine
{
    public class Parser<T> : IParser<T>
    {
        public const int SuccessExitCode = 0;
        public const int FailureExitCode = -1;
        private readonly CommandLineParser.CommandLineParser _parser;
        private readonly IArgumentsConfig<T> _arguments;
        private string[] _args = new string[0];
        internal Parser(IArgumentsConfig<T> arguments)
        {
            _arguments = arguments;
            _parser = new CommandLineParser.CommandLineParser();
            _parser.IgnoreCase = true;
            _parser.Arguments.AddRange(_arguments.All);
        }
        public string Usage
        {
            get
            {
                TextWriter str = new StringWriter();
                _parser.PrintUsage(str);
                return str.ToString().Trim();
            }
        }
        public string CommandLine
        {
            get { return String.Join(" ", _args); }
        }
        public T Parse()
        {
            _parser.ParseCommandLine(_args);
            
            return _arguments.AsOutput();
        }
        public void ReadArgs(string[] args)
        {
            _args = args;
        }
        public bool UsageShouldBeDisplayed
        {
            get { return (_args.Contains("--help") || _args.Contains("/help") ||
                          _args.Contains("/?")); }
        }
    }
}