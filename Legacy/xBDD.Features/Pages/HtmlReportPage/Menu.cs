using xBDD.Browser;

namespace xBDD.Features.Pages.HtmlReportPage
{
    public class Menu
    {
        public PageElement Section = new PageElement("the menu","#menu");
        public PageElement MenuButton = new PageElement("the menu button","#menu-button");
        public PageElement ExpandAllAreasLink = new PageElement("the expand all areas link","#expand-all-areas-button");
        public PageElement CollapseAllAreasLink = new PageElement("the collapse all areas link", "#collapse-all-areas-button");
    }
}