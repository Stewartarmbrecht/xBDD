using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xBDD.Model;
using xBDD.Utility;

namespace xBDD.Reporting.Html
{
    /// <summary>
    /// Writes the results of a test run to an HTML represenation.
    /// </summary>
    public class HtmlWriter
    {
        int areaCounter = 0;
        int featureCounter = 0;
        int scenarioCounter = 0;
        int stepCounter = 0;
        string areaNameSkip = "";
        bool failuresOnly = false;
        internal HtmlWriter(string areaNameSkip, bool failuresOnly)
        {
            this.areaNameSkip = areaNameSkip;
            this.failuresOnly = failuresOnly;
        }

        /// <summary>
        /// Writes the results of a test run to an HTML represenation.
        /// </summary>
        /// <param name="testRun">The test run to write to HTML.</param>
        /// <returns>The HTML string representation of the test run results.</returns>
        public string WriteToHtml(TestRun testRun)
        {
            testRun.CalculateStartAndEndTimes();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html>");
            WriteHtml(testRun, sb);
            return sb.ToString();
        }
        void WriteHtml(TestRun testRun, StringBuilder sb)
        {
            sb.AppendLine("<html>");
            WriteHeader(testRun, sb);
            WriteBody(testRun, sb);
            sb.Append("</html>");
        }
        void WriteHeader(TestRun testRun, StringBuilder sb)
        {
            sb.AppendLine("<head>");
            sb.AppendLine("    <meta charset=\"utf-8\" />");
            sb.AppendLine("    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\" />");
            WriteTag("title", sb, 1, null, testRun.Name.HtmlEncode(), true);
            sb.AppendLine("    <link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/open-iconic/1.1.1/font/css/open-iconic-bootstrap.min.css\" integrity=\"sha256-BJ/G+e+y7bQdrYkS2RBTyNfBHpA9IuGaPmf9htub5MQ=\" crossorigin=\"anonymous\" />");
            sb.AppendLine("    <link rel=\"stylesheet\" href=\"https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css\" integrity=\"sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO\" crossorigin=\"anonymous\">");
            WriteStyles(sb);
            sb.AppendLine("</head>");
        }

        private void WriteStyles(StringBuilder sb)
        {

            sb.Append("    <style>");
            sb.Append(" div#testrun-dates { margin: 0rem 0rem .5rem 5rem; }");
            sb.Append(" h1.testrun-name { margin: .5rem 0rem 0rem 0rem; }");
            sb.Append(" span.area.badge { width: 2.5rem; height: 1.5rem; position: absolute; border: 1px white solid; }");
            sb.Append(" span.badge-distro { width: 3.5rem; display: inline-block; height: 1.5rem; vertical-align: bottom; }");
            sb.Append(" span.area.stats { font-size: 75%; font-weight: 700; line-height: 1; text-align: center; white-space: nowrap; border-radius: .25rem; height: 1.5em; display: inline-block; width: 1.75rem; position: absolute; margin-left: 2rem; z-index: -1; vertical-align: middle; }");
            sb.Append(" span.feature.badge { width: 2.5rem; height: 1.5rem; position: absolute; border: 1px white solid; }");
            sb.Append(" span.scenario.badge { width: 2rem }");
            sb.Append(" span.duration { font-size: 1rem; color: gray; }");
            sb.Append(" span.reason { font-size: 1rem; color: gray; }");
            sb.Append(" span.status { font-size: 1rem; color: gray; }");
            sb.Append(" span.step.duration { font-size: .75rem; color: gray; }");
            sb.Append(" span.oi.oi-info { font-size: 80% }");
            sb.Append(" ol.areas { margin: .5rem 0rem; }");
            sb.Append(" ol.areas, ol.features, ol.scenarios, ol.steps { margin-left: 3rem; }");
            sb.Append(" span.badge { margin-left: .25rem; }");
            sb.Append(" span.distro { width: 1.5rem; height: 1.5rem; display: inline-block; margin-left: 2rem; border: 1px solid white; }");
            sb.Append(" span.name { margin-left: .75rem; }");
            sb.Append(" dl.exception { margin: 1rem 3rem; padding: 1rem; }");
            sb.Append(" dl.exception dt { margin-bottom: .25rem; }");
            sb.Append(" ol.features { margin-bottom: 2rem; }");
            sb.Append(" ol.scenarios { margin-bottom: 1.5rem; }");
            sb.Append(" ol.steps { margin-bottom: 1rem; }");
            sb.Append(" iframe { border: 1px solid gray; resize: both; overflow: auto; }");
            sb.Append(" h2, h3, h4, h5 { font-size: 1.25rem; margin: .5rem; font-weight: 400; }");
            sb.Append(" h5 { font-size: 1rem; margin: .25rem .75rem; }");
            sb.Append(" dl.error-type, dl.error-message, dl.error-stack { padding: .5rem; }");
            sb.Append(" dl.error-type pre, dl.error-message pre, dl.error-stack pre { padding: .5rem; }");
            sb.Append(" pre.feature-statement { margin: 0rem 0rem 1rem 3rem; padding: .5rem; }");
            sb.Append(" .table th, .table td { border-top: none !important; line-height: 1 !important; padding: 2px 10px !important; }");
            sb.Append(" td.graph td { padding: 0px !important; }");
            sb.Append(" .table { margin: 0px !important; }");
            sb.Append(" .table td.bar { padding: 0px !important; }");
            sb.Append(" .testrun-percent-bar { background-color: #56C1F7; }");
            sb.Append(" .area-percent-bar { background-color: #A4DEFB; }");
            sb.Append(" .pointer { cursor: pointer }");
            sb.Append(" pre { white-space: pre !important; }");
            sb.Append(" pre.mp { margin: 1rem auto; width: 95%; }");
            sb.Append(" pre.output { margin: 1rem auto; width: 95%; }");
            sb.Append(" .collapsing { -webkit-transition: none; transition: none; display: none; }");
            sb.Append(" pre.prettyprint {  background-color: #eee; }");
            sb.Append(" .linenums li { list-style-type: decimal !iinputortant;}");
            sb.AppendLine("</style>");  
        }

