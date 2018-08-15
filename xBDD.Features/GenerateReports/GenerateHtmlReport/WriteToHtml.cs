namespace xBDD.Features.GenerateReports.GenerateHtmlReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Threading.Tasks;
	using xBDD.Features.Actors;
	using xBDD.Features.Pages;

    [TestClass]
    public class WriteToHtml
    {
        private readonly TestContextWriter outputWriter;

        public WriteToHtml()
        {
            outputWriter = new TestContextWriter();
        }
        
        [TestMethod]
        public async Task StandardFullReport()
        {
            var xBDD = new xBDDMock();
            Wrapper<string> html = new Wrapper<string>();            
            await xB.CurrentRun.AddScenario(this, 1)
                .GivenAsync("you execute a test run", async (s) => {
                    xBDD.CurrentRun.TestRun.Name = "My Test Run";
                    await xBDD.CurrentRun.AddScenario("My Scenario", "My Feature", "My Area")
                        .Given("My Step 1",(ms)=> {})
                        .When("My Step 2",(ms)=> {})
                        .Then("My Step 3", (ms) => {})
                        .Run();
                })
                .WhenAsync("you execute the following code:", async (s) => { 
                    html.Object = await xBDD.CurrentRun.TestRun.WriteToHtml();
                 }, "string report = xB.CurrentRun.WriteToHTML()", TextFormat.sh)
                .Then("the report string will contain the entire HTML report that can be written to a file, sent via email, etc.", (s) => { 
                    Assert.AreEqual(html.Object.IndexOf("<!DOCTYPE html>"), 0);
                    s.Output = html.Object;
                    s.OutputFormat = TextFormat.sh;
                 })
                .Run();
        }
    }
    
}