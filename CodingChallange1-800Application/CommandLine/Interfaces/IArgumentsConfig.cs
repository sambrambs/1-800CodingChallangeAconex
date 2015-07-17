using System.Collections.Generic;
using CommandLineParser.Arguments;

namespace CodingChallange1_800Application.CommandLine.Interfaces
{
    public interface IArgumentsConfig<T>
    {
        IEnumerable<Argument> All { get; }
        T AsOutput();
    }
}