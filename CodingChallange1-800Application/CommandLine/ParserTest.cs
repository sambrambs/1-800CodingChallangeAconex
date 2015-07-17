using System.Collections.Generic;
using CommandLineParser.Exceptions;
using NUnit.Framework;

namespace CodingChallange1_800Application.CommandLine
{
    [TestFixture]
    public class ParserTest
    {
        private Parser<object> _parser;
        private TestArguments _arguments;
        [SetUp]
        public void SetUp()
        {
            _arguments = new TestArguments();
            _parser = null;
        }
        [Test]
        public void PublishesTheUsageString()
        {
            GivenANewParser();
            AssertIsUsage(_parser.Usage);
        }
        [Test]
        public void ShowsUsageWithHelpArgs()
        {
            GivenANewParser();
            _parser.ReadArgs(new [] { "--help"});
            Assert.IsTrue(_parser.UsageShouldBeDisplayed, "Parser.UsageShouldBeDisplayed");
        }
        [Test]
        public void DoesNotShowUsageWithValidArgs()
        {
            ParseArgumentsWithUser();
            Assert.IsFalse(_parser.UsageShouldBeDisplayed, "Parser.UsageShouldBeDisplayed");
        }
        [Test]
        public void ByDefaultCommandLineIsEmpty()
        {
            GivenANewParser();
            Assert.AreEqual("", _parser.CommandLine, "Command Line");
        }
        [Test]
        public void KnowsTheActualCommandLineTextAfterAParsing()
        {
            var args = new[] {TestArguments.UserShortArg, "spoke", TestArguments
                .NumberShortArg, "42"};
            ParseArguments(args);
            Assert.AreEqual(string.Join(" ", args), _parser.CommandLine, "Command line");
        }
        [Test]
        public void ActuallyParsesTheCommandLine()
        {
            const string User = "Bob";
            const int Number = 12;
            ParseArguments(TestArguments.UserShortArg, User, TestArguments.NumberShortArg, Number.ToString());
            Assert.AreEqual(User, _arguments.User.Value, "Parsed user argument")
                ;
            Assert.AreEqual(Number, _arguments.Number.Value, "Parsed number argument");
        }
        [Test, ExpectedException(typeof(InvalidConversionException))]
        public void ThrowsWhenAParsingErrorOccurs()
        {
            ParseArgumentsWithUser(TestArguments.NumberShortArg, "malformed number ...");
        }
        [Test]
        public void CreatesTheOutputOnSuccessfulParsing()
        {
            Assert.AreEqual(_arguments.Output, ParseArgumentsWithUser(), "Outputbuilt by the parser");
        }
        [Test]
        public void HandlesUperCaseArguments()
        {
            const string User = "Client";
            ParseArguments("--" + TestArguments.UserLongName.ToUpper(), User);
            Assert.AreEqual(User, _arguments.User.Value, "User specified with upcase argument name");
        }
        private object ParseArgumentsWithUser(params string[] extraArgs)
        {
            var allArgs = new List<string> { TestArguments.UserShortArg, "Jimmy"
            };
            allArgs.AddRange(extraArgs);
            return ParseArguments(allArgs.ToArray());
        }
        private object ParseArguments(params string[] args)
        {
            GivenANewParser();
            _parser.ReadArgs(args);
            return _parser.Parse();
        }
        private void GivenANewParser()
        {
            _parser = new Parser<object>(_arguments);
        }
        private static void AssertIsUsage(string text)
        {
            Assert.That(text, Is.StringStarting("Usage:"), "Command line usage")
                ;
            Assert.That(text, Is.StringContaining(TestArguments.UserShortArg), "Command line usage");
            Assert.That(text, Is.StringContaining(TestArguments.NumberShortArg),
                "Command line usage");
        }
    }
}