        void WriteBody(TestRun testRun, StringBuilder sb)
        {
            WriteTagOpen("body", sb, 0, "container-fluid", false);
            WriteNavBar(sb);
            WriteTestRun(testRun, sb);
            sb.AppendLine("    <script src=\"https://code.jquery.com/jquery-3.3.1.slim.min.js\" integrity=\"sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo\" crossorigin=\"anonymous\"></script>");
            sb.AppendLine("    <script src=\"https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js\" integrity=\"sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49\" crossorigin=\"anonymous\"></script>");
            sb.AppendLine("    <script src=\"https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js\" integrity=\"sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy\" crossorigin=\"anonymous\"></script>");
            sb.AppendLine("    <script src=\"https://cdn.rawgit.com/google/code-prettify/master/loader/run_prettify.js\"></script>");
            sb.AppendLine("    <script language=\"javascript\" type=\"text/javascript\">function resizeIframe(obj) { obj.style.height = obj.contentWindow.document.body.scrollHeight + 'px'; }</script>");
            WriteTagClose("body", sb, 0);
        }

        private void WriteNavBar(StringBuilder sb)
        {
            var failuresOnlyText = "";
            if(this.failuresOnly) {
                failuresOnlyText = " [Failures Only]";
            }
            var html = $@"
                    <nav class=""navbar navbar-expand-lg navbar-light bg-light"">
                        <a class=""navbar-brand"" href=""#"">xBDD Test Results{failuresOnlyText}</a>
                        <button id=""menu-button"" 
                            class=""navbar-toggler"" 
                            type=""button"" 
                            data-toggle=""collapse"" 
                            data-target=""#navbarNavAltMarkup"" 
                            aria-controls=""navbarNavAltMarkup"" 
                            aria-expanded=""false"" 
                            aria-label=""Toggle navigation"">
                            <span class=""navbar-toggler-icon""></span>
                        </button>
                        <div class=""collapse navbar-collapse"" id=""navbarNavAltMarkup"">
                            <div class=""navbar-nav"">
                            <a class=""nav-item nav-link active"" href=""javascript: $('ol.features').collapse('show');"" id=""expand-all-areas-button"">Expand All Areas <span class=""sr-only"">(current)</span></a>
                            </div>
                        </div>
                    </nav>".RemoveIndentation(4, true);

            sb.Append(html);
        }

        private void WriteTestRun(TestRun testRun, StringBuilder sb)
        {
            var scenarioCount = testRun.Areas.Count;
            var cssClass = "testrun-name";
            var badgeClass = "";
            if (scenarioCount == 0)
            {
                badgeClass = "badge-secondary";
            }
            else
            {
                switch (testRun.Outcome)
                {
                    case Outcome.Failed:
                        badgeClass = "badge-danger";
                        break;
                    case Outcome.NotRun:
                        badgeClass = "badge-info";
                        break;
                    case Outcome.Passed:
                        badgeClass = "badge-success";
                        break;
                    case Outcome.Skipped:
                        badgeClass = "badge-warning";
                        break;
                }
            }
            WriteTagOpen("div", sb, 1, "page-header", false, null, "margin-top: 0px !important;");
            WriteTagOpen("h1", sb, 2, cssClass, true);

            WriteTag("span", sb, 0, $"testrun badge pointer badge-pill total {badgeClass}", testRun.AreaStats.Total.ToString(), true, null, null, " title=\"Areas\"");
            WriteTag("span", sb, 0, "name", testRun.Name.HtmlEncode(), true);

            if(testRun.Reason != null) {
                WriteTag("span", sb, 0, "testrun reason", $" [{testRun.Reason.HtmlEncode()}]",true);
            }

            var duration = testRun.EndTime - testRun.StartTime;
            var formattedDuration = duration.TotalMilliseconds.ToString("N", System.Globalization.CultureInfo.InvariantCulture);
            formattedDuration = formattedDuration.Substring(0, formattedDuration.Length-3);
            WriteTag("span", sb, 0, "testrun duration", $" [{formattedDuration} ms]",true);

            WriteTagClose("h1", sb, 2);
            WriteTagClose("div", sb, 1);
            if(testRun.StartTime != DateTime.MinValue) {
                WriteTagOpen("div", sb, 1, null, false, "testrun-dates", "margin-top: 0px !important;");
                WriteTag("span", sb, 0, null, testRun.StartTime.ToString("yyyy-MM-dd hh:mm tt \"GMT\"zzz"), true, "testrun-start-date", null, " title=\"Start\"");
                WriteTagClose("div", sb, 1);
            }
            WriteStatsTableStart(sb, 1, null, false);
            WriteStats(sb, testRun.AreaStats, 1, "testrun-area-stats", "Areas");
            WriteStats(sb, testRun.FeatureStats, 1, "testrun-feature-stats", "Features");
            WriteStats(sb, testRun.ScenarioStats, 1, "testrun-scenario-stats", "Scenarios");
            WriteStatsTableClose(sb, 1);
            if (scenarioCount > 0)
            {
                WriteAreas(testRun, sb);
            }
        }

