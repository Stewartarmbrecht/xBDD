namespace xBDD.Reporting.Features
{
    using xBDD.Model;
    using xBDD.Browser;

    public class Pages
    {

        public PageLocation TestResults;
        public Pages()
        {
            var location = System.Reflection.Assembly.GetEntryAssembly().Location;
            var directory = System.IO.Path.GetDirectoryName(location);
            var path = "file:///" + directory + $"{System.IO.Path.DirectorySeparatorChar}TestHtmlReport.html";
            this.TestResults = new PageLocation("the Test Html Report", path);
        }
        public readonly PageElement FirstAreaName = new PageElement("the first area name", "#area-1-name");
        public readonly PageElement FirstAreasFeatureList = new PageElement("the first area's feature list", "#area-1-features");
        public readonly PageElement FirstAreasFeatureListNotExpandingOrCollapsing = new PageElement("the first area's feature list that is not expanding or collapsing", "#area-1-features:not(.collapsing)");
        public readonly PageElement ExpandAllAreasLink = new PageElement("the expand all areas link", "#expand-all-areas-button");
        public readonly PageElement MenuButton = new PageElement("the menu button", "#menu-button");
        public readonly PageElement CollapseAllAreasLink = new PageElement("the collapse all areas link", "#collapse-all-areas-button");
        public readonly PageElement SecondAreasFeatureList = new PageElement("the second area's feature list", "#area-2-features");
        public readonly PageElement SecondAreasFeatureListNotExpandingOrCollapsing = new PageElement("the second area's feature list that is not expanding or collapsing", "#area-2-features:not(.collapsing)");
    }
}