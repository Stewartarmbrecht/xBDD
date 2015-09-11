﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xBDD.xUnit;
using Xunit.Abstractions;

namespace xBDD.Test.Features.RunHtmlReport
{
    public class ViewHtmlReport
    {
        private readonly IOutputWriter outputWriter;

        public ViewHtmlReport(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }

        [ScenarioFact]
        public void ViewName()
        {
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void RunDate()
        {
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void ViewRootArea()
        {
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
    }
}
