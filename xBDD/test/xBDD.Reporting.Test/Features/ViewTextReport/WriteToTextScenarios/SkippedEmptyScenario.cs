using xBDD.Test;
namespace xBDD.Reporting.Test.Features.ViewTextReport.WriteToTextScenarios
{
    public class SkippedEmptyScenario : IExecute<string>
    {
        public string Execute()
        {
            var xBDD = new xBDDMock();
            xBDD.CurrentRun.TestRun.Name = "My Test Run";
            try
            {
                xBDD.CurrentRun
                    .AddScenario("My Scenario", "My Feature", "My.Area.Path")
                    .Skip("Deferred");
            }
            catch { }
            return xBDD.CurrentRun.TestRun.WriteToText();
        }
    }
}
