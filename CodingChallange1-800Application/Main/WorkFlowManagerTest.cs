using CodingChallange1_800Application.CommandLine.Interfaces;
using CodingChallange1_800Application.Services;
using CodingChallange1_800Application.Services.Factories;
using CodingChallange1_800Application.Services.Interfaces;
using Moq;
using NUnit.Framework;

namespace CodingChallange1_800Application.Main
{
    [TestFixture]
    public class WorkFlowManagerTest
    {
        private Mock<IParser<IArgumentsValues>> _parser;
        private Mock<IFactory> _factory;
        private WorkFlowManager _workFlowManager;
        private Mock<FileSystemMock> _fileSystem;
        private Mock<IConsoleService> _consoleService;
        [SetUp]
        public void SetUp()
        {
            _fileSystem = FileSystemMock.New();
            _consoleService = new Mock<IConsoleService>();
            _factory = new Mock<IFactory>();
            _factory.SetupGet(x => x.FileSystem).Returns(_fileSystem.Object);
            _factory.SetupGet(x => x.ConsoleService).Returns(_consoleService.Object);
            var arguments = Mock.Of<IArgumentsValues>();
            _parser = new Mock<IParser<IArgumentsValues>>();
            _parser.Setup(x => x.Parse()).Returns(arguments);
            _parser.Setup(x => x.Usage).Returns("Special usage");
            _factory.Setup(x => x.CommandLineParser)
                .Returns(_parser.Object);
            _workFlowManager = new WorkFlowManager(_factory.Object);
        }
        [Test]
        public void PassesTheArgumentsToTheParser()
        {
            var args = new[] { "-I", "-O" };
            WhenRan(args);

            _parser.Verify(x => x.ReadArgs(args), "Parser.ReadArgs");
        }
        [Test]
        public void ShowsHelpWithNoArgs()
        {
            WithAShowHelpCommandLine();
            WhenRan();
            _parser.Verify(x => x.Usage, "Help displayed");
        }
        [Test]
        public void DoesNotShowTheHelpWithValidArguments()
        {
            WhenRan();
            _parser.Verify(x => x.Usage, Times.Never(), "Help displayed");
        }
        [Test]
        public void ParserParsesTheArguments()
        {
            var args = new[] { "-I", "-O" };
            WhenRan(args);
            _parser.Verify(x => x.ReadArgs(args), "Parser.ReadArgs");
            _parser.Verify(x => x.Parse(), "Parser.Parse");
        }
        private void WithAShowHelpCommandLine()
        {
            _parser.SetupGet(x => x.UsageShouldBeDisplayed).Returns(true);
        }
        private void WhenRan(params string[] args)
        {
            _workFlowManager.Run(args);
        }
    }
}