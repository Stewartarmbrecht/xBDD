using System.Threading.Tasks;
using xBDD.Test;
namespace xBDD.Reporting.Test.Features.ViewTextReport.WriteToTextScenarios
{
    public class EmptyTestRun : IExecute<string>
    {
        public async Task<string> Execute()
        {
            var xBDD = new xBDDMock();
            xBDD.CurrentRun.TestRun.Name = "My Test Run";
            return await xBDD.CurrentRun.TestRun.WriteToText();
        }
    }
}
