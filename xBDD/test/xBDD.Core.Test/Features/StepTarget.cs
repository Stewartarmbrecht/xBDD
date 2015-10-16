using System;
using xBDD.Model;
using Xunit;

namespace xBDD.Core.Test.Features
{
    internal class StepTarget
    {
        internal static Step NameWillBe(string expectedName, Wrapper<Step> sut)
        {
            return xB.CreateStep(
                "the step name will be '" + expectedName + "'",
                (s) => {
                    Assert.Equal(expectedName, sut.Object.Name);
                }
                );
        }

        internal static Step FullNameWillBe(string expectedName, Wrapper<Step> sut)
        {
            return xB.CreateStep(
                "the full step name will be '" + expectedName + "'",
                (s) => {
                    Assert.Equal(expectedName, sut.Object.FullName);
                }
                );
        }

        internal static Step ActionWillNotBeNull(Wrapper<Step> stepWrapper)
        {
            return xB.CreateStep(
                "the step will have an action defined",
                (s) =>
                {
                    Assert.NotNull(stepWrapper.Object.Action);
                }
                );
        }

        internal static Step ActionTypeWillBe(ActionType actionType, Wrapper<Step> stepWrapper)
        {
            return xB.CreateStep(
                "the step action type will be "+ Enum.GetName(typeof(ActionType), actionType),
                (s) =>
                {
                    Assert.Equal(actionType, stepWrapper.Object.ActionType);
                }
                );
        }

        internal static Step AsyncActionWillNotBeNull(Wrapper<Step> stepWrapper)
        {
            return xB.CreateStep(
                "the step will have an async action defined",
                (s) =>
                {
                    Assert.NotNull(stepWrapper.Object.ActionAsync);
                }
                );
        }
    }
}