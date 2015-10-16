using xBDD.Model;

namespace xBDD.Core.Test.Features.DefineScenarios.SampleCode
{
    public class AddAReusableStep
    {
        public ScenarioBuilder Add()
        {
            return xB.CurrentRun
                .AddScenario(this)
                .Given(User.PerformsAnAction());
        }
    }

    public static class User
    {
        public static Step PerformsAnAction()
        {
            return xB.CreateStep("the user performs an action",
                (s) =>
                {
                    //my action here.
                });
        }
    }
}
