namespace xBDD.Features.GenerateReports.GenerateJsonReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Threading.Tasks;
	using xBDD.Features.Actors;
	using xBDD.Features.Pages;

    [TestClass]
    public class WriteToJson
    {
        private readonly TestContextWriter outputWriter;

        public WriteToJson()
        {
            outputWriter = new TestContextWriter();
        }
        
        [TestMethod]
        public async Task StandardFullReport()
        {
            Wrapper<string> html = new Wrapper<string>();            
            await xB.CurrentRun.AddScenario(this, 1)
                .Given("you execute a test run", (s) => {
                    var xBDD = new xBDDMock();
                    xBDD.CurrentRun.TestRun.Name = "My Test Run";
                })
                .When("you execute the following code:", (s) => { 
                    html.Object = xB.CurrentRun.TestRun.WriteToJson();
                 }, "string report = xBDD.CurrentRun.WriteToJson()", TextFormat.sh)
                .Then("the report string will contains the entire Json representation of the test run", (s) => { 
                    Assert.AreEqual(html.Object.IndexOf("{"), 0);
                    s.Output = html.Object;
                    s.OutputFormat = TextFormat.js;
                 })
                .Run();
        }
    }
    
}