        private void WriteStatsTableClose(StringBuilder sb, int baseIndent)
        {
            WriteTagClose("table", sb, baseIndent);
        }

        private void WriteStatsTableStart(StringBuilder sb, int baseIndent, string id = null, Boolean collapsed = true)
        {
            var collapse = (collapsed ? "collapse":"");
            WriteTagOpen("table", sb, baseIndent, $"table table-condensed {collapse}", false, id, "width: 100%; empty-cells: show;");
        }

        private void WriteStats(StringBuilder sb, OutcomeStats stats, int baseIndent, string id, string label)
        {
            WriteTagOpen("tr", sb, baseIndent + 1, null, false, id);
            WriteTag("td", sb, baseIndent + 2, "stats-label text-muted text-right", label, true, null, "width: 0%; padding-left: 0px !important;");
            WriteTag("td", sb, baseIndent + 2, "passed success text-center", stats.Passed.ToString(), true, null, "width: 3.3333333333333%;");
            WriteTag("td", sb, baseIndent + 2, "skipped warning text-center", stats.Skipped.ToString(), true, null, "width: 3.3333333333333%;");
            WriteTag("td", sb, baseIndent + 2, "failed danger text-center", stats.Failed.ToString(), true, null, "width: 3.3333333333333%;");
            WriteTagOpen("td", sb, baseIndent + 2, "outcome-bar-chart", false, null, "width: 90%;");
            WriteTagOpen("table", sb, baseIndent, "table", false, null, "width: 100%; empty-cells: show; height: 14px;");
            WriteTagOpen("tr", sb, baseIndent + 1, null, false);
            
            if(stats.Total == 0)
            {
                WriteTag("td", sb, baseIndent + 2, "empty-bar", null, true, null, "width: 100%;");
            }
            else
            {
                double passedPercent = stats.Total == 0 ? 0 : (((double)stats.Passed / (double)stats.Total) * 100);
                var passedStyle = String.Format("width: {0}%", passedPercent);
                WriteTag("td", sb, baseIndent + 2, "bar passed-bar bg-success text-center", null, true, null, passedStyle);
                
                double skippedPercent = stats.Total == 0 ? 0 : (((double)stats.Skipped / (double)stats.Total) * 100);
                var skippedStyle = String.Format("width: {0}%", skippedPercent);
                WriteTag("td", sb, baseIndent + 2, "bar skipped-bar bg-warning text-center", null, true, null, skippedStyle);
                
                double failedPercent = stats.Total == 0 ? 0 : (((double)stats.Failed / (double)stats.Total) * 100);
                var failedStyle = String.Format("width: {0}%", failedPercent);
                WriteTag("td", sb, baseIndent + 2, "bar failed-bar bg-danger text-center", null, true, null, failedStyle);
            }

            WriteTagClose("tr", sb, baseIndent + 1);
            WriteTagClose("table", sb, baseIndent);
            WriteTagClose("td", sb, baseIndent + 1);
            WriteTagClose("tr", sb, baseIndent);
        }

        void WriteAreas(TestRun testRun, StringBuilder sb)
        {
            var areasOpenWritten = false;
            var scenarioWritten = false;
            Scenario lastScenario = null;
            var sortedScenarios = testRun.Scenarios.OrderBy(x => x.Feature.Area.Name).ThenBy(x => x.Feature.Name).ThenBy(x => x.Name);
            if(testRun.Sorted)
                sortedScenarios = testRun.Scenarios.OrderBy(x => x.Feature.Sort).ThenBy(x => x.Sort);
            foreach (var scenario in sortedScenarios)
            {
                if(!this.failuresOnly || this.failuresOnly && scenario.Outcome == Outcome.Failed)
                {
                    if(!areasOpenWritten) {
                        WriteTagOpen("ol", sb, 1, "areas list-unstyled", false);
                        areasOpenWritten = true;
                    }
                    WriteAreaFeatureAndScenario(lastScenario, scenario, sb);
                    scenarioWritten = true;
                    lastScenario = scenario;
                }
            }

            if(scenarioWritten)
            {
                WriteFeatureClose(sb);
                WriteAreaClose(sb);
                WriteTagClose("ol", sb, 1);//areas
            }
        }
        void WriteAreaFeatureAndScenario(Scenario lastScenario, Scenario scenario, StringBuilder sb)
        {
            if (lastScenario == null || (lastScenario != null && lastScenario.Feature.Area.Name != scenario.Feature.Area.Name))
            {
                if (lastScenario != null)
                {
                    WriteFeatureClose(sb);
                    WriteAreaClose(sb);
                }
                WriteAreaOpen(scenario, sb);
                WriteFeatureOpen(scenario, sb);
            }
            else if (lastScenario == null || (lastScenario != null && lastScenario.Feature.Name != scenario.Feature.Name))
            {
                if (lastScenario != null)
                {
                    WriteFeatureClose(sb);
                }
                WriteFeatureOpen(scenario, sb);
            }

            WriteScenario(scenario, sb);
        }

        private void WriteScenario(Scenario scenario, StringBuilder sb)
        {
            WriteScenarioOpen(scenario, sb);
            //WriteScenarioTitleLine(scenario, sb);
            if (scenario.Steps.Count > 0)
            {
                WriteSteps(scenario, sb);
            }
            WriteScenarioClose(sb);
        }

