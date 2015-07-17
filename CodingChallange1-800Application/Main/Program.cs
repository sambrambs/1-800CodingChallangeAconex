using CodingChallange1_800Application.Services.Factories;

namespace CodingChallange1_800Application.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new Factory();
            var workflow = factory.NewWorkflowManager();
            workflow.Run(args);
        }
    }
}
