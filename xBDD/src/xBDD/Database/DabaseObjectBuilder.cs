using System;
using xBDD.Database;

namespace xBDD.Database
{
    internal class DabaseObjectBuilder : IDatabaseObjectBuilder
    {
        private IxBDDDbContext dbContext;
        private IDatabaseFactory factory;

        public DabaseObjectBuilder(IxBDDDbContext dbContext, IDatabaseFactory factory)
        {
            this.dbContext = dbContext;
            this.factory = factory;
        }

        public TestRun BuildTestRun(ITestRun testRun)
        {
            var testRunDb = factory.CreateTestRun(testRun);
            dbContext.TestRuns.Add(testRunDb);
            BuildScenarios(testRun, testRunDb);
            return testRunDb;
        }

        private void BuildScenarios(ITestRun testRun, TestRun testRunDb)
        {
            foreach(var scenario in testRun.Scenarios)
            {
                Scenario scenarioDb = factory.CreateScenario(scenario, testRunDb);
                scenarioDb.TestRun = testRunDb;
                dbContext.Scenarios.Add(scenarioDb);
                BuildSteps(scenario, scenarioDb);
            }
        }

        private void BuildSteps(IScenario scenario, Scenario scenarioDb)
        {
            foreach(var step in scenario.Steps)
            {
                Step stepDb = factory.CreateStep(step, scenarioDb);
                stepDb.Scenario = scenarioDb;
                dbContext.Steps.Add(stepDb);
            }
        }
    }
}