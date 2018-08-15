using System.Threading.Tasks;
using xBDD.Features;
namespace xBDD.Features.GenerateReports.GenerateTextReport.WriteToTextScenarios
{
    public class SkippedEmptyScenario : IExecute<string>
    {
        public async Task<string> Execute()
        {
            var xBDD = new xBDDMock();
            xBDD.CurrentRun.TestRun.Name = "My Test Run";
            try
            {
                await xBDD.CurrentRun
                    .AddScenario("My Scenario", "My Feature", "My.Area.Path")
	    			.Skip("Deferred", reason => { } );
            }
            catch { }
            return await xBDD.CurrentRun.TestRun.WriteToText();
        }
    }
}
