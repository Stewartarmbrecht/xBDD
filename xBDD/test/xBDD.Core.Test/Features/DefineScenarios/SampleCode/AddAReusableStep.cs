using xBDD.Model;

namespace xBDD.Core.Test.Features.DefineScenarios.SampleCode
{
    public class AddAReusableStep
    {
        public ScenarioBuilder Add()
        {
            return xBDD.CurrentRun
                .AddScenario(this)
                .Given(User.PerformsAnAction());
        }
    }

    public static class User
    {
        public static Step PerformsAnAction()
        {
            return xBDD.CreateStep("the user performs an action",
                (s) =>
                {
                    //my action here.
                });
        }
    }
}
