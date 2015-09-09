using System;
using xBDD.Test.Sample;
using Xunit;

namespace xBDD.Test.Features.OverrideNames
{
    [StepLibrary]
    public class Steps : CommonSteps
    {
        public string ExpectedAreaPath { get; internal set; }
        public string ExpectedFeatureName { get; internal set; }
        public string ExpectedScenarioName { get; internal set; }
        public string StepName { get; internal set; }
        public string PageName { get; internal set; }
        public string ParameterReplacementCall { get; internal set; }
        public string NewStepName { get; internal set; }

        internal void the_step_name_should_be_NewStepName(IStep obj)
        {
            throw new NotImplementedException();
        }

        internal void the_step_calls_to_replace_the_parameters_in_its_name_with_ParameterReplacementCall(IStep obj)
        {
        }

        #region Given
        internal void the_scenario_has_a_step_with_the_name_StepName(IStep obj)
        {
            Scenario.Given(StepName, st => { });
            Step = Scenario.Steps[0];
        }

        #endregion 
    }
}
