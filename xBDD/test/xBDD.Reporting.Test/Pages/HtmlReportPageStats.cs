using Microsoft.Dnx.Runtime;
using Microsoft.Dnx.Runtime.Infrastructure;
using Microsoft.Framework.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace xBDD.Reporting.Test.Pages
{
    public partial class HtmlReportPageStats : HtmlReportPage
    {
        IWebDriver driver;
        public HtmlReportPageStats(IWebDriver driver)
            : base(driver)
        {
            this.driver = driver; 
            PageFactory.InitElements(Browser.Current, this);
        }

        [FindsBy(How = How.Id, Using = "testrun-area-stats")]
        public IWebElement TestRunAreaOutcomeBar { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-area-stats td.passed-bar")]
        public IWebElement TestRunAreaOutcomeSuccessBar { get; internal set; }

        [FindsBy(How = How.CssSelector, Using = "#testrun-area-stats td.skipped-bar")]
        public IWebElement TestRunAreaOutcomeSkippedBar { get; internal set; }

        [FindsBy(How = How.CssSelector, Using = "#testrun-area-stats td.failed-bar")]
        public IWebElement TestRunAreaOutcomeFailedBar { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-area-stats td.total")]
        public IWebElement TestRunAreaOutcomeTotal { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-area-stats td.passed")]
        public IWebElement TestRunAreaOutcomePassed { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-area-stats td.skipped")]
        public IWebElement TestRunAreaOutcomeSkipped { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-area-stats td.failed")]
        public IWebElement TestRunAreaOutcomeFailed { get; internal set; }

        
        [FindsBy(How = How.Id, Using = "testrun-feature-stats")]
        public IWebElement TestRunFeatureOutcomeBar { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-feature-stats td.passed-bar")]
        public IWebElement TestRunFeatureOutcomeSuccessBar { get; internal set; }

        [FindsBy(How = How.CssSelector, Using = "#testrun-feature-stats td.skipped-bar")]
        public IWebElement TestRunFeatureOutcomeSkippedBar { get; internal set; }

        [FindsBy(How = How.CssSelector, Using = "#testrun-feature-stats td.failed-bar")]
        public IWebElement TestRunFeatureOutcomeFailedBar { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-feature-stats td.total")]
        public IWebElement TestRunFeatureOutcomeTotal { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-feature-stats td.passed")]
        public IWebElement TestRunFeatureOutcomePassed { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-feature-stats td.skipped")]
        public IWebElement TestRunFeatureOutcomeSkipped { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-feature-stats td.failed")]
        public IWebElement TestRunFeatureOutcomeFailed { get; internal set; }


        [FindsBy(How = How.Id, Using = "testrun-scenario-stats")]
        public IWebElement TestRunScenarioOutcomeBar { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-scenario-stats td.passed-bar")]
        public IWebElement TestRunScenarioOutcomeSuccessBar { get; internal set; }

        [FindsBy(How = How.CssSelector, Using = "#testrun-scenario-stats td.skipped-bar")]
        public IWebElement TestRunScenarioOutcomeSkippedBar { get; internal set; }

        [FindsBy(How = How.CssSelector, Using = "#testrun-scenario-stats td.failed-bar")]
        public IWebElement TestRunScenarioOutcomeFailedBar { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-scenario-stats td.total")]
        public IWebElement TestRunScenarioOutcomeTotal { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-scenario-stats td.passed")]
        public IWebElement TestRunScenarioOutcomePassed { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-scenario-stats td.skipped")]
        public IWebElement TestRunScenarioOutcomeSkipped { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-scenario-stats td.failed")]
        public IWebElement TestRunScenarioOutcomeFailed { get; internal set; }


        [FindsBy(How = How.Id, Using = "testrun-step-stats")]
        public IWebElement TestRunStepOutcomeBar { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-step-stats td.passed-bar")]
        public IWebElement TestRunStepOutcomeSuccessBar { get; internal set; }

        [FindsBy(How = How.CssSelector, Using = "#testrun-step-stats td.skipped-bar")]
        public IWebElement TestRunStepOutcomeSkippedBar { get; internal set; }

        [FindsBy(How = How.CssSelector, Using = "#testrun-step-stats td.failed-bar")]
        public IWebElement TestRunStepOutcomeFailedBar { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-step-stats td.total")]
        public IWebElement TestRunStepOutcomeTotal { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-step-stats td.passed")]
        public IWebElement TestRunStepOutcomePassed { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-step-stats td.skipped")]
        public IWebElement TestRunStepOutcomeSkipped { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-step-stats td.failed")]
        public IWebElement TestRunStepOutcomeFailed { get; internal set; }


        public IWebElement AreaFeatureOutcomeBar(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-feature-stats"));
        }
        public IWebElement AreaFeatureOutcomeSuccessBar(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-feature-stats td.passed-bar"));
        }
        public IWebElement AreaFeatureOutcomeSkippedBar(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-feature-stats td.skipped-bar"));
        }
        public IWebElement AreaFeatureOutcomeFailedBar(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-feature-stats td.failed-bar"));
        }
        public IWebElement AreaFeatureOutcomeTotal(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-feature-stats td.total"));
        }
        public IWebElement AreaFeatureOutcomePassed(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-feature-stats td.passed"));
        }
        public IWebElement AreaFeatureOutcomeSkipped(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-feature-stats td.skipped"));
        }
        public IWebElement AreaFeatureOutcomeFailed(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-feature-stats td.failed"));
        }


        public IWebElement AreaScenarioOutcomeBar(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-scenario-stats"));
        }
        public IWebElement AreaScenarioOutcomeSuccessBar(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-scenario-stats td.passed-bar"));
        }
        public IWebElement AreaScenarioOutcomeSkippedBar(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-scenario-stats td.skipped-bar"));
        }
        public IWebElement AreaScenarioOutcomeFailedBar(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-scenario-stats td.failed-bar"));
        }
        public IWebElement AreaScenarioOutcomeTotal(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-scenario-stats td.total"));
        }
        public IWebElement AreaScenarioOutcomePassed(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-scenario-stats td.passed"));
        }
        public IWebElement AreaScenarioOutcomeSkipped(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-scenario-stats td.skipped"));
        }
        public IWebElement AreaScenarioOutcomeFailed(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-scenario-stats td.failed"));
        }


        public IWebElement AreaStepOutcomeBar(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-step-stats"));
        }
        public IWebElement AreaStepOutcomeSuccessBar(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-step-stats td.passed-bar"));
        }
        public IWebElement AreaStepOutcomeSkippedBar(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-step-stats td.skipped-bar"));
        }
        public IWebElement AreaStepOutcomeFailedBar(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-step-stats td.failed-bar"));
        }
        public IWebElement AreaStepOutcomeTotal(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-step-stats td.total"));
        }
        public IWebElement AreaStepOutcomePassed(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-step-stats td.passed"));
        }
        public IWebElement AreaStepOutcomeSkipped(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-step-stats td.skipped"));
        }
        public IWebElement AreaStepOutcomeFailed(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-step-stats td.failed"));
        }

        public static HtmlReportPageStats Load()
        {
            var provider = CallContextServiceLocator.Locator.ServiceProvider;
            var appEnv = provider.GetRequiredService<IApplicationEnvironment>();
            var path = "file:///" + appEnv.ApplicationBasePath + "\\TestHtmlReport.html";
            Browser.Current.Navigate().GoToUrl(path);
            HtmlReportPageStats report = new HtmlReportPageStats(Browser.Current);
            return report;
        }
    }
}