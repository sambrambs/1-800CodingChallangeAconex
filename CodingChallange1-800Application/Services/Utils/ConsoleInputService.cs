using System;
using CodingChallange1_800Application.Services.Interfaces;

namespace CodingChallange1_800Application.Services.Utils
{
    public class ConsoleInputService : IConsoleService
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}