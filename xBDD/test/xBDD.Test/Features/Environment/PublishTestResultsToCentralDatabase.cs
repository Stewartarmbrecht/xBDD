using System.Threading.Tasks;
//using xBDD.xUnit;
//using Xunit;
//using Xunit.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace xBDD.Test.Features.Environment
{
    [TestClass]
    public class PublishTestResultsToCentralDatabase
    {
        private readonly TestContextWriter outputWriter;

        public PublishTestResultsToCentralDatabase()
        {
            outputWriter = new TestContextWriter();
        }

        [TestMethod]
        public async Task PublishAfterTestRun ()
        {
            await xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Given(xB.CreateStep("the developer sets the solution to the Publish configuration"))
                .And(xB.CreateStep("the developer defines a valid connection string for an environment variable named 'Data:DefaultConnection:ConnectionString'"))
                .When(xB.CreateStep("the developer runs the tests"))
                .Then(xB.CreateStep("the test results should be published to the database"))
                .Run();
        }
        [TestMethod]
        public async Task PublishAfterCITestRun()
        {
            await xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .When(xB.CreateStep("the developer pushes a commit to the master branch"))
                .Then(xB.CreateStep("the CI process should build the solution, run the tests, and publish the results to a central database"))
                .Run();
        }
    }
}
