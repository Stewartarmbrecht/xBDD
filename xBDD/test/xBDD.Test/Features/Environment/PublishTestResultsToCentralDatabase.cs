using xBDD.xUnit;
using Xunit;
using Xunit.Abstractions;

namespace xBDD.Test.Features.Environment
{
    [Collection("xBDDTest")]
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
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Given(xB.CreateStep("the developer sets the solution to the Publish configuration"))
                .And(xB.CreateStep("the developer defines a valid connection string for an environment variable named 'Data:DefaultConnection:ConnectionString'"))
                .When(xB.CreateStep("the developer runs the tests"))
                .Then(xB.CreateStep("the test results should be published to the database"))
                .Run();
        }
        [ScenarioFact]
        public void PublishAfterCITestRun()
        {
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .When(xB.CreateStep("the developer pushes a commit to the master branch"))
                .Then(xB.CreateStep("the CI process should build the solution, run the tests, and publish the results to a central database"))
                .Run();
        }
    }
}
