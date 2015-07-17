using CodingChallange1_800Application.Services.Interfaces;
using Moq;
using NUnit.Framework;

namespace CodingChallange1_800Application.Services
{
    [TestFixture]
    public class ConsoleInputReaderTest
    {
        
        [Test]
        public void ReadsFromConsoleService()
        {
            var consoleService = new Mock<IConsoleService>();
            var consoleReader = new ConsoleInputReader(consoleService.Object);
            consoleReader.Read();
            consoleService.Verify(x=>x.Read(), Times.AtLeastOnce, "Console.Read"
                );
        }
    }
}