using Microsoft.Dnx.Runtime;
using Microsoft.Dnx.Runtime.Infrastructure;
using Microsoft.Framework.DependencyInjection;
using OpenQA.Selenium;
using xBDD.Browser;
namespace xBDD.Reporting.Test.Pages
{
    public class HtmlReportPage
    {
        IWebDriver driver;
        public HtmlReportPage(IWebDriver driver)
        {
            this.driver = driver; 
        }
        static PageLocation pageLocation;
        public static PageLocation PageLocation 
        {
            get
            {
                if(pageLocation == null)
                {
                    var provider = CallContextServiceLocator.Locator.ServiceProvider;
                    var appEnv = provider.GetRequiredService<IApplicationEnvironment>();
                    var path = "file:///" + appEnv.ApplicationBasePath + "\\TestHtmlReport.html";
                    pageLocation = new PageLocation("Test Html Report", path);
                }
                return pageLocation;
            }
            
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

        public static PageElement TestRunName = new PageElement("test run name",".testrun-name");
    }
}