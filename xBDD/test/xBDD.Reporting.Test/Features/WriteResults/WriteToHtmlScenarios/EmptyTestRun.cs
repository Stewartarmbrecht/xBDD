﻿using xBDD.Test;
namespace xBDD.Reporting.Test.Features.WriteResults.WriteToHtmlScenarios
{
    public class EmptyTestRun : IExecute<string>
    {
        public string Execute()
        {
            var xBDD = new xBDDMock();
            xBDD.CurrentRun.TestRun.Name = "My Test Run";
            return xBDD.CurrentRun.TestRun.WriteToHtml();
        }
    }
}
