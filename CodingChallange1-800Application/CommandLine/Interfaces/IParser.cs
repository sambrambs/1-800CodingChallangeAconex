namespace CodingChallange1_800Application.CommandLine.Interfaces
{
    public interface IParser<T> : ICommandLine
    {
        string Usage { get; }
        bool UsageShouldBeDisplayed { get; }
        void ReadArgs(string[] args);
        T Parse();
    }
}