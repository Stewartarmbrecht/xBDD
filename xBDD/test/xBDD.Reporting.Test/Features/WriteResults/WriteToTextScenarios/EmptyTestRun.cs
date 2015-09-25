using xBDD.Test;
namespace xBDD.Reporting.Test.Features.WriteResults.WriteToTextScenarios
{
    public class EmptyTestRun : IExecute<string>
    {
        public string Execute()
        {
            var xBDD = new xBDDMock();
            xBDD.CurrentRun.Name = "My Test Run";
            return xBDD.CurrentRun.WriteToText();
        }
    }
}
