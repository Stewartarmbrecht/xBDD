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
        }
    }
}
