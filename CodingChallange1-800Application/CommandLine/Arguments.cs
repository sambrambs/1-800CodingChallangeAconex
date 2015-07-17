using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using CodingChallange1_800Application.CommandLine.Interfaces;
using CodingChallange1_800Application.CommandLine.Utils;
using CommandLineParser.Arguments;

namespace CodingChallange1_800Application.CommandLine
{
    public class Arguments : IArgumentsConfig<IArgumentsValues>, IArgumentsValues
    {
        private const char InputFileShortName = 'I';
        private const char DictionaryShortName = 'D';
        internal const string InputFileLongName = "input-file";
        internal const string DictionaryLongName = "dictionary-file";
        private readonly FileArgument _inputFile;
        private readonly FileArgument _dictionaryFile;
        public Arguments()
        {
            _inputFile = new FileArgument(InputFileShortName, InputFileLongName,
                Help.InputFileArgument);
            _dictionaryFile = new FileArgument(DictionaryShortName, DictionaryLongName,
                Help.DictionaryFileArgument)
            {
                DefaultValue = new FileInfo("defaultDictionary")
            };
        }
        public IEnumerable<Argument> All
        {
            get
            {
                return GetType().GetFields(BindingFlags.Instance | BindingFlags.
                    NonPublic)
                    .Select(field => field.GetValue(this)).OfType<Argument>().ToList();
            }
        }
        public FileInfo InputFile
        {
            get { return _inputFile.Value; }
        }
        public FileInfo DictionaryFile
        {
            get { return _dictionaryFile.Value; }
        }
        public IArgumentsValues AsOutput()
        {
            return this;
        }
    }
}