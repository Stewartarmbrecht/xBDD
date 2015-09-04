using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Test.Features.RunHtmlReport
{
    public class ViewHtmlReportScenario

    {
        [ScenarioFact]
        public void ViewName()
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
        public void ViewTimes()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }

        [ScenarioFact]
        public void ViewChildSteps()
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
