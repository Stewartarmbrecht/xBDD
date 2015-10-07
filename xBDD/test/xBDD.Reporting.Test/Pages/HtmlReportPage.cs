using OpenQA.Selenium;

namespace xBDD.Reporting.Test.Pages
{
    public class HtmlReportPage
    {
        IWebDriver driver;
        public HtmlReportPage(IWebDriver driver)
        {
            this.driver = driver; 
        }
        internal IWebElement Area(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-" + areaNumber + " h2"));
        }

        internal IWebElement Feature(int featureNumber)
        {
            return driver.FindElement(By.CssSelector("#feature-" + featureNumber + " h3"));
        }

        internal IWebElement Scenario(int scenarioNumber)
        {
            return driver.FindElement(By.CssSelector("#scenario-" + scenarioNumber + " div.panel"));
        }

        internal IWebElement ScenarioTitleLine(int scenarioNumber)
        {
            return driver.FindElement(By.CssSelector("#scenario-" + scenarioNumber + " div.panel-heading"));
        }

        public string Html { get { return driver.PageSource; } }

    }
}