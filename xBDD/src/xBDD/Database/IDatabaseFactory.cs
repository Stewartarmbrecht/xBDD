using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Database
{
    public interface IDatabaseFactory
    {
        TestRun CreateTestRun(ITestRun testRun);
        Scenario CreateScenario(IScenario scenario, TestRun testRun);
        Step CreateStep(IStep step, Scenario scenario);
    }
}
