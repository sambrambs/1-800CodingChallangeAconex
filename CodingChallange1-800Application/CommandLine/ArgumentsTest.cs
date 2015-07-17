using System.IO;
using System.Linq;
using CommandLineParser.Arguments;
using NUnit.Framework;

namespace CodingChallange1_800Application.CommandLine
{
    [TestFixture]
    public class ArgumentsTest
    {
        private Arguments _arguments;
        [SetUp]
        public void SetUp()
        {
            _arguments = new Arguments();
        }
        [Test]
        public void AllCollectsAllArguments()
        {
            AssertArgument<FileArgument>(Arguments.InputFileLongName);
            AssertArgument<FileArgument>(Arguments.DictionaryLongName);
        }
        private void AssertArgument<T>(string longName) where T : Argument
        {
            var argument = FindArgument(longName);
            Assert.IsNotNull(argument, "there should be an argument " + longName
                );
            Assert.IsInstanceOf(typeof(T), argument, "argument " + longName);
        }
        private Argument FindArgument(string longName)
        {
            return _arguments.All.First(x => x.LongName == longName);
        }
        [Test]
        public void AllArgumentsShouldHaveDifferentShortNames()
        {
            var shortNames = _arguments.All.Select(x => x.ShortName).Where(x => 
                x != ' ');
            Assert.AreEqual(shortNames, shortNames.Distinct(), "distinct short names");
        }
        [Test]
        public void AllArgumentsShouldHaveDifferentLongNames()
        {
            var longNames = _arguments.All.Select(x => x.LongName);
            Assert.AreEqual(longNames, longNames.Distinct(), "distinct long names");
        }
        [Test]
        public void PropertiesHaveTheValueOfTheCorrespondingArguments()
        {
            InputFileArgument.Value = new FileInfo("inputFileName"); 
            Assert.AreEqual(InputFileArgument.Value, _arguments.InputFile, "Arguments.InputFileName");
            DictionaryFileArgument.Value = new FileInfo("dictionaryFileName"); 
            Assert.AreEqual(DictionaryFileArgument.Value, _arguments.DictionaryFile, 
                "Arguments.DictionaryFileName");
        }
        [Test]
        public void DictionaryArgumentIsDefaultDictionaryByDedfault()
        {
            Assert.AreEqual(new FileInfo("defaultDictionary").FullName, DictionaryFileArgument.DefaultValue.FullName, 
                "DictionaryFileArgument default value");
        }
        [Test]
        public void ReturnsItselfAsOutput()
        {
            Assert.AreSame(_arguments, _arguments.AsOutput(), "Arguments.AsOutput");
        }
        private FileArgument DictionaryFileArgument
        {
            get { return (FileArgument)FindArgument(Arguments.DictionaryLongName); }
        }
        private FileArgument InputFileArgument
        {
            get { return (FileArgument)FindArgument(Arguments.InputFileLongName)
                ; }
        }
    }
}