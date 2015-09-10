using System.Reflection;
using xBDD.Utility;

namespace xBDD.Core
{
    public interface ICoreFactory
    {
        IUtilityFactory UtilityFactory { get; }
        ITestRun CreateTestRun();
        IScenario CreateScenario(ITestRun testRun);
        IScenarioBuilder CreateScenarioBuilder(IScenarioInternal scenario);
        IScenarioRunner CreateScenarioRunner(IScenarioInternal scenario);
        IStep CreateStep(IScenarioInternal scenario);
        IStepExecutor CreateStepExecutor(IScenarioInternal scenario);
        IStepExceptionHandler CreateStepExceptionHandler(IScenarioInternal scenario);
        IScenarioOutputWriter CreateScenarioOutputWriter(IScenarioInternal scenario, IOutputWriter outputWriter);
    }
}
