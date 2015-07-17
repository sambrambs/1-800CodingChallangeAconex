using System;

namespace CodingChallange1_800Application.CommandLine.Utils
{
    public static class Help
    {
        internal static readonly string InputFileArgument = Format(
            "Input file argument");
        internal static readonly string DictionaryFileArgument = Format(
            "Dictionary file argument");
        private static string Format(params string[] lines)
        {
            return String.Join("\r\n\t\t", lines);
        }
    }
}