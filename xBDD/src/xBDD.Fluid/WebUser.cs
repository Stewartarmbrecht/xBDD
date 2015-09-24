using System;

namespace xBDD.Fluid
{
    internal class WebUser
    {
        internal static Step Exists(string v1, string v2)
        {
            var step = new Step();
            step.AppendTitle("a user exists with username '" + v1 + "' and password '" + v2 + "'");
            step.Action = () => { };
            return step;
        }

        internal static Step NavigatesTo(IWebPage currentPage)
        {
            return new Step("the user navigates to the '" + currentPage.Name + "' page", () =>
            {
               currentPage = currentPage.NavigateTo();
            });
        }

        internal static Step UpdatesField(string fieldName, string fieldValue, IWebPage currentPage)
        {
            return new Step("the user updates the field '" + fieldName + "' to have a value of '" + fieldValue + "'", () => 
            {
                currentPage.UpdateField(fieldName, fieldValue);
            });
        }

        internal static Step Clicks(string v, IWebPage currentPage)
        {
            throw new NotImplementedException();
        }

        internal static Step ShouldSeeATitleOf(string v, IWebPage currentPage)
        {
            throw new NotImplementedException();
        }

        internal static Step ShouldSeeMessageOf(string v, IWebPage currentPage)
        {
            throw new NotImplementedException();
        }
    }
}