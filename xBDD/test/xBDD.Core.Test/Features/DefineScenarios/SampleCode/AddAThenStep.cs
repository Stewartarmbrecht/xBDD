﻿namespace xBDD.Core.Test.Features.DefineScenarios.SampleCode
{
    public class AddAThenStep
    {
        public ScenarioBuilder Add()
        {
            return xBDD.CurrentRun
                .AddScenario(this)
                .Given(xBDD.CreateStep("my starting condition", () => { /*my setup here*/ }))
                .When(xBDD.CreateStep("my action", () => { /*my action here*/ }))
                .Then(xBDD.CreateStep("my ending condition", () => { /*my validation here*/ }));
        }
    }
}
