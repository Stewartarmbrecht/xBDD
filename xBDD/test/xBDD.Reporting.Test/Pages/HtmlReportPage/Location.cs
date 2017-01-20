////using Microsoft.Dnx.Runtime;
////using Microsoft.Dnx.Runtime.Infrastructure;
////using Microsoft.Framework.DependencyInjection;
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
                    var location = System.Reflection.Assembly.GetEntryAssembly().Location;
                    var directory = System.IO.Path.GetDirectoryName(location);
                    var path = "file:///" + directory + "\\TestHtmlReport.html";
                    pageLocation = new PageLocation("Test Html Report", path);
                }
                return pageLocation;
            }
            
        }
    }
}