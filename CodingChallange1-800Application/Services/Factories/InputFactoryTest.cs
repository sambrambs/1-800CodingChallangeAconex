using System.IO;
using NUnit.Framework;

namespace CodingChallange1_800Application.Services.Factories
{
    [TestFixture]
    public class InputFactoryTest
    {
        [Test]
        public void InputFactoryreturnsConsoleInputReaderIfFileAbsent()
        {
            var inputFactory = new InputFactory(null);
            var inputReader = inputFactory.InputReader();
            Assert.AreEqual(typeof(ConsoleInputReader), inputReader.GetType(), "Console input reader");
        }

        [Test]
        public void InputFactoryreturnsFileInputReaderIfFilePresent()
        {
            var inputFactory = new InputFactory(new FileInfo("file"));
            var inputReader = inputFactory.InputReader();
            Assert.AreEqual(typeof(FileInputReader), inputReader.GetType(), "Console input reader");
        }
    }
}