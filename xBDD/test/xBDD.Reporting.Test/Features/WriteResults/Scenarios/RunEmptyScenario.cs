using xBDD.Test;

namespace xBDD.Reporting.Test.Features.WriteResults.Scenarios
{
    public class RunEmptyScenario : IExecute<string>
    {
        public string Execute()
        {
            var xBDD = new xBDDMock();
            xBDD.CurrentRun.Name = "My Test Run";
            xBDD.CurrentRun
                .AddScenario("My Scenario", "My Feature", "My.Area.Path")
                .Run();
            return xBDD.CurrentRun.WriteToText();
        }
    }
}
