using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Test.Sample
{
    public interface ISimpleTestRun
    {
        IScenario Scenario { get; set; }

        void FailingScenario();
        Task FailingScenarioAsync();
        void PassingScenario();
        Task PassingScenarioAsync();
        void FailingScenarioWithFailingTimeCapturingStep();
        void PassingScenarioWithTimeCapturingStep();
        void SkippedScenario();
        int SaveToDatabase(string connectionName);
    }
}
