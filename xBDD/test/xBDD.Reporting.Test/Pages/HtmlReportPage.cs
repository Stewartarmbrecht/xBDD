using System;
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

        [FindsBy(How = How.ClassName, Using = "testrun-name")]
        public IWebElement TestRunName { get; set; }
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

        internal bool TestRunNameIsGray()
        {
            bool result = false;
            if(TestRunName != null)
            {
                var classAttr = TestRunName.GetAttribute("class");
                if(classAttr != null)
                    result = classAttr.Contains("text-muted");
            }
            return result;
        }

        internal bool TestRunNameIsGreen()
        {
            bool result = false;
            if(TestRunName != null)
            {
                var classAttr = TestRunName.GetAttribute("class");
                if(classAttr != null)
                    result = classAttr.Contains("text-success");
            }
            return result;
        }

        internal bool TestRunNameIsYellow()
        {
            bool result = false;
            if(TestRunName != null)
            {
                var classAttr = TestRunName.GetAttribute("class");
                if(classAttr != null)
                    result = classAttr.Contains("text-warning");
            }
            return result;
        }

        internal bool TestRunNameIsRed()
        {
            bool result = false;
            if(TestRunName != null)
            {
                var classAttr = TestRunName.GetAttribute("class");
                if(classAttr != null)
                    result = classAttr.Contains("text-danger");
            }
            return result;
        }
    }
}