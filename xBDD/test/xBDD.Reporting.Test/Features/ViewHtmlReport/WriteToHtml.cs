using Xunit;
using Xunit.Abstractions;
using xBDD.xUnit;

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
        public void GetString()
        {
            Wrapper<string> html = new Wrapper<string>();            
            xBDD.CurrentRun.AddScenario(this)
                .When("the code calls 'xBDD.CurrentRun.WriteToHTML()", () => { 
                    var xBDD = new xBDDMock();
                    xBDD.CurrentRun.TestRun.Name = "My Test Run";
                    html.Object = xBDD.CurrentRun.TestRun.WriteToHtml();
                 })
                .Then("the code should return a string value of the html report", () => { 
                    Assert.StartsWith("<!DOCTYPE html>", html.Object);
                 })
                .Run();
        }
    }
    
}