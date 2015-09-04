using System.Threading.Tasks;

namespace xBDD.Core
{
    public interface IScenarioRunner
    {
        void Run();
        Task RunAsync();
    }
}