using OpenQA.Selenium;
using Xunit;
using xBDD.Model;
using xBDD.Reporting.Test.Pages;

namespace xBDD.Reporting.Test.Steps
{
    public static class WebUser
    {
        internal static Step ViewsReportGeneral(Wrapper<HtmlReportPageGeneral> report)
        {
            var step = xBDD.CreateStep(
                "the user views the html report",
                (s) => {
                    report.Object = HtmlReportPageGeneral.Load();
                    s.Output = report.Object.Html;
                    s.OutputFormat = TextFormat.htmlpreview;
                });
            return step;
        }
        internal static Step ViewsReportStats(Wrapper<HtmlReportPageStats> report)
        {
            var step = xBDD.CreateStep(
                "the user views the html report",
                (s) => {
                    report.Object = HtmlReportPageStats.Load();
                    s.Output = report.Object.Html;
                    s.OutputFormat = TextFormat.htmlpreview;
                });
            return step;
        }
        internal static Step ShouldSeeElementWithText(Wrapper<OpenQA.Selenium.IWebDriver> webDriver, string cssClass, string expectedText, string stepName = null)
        {
            if(stepName == null)
                stepName = "the user should see an element with a class of '" + cssClass + "' and a text value of '"+expectedText+"'";
                
            var step = xBDD.CreateStep(
                stepName,
                (s) => {
                    Assert.Equal(expectedText, webDriver.Object.FindElement(By.ClassName(cssClass)).Text);
                });
            return step;
        }

        internal static Step Clicks(string descriptionOfWhatIsClicked, string cssSelector, Wrapper<IWebDriver> webDriver)
        {
            if(descriptionOfWhatIsClicked == null)
                descriptionOfWhatIsClicked = "the user clicks an element that matches this css selector '" + cssSelector + "'";
            
            descriptionOfWhatIsClicked = "the user clicks " + descriptionOfWhatIsClicked;
                
            var step = xBDD.CreateStep(
                descriptionOfWhatIsClicked,
                (s) => {
                    webDriver.Object.FindElement(By.CssSelector(cssSelector)).Click();
                });
            return step;
        }

        internal static Step ShouldSeeATitleOf(Wrapper<OpenQA.Selenium.IWebDriver> webDriver, string title, string stepName)
        {
            if(stepName == null)
                stepName = "the user should see a title of '" + title + "'";
                
            var step = xBDD.CreateStep(
                stepName,
                (s) => {
                    Assert.Equal(title, webDriver.Object.Title);
                });
            return step;
        }
    }
}