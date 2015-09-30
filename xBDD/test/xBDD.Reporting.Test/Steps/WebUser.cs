using OpenQA.Selenium;
using Xunit;
using xBDD.Model;
using xBDD.Reporting.Test.Pages;

namespace xBDD.Reporting.Test.Steps
{
    public static class WebUser
    {
        internal static Step ViewsReport(Wrapper<HtmlReportPage> report)
        {
            var step = xBDD.CreateStep(
                "the user views the html report",
                () => {
                    report.Object = HtmlReportPage.Load();
                });
            return step;
        }
        internal static Step ShouldSeeElementWithText(Wrapper<OpenQA.Selenium.IWebDriver> webDriver, string cssClass, string expectedText, string stepName = null)
        {
            if(stepName == null)
                stepName = "the user should see an element with a class of '" + cssClass + "' and a text value of '"+expectedText+"'";
                
            var step = xBDD.CreateStep(
                stepName,
                () => {
                    Assert.Equal(expectedText, webDriver.Object.FindElement(By.ClassName(cssClass)).Text);
                });
            return step;
        }

        internal static Step ShouldSeeATitleOf(Wrapper<OpenQA.Selenium.IWebDriver> webDriver, string title, string stepName)
        {
            if(stepName == null)
                stepName = "the user should see a title of '" + title + "'";
                
            var step = xBDD.CreateStep(
                stepName,
                () => {
                    Assert.Equal(title, webDriver.Object.Title);
                });
            return step;
        }
    }
}