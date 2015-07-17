using System.IO;

namespace CodingChallange1_800Application.CommandLine.Interfaces
{
    public interface IArgumentsValues
    {
        FileInfo InputFile { get; }
        FileInfo DictionaryFile { get; }
    }
}