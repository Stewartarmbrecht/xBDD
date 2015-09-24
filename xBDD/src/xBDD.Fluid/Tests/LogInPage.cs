using System;

namespace xBDD.Fluid
{
    public class LogInPage : WebPage
    {
        public static LogInPage NavigateTo()
        {
            return new LogInPage();
        }
    }
}