using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Test.Features.RunHtmlReport
{
    public class ViewHtmlReportStep

    {
        [ScenarioFact]
        public void ViewName()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void ViewMultilineParameter()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void ViewTableParameter()
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
    }
}