        void WriteAreaOpen(Scenario scenario, StringBuilder sb)
        {
            string style = null;
            string className = null;
            string badgeClassName = null;
            switch (scenario.Feature.Area.Outcome)
            {
                case Outcome.NotRun:
                    style = "#949494";
                    badgeClassName = "badge-secondary";
                    break;
                case Outcome.Passed:
                    style = "#5A8B5B";
                    className = "collapsed";
                    badgeClassName = "badge-success";
                    break;
                case Outcome.Failed:
                    style = "#AD4D4B";
                    badgeClassName = "badge-danger";
                    break;
                case Outcome.Skipped:
                    style = "#917545";
                    //className = "text-warning";
                    badgeClassName = "badge-warning";
                    break;
                default:
                    break;
            }
            style = "border-left: 2px solid "+style+";";
            //  style = "box-shadow: inset 1px 1px 8px 1px "+style+";";
            areaCounter++;
            var expanded = scenario.Feature.Area.Outcome == Outcome.Failed && this.failuresOnly;
            var expandedText = expanded ? "true" : "false";
            WriteTagOpen("li", sb, 2, "area", false, "area-" + areaCounter);

            var areaTitleAttributes = $" data-toggle=\"collapse\" href=\"#area-{areaCounter}-features\" aria-expanded=\"{expandedText}\" aria-controls=\"area-{areaCounter}-features\" ";
            var areaBadgeAttributes = $" data-toggle=\"collapse\" href=\"#area-{areaCounter}-stats\" aria-expanded=\"false\" aria-controls=\"area-{areaCounter}-stats\" ";
            WriteTagOpen("h2", sb, 3, className, true, null, null, null);
            //WriteTag("small", sb, 4, null, "Area", true);

            WriteBadge("area", "Features", areaCounter, scenario.Feature.Area.FeatureStats, sb, scenario, areaBadgeAttributes, badgeClassName);

            var areaName = scenario.Feature.Area.Name;
            if(this.areaNameSkip != null && this.areaNameSkip.Length > 0) {
                areaName = areaName.Replace(this.areaNameSkip, "");
            }
            if(areaName.Length == 0) {
                areaName = "[Missing! (or Full Name Skipped)]";
            }
            WriteTag("span", sb, 4, "name pointer", areaName.HtmlEncode(), true,  $"area-{areaCounter}-name", null, areaTitleAttributes);
            
            if(scenario.Feature.Area.Reason != null) {
                WriteTag("span", sb, 0, "area reason", $" [{scenario.Feature.Area.Reason.HtmlEncode()}]",true);
            }
            
            var duration = scenario.Feature.Area.EndTime - scenario.Feature.Area.StartTime;
            var formattedDuration = duration.TotalMilliseconds.ToString("N", System.Globalization.CultureInfo.InvariantCulture);
            formattedDuration = formattedDuration.Substring(0, formattedDuration.Length-3);
            WriteTag("span", sb, 0, "area duration", $" [{formattedDuration} ms]",true);

            WriteTagClose("h2", sb, 3);

            WriteStatsTableStart(sb, 3, "area-"+areaCounter+"-stats");
            WriteStats(sb, scenario.Feature.Area.FeatureStats, 3, $"area-{areaCounter}-feature-stats", "Features");
            WriteStats(sb, scenario.Feature.Area.ScenarioStats, 3, $"area-{areaCounter}-scenario-stats", "Scenarios");
            WriteStatsTableClose(sb, 3);

            var featuresClasName = "features list-unstyled collapse" + (expanded ? " show" : "");
            WriteTagOpen("ol", sb, 3, featuresClasName, false, "area-" + areaCounter + "-features", style, String.Format(" aria-expanded=\"{0}\"", expandedText));
        }

