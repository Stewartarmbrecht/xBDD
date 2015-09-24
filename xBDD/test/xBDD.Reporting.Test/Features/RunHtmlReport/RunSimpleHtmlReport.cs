using xBDD.xUnit;
using Xunit;
using Xunit.Abstractions;

namespace xBDD.Test.Features.RunHtmlReport
{
    [Collection("xBDDReportingTest")]
    public class RunSimpleHtmlReport
    {
        private readonly OutputWriter outputWriter;

        public RunSimpleHtmlReport(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }

        [ScenarioFact]
        public void RunReport()
        {
            xBDD.CurrentRun.AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }

    }
}
