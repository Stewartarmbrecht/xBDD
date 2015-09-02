﻿using Xunit;

namespace xBDD.Test.Features.OverridingNames
{
    public class OverrideScenarioName
    {
        [Fact]
        public void WhenAddingScenario()
        {
            var scenarioName = "Create Scenario With Name";
            var scenario = xBDD.CurrentRun.AddScenario(scenarioName);
            Assert.Equal(scenarioName, scenario.Name);
        }
        [Fact]
        [ScenarioName("With A Scenario Name Attribute")]
        public void WithScenarioNameAttribute()
        {
            var scenario = xBDD.CurrentRun.AddScenario();
            Assert.Equal("With A Scenario Name Attribute", scenario.Name);
        }
    }
}
