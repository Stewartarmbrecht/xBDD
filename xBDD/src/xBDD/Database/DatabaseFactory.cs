using System;
using xBDD.Database;

namespace xBDD.Database
{
    internal class DatabaseFactory : IDatabaseFactory
    {
        public Scenario CreateScenario(IScenario scenario, TestRun testRun)
        {
            return new Scenario()
            {
                AreaPath = scenario.AreaPath,
                FeatureName = scenario.FeatureName,
                Name = scenario.Name,
                Outcome = scenario.Outcome,
                EndTime = scenario.EndTime,
                TestRun = testRun,
                StartTime = scenario.StartTime
            };
        }

        public Step CreateStep(IStep step, Scenario scenario)
        {
            return new Step()
            {
                EndTime = step.EndTime,
                Exception = step.Exception == null ? null : step.Exception.Message + "\n" + step.Exception.StackTrace,
                Name = step.Name,
                Outcome = step.Outcome,
                Reason = step.Reason,
                Scenario = scenario,
                StartTime = step.StartTime
            };
        }

        public TestRun CreateTestRun(ITestRun testRun)
        {
            return new TestRun()
            {
                Name = testRun.Name
            };
        }
    }
}