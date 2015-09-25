using xBDD.Test;
namespace xBDD.Reporting.Test.Features.WriteResults.WriteToTextScenarios
{
    public class RunMultipleAreas : IExecute<string>
    {
        public string Execute()
        {
            var xBDD = new xBDDMock();
            xBDD.CurrentRun.Name = "My Test Run";
            try
            {
                xBDD.CurrentRun
                    .AddScenario("My Scenario One", "My Feature One", "My.Area.Path.One")
                    .Given(xBDD.CreateStep("my starting condition"))
                    .When(xBDD.CreateStep("my action"))
                    .Then(xBDD.CreateStep("my ending condition"))
                    .Run();
                xBDD.CurrentRun
                    .AddScenario("My Scenario Two", "My Feature One", "My.Area.Path.One")
                    .Given(xBDD.CreateStep("my starting condition"))
                    .When(xBDD.CreateStep("my action"))
                    .Then(xBDD.CreateStep("my ending condition"))
                    .Run();
                xBDD.CurrentRun
                    .AddScenario("My Scenario One", "My Feature Two", "My.Area.Path.Two")
                    .Given(xBDD.CreateStep("my starting condition"))
                    .When(xBDD.CreateStep("my action"))
                    .Then(xBDD.CreateStep("my ending condition"))
                    .Run();
                xBDD.CurrentRun
                    .AddScenario("My Scenario Two", "My Feature Two", "My.Area.Path.Two")
                    .Given(xBDD.CreateStep("my starting condition"))
                    .When(xBDD.CreateStep("my action"))
                    .Then(xBDD.CreateStep("my ending condition"))
                    .Run();
            }
            catch { }
            return xBDD.CurrentRun.WriteToText();
        }
    }
}
