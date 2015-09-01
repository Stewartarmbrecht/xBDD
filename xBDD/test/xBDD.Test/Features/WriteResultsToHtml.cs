namespace xBDD.Test.Features
{
    public class WriteResultsToHtml
    {
        public void WriteSimpleTestRun()
        {
            BuildAndExecuteTestRun();
            IReportWriter writer = xBDD.ReportFactory.GetHtmlReportWriter();
            writer.WriteReport(xBDD.CurrentRun);
        }

        private void BuildAndExecuteTestRun()
        {
            for(int i = 0; i < 3; i++)
            {
                var area = "Sample.Area" + (i+1).ToString();
                BuildFeatures(area);
            }
        }

        private static void BuildFeatures(string area)
        {
            for (int i = 0; i < 3; i++)
            {
                var feature = "Feature " + (i + 1).ToString();
                BuildScenarios(area, feature);
            }
        }

        private static void BuildScenarios(string area, string feature)
        {
            for (int i = 0; i < 3; i++)
            {
                var scenario = xBDD.CurrentRun.AddScenario(area, feature, "Scenario " + (i + 1).ToString());
                scenario.Given("Condition 1", step => { });
                scenario.And("Condition 2", step => { });
                scenario.When("Action 1", step => { });
                scenario.Then("Validation 1", step => { });
                scenario.Run();
            }
        }
    }
}
