using System;
using xBDD.Model;
using Xunit;

namespace xBDD.Core.Test.Features
{
    internal class ScenarioTarget
    {
        internal static Step WillBeCreated(Wrapper<Scenario> sut)
        {
            return xB.CreateStep(
                "the scenario will be created",
                (s) =>
                {
                    Assert.NotNull(sut.Object);
                });
        }

        internal static Step NameWillMatchMethodName(string expectedName, Wrapper<Scenario> sut)
        {
            return xB.CreateStep(
                "the scenario name will match the method name with spaces: '" + expectedName + "'",
                (s) => {
                    Assert.Equal(expectedName, sut.Object.Name);
                }
                );
        }

        internal static Step FeatureNameWillMatchClassName(string expectedName, Wrapper<Scenario> sut)
        {
            return xB.CreateStep(
                "the feature name will match the class name with spaces: '" + expectedName + "'",
                (s) => {
                    Assert.Equal(expectedName, sut.Object.Feature.Name);
                }
                );
        }

        internal static Step WillHaveAStep(int stepNumber, Wrapper<Scenario> scenarioWrapper, Wrapper<Step> stepWrapper)
        {
            return xB.CreateStep(
                "the scenario will have a step at position " + stepNumber,
                (s) =>
                {
                    stepWrapper.Object = scenarioWrapper.Object.Steps[stepNumber - 1];
                    Assert.NotNull(stepWrapper.Object);
                }
                );
        }

        internal static Step AreaPathWillMatchNamespace(string expected, Wrapper<Scenario> sut)
        {
            return xB.CreateStep(
                "the area path will match the namespace: '" + expected + "'",
                (s) => {
                    Assert.Equal(expected, sut.Object.Feature.Area.Name);
                }
                );
        }

        internal static Step WillHaveOutcome(Outcome outcome, Wrapper<Scenario> sut)
        {
            return xB.CreateStep(
                "the scenario will have an outcome of '" + Enum.GetName(typeof(Outcome), outcome) + "'",
                (s) => {
                    Assert.Equal(outcome, sut.Object.Outcome);
                }
                );
        }
    }
}