using System;
using Xunit;

namespace xBDD.Core.Test.Features
{
    internal class StepTarget
    {
        internal static Step NameShouldBe(string expectedName, Wrapper<Step> sut)
        {
            return xBDD.CreateStep(
                "the step name should be '" + expectedName + "'",
                () => {
                    Assert.Equal(expectedName, sut.Object.Name);
                }
                );
        }

        internal static Step FullNameShouldBe(string expectedName, Wrapper<Step> sut)
        {
            return xBDD.CreateStep(
                "the full step name should be '" + expectedName + "'",
                () => {
                    Assert.Equal(expectedName, sut.Object.FullName);
                }
                );
        }

        internal static Step ActionShouldNotBeNull(Wrapper<Step> stepWrapper)
        {
            return xBDD.CreateStep(
                "the step should have an action defined",
                () =>
                {
                    Assert.NotNull(stepWrapper.Object.Action);
                }
                );
        }
    }
}