        void WriteBadge(string type, string title, int count, OutcomeStats stats, StringBuilder sb, Scenario scenario, string badgeAttributes, string badgeClassName) {
            WriteTagOpen("span", sb, 0, $"{type} badge-distro", true, $"{type}-{count}-badge-distro", null, $"{badgeAttributes} title=\"{title}\"");

            //Create Badge with distribution 
            WriteTag("span", sb, 0, $"{type} badge badge-pill pointer total {badgeClassName}", stats.Total.ToString(), true, $"{type}-{count}-badge", null);
            WriteTagOpen("span", sb, 0, $"{type} distro pointer", true, $"{type}-{count}-distro");
            double totalCount = stats.Total;
            double passedPercent = ((double)stats.Passed/totalCount)*100;
            double skippedPercent = ((double)stats.Skipped/totalCount)*100;
            double failedPercent = ((double)stats.Failed/totalCount)*100;
            var skippedRadius = "";
            if(skippedPercent > 0) {
                if(passedPercent == 0) {
                    skippedRadius = "border-top-right-radius: .25em;";
                }
                if(failedPercent == 0) {
                    skippedRadius = $"{skippedRadius} border-bottom-right-radius: .25em;";
                }
            }
            var passedRadius = "border-top-right-radius: .25em;";
            if(skippedPercent == 0 && failedPercent == 0) {
                passedRadius = $"{passedRadius} border-bottom-right-radius: .25em;";
            }
            var failedRadius = "border-bottom-right-radius: .25em;";
            if(passedPercent == 0 && skippedPercent == 0) {
                failedRadius = $"{failedRadius} border-top-right-radius: .25em;";
            }
            if(passedPercent > 0) {
                WriteTag("div", sb, 0, "distro bg-success", null, true, null, $"height: {passedPercent}%; width: 100%; {passedRadius}");
            }
            if(skippedPercent > 0) {
                WriteTag("div", sb, 0, "distro bg-warning", null, true, null, $"height: {skippedPercent}%; width: 100%; {skippedRadius}");
            }
            if(failedPercent > 0) {
                WriteTag("div", sb, 0, "distro bg-danger", null, true, null, $"height: {failedPercent}%; width: 100%; {failedRadius}");
            }
            WriteTagClose("span", sb, 0);//distribution graph
            WriteTagClose("span", sb, 0);//badge and distro graph
        }
        void WriteAreaClose(StringBuilder sb)
        {
            WriteTagClose("ol", sb, 3);
            WriteTagClose("li", sb, 2);
        }
        void WriteFeatureOpen(Scenario scenario, StringBuilder sb)
        {
            string badgeClassName = null;
            string borderStyle = "";
            switch (scenario.Feature.Outcome)
            {
                case Outcome.NotRun:
                    borderStyle = "#949494";
                    badgeClassName = "badge-secondary";
                    break;
                case Outcome.Passed:
                    borderStyle = "#5A8B5B";
                    badgeClassName = "badge-success";
                    break;
                case Outcome.Failed:
                    borderStyle = "#AD4D4B";
                    badgeClassName = "badge-danger";
                    break;
                case Outcome.Skipped:
                    borderStyle = "#917545";
                    badgeClassName = "badge-warning";
                    break;
                default:
                    break;
            }
            borderStyle = $"border-left: 2px solid {borderStyle};";
            featureCounter++;
            var expanded = scenario.Feature.Outcome == Outcome.Failed && this.failuresOnly;
            var expandedText = expanded ? "true" : "false";

            WriteTagOpen("li", sb, 4, "feature", false, "feature-" + featureCounter);

            var titleAttributes = $" data-toggle=\"collapse\" href=\"#feature-{featureCounter}-scenarios\" aria-expanded=\"{expandedText}\" aria-controls=\"feature-{featureCounter}-scenarios\" ";
            var badgeAttributes = $" data-toggle=\"collapse\" href=\"#feature-{featureCounter}-stats\" aria-expanded=\"false\" aria-controls=\"feature-{featureCounter}-stats\" ";
            WriteTagOpen("h3", sb, 5, null, true, "vertical-align: top !important;", null, null);

            WriteBadge("feature", "Scenarios", featureCounter, scenario.Feature.ScenarioStats, sb, scenario, badgeAttributes, badgeClassName);

            //WriteTag("span", sb, 6, $"feature badge pointer total {badgeClassName}", scenario.Feature.ScenarioStats.Total.ToString(), true, null, null, $"{badgeAttributes} title=\"Scenarios\"");
            if (scenario.Feature.Actor != null || scenario.Feature.Value != null || scenario.Feature.Capability != null)
            {
                sb.Append($"<span class=\"feature-statement-link badge pointer badge-secondary\" id=\"feature-{featureCounter}-statement-link\" data-toggle=\"collapse\" href=\"#feature-{featureCounter}-statement\" aria-expanded=\"false\" aria-controls=\"feature-{featureCounter}-statement\"><span class=\"oi oi-info\" aria-hidden=\"true\"></span></span>");
            }
            WriteTag("span", sb, 6, "name pointer", scenario.Feature.Name.HtmlEncode(), true, null, null, titleAttributes);

            if(scenario.Feature.Reason != null) {
                WriteTag("span", sb, 0, "feature reason", $" [{scenario.Feature.Reason.HtmlEncode()}]",true);
            }

            var duration = scenario.Feature.EndTime - scenario.Feature.StartTime;
            var formattedDuration = duration.TotalMilliseconds.ToString("N", System.Globalization.CultureInfo.InvariantCulture);
            formattedDuration = formattedDuration.Substring(0, formattedDuration.Length-3);
            WriteTag("span", sb, 0, "feature duration", $" [{formattedDuration} ms]",true);

            WriteTagClose("h3", sb, 5);

            WriteStatsTableStart(sb, 5, "feature-"+featureCounter+"-stats");
            WriteStats(sb, scenario.Feature.ScenarioStats, 5, "feature-"+featureCounter+"-scenario-stats", "Scenarios");
            WriteStatsTableClose(sb, 5);
            
            WriteFeatureStatement(scenario, sb, featureCounter);

            var scenariosClassName = "scenarios list-unstyled collapse" + (expanded ? " show" : "");
            WriteTagOpen("ol", sb, 5, scenariosClassName, false, "feature-" + featureCounter + "-scenarios", borderStyle, $" aria-expanded=\"{expandedText}\"");
        }
        void WriteFeatureStatement(Scenario scenario, StringBuilder sb, int featureNumber)
        {
            if(scenario.Feature.Actor != null || scenario.Feature.Value != null || scenario.Feature.Capability != null)
            {
                WriteTagOpen("div", sb, 5, "output collapse", false, "feature-" + featureNumber + "-statement", null, " aria-expanded=\"false\"");
                var statement = $"As a {scenario.Feature.Actor??"[Missing!]"}{System.Environment.NewLine}You can {scenario.Feature.Value??"[Missing!]"}{System.Environment.NewLine}By {scenario.Feature.Capability??"[Missing!]"}";
                WriteTag("pre", sb, 6, "feature-statement bg-light rounded", statement, true, $"feature-{featureCounter}-statement");
                WriteTagClose("div", sb, 0);
            }
        }
        void WriteFeatureClose(StringBuilder sb)
        {
            WriteTagClose("ol", sb, 5);
            WriteTagClose("li", sb, 4);
        }
        void WriteScenarioOpen(Scenario scenario, StringBuilder sb)
        {
            var className = "scenario " + Enum.GetName(typeof(Outcome), scenario.Outcome).ToLower();
            var badgeClassName = "";
            switch (scenario.Outcome)
            {
                case Outcome.NotRun:
                    break;
                case Outcome.Passed:
                    badgeClassName = badgeClassName + "badge-success";
                    break;
                case Outcome.Failed:
                    badgeClassName = badgeClassName + "badge-danger";
                    break;
                case Outcome.Skipped:
                    badgeClassName = badgeClassName + "badge-warning";
                    break;
                default:
                    break;
            }
            scenarioCounter++;
            WriteTagOpen("li", sb, 6, className, false, "scenario-" + scenarioCounter);

            var expanded = scenario.Outcome == Outcome.Failed && this.failuresOnly;
            var expandedText = expanded ? "true" : "false";

            var titleAttributes = $" data-toggle=\"collapse\" href=\"#scenario-{scenarioCounter}-steps\" aria-expanded=\"{expandedText}\" aria-controls=\"scenario-{scenarioCounter}-steps\" ";
            WriteTagOpen("h4", sb, 7, "panel-heading", true, null, null, titleAttributes);

            WriteTag("span", sb, 8, $"scenario badge pointer total {badgeClassName}", scenario.StepStats.Total.ToString(), true, null, null, " title=\"Steps\"");

            WriteTag("span", sb, 0, "name pointer", scenario.Name.HtmlEncode(), true);

            if(scenario.Reason != null) {
                WriteTag("span", sb, 0, "scenario reason", $" [{scenario.Reason.HtmlEncode()}]",true);
            }
            
            var duration = scenario.EndTime - scenario.StartTime;
            var formattedDuration = duration.TotalMilliseconds.ToString("N", System.Globalization.CultureInfo.InvariantCulture);
            formattedDuration = formattedDuration.Substring(0, formattedDuration.Length-3);
            WriteTag("span", sb, 0, "scenario duration", $" [{formattedDuration} ms]",true);

            WriteTagClose("h4", sb, 7);

            var stepsClassName = "steps list-unstyled collapse" + (expanded ? " show" : "");
            WriteTagOpen("ol", sb, 7, stepsClassName, false, "scenario-" + scenarioCounter + "-steps", null, String.Format(" aria-expanded=\"{0}\"", expandedText));
        }
        void WriteScenarioClose(StringBuilder sb)
        {
            WriteTagClose("ol", sb, 7);
            WriteTagClose("li", sb, 6);
        }
        void WriteScenarioStatus(Scenario scenario, StringBuilder sb)
        {
            WriteTagOpen("span",sb, 0, "status", true);
            sb.Append("[");
            sb.Append(Enum.GetName(typeof(Outcome), scenario.Outcome));
            if (scenario.Reason != null && scenario.Reason != "Failed Step")
            {
                sb.Append(" - ");
                sb.Append(scenario.Reason.HtmlEncode());
            }
            sb.Append("]");
            WriteTagClose("span", sb, 0);
        }
        void WriteScenarioTitleLine(Scenario scenario, StringBuilder sb)
        {
        }
        void WriteSteps(Scenario scenario, StringBuilder sb)
        {
            var expanded = scenario.Outcome == Outcome.Failed && failuresOnly;
            var expandedText = expanded ? "true" : "false";

            var stepsClassName = "steps list-unstyled collapse" + (expanded ? " in" : "");
            //WriteTagOpen("ol", sb, 8, stepsClassName, false, "scenario-" + scenarioCounter + "-steps", null, String.Format(" aria-expanded=\"{0}\"", expandedText));
            foreach(Step step in scenario.Steps)
            {
                stepCounter++;
                WriteStep(step, sb, stepCounter);
            }
        //WriteTagClose("ol", sb, 8);
        }
        void WriteStep(Step step, StringBuilder sb, int stepNumber)
        {
            var badgeClassName = "step " + Enum.GetName(typeof(Outcome), step.Outcome).ToLower();
            switch (step.Outcome)
            {
                case Outcome.NotRun:
                    badgeClassName = badgeClassName + " badge-info";
                    break;
                case Outcome.Passed:
                    badgeClassName = badgeClassName + " badge-success";
                    break;
                case Outcome.Failed:
                    badgeClassName = badgeClassName + " badge-danger";
                    break;
                case Outcome.Skipped:
                    badgeClassName = badgeClassName + " badge-warning";
                    break;
                default:
                    break;
            }
            WriteTagOpen("li", sb, 8, null, false, "step-" + stepNumber);

            WriteTagOpen("h5", sb, 9, null, true);
            WriteTag("span", sb, 10, $"step badge pointer total badge-pill {badgeClassName}", " ", true, $"step-{stepNumber}-badge");
            WriteTag("span", sb, 0, "name", step.FullName.HtmlEncode(), true);
            
            if (!String.IsNullOrEmpty(step.Input))
            {
                sb.Append(String.Format("<a class=\"step-input-link\" data-toggle=\"collapse\" href=\"#step-{0}-input\" aria-expanded=\"false\" aria-controls=\"step-{0}-input\"> [Input]</a>", stepNumber));
            }
            
            if (!String.IsNullOrEmpty(step.Output))
            {
                sb.Append(String.Format("<a class=\"step-output-link\" data-toggle=\"collapse\" href=\"#step-{0}-output\" aria-expanded=\"false\" aria-controls=\"step-{0}-output\"> [Output]</a>", stepNumber));
            }
            
            if (step.Scenario.Outcome == Outcome.Failed && step.Outcome != Outcome.Passed)
            {
                if(step.Exception != null)
                {
                    sb.Append($"<a class=\"step-error-link\" data-toggle=\"collapse\" href=\"#step-{stepNumber}-error\" aria-expanded=\"false\" aria-controls=\"step-{stepNumber}-error\"> [Error!]</a>");
                } else 
                {
                    WriteTagOpen("span", sb, 0, "status", true);
                    sb.Append(" [");
                    sb.Append(Enum.GetName(typeof(Outcome), step.Outcome));
                    if (step.Reason != null && (step.Outcome != Outcome.Failed || step.Reason == "Not Implemented"))
                    {
                        sb.Append(" - ");
                        sb.Append(step.Reason.HtmlEncode());
                    }
                    sb.Append("]");
                }
                WriteTagClose("span", sb, 0);
            }

            var duration = step.EndTime - step.StartTime;
            var formattedDuration = duration.TotalMilliseconds.ToString("N", System.Globalization.CultureInfo.InvariantCulture);
            formattedDuration = formattedDuration.Substring(0, formattedDuration.Length-3);
            WriteTag("span", sb, 0, "step duration", $" [{formattedDuration} ms]",true);
            WriteTagClose("h5", sb, 0);
            if (!String.IsNullOrEmpty(step.Input))
            {
                WriteMultilineParameter(step, sb, stepNumber);
            }
            if (step.Exception != null && step.Outcome != Outcome.Skipped)
                WriteException(step.Exception, sb, 0, stepNumber);

            if (!String.IsNullOrEmpty(step.Output))
            {
                WriteOutput(step, sb, stepNumber);
            }
            WriteTagClose("li", sb, 8);
        }
        void WriteException(Exception exception, StringBuilder sb, int level, int stepNumber, bool innerException = false)
        {
            if(!innerException)
            {
                WriteTagOpen("div", sb, 9, "error collapse", false, "step-" + stepNumber + "-error", null, " aria-expanded=\"false\"");
            }
            WriteTagOpen("dl", sb, 9 + level, "exception dl-horizontal border border-danger rounded", false);
            WriteTag("dt", sb, 10 + level, null, "Error Type", true);
            WriteTag("dd", sb, 10 + level, "error-type", exception.GetType().Name.HtmlEncode(), true);
            WriteTag("dt", sb, 10 + level, null, "Message", true);
            WriteTag("dd", sb, 10 + level, "error-message bg-light", "<pre><code>" + exception.Message.HtmlEncode() + "</code></pre>", true);
            WriteTag("dt", sb, 10 + level, null, "Stack", true);
            WriteTag("dd", sb, 10 + level, "error-stack bg-light", "<pre><code>" + exception.StackTrace.HtmlEncode() + "</code></pre>", true);
            if(exception.InnerException != null)
            {
                WriteTag("dt", sb, 10 + level, null, "Inner Exception", true);
                WriteTagOpen("dd", sb, 10 + level, "inner-exception", true);
                WriteException(exception.InnerException, sb,  level++, stepNumber, true);
                WriteTagClose("dd", sb, 10 + level);
            }
            WriteTagClose("dl", sb, 9 + level);
            if(!innerException)
            {
                WriteTagClose("div", sb, 0);
            }
        }
        void WriteMultilineParameter(Step step, StringBuilder sb, int stepNumber)
        {
            WriteTagOpen("div", sb, 9, "input collapse", false, "step-" + stepNumber + "-input", null, " aria-expanded=\"false\"");
            WriteTag("div", sb, 10, "input title", "Input", false, "step-" + stepNumber + "-input-title");
            if(step.InputFormat == TextFormat.htmlpreview)
            {
                WriteMultilineParameterWithHtmlPreview(step, sb, stepNumber);
            }
            else
            {
                var className = "input prettyprint linenums rounded";
                if (step.InputFormat != TextFormat.code)
                    className = className + " lang-" + Enum.GetName(typeof(TextFormat), step.InputFormat);
                WriteTagOpen("pre", sb, 10, className, true, $"input-{stepNumber}");
                sb.Append(step.Input.HtmlEncode());
                WriteTagClose("pre", sb, 0);
            }
            WriteTagClose("div", sb, 0);
        }

