namespace xBDD.Test.Features.DefineScenarios
{
    public class SpecifyParameters
    {
        [ScenarioFact]
        public void InlineWithTypedState()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void InlineWithDynamicState()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void MultilineParameter()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void TableParameter()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
    }
}
