using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Fluid.Tests.Steps
{
    public class User
    {
        public static Func<Step<IWebPage>> LogsIn(string userName, string password)
        {
            return () =>
            {
                WebPage wp = new WebPage();
                return new Step<IWebPage>(wp);
            };
        }

        internal static Func<Step<IWebPage>, Step<IWebPage>> Clicks(string buttonName)
        {
            return previousStep =>
            {
                IWebPage page = new WebPage();
                var step = previousStep.GetNextStep(page);
                step.AppendTitle("user clicks the '" + buttonName + "' button");
                step.Action = () =>
                {
                    page = previousStep.State.Click(buttonName);
                };
                return step;
            };
        }

        internal static Func<Step<IWebPage>, Step<IWebPage>> ShouldSeeATitleOf(string expectedTitle)
        {
            return previousStep =>
            {
                var step = previousStep.GetNextStep(previousStep.State);
                step.AppendTitle("user should see a title of '" + expectedTitle + "'");
                step.Action = () =>
                {
                    if (previousStep.State.Title != expectedTitle)
                        throw new Exception("Wrong title.  Expected: '" + expectedTitle + "' but got '" + previousStep.State.Title + "'");
                };
                return step;
            };
        }

        internal static Func<Step<IWebPage>, Step<IWebPage>> ShouldSeeMessageOf(string expectedMessage)
        {
            return previousStep =>
            {
                var step = previousStep.GetNextStep(previousStep.State);
                step.AppendTitle("user should see a message of '" + expectedMessage + "'");
                step.Action = () =>
                {
                    var message = previousStep.State.GetFieldText("message");
                    if (message != expectedMessage)
                        throw new Exception("Wrong message.  Expected: '" + expectedMessage + "' but got '" + message + "'");
                };
                return step;
            };
        }

        internal static Func<Step<IWebPage>, Step<IWebPage>> UpdatesField(string fieldName, string fieldValue)
        {
            return (previousStep) =>
            {
                var step = previousStep.GetNextStep(previousStep.State);
                step.AppendTitle("user updates the field '" + fieldName + "' with a value of '" + fieldValue + "'");
                step.Action = () =>
                {
                    previousStep.State.UpdateField(fieldName, fieldValue);
                };
                return step;
            };
        }

        internal static Func<Step, Step<IWebPage>> NavigatesTo(string pageName)
        {
            return (previousStep) =>
            {
                IWebPage target = new WebPage();
                var step = previousStep.GetNextStep(target);
                step.AppendTitle("user navigates to '" + pageName + "'");
                step.Action = () =>
                {
                    target = LogInPage.NavigateTo();
                };
                return step;
            };
        }

        internal static Func<Step<IWebPage>> FirstNavigatesTo(string pageName)
        {
            return () =>
            {
                IWebPage target = new WebPage();
                var step = new Step<IWebPage>(target);
                step.AppendTitle("user navigates to '" + pageName + "'");
                step.Action = () =>
                {
                    target = LogInPage.NavigateTo();
                };
                return step;
            };
        }

        internal static Func<Step> Exists(string userName, string password)
        {
            return () =>
            {
                var step = new Step();
                step.AppendTitle("user '" + userName + "' with passord '" + password + "' exists");
                step.Action = () =>
                {
                    //Add user if missing.
                };
                return step;
            };
        }
    }
}
