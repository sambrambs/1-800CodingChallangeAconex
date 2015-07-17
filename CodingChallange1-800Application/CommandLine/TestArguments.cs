using System.Collections.Generic;
using CodingChallange1_800Application.CommandLine.Interfaces;
using CommandLineParser.Arguments;

namespace CodingChallange1_800Application.CommandLine
{
    public class TestArguments : IArgumentsConfig<object>
    {
        internal const char UserShortName = 'U';
        internal const string UserLongName = "user";
        internal static readonly string UserShortArg = "-" + UserShortName;
        internal const char NumberShortName = 'N';
        internal static readonly string NumberShortArg = "-" + NumberShortName;
        internal readonly ValueArgument<string> User = new ValueArgument<string>
            (UserShortName, UserLongName)
        {
            Optional = false
        };
        internal readonly ValueArgument<int> Number = new ValueArgument<int>(NumberShortName, "number");
        public IEnumerable<Argument> All
        {
            get { return new Argument[] {User, Number}; }
        }
        internal readonly object Output = new object();
        public object AsOutput()
        {
            return Output;
        }
    }
}