using System.Runtime;
using xb = xBDD;

namespace xBDD.Reporting.Database.Core
{
    public class DatabaseObjectBuilder
    {
        private DatabaseContext dbContext;
        private DatabaseFactory factory;

        public DatabaseObjectBuilder(DatabaseContext dbContext, DatabaseFactory factory)
        {
            this.dbContext = dbContext;
            this.factory = factory;
        }

        public TestRun BuildTestRun(xb.TestRun testRun)
        {
            var testRunDb = factory.CreateTestRun(testRun);
            dbContext.TestRuns.Add(testRunDb);
            BuildScenarios(testRun, testRunDb);
            return testRunDb;
        }

        private void BuildScenarios(xb.TestRun testRun, TestRun testRunDb)
        {
            foreach(xb.Scenario scenario in testRun.Scenarios)
            {
                Scenario scenarioDb = factory.CreateScenario(scenario, testRunDb);
                scenarioDb.TestRun = testRunDb;
                dbContext.Scenarios.Add(scenarioDb);
                BuildSteps(scenario, scenarioDb);
            }
        }

        private void BuildSteps(xb.Scenario scenario, Scenario scenarioDb)
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