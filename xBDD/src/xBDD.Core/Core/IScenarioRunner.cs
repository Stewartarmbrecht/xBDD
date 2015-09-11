using System.Threading.Tasks;

namespace xBDD.Core
{
    public interface IScenarioRunner
    {
        void Run();
        Task RunAsync();
        void Skip(string reason);
        Task SkipAsync(string reason);
        void SetOutputWriter(IOutputWriter outputWriter);
    }
}