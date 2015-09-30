using System.Linq;
using xb = xBDD.Model;

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
            var scenarios = from area in testRun.Areas
                            from feature in area.Features
                            from scenario in feature.Scenarios
                            select scenario; 
            foreach(xb.Scenario scenario in scenarios)
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