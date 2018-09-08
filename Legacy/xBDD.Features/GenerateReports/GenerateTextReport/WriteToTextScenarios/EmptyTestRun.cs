using System.Threading.Tasks;
using xBDD.Features;
namespace xBDD.Features.GenerateReports.GenerateTextReport.WriteToTextScenarios
{
    public class EmptyTestRun : IExecute<string>
    {
        public async Task<string> Execute()
        {
            return await Task.Run(() => {
                var xBDD = new xBDDMock();
                xBDD.CurrentRun.TestRun.Name = "My Test Run";
                return xBDD.CurrentRun.TestRun.WriteToText();
            });
        }
    }
}
