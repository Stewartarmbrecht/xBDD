using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Test.Features.RunHtmlReport
{
    public class ViewHtmlReportFeature
    {
        [ScenarioFact]
        public void ViewFeatureName()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void ViewFeatureStatement()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void ViewOutcomeWhenPassing()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void ViewOutcomeWhenFailing()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void ViewOutcomeWhenSkipped()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void ViewFeatureTimes()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }

        [ScenarioFact]
        public void ViewChildScenarios()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }

        [ScenarioFact]
        public void ViewChildScenarioCountsAllPassingScenarios()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void ViewChildScenarioCountsWithFaillingScenario()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void ViewChildScenarioCountsWithSkippedScenarios()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void ViewChildScenarioCountsWithSkippedAndFailingScenarios()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void ViewChildStepCountsAllPassingSteps()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void ViewChildStepCountsWithFaillingStep()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void ViewChildStepCountsWithSkippedSteps()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void ViewChildStepCountsWithSkippedAndFailingSteps()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
    }
}