        void WriteMultilineParameterWithHtmlPreview(Step step, StringBuilder sb, int stepNumber)
        {
            var previewCode = step.Input.HtmlEncode();
            var previewHtml = step.Input
                .Replace(System.Environment.NewLine, " \\" + System.Environment.NewLine)
                .Replace(":", "\\:")
                .Replace("/", "\\/")
                .Replace("!", "\\!")
                .Replace("\"", "\\\"");
            var html = $@"
                                    <div class=""input rounded"">
                                        <div class=""nav nav-tabs"" role=""tablist"">
                                            <a href=""#preview{stepNumber}""
                                                id=""#preview{stepNumber}-tab""
                                                class=""nav-item nav-link active"" 
                                                aria-controls=""preview{stepNumber}"" 
                                                aria-selected=""true""
                                                role=""tab"" 
                                                data-toggle=""tab"">Preview</a>
                                            <a href=""#code{stepNumber}"" 
                                                id=""#code{stepNumber}-tab""
                                                class=""nav-item nav-link"" 
                                                aria-controls=""code{stepNumber}"" 
                                                role=""tab"" 
                                                data-toggle=""tab"">Code</a>
                                        </div>
                                        <div class=""tab-content"">
                                            <div role=""tabpanel"" class=""tab-pane active"" id=""preview{stepNumber}"">
                                                <iframe width=""100%"" id=""iframe{stepNumber}""></iframe>
                                                <script type=""text/javascript"">
                                                    var iframe{stepNumber}doc = document.getElementById('iframe{stepNumber}').contentWindow.document;
                                                    iframe{stepNumber}doc.open();
                                                    var html{stepNumber} = ""{previewHtml}"";
                                                    iframe{stepNumber}doc.write(html{stepNumber});
                                                    resizeIframe(document.getElementById('iframe{stepNumber}'));
                                                    iframe{stepNumber}doc.close();
                                                </script>
                                            </div>
                                            <div role=""tabpanel"" class=""tab-pane"" id=""code{stepNumber}"">
                                                <pre class=""input prettyprint linenums lang-html"">{previewCode}</pre>
                                            </div>
                                        </div>
                                    </div>";
            sb.AppendLine(html);
        }

