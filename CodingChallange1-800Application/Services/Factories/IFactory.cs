using CodingChallange1_800Application.CommandLine.Interfaces;
using CodingChallange1_800Application.Services.Interfaces;

namespace CodingChallange1_800Application.Services.Factories
{
    public interface IFactory
    {
        IParser<IArgumentsValues> CommandLineParser { get; }
        IFileSystem FileSystem { get; }
        IConsoleService ConsoleService { get; }
    }
}