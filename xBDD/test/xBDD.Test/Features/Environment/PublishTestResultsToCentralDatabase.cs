using xBDD.xUnit;
using Xunit.Abstractions;

namespace xBDD.Test.Features.Environment
{
    public class PublishTestResultsToCentralDatabase
    {
        private readonly OutputWriter outputWriter;

        public PublishTestResultsToCentralDatabase(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }

        [ScenarioFact]
        public void PublishAfterTestRun ()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Given(xBDD.CreateStep("the developer sets the solution to the Publish configuration"))
                .And(xBDD.CreateStep("the developer defines a valid connection string for an environment variable named 'Data:DefaultConnection:ConnectionString'"))
                .When(xBDD.CreateStep("the developer runs the tests"))
                .Then(xBDD.CreateStep("the test results should be published to the database"))
                .Run();
        }
        [ScenarioFact]
        public void PublishAfterCTestRun()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Re-writing");
            //var s = new Steps();
            //xBDD.CurrentRun
            //    .AddScenario(this)
            //    .SetOutputWriter(outputWriter)
            //    .When(s.When.a_developer_pushes_a_commit_to_the_GitHub_repository)
            //    .Then(s.Then.a_visual_studio_online_build_should_trigger)
            //    .And(s.Then.build_the_projects)
            //    .And(s.Then.run_the_tests)
            //    .And(s.Then.publish_the_xBDD_test_restults_to_an_azure_database)
            //    .And(s.Then.publish_the_xUnit_test_restults_to_visual_studio_online)
            //    .Run();
        }
    }
}
