using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Test.Features.RunHtmlReport
{
    public class ViewHtmlReport
    {
        [ScenarioFact]
        public void ViewName()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void RunDate()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void ViewRootArea()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
    }
}
