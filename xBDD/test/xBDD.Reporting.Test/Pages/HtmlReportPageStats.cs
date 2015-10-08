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
        [FindsBy(How = How.CssSelector, Using = "#testrun-area-stats td.total")]
        public IWebElement TestRunAreaOutcomeTotal { get; internal set; }
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
        [FindsBy(How = How.CssSelector, Using = "#testrun-feature-stats td.total")]
        public IWebElement TestRunFeatureOutcomeTotal { get; internal set; }
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
        [FindsBy(How = How.CssSelector, Using = "#testrun-scenario-stats td.total")]
        public IWebElement TestRunScenarioOutcomeTotal { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-scenario-stats td.passed")]
        public IWebElement TestRunScenarioOutcomePassed { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-scenario-stats td.skipped")]
        public IWebElement TestRunScenarioOutcomeSkipped { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-scenario-stats td.failed")]
        public IWebElement TestRunScenarioOutcomeFailed { get; internal set; }


        [FindsBy(How = How.Id, Using = "testrun-step-stats")]
        public IWebElement TestRunStepOutcomeStats { get; internal set; }
        [FindsBy(How = How.CssSelector, Using = "#testrun-step-stats td.outcome-bar-chart")]
        public IWebElement TestRunStepOutcomeBarChart { get; internal set; }
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


        public IWebElement AreaStepOutcomeStats(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-step-stats"));
        }
        public IWebElement AreaStepOutcomeBarChart(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-step-stats td.outcome-bar-chart"));
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
            return driver.FindElement(By.CssSelector("#feature-"+featureNumber+"-scenario-stats td.total"));
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
        public IWebElement AreaStepTotalPercentageBarChart(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-step-stats td.total-percentage-bar-chart"));
        }
        public IWebElement AreaStepTotalPercentageTestRunBar(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-step-stats td.testrun-percent-bar"));
        }
        public IWebElement AreaScenarioTotalPercentageBarChart(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-scenario-stats td.total-percentage-bar-chart"));
        }
        public IWebElement AreaScenarioTotalPercentageTestRunBar(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-scenario-stats td.testrun-percent-bar"));
        }
        public IWebElement AreaFeatureTotalPercentageBarChart(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-feature-stats td.total-percentage-bar-chart"));
        }
        public IWebElement AreaFeatureTotalPercentageTestRunBar(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-"+areaNumber+"-feature-stats td.testrun-percent-bar"));
        }


        public IWebElement FeatureStepOutcomeStats(int featureNumber)
        {
            return driver.FindElement(By.CssSelector("#feature-"+featureNumber+"-step-stats"));
        }
        public IWebElement FeatureStepOutcomeBarChart(int featureNumber)
        {
            return driver.FindElement(By.CssSelector("#feature-"+featureNumber+"-step-stats td.outcome-bar-chart"));
        }
        public IWebElement FeatureStepOutcomeSuccessBar(int featureNumber)
        {
            return driver.FindElement(By.CssSelector("#feature-"+featureNumber+"-step-stats td.passed-bar"));
        }
        public IWebElement FeatureStepOutcomeSkippedBar(int featureNumber)
        {
            return driver.FindElement(By.CssSelector("#feature-"+featureNumber+"-step-stats td.skipped-bar"));
        }
        public IWebElement FeatureStepOutcomeFailedBar(int featureNumber)
        {
            return driver.FindElement(By.CssSelector("#feature-"+featureNumber+"-step-stats td.failed-bar"));
        }
        public IWebElement FeatureStepOutcomeTotal(int featureNumber)
        {
            return driver.FindElement(By.CssSelector("#feature-"+featureNumber+"-step-stats td.total"));
        }
        public IWebElement FeatureStepOutcomePassed(int featureNumber)
        {
            return driver.FindElement(By.CssSelector("#feature-"+featureNumber+"-step-stats td.passed"));
        }
        public IWebElement FeatureStepOutcomeSkipped(int featureNumber)
        {
            return driver.FindElement(By.CssSelector("#feature-"+featureNumber+"-step-stats td.skipped"));
        }
        public IWebElement FeatureStepOutcomeFailed(int featureNumber)
        {
            return driver.FindElement(By.CssSelector("#feature-"+featureNumber+"-step-stats td.failed"));
        }
        public IWebElement FeatureStepTotalPercentageBarChart(int featureNumber)
        {
            return driver.FindElement(By.CssSelector("#feature-"+featureNumber+"-step-stats td.total-percentage-bar-chart"));
        }
        public IWebElement FeatureStepTotalPercentageTestRunBar(int featureNumber)
        {
            return driver.FindElement(By.CssSelector("#feature-"+featureNumber+"-step-stats td.testrun-percent-bar"));
        }
        public IWebElement FeatureStepTotalPercentageAreaBar(int featureNumber)
        {
            return driver.FindElement(By.CssSelector("#feature-"+featureNumber+"-step-stats td.area-percent-bar"));
        }
        public IWebElement FeatureScenarioTotalPercentageBarChart(int featureNumber)
        {
            return driver.FindElement(By.CssSelector("#feature-"+featureNumber+"-scenario-stats td.total-percentage-bar-chart"));
        }
        public IWebElement FeatureScenarioTotalPercentageTestRunBar(int featureNumber)
        {
            return driver.FindElement(By.CssSelector("#feature-"+featureNumber+"-scenario-stats td.testrun-percent-bar"));
        }
        public IWebElement FeatureScenarioTotalPercentageAreaBar(int featureNumber)
        {
            return driver.FindElement(By.CssSelector("#feature-"+featureNumber+"-scenario-stats td.feature-percent-bar"));
        }


        public IWebElement ScenarioStepOutcomeStats(int scenarioNumber)
        {
            return driver.FindElement(By.CssSelector("#scenario-"+scenarioNumber+"-step-stats"));
        }
        public IWebElement ScenarioStepOutcomeBarChart(int scenarioNumber)
        {
            return driver.FindElement(By.CssSelector("#scenario-"+scenarioNumber+"-step-stats td.outcome-bar-chart"));
        }
        public IWebElement ScenarioStepTotalPercentageBarChart(int scenarioNumber)
        {
            return driver.FindElement(By.CssSelector("#scenario-"+scenarioNumber+"-step-stats td.total-percentage-bar-chart"));
        }
        public IWebElement ScenarioStepOutcomeSuccessBar(int scenarioNumber)
        {
            return driver.FindElement(By.CssSelector("#scenario-"+scenarioNumber+"-step-stats td.passed-bar"));
        }
        public IWebElement ScenarioStepOutcomeSkippedBar(int scenarioNumber)
        {
            return driver.FindElement(By.CssSelector("#scenario-"+scenarioNumber+"-step-stats td.skipped-bar"));
        }
        public IWebElement ScenarioStepOutcomeFailedBar(int scenarioNumber)
        {
            return driver.FindElement(By.CssSelector("#scenario-"+scenarioNumber+"-step-stats td.failed-bar"));
        }
        public IWebElement ScenarioStepOutcomeTotal(int scenarioNumber)
        {
            return driver.FindElement(By.CssSelector("#scenario-"+scenarioNumber+"-step-stats td.total"));
        }
        public IWebElement ScenarioStepOutcomePassed(int scenarioNumber)
        {
            return driver.FindElement(By.CssSelector("#scenario-"+scenarioNumber+"-step-stats td.passed"));
        }
        public IWebElement ScenarioStepOutcomeSkipped(int scenarioNumber)
        {
            return driver.FindElement(By.CssSelector("#scenario-"+scenarioNumber+"-step-stats td.skipped"));
        }
        public IWebElement ScenarioStepOutcomeFailed(int scenarioNumber)
        {
            return driver.FindElement(By.CssSelector("#scenario-"+scenarioNumber+"-step-stats td.failed"));
        }
        public IWebElement ScenarioStepTotalPercentageTestRunBar(int scenarioNumber)
        {
            return driver.FindElement(By.CssSelector("#scenario-"+scenarioNumber+"-step-stats td.testrun-percent-bar"));
        }
        public IWebElement ScenarioStepTotalPercentageAreaBar(int scenarioNumber)
        {
            return driver.FindElement(By.CssSelector("#scenario-"+scenarioNumber+"-step-stats td.area-percent-bar"));
        }
        public IWebElement ScenarioStepTotalPercentageScenarioBar(int scenarioNumber)
        {
            return driver.FindElement(By.CssSelector("#scenario-"+scenarioNumber+"-step-stats td.feature-percent-bar"));
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