using xBDD.xUnit;
using Xunit.Abstractions;

namespace xBDD.Test.Features.RunHtmlReport
{
    public class ViewHtmlReportStep

    {
        private readonly IOutputWriter outputWriter;

        public ViewHtmlReportStep(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }

        [ScenarioFact]
        public void ViewName()
        {
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Skip();
        }
        [ScenarioFact]
        public void ViewMultilineParameter()
        {
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Skip();
        }
        [ScenarioFact]
        public void ViewTableParameter()
        {
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Skip();
        }
        [ScenarioFact]
        public void ViewOutcomeWhenPassing()
        {
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Skip();
        }
        [ScenarioFact]
        public void ViewOutcomeWhenFailing()
        {
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Skip();
        }
        [ScenarioFact]
        public void ViewOutcomeWhenSkipped()
        {
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Skip();
        }
    }
}
