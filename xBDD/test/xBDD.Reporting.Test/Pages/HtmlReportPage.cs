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

        internal IWebElement AreaFeatures(int areaNumber)
        {
            return driver.FindElement(By.CssSelector("#area-" + areaNumber + " ol.features"));
        }

        [FindsBy(How = How.ClassName, Using = "testrun-name")]
        public IWebElement TestRunName { get; set; }
        [FindsBy(How = How.Id, Using = "menu")]
        public IWebElement Menu { get; internal set; }
        [FindsBy(How = How.Id, Using = "menu-button")]
        public IWebElement MenuButton { get; internal set; }

        [FindsBy(How = How.Id, Using = "collapse-all-areas-button")]
        public IWebElement CollapseAllAreasButton { get; internal set; }

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