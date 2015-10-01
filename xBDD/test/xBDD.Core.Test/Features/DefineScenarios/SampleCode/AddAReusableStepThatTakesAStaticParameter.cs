using xBDD.Model;

namespace xBDD.Core.Test.Features.DefineScenarios.SampleCode
{
    public class AddAReusableStepThatTakesAStaticParameter
    {
        public ScenarioBuilder Add()
        {
            return xBDD.CurrentRun
                .AddScenario(this)
                .Given(ParameterUser.PerformsAnAction("save"));
        }
    }

    public static class ParameterUser
    {
        public static Step PerformsAnAction(string actionType)
        {
            return xBDD.CreateStep("the user performs a '"+actionType+"' action",
                (s) =>
                {
                    //my action here.
                });
        }
    }
}
