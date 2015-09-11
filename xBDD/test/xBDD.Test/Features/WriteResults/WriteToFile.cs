using Microsoft.Framework.Runtime;
using Microsoft.Framework.Runtime.Infrastructure;
using Microsoft.Framework.DependencyInjection;
using System.IO;
using xBDD.xUnit;
using Xunit;
using Xunit.Abstractions;

namespace xBDD.Test.Features.SaveResults
{
    [Collection("TestRunCollection")]
    public class WriteToFile
    {
        private readonly IOutputWriter outputWriter;

        public WriteToFile(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }

        [ScenarioFact]
        public void WriteEmtpyTestRun()
        {
            var s = new Steps();
            s.State.TestRunName = "My Test Run";
            s.State.FileName = "EmptyTestRun.xml";
            var provider = CallContextServiceLocator.Locator.ServiceProvider;
            var appEnv = provider.GetRequiredService<IApplicationEnvironment>();

            s.State.ExpectedFileText = File.ReadAllText(appEnv.ApplicationBasePath + "\\Features\\WriteResults\\TextFiles\\EmptyTestRun.txt");
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_test_run_with_name_TestRunName)
                .And("the xBDD.Reporting package is referenced", step => { })
                .When(s.When.the_WriteToFile_method_is_called_on_the_test_run)
                .Then(s.Then.the_file_writen_will_match_the_following)
                .Run();
        }

        [ScenarioFact]
        public void ToExistingDatabase()
        {
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Skip();
        }

        [ScenarioFact]
        public void ToExistingDatabaseFails()
        {
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Skip();
        }

        [ScenarioFact]
        public void GetTestResults()
        {
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Skip();
        }
    }
}
