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
        public IWebElement TestRunAreaOutcomeStats { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-area-stats td.outcome-bar-chart")]
        public IWebElement TestRunAreaOutcomeBarChart { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-area-stats td.passed-bar")]
        public IWebElement TestRunAreaOutcomeSuccessBar { get; internal set; }

        [FindsBy(How = How.CssSelector, Using = "#testrun-area-stats td.skipped-bar")]
        public IWebElement TestRunAreaOutcomeSkippedBar { get; internal set; }

        [FindsBy(How = How.CssSelector, Using = "#testrun-area-stats td.failed-bar")]
        public IWebElement TestRunAreaOutcomeFailedBar { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-area-stats td.passed")]
        public IWebElement TestRunAreaOutcomePassed { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-area-stats td.skipped")]
        public IWebElement TestRunAreaOutcomeSkipped { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-area-stats td.failed")]
        public IWebElement TestRunAreaOutcomeFailed { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-area-stats td.empty-bar")]
        public IWebElement TestRunAreaOutcomeEmptyBar { get; internal set; }

        
        [FindsBy(How = How.Id, Using = "testrun-feature-stats")]
        public IWebElement TestRunFeatureOutcomeStats { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-feature-stats td.outcome-bar-chart")]
        public IWebElement TestRunFeatureOutcomeBarChart { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-feature-stats td.passed-bar")]
        public IWebElement TestRunFeatureOutcomeSuccessBar { get; internal set; }

        [FindsBy(How = How.CssSelector, Using = "#testrun-feature-stats td.skipped-bar")]
        public IWebElement TestRunFeatureOutcomeSkippedBar { get; internal set; }

        [FindsBy(How = How.CssSelector, Using = "#testrun-feature-stats td.failed-bar")]
        public IWebElement TestRunFeatureOutcomeFailedBar { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-feature-stats td.passed")]
        public IWebElement TestRunFeatureOutcomePassed { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-feature-stats td.skipped")]
        public IWebElement TestRunFeatureOutcomeSkipped { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-feature-stats td.failed")]
        public IWebElement TestRunFeatureOutcomeFailed { get; internal set; }


        [FindsBy(How = How.Id, Using = "testrun-scenario-stats")]
        public IWebElement TestRunScenarioOutcomeStats { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-scenario-stats td.outcome-bar-chart")]
        public IWebElement TestRunScenarioOutcomeBarChart { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-scenario-stats td.passed-bar")]
        public IWebElement TestRunScenarioOutcomeSuccessBar { get; internal set; }

        [FindsBy(How = How.CssSelector, Using = "#testrun-scenario-stats td.skipped-bar")]
        public IWebElement TestRunScenarioOutcomeSkippedBar { get; internal set; }

        [FindsBy(How = How.CssSelector, Using = "#testrun-scenario-stats td.failed-bar")]
        public IWebElement TestRunScenarioOutcomeFailedBar { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-scenario-stats td.passed")]
        public IWebElement TestRunScenarioOutcomePassed { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-scenario-stats td.skipped")]
        public IWebElement TestRunScenarioOutcomeSkipped { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-scenario-stats td.failed")]
        public IWebElement TestRunScenarioOutcomeFailed { get; internal set; }




        public IWebElement AreaFeatureOutcomeStats(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-feature-stats"));
        }
        public IWebElement AreaFeatureOutcomeBarChart(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-feature-stats td.outcome-bar-chart"));
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
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+" span.badge.total"));
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


        public IWebElement AreaScenarioOutcomeStats(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-scenario-stats"));
        }
        public IWebElement AreaScenarioOutcomeBarChart(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-scenario-stats td.outcome-bar-chart"));
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



        public IWebElement FeatureScenarioOutcomeStats(int featureNumber)
        {
            return driver.FindElement(By.CssSelector("#feature-"+featureNumber+"-scenario-stats"));
        }
        public IWebElement FeatureScenarioOutcomeBarChart(int featureNumber)
        {
            return driver.FindElement(By.CssSelector("#feature-"+featureNumber+"-scenario-stats td.outcome-bar-chart"));
        }
        public IWebElement FeatureScenarioOutcomeSuccessBar(int featureNumber)
        {
            return driver.FindElement(By.CssSelector("#feature-"+featureNumber+"-scenario-stats td.passed-bar"));
        }
        public IWebElement FeatureScenarioOutcomeSkippedBar(int featureNumber)
        {
            return driver.FindElement(By.CssSelector("#feature-"+featureNumber+"-scenario-stats td.skipped-bar"));
        }
        public IWebElement FeatureScenarioOutcomeFailedBar(int featureNumber)
        {
            return driver.FindElement(By.CssSelector("#feature-"+featureNumber+"-scenario-stats td.failed-bar"));
        }
        public IWebElement FeatureScenarioOutcomeTotal(int featureNumber)
        {
            return driver.FindElement(By.CssSelector("#feature-"+featureNumber+" span.badge.total"));
        }
        public IWebElement FeatureScenarioOutcomePassed(int featureNumber)
        {
            return driver.FindElement(By.CssSelector("#feature-"+featureNumber+"-scenario-stats td.passed"));
        }
        public IWebElement FeatureScenarioOutcomeSkipped(int featureNumber)
        {
            return driver.FindElement(By.CssSelector("#feature-"+featureNumber+"-scenario-stats td.skipped"));
        }
        public IWebElement FeatureScenarioOutcomeFailed(int featureNumber)
        {
            return driver.FindElement(By.CssSelector("#feature-"+featureNumber+"-scenario-stats td.failed"));
        }



        public IWebElement ScenarioStepOutcomeTotal(int scenarioNumber)
        {
            return driver.FindElement(By.CssSelector("#scenario-"+scenarioNumber+" span.badge.total"));
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