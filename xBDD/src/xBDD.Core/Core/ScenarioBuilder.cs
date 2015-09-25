using System;
using System.Threading.Tasks;

namespace xBDD.Core
{
    public class ScenarioBuilder
    {
        CoreFactory factory;
        Scenario scenario;

        public ScenarioBuilder(Scenario scenario, CoreFactory factory)
        {
            this.factory = factory;
            this.scenario = scenario;
        }

        public Scenario Given(Step step)
        {
            step.ActionType = ActionType.Given;
            step.Scenario = scenario;
            scenario.Steps.Add(step);
            return scenario;
        }
        public Scenario When(Step step)
        {
            step.ActionType = ActionType.When;
            step.Scenario = scenario;
            scenario.Steps.Add(step);
            return scenario;
        }
        public Scenario Then(Step step)
        {
            step.ActionType = ActionType.Then;
            step.Scenario = scenario;
            scenario.Steps.Add(step);
            return scenario;
        }

        public Scenario And(Step step)
        {
            step.ActionType = ActionType.And;
            step.Scenario = scenario;
            scenario.Steps.Add(step);
            return scenario;
        }
    }
}
