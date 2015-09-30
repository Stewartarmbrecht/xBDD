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
    }
}