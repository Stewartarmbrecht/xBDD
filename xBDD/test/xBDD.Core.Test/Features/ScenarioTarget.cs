using System;
using Xunit;

namespace xBDD.Core.Test.Features
{
    internal class ScenarioTarget
    {
        internal static Step WillBeCreated(Wrapper<Scenario> sut)
        {
            return xBDD.CreateStep(
                "the scenario will be created",
                () =>
                {
                    Assert.NotNull(sut.Object);
                });
        }

        internal static Step NameWillMatchMethodName(string expectedName, Wrapper<Scenario> sut)
        {
            return xBDD.CreateStep(
                "the scenario name will match the method name with spaces: '" + expectedName + "'",
                () => {
                    Assert.Equal(expectedName, sut.Object.Name);
                }
                );
        }

        internal static Step FeatureNameWillMatchClassName(string expectedName, Wrapper<Scenario> sut)
        {
            return xBDD.CreateStep(
                "the feature name will match the class name with spaces: '" + expectedName + "'",
                () => {
                    Assert.Equal(expectedName, sut.Object.FeatureName);
                }
                );
        }

        internal static Step WillHaveAStep(int stepNumber, Wrapper<Scenario> scenarioWrapper, Wrapper<Step> stepWrapper)
        {
            return xBDD.CreateStep(
                "the scenario will have a step at position " + stepNumber,
                () =>
                {
                    stepWrapper.Object = scenarioWrapper.Object.Steps[stepNumber - 1];
                    Assert.NotNull(stepWrapper.Object);
                }
                );
        }

        internal static Step AreaPathWillMatchNamespace(string expected, Wrapper<Scenario> sut)
        {
            return xBDD.CreateStep(
                "the area path will match the namespace: '" + expected + "'",
                () => {
                    Assert.Equal(expected, sut.Object.AreaPath);
                }
                );
        }

        internal static Step WillHaveOutcome(Outcome outcome, Wrapper<Scenario> sut)
        {
            return xBDD.CreateStep(
                "the scenario will have an outcome of '" + Enum.GetName(typeof(Outcome), outcome) + "'",
                () => {
                    Assert.Equal(outcome, sut.Object.Outcome);
                }
                );
        }
    }
}