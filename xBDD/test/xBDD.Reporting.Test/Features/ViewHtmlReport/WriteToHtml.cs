using Xunit;
using Xunit.Abstractions;
using xBDD.xUnit;
using System.Threading.Tasks;

namespace xBDD.Reporting.Test.Features.ViewHtmlReport
{
    [Collection("xBDDReportingTest")]
    public class WriteToHtml
    {
        private readonly OutputWriter outputWriter;

        public WriteToHtml(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }
        
        [ScenarioFact]
        public async Task StandardFullReport()
        {
            Wrapper<string> html = new Wrapper<string>();            
            await xB.CurrentRun.AddScenario(this)
                .Given("a completed test run", (s) => {
                    var xBDD = new xBDDMock();
                    xBDD.CurrentRun.TestRun.Name = "My Test Run";
                })
                .WhenAsync("the following code executes 'var report = xBDD.CurrentRun.WriteToHTML()'", async (s) => { 
                    html.Object = await xB.CurrentRun.TestRun.WriteToHtml();
                 })
                .Then("the report variable will be a string that contains the entire HTML report that can be written to a file, or sent via email, or whatever...", (s) => { 
                    Assert.StartsWith("<!DOCTYPE html>", html.Object);
                 })
                .Run();
        }
    }
    
}