        void WriteOutput(Step step, StringBuilder sb, int stepNumber)
        {
            WriteTagOpen("div", sb, 9, "output collapse", false, "step-" + stepNumber + "-output", null, " aria-expanded=\"false\"");
            WriteTag("div", sb, 10, "output title", "Output", false, "step-" + stepNumber + "-output-title");

            if(step.OutputFormat == TextFormat.htmlpreview)
            {
                WriteOutputWithHtmlPreview(step, sb, stepNumber);
            }
            else
            {
                var className = "output prettyprint linenums rounded";
                if (step.OutputFormat != TextFormat.code)
                    className = className + " lang-" + Enum.GetName(typeof(TextFormat), step.OutputFormat);
                WriteTagOpen("pre", sb, 10, className, true, "output-" + stepNumber);
                sb.Append(step.Output.HtmlEncode());
                WriteTagClose("pre", sb, 0);
            }
            WriteTagClose("div", sb, 0);
        }

        void WriteOutputWithHtmlPreview(Step step, StringBuilder sb, int stepNumber)
        {
            var htmlCode = step.Output.HtmlEncode();
            var htmlPreview = step.Output
                .Replace(System.Environment.NewLine, $" \\{System.Environment.NewLine}")
                .Replace(":", "\\:")
                .Replace("/", "\\/")
                .Replace("!", "\\!")
                .Replace("\"", "\\\"");
            var html = $@"
                                        <strong><h5>Output</h5></strong>
                                        <div class=""nav nav-tabs"" role=""tablist"">
                                            <a href=""#output-preview-{stepNumber}""
                                                id=""#output-preview-{stepNumber}-tab""
                                                class=""nav-item nav-link active"" 
                                                aria-controls=""output-preview-{stepNumber}"" 
                                                aria-selected=""true""
                                                role=""tab"" 
                                                data-toggle=""tab"">Preview</a>
                                            <a href=""#output-code-{stepNumber}"" 
                                                id=""#output-code-{stepNumber}-tab""
                                                class=""nav-item nav-link"" 
                                                aria-controls=""output-code-{stepNumber}"" 
                                                role=""tab"" 
                                                data-toggle=""tab"">Code</a>
                                        </div>
                                        <div class=""tab-content"">
                                            <div role=""tabpanel"" class=""tab-pane active"" id=""output-preview-{stepNumber}"">
                                                <iframe width=""100%"" height=""400px"" id=""iframe{stepNumber}""></iframe>
                                                <script type=""text/javascript"">
                                                    var iframe{stepNumber}doc = document.getElementById('iframe{stepNumber}').contentWindow.document;
                                                    iframe{stepNumber}doc.open();
                                                    var html{stepNumber} = ""{htmlPreview}"";
                                                    iframe{stepNumber}doc.write(html{stepNumber});
                                                    iframe{stepNumber}doc.close();
                                                </script>
                                            </div>
                                            <div role=""tabpanel"" class=""tab-pane"" id=""output-code-{stepNumber}"">
                                                <pre class=""input prettyprint linenums lang-html"">{htmlCode}</pre>
                                            </div>
                                        </div>";
            sb.AppendLine(html);
        }

        void WriteTag(string tag, StringBuilder sb, 
            int indentation, string className, string text, 
            bool inline, string id = null, string style = null, string attributes = null)
        {
            WriteTagOpen(tag, sb, indentation, className, inline, id, style, attributes);
            sb.Append(text);
            WriteTagClose(tag, sb, inline?0:indentation);
        }
        void WriteTagOpen(string tag, StringBuilder sb, int indentation, 
            string className, bool inline, string id = null, 
            string style = "", string attributes = null)
        {
            WriteIndentation(sb, indentation);
            sb.Append("<");
            sb.Append(tag);
            if (className != null)
            {
                sb.Append(" class=\"");
                sb.Append(className);
                sb.Append("\"");
            }
            if (style != null && style != "")
            {
                sb.Append(" style=\"");
                sb.Append(style);
                sb.Append("\"");
            }
            
            if (id != null)
            {
                sb.Append(" id=\"");
                sb.Append(id);
                sb.Append("\"");
            }
            if(attributes != null)
                sb.Append(attributes);
            if (inline)
                sb.Append(">");
            else
                sb.AppendLine(">");
        }
        void WriteTagClose(string tag, StringBuilder sb, int indentation)
        {
            WriteIndentation(sb, indentation);
            sb.Append("</");
            sb.Append(tag);
            sb.AppendLine(">");
        }
        void WriteIndentation(StringBuilder sb, int indentation)
        {
            for (int i = 0; i < indentation; i++)
            {
                sb.Append("    ");
            }
        }

    }
}
