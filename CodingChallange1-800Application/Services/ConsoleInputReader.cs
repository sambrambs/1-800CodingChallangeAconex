using CodingChallange1_800Application.Services.Interfaces;

namespace CodingChallange1_800Application.Services
{
    public class ConsoleInputReader : IInputReader
    {
        private readonly IConsoleService _consoleService;
        public ConsoleInputReader(IConsoleService consoleService)
        {
            _consoleService = consoleService;
        }
        public string Read()
        {
            return _consoleService.Read();
        }
    }
}