using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Core.Test.Features.DefineScenarios.SampleCode
{
    public class AddAReusableStep
    {
        public Scenario DefaultMethod()
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
                () =>
                {
                    //my action here.
                });
        }
    }
}
