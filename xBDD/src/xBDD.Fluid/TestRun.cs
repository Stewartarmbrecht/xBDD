using System;

namespace xBDD.Fluid
{
    public class TestRun
    {
        public Scenario AddScenario(string scenarioName)
        {
            return new Scenario();
        }
        public NewScenario AddNewScenario(string scenarioName)
        {
            return new NewScenario();
        }
    }
}