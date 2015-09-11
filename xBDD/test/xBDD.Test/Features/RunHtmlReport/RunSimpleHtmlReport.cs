using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xBDD.xUnit;
using Xunit.Abstractions;

namespace xBDD.Test.Features.RunHtmlReport
{
    public class RunSimpleHtmlReport
    {
        private readonly IOutputWriter outputWriter;

        public RunSimpleHtmlReport(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }

        [ScenarioFact]
        public void RunReport()
        {
            xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }

    }
}
