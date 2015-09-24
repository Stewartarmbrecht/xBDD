using System;
using Xunit;

namespace xBDD.Core.Test.Features
{
    internal class ScenarioTarget
    {
        internal static Step ShouldBeCreated(Wrapper<Scenario> sut)
        {
            return xBDD.CreateStep(
                "the scenario should be created",
                () =>
                {
                    Assert.NotNull(sut.Object);
                });
        }

        internal static Step NameShouldMatchMethodName(string expectedName, Wrapper<Scenario> sut)
        {
            return xBDD.CreateStep(
                "the scenario name should match the method name with spaces: '" + expectedName + "'",
                () => {
                    Assert.Equal(expectedName, sut.Object.Name);
                }
                );
        }

        internal static Step FeatureNameShouldMatchClassName(string expectedName, Wrapper<Scenario> sut)
        {
            return xBDD.CreateStep(
                "the feature name should match the class name with spaces: '" + expectedName + "'",
                () => {
                    Assert.Equal(expectedName, sut.Object.FeatureName);
                }
                );
        }

        internal static Step ShouldHaveAStep(int stepNumber, Wrapper<Scenario> scenarioWrapper, Wrapper<Step> stepWrapper)
        {
            return xBDD.CreateStep(
                "the scenario should have a step at position " + stepNumber,
                () =>
                {
                    stepWrapper.Object = scenarioWrapper.Object.Steps[stepNumber - 1];
                    Assert.NotNull(stepWrapper.Object);
                }
                );
        }

        internal static Step AreaPathShouldMatchNamespace(string expected, Wrapper<Scenario> sut)
        {
            return xBDD.CreateStep(
                "the area path should match the namespace: '" + expected + "'",
                () => {
                    Assert.Equal(expected, sut.Object.AreaPath);
                }
                );
        }
    }
}