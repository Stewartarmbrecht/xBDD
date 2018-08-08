using System.Threading.Tasks;
using xBDD.Test;
namespace xBDD.Reporting.Features.GenerateTextReport.WriteToTextScenarios
{
    public class RunEmptyScenario : IExecute<string>
    {
        public async Task<string> Execute()
        {
            var xBDD = new xBDDMock();
            xBDD.CurrentRun.TestRun.Name = "My Test Run";
            await xBDD.CurrentRun
                .AddScenario("My Scenario", "My Feature", "My.Area.Path")
                .Run();
            return await xBDD.CurrentRun.TestRun.WriteToText();
        }
    }
}
