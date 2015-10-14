using Microsoft.Dnx.Runtime;
using Microsoft.Dnx.Runtime.Infrastructure;
using Microsoft.Framework.DependencyInjection;
using xBDD.Browser;

namespace xBDD.Reporting.Test.Pages.HtmlReportPage
{
    public class Location
    {
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
    }
}