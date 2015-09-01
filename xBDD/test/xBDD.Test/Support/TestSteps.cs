using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Test.Support
{
    public static class TestSteps
    {
        public static void TheUserSuccessfullyLogsInAfterXFailedAttempts(IStep step, int count)
        {
            step.SetNameWithReplacement("X", count.ToString());
        }
        public static void TheUserNavigatesToTheXPage(IStep step, Page page)
        {
            step.SetNameWithReplacement("X", page.PageName);
            page.Response = "Here you go!";
        }
        public static void TheLoadedPageShouldHaveATitleOfX(IStep step, Page page, string title)
        {
            step.SetNameWithReplacement("X", page.PageName);
        }
        public static void TheLoadedPageShouldHaveAMessageOfX(IStep step, Page state, string message)
        {
            step.SetNameWithReplacement("X", "'" + message + "'");
        }
        public static void Step_1(IStep step)
        {
            step.Scenario.State.Counter = 1;
        }
        public static void Step_2(IStep step)
        {
            step.Scenario.State.Counter++;
        }
        public static void Step_3(IStep step)
        {
            step.Scenario.State.Counter++;
        }
        public static void Step_4(IStep step)
        {
            step.Scenario.State.Counter++;
        }

    }
}
