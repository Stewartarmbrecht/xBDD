namespace xBDD.Features.GenerateReports.GenerateHtmlReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Threading.Tasks;
	using xBDD.Features.Actors;
	using xBDD.Features.Pages;

    [TestClass]
    public class WriteToHtml: xBDDFeatureBase
    {
        Developer you = new Developer();

        [TestMethod]
        public async Task StandardFullReport()
        {
			var pathToOutputFile = "../MySample.Features/test-results/MySample.Features.Results.All.html";
			var pathToTemplateFile = "../xBDD.Features/GenerateReports/GenerateHtmlReport/WriteToHtml.template";
            await xB.CurrentRun.AddScenario(this, 1)
                .Given(you.HaveATestProjectThatProducesAllOutcomes())
                .When(you.HaveTheFollowingTestSetupAndBreakdownClass("that generates the html report"))
                .And(you.ExecuteTheTestRun())
                .Then(you.WillSeeTheOutputMatches(pathToTemplateFile, pathToOutputFile, "you will see an html report is generated that displays the test results in a collapsible tree"))
                .Run();
        }
    }
    
}