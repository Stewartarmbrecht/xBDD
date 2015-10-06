using Microsoft.Dnx.Runtime;
using Microsoft.Dnx.Runtime.Infrastructure;
using Microsoft.Framework.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace xBDD.Reporting.Test.Pages
{
    public class HtmlReportPage
    {
        IWebDriver driver;
        public HtmlReportPage(IWebDriver driver)
        {
            this.driver = driver; 
            PageFactory.InitElements(Browser.Current, this);
        }
        public static HtmlReportPage Load()
        {
            var provider = CallContextServiceLocator.Locator.ServiceProvider;
            var appEnv = provider.GetRequiredService<IApplicationEnvironment>();
            var path = "file:///" + appEnv.ApplicationBasePath + "\\TestHtmlReport.html";
            Browser.Current.Navigate().GoToUrl(path);
            HtmlReportPage report = new HtmlReportPage(Browser.Current);
            return report;
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

        internal IWebElement AreaFeatures(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-" + areaNumber + " ol.features"));
        }

        internal IWebElement FeatureScenarios(int featureNumber)
        {
            return driver.FindElement(By.CssSelector("#feature-" + featureNumber + " ol.scenarios"));
        }

        internal IWebElement ScenarioSteps(int scenarioNumber)
        {
            return driver.FindElement(By.CssSelector("#scenario-" + scenarioNumber + " div.panel-body"));
        }

        [FindsBy(How = How.ClassName, Using = "testrun-name")]
        public IWebElement TestRunName { get; set; }
        [FindsBy(How = How.Id, Using = "menu")]
        public IWebElement Menu { get; internal set; }
        [FindsBy(How = How.Id, Using = "menu-button")]
        public IWebElement MenuButton { get; internal set; }

        [FindsBy(How = How.Id, Using = "expand-all-areas-button")]
        public IWebElement ExpandAllAreasButton { get; internal set; }

        internal IWebElement Exception(int stepNumber)
        {
            return  driver.FindElement(By.CssSelector("#step-" + stepNumber + " dl.exception"));
        }

        internal IWebElement ExceptionType(int stepNumber)
        {
            return  driver.FindElement(By.CssSelector("#step-" + stepNumber + " dl.exception dd.error-type"));
        }

        internal IWebElement ExceptionMessage(int stepNumber)
        {
            return  driver.FindElement(By.CssSelector("#step-" + stepNumber + " dl.exception dd.error-message"));
        }

        internal IWebElement ExceptionStackTrace(int stepNumber)
        {
            return  driver.FindElement(By.CssSelector("#step-" + stepNumber + " dl.exception dd.error-stack"));
        }

        internal IWebElement InnerException(int stepNumber)
        {
            var selector = "#step-" + stepNumber + " dl.exception>dd.inner-exception>dl.exception";
            return  driver.FindElement(By.CssSelector(selector));
        }

        internal IWebElement InnerExceptionType(int stepNumber)
        {
            var selector = "#step-" + stepNumber + " dl.exception>dd.inner-exception>dl.exception>dd.error-type";
            return  driver.FindElement(By.CssSelector(selector));
        }

        internal IWebElement InnerExceptionMessage(int stepNumber)
        {
            var selector = "#step-" + stepNumber + " dl.exception>dd.inner-exception>dl.exception>dd.error-message";
            return  driver.FindElement(By.CssSelector(selector));
        }

        internal IWebElement InnerExceptionStackTrace(int stepNumber)
        {
            var selector = "#step-" + stepNumber + " dl.exception>dd.inner-exception>dl.exception>dd.error-stack";
            return  driver.FindElement(By.CssSelector(selector));
        }

        public string Title { get { return driver.Title; } }

        public string Html { get { return driver.PageSource; } }

        public string GetStepOutputText(int stepNumber)
        {
            string text = null;
            var outputPre = driver.FindElement(By.Id("output-" + stepNumber));
            if(outputPre != null)
                text = outputPre.Text;
            return text;
        }

        public IWebElement StepOutputLink(int stepNumber)
        {
            return driver.FindElement(By.CssSelector("#step-" + stepNumber + " a.step-output-link"));
        }
        public IWebElement StepOutput(int stepNumber)
        {
            return driver.FindElement(By.CssSelector("#step-" + stepNumber + " div.output"));
        }
        public TextFormat? GetStepOutputFormat(int stepNumber)
        {
            TextFormat? format = null;
            string className = null;
            var outputPre = driver.FindElement(By.Id("output-" + stepNumber));
            if(outputPre != null)
            {
                className = outputPre.GetAttribute("class");
            }
            
            if(className == "text")
                format = TextFormat.text;
            else if(className == "code prettify")
                format = TextFormat.code;
            else if(className == "code prettify lang-html")
            {
                format = TextFormat.code;
                var outputFrame = driver.FindElement(By.Id("output-preview-" + stepNumber));
                if(outputFrame != null)
                    format = TextFormat.htmlpreview;
            }
            return format;
        }

        internal Color GetTestRunNameColor()
        {
            Color result = Color.Unknown;
            if(TestRunName != null)
            {
                var classAttr = TestRunName.GetAttribute("class");
                if(classAttr != null)
                {
                    if(classAttr.Contains("text-muted"))
                        result = Color.Gray;
                    else if(classAttr.Contains("text-success"))
                        result = Color.Green;
                    else if(classAttr.Contains("text-warning"))
                        result = Color.Yellow;
                    else if(classAttr.Contains("text-danger"))
                        result = Color.Red;
                }
            }
            return result;
        }
        internal Color GetAreaNameColor(int areaNumber)
        {
            var area = Area(areaNumber);
            Color result = Color.Unknown;
            if(area != null)
            {
                var classAttr = area.GetAttribute("class");
                if(classAttr != null)
                {
                    if(classAttr.Contains("text-muted"))
                        result = Color.Gray;
                    else if(classAttr.Contains("text-success"))
                        result = Color.Green;
                    else if(classAttr.Contains("text-warning"))
                        result = Color.Yellow;
                    else if(classAttr.Contains("text-danger"))
                        result = Color.Red;
                }
            }
            return result;
        }
        internal Color GetFeatureNameColor(int featureNumber)
        {
            var feature = Feature(featureNumber);
            Color result = Color.Unknown;
            if(feature != null)
            {
                var classAttr = feature.GetAttribute("class");
                if(classAttr != null)
                {
                    if(classAttr.Contains("text-muted"))
                        result = Color.Gray;
                    else if(classAttr.Contains("text-success"))
                        result = Color.Green;
                    else if(classAttr.Contains("text-warning"))
                        result = Color.Yellow;
                    else if(classAttr.Contains("text-danger"))
                        result = Color.Red;
                }
            }
            return result;
        }
        internal Color GetScenarioNameColor(int scenarioNumber)
        {
            var scenario = Scenario(scenarioNumber);
            Color result = Color.Unknown;
            if(scenario != null)
            {
                var classAttr = scenario.GetAttribute("class");
                if(classAttr != null)
                {
                    if(classAttr.Contains("panel-default"))
                        result = Color.Gray;
                    else if(classAttr.Contains("panel-success"))
                        result = Color.Green;
                    else if(classAttr.Contains("panel-warning"))
                        result = Color.Yellow;
                    else if(classAttr.Contains("panel-danger"))
                        result = Color.Red;
                }
            }
            return result;
        }
    }
    
    public enum Color 
    {
        Gray,
        Green,
        Yellow,
        Red,
        Unknown
    }
}