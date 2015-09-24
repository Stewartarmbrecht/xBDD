using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Fluid.Tests.Steps
{
    public static class CalculatorUser
    {
        internal static Func<Step<Calculator>> GetsACalculator()
        {
            return () =>
            {
                Calculator calc = new Calculator();
                Step<Calculator> step = new Step<Calculator>(calc);
                step.AppendTitle("the user has an instance of the calculator");
                return step;
            };
        }

        internal static Func<Step<Calculator>, Step<Calculator>> Presses(string value)
        {
            return previousStep =>
            {
                var step = previousStep.GetNextStep(previousStep.State);
                step.AppendTitle("the user enters '" + value + "'");
                step.Action = () => {
                    step.State.Enter(value);
                };
                return step;
            };
        }

        internal static Func<Step<Calculator>, Step<Calculator>> ShouldSeeAResultOf(int display)
        {
            return previousStep =>
            {
                var step = previousStep.GetNextStep(previousStep.State);
                step.AppendTitle("the should see '" + display + "'");
                step.Action = () => {
                    if (step.State.Display != display)
                        throw new Exception("Display is wrong.  Expected: " + display + " Actual: " + step.State.Display);
                };
                return step;
            };
        }

        internal static Step HasACalculator(Calculator calc)
        {
            var step = new Step();
            step.AppendTitle("the user has a calculator");
            step.Action = () => { calc = new Calculator(); };
            return step;
        }

        internal static Step EntersASeries(Calculator sut, params string[] keys)
        {
            var step = new Step();
            step.AppendTitle("the user enters '" + keys.ToString() + "'");
            step.Action = () => {
                foreach (string key in keys)
                {
                    sut.Enter(key);
                }
            };
            return step;
        }

        internal static Step ShouldSeeADisplayOf(Calculator sut, string displayValue)
        {
            var step = new Step();
            step.AppendTitle("the user should see a display of '" + displayValue + "'");
            step.Action = () => {
                if (sut.Display != 4)
                    throw new Exception("Display was not "+displayValue+" it was '" + sut.Display + "'");
            };
            return step;
        }
    }
}
