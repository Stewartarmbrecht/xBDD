using System;
using xBDD.Browser;

namespace xBDD.Reporting.Test.Pages.HtmlReportPage
{
    public class Feature
    {
        public static PageElement Name(int featureNumber)
        {
            return new PageElement("feature name","#feature-" + featureNumber + " h3 span.name");
        }
        public static PageElement NameGreen(int featureNumber)
        {
            return new PageElement("feature " + featureNumber + " with green name", "#feature-" + featureNumber + " h3.text-success");   
        }
        public static PageElement NameYellow(int featureNumber)
        {
            return new PageElement("feature " + featureNumber + " with yellow name", "#feature-" + featureNumber + " h3.text-warning");   
        }
        public static PageElement NameRed(int featureNumber)
        {
            return new PageElement("feature " + featureNumber + " with red name", "#feature-" + featureNumber + " h3.text-danger");   
        }
        public static PageElement NameGrey(int featureNumber)
        {
            return new PageElement("feature " + featureNumber + " with grey name", "#feature-" + featureNumber + " h3.text-muted");   
        }
        public static PageElement Scenarios(int featureNumber)
        {
            return new PageElement("feature " + featureNumber + " scenarios", "#feature-" + featureNumber + "-scenarios");   
        }
        internal static PageElement Statement(int featureNumber)
        {
            return new PageElement("feature " + featureNumber + " scenarios", "#feature-" + featureNumber + "-statement");   
        }
    }
}