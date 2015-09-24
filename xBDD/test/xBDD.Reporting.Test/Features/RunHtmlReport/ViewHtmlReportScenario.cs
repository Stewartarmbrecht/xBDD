using xBDD.xUnit;
using Xunit.Abstractions;

namespace xBDD.Test.Features.RunHtmlReport
{
    public class ViewHtmlReportScenario

    {
        private readonly OutputWriter outputWriter;

        public ViewHtmlReportScenario(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }

        [ScenarioFact]
        public void ViewName()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void ViewOutcomeWhenPassing()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void ViewOutcomeWhenFailing()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void ViewOutcomeWhenSkipped()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void ViewTimes()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }

        [ScenarioFact]
        public void ViewChildSteps()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }

        [ScenarioFact]
        public void ViewChildStepCountsAllPassingSteps()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void ViewChildStepCountsWithFaillingStep()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void ViewChildStepCountsWithSkippedSteps()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void ViewChildStepCountsWithSkippedAndFailingSteps()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
    }
}
