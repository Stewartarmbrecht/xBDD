using xBDD.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace xBDD.Reporting.Features.ViewHtmlReport
{
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
                    Assert.AreEqual(html.Object.IndexOf("<!DOCTYPE html>"), 0);
                 })
                .Run();
        }
    }
    
}