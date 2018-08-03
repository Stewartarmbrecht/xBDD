using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xBDD.Model;

namespace xBDD.Reporting.Html
{
    public class HtmlWriter
    {
        int areaCounter = 0;
        int featureCounter = 0;
        int scenarioCounter = 0;
        int stepCounter = 0;
        public Task<string> WriteToString(TestRun testRun)
        {
            return Task.Run(() => {
                StringBuilder sb = new StringBuilder();
                //sb.AppendLine(JsonConvert.SerializeObject(testRun));
                sb.AppendLine("<!DOCTYPE html>");
                WriteHtml(testRun, sb);
                return sb.ToString();
            });
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
            sb.AppendLine("    <link rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css\">");
            sb.AppendLine("    <link rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap-theme.min.css\">");
            WriteStyles(sb);
            sb.AppendLine("</head>");
        }

        private void WriteStyles(StringBuilder sb)
        {
            sb.Append("    <style>");
            sb.Append(" ul.steps, div.output, div.mp, dl.exception { margin-left: 2em }");
            sb.Append(" iframe { border: 1px solid gray; resize: both; overflow: auto; }");
            sb.Append(" li.scenario h4 { margin: .5em; }");
            //sb.Append(" ol.features { padding: .5em; }");
            sb.Append(" li.feature { margin: 1.5em; padding: 1em 2em; box-shadow: 1px 1px 8px 1px rgb(202, 202, 202); }");
            sb.Append(" li.scenario .panel { margin: 1.5em; }");
            sb.Append(" .table th, .table td { border-top: none !important; line-height: 1 !important; padding: 2px 10px !important; }");
            sb.Append(" td.graph td { padding: 0px !important; }");
            sb.Append(" .table { margin: 0px !important; }");
            sb.Append(" h3 { margin: 8px !important; }");
            sb.Append(" .table td.bar { padding: 0px !important; }");
            sb.Append(" .testrun-percent-bar { background-color: #56C1F7; }");
            sb.Append(" .area-percent-bar { background-color: #A4DEFB; }");
            sb.Append(" .pointer { cursor: pointer }");
            sb.Append(" .feature-statement { margin-top: 1em; }");
            sb.AppendLine("</style>");  
        }

        void WriteBody(TestRun testRun, StringBuilder sb)
        {
            WriteTagOpen("body", sb, 0, "container-fluid", false);
            WriteNavBar(sb);
            WriteTestRun(testRun, sb);
            sb.AppendLine("    <script src=\"https://code.jquery.com/jquery-2.1.4.min.js\"></script>");
            sb.AppendLine("    <script src=\"https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js\"></script>");
            sb.AppendLine("    <script src=\"https://cdn.rawgit.com/google/code-prettify/master/loader/run_prettify.js?skin=sunburst\"></script>");
            sb.AppendLine("    <script language=\"javascript\" type=\"text/javascript\">function resizeIframe(obj) { obj.style.height = obj.contentWindow.document.body.scrollHeight + 'px'; }</script>");
            WriteTagClose("body", sb, 0);
        }

        private void WriteNavBar(StringBuilder sb)
        {
            WriteTagOpen("nav", sb, 1, "navbar navbar-default", false, "menu");
            WriteTagOpen("div", sb, 2, "container-fluid", false);
            WriteTagOpen("div", sb, 3, "navbar-header", false);
            WriteTagOpen("button", sb, 4, "navbar-toggle collapsed", false, "menu-button", null,
                " type=\"button\" data-toggle=\"collapse\" data-target=\"#menu-body\" aria-expanded=\"false\"");
            WriteTag("span", sb, 5, "sr-only", "Toggle Navigation", true);
            WriteTag("span", sb, 5, "icon-bar", null, true);
            WriteTag("span", sb, 5, "icon-bar", null, true);
            WriteTag("span", sb, 5, "icon-bar", null, true);
            WriteTagClose("button", sb, 4);
            WriteTagClose("div", sb, 3);

            WriteTagOpen("div", sb, 3, "collapse navbar-collapse", false, "menu-body");
            WriteTagOpen("ul", sb, 4, "nav navbar-nav", false);
            WriteTagOpen("li", sb, 5, null, false);
            WriteTag("a", sb, 5, null, "Expand All Areas", true, "expand-all-areas-button", null, " href=\"javascript: $('ol.features').collapse('show');\"");
            WriteTagClose("li", sb, 5);
            WriteTagClose("ul", sb, 4);
            WriteTagClose("div", sb, 3);
            WriteTagClose("div", sb, 2);
            WriteTagClose("nav", sb, 1);
        }

        private void WriteTestRun(TestRun testRun, StringBuilder sb)
        {
            var scenarioCount = testRun.Areas.Count;
            var cssClass = "testrun-name";
            if (scenarioCount == 0)
            {
                cssClass = cssClass + " text-muted";
            }
            else
            {
                switch (testRun.Outcome)
                {
                    case Outcome.Failed:
                        cssClass = cssClass + " text-danger";
                        break;
                    case Outcome.NotRun:
                        cssClass = cssClass + " text-info";
                        break;
                    case Outcome.Passed:
                        cssClass = cssClass + " text-success";
                        break;
                    case Outcome.Skipped:
                        cssClass = cssClass + " text-warning";
                        break;
                }
            }
            WriteTagOpen("div", sb, 1, "page-header", false, null, "margin-top: 0px !important;");
            WriteTagOpen("h1", sb, 2, cssClass, true);
            WriteTag("small", sb, 2, null, "Test Run", true);
            sb.Append("<br/>");
            WriteTag("span", sb, 0, "name", testRun.Name.HtmlEncode(), true);
            WriteTag("span", sb, 0, "badge pull-right total", testRun.AreaStats.Total.ToString(), true, null, null, " title=\"Areas\"");
            WriteTagClose("h1", sb, 2);
            WriteTagClose("div", sb, 1);
            WriteStatsTableStart(sb, 1);
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

        private void WriteStatsTableStart(StringBuilder sb, int baseIndent)
        {
            WriteTagOpen("table", sb, baseIndent, "table table-condensed", false, null, "width: 100%; empty-cells: show;");
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
            WriteTagOpen("ol", sb, 1, "areas list-unstyled", false);
            Scenario lastScenario = null;
            foreach (var scenario in testRun.Scenarios.OrderBy(x => x.Feature.Area.Name).ThenBy(x => x.Feature.Name).ThenBy(x => x.Name))
            {
                WriteAreaFeatureAndScenario(lastScenario, scenario, sb);
                lastScenario = scenario;
            }

            WriteFeatureClose(sb);
            WriteAreaClose(sb);
            WriteTagClose("ol", sb, 1);//areas
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
            WriteScenarioTitleLine(scenario, sb);
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
            switch (scenario.Feature.Area.Outcome)
            {
                case Outcome.NotRun:
                    style = "#949494";
                    className = "text-muted";
                    break;
                case Outcome.Passed:
                    style = "#5A8B5B";
                    className = "text-success collapsed";
                    break;
                case Outcome.Failed:
                    style = "#AD4D4B";
                    className = "text-danger";
                    break;
                case Outcome.Skipped:
                    style = "#917545";
                    className = "text-warning";
                    break;
                default:
                    break;
            }
            style = "border-left: 2px solid "+style+";";
            //  style = "box-shadow: inset 1px 1px 8px 1px "+style+";";
            areaCounter++;
            var expanded = scenario.Feature.Area.Outcome == Outcome.Failed;
            var expandedText = expanded ? "true" : "false";
            WriteTagOpen("li", sb, 2, "area", false, "area-" + areaCounter);

            var areaTitleAttributes = String.Format(" data-toggle=\"collapse\" href=\"#area-{0}-features\" aria-expanded=\"{1}\" aria-controls=\"area-{0}-features\" ", areaCounter, expandedText);
            WriteTagOpen("h2", sb, 3, className, true, null, null, areaTitleAttributes);
            WriteTag("small", sb, 4, null, "Area", true);
            WriteTag("span", sb, 4, "name pointer", scenario.Feature.Area.Name.HtmlEncode(), true);
            WriteTag("span", sb, 4, "badge pull-right total", scenario.Feature.Area.FeatureStats.Total.ToString(), true, null, null, " title=\"Features\"");
            WriteTagClose("h2", sb, 3);

            WriteStatsTableStart(sb, 3);
            WriteStats(sb, scenario.Feature.Area.FeatureStats, 3, "area-"+areaCounter+"-feature-stats", "Features");
            WriteStats(sb, scenario.Feature.Area.ScenarioStats, 3, "area-"+areaCounter+"-scenario-stats", "Scenarios");
            WriteStatsTableClose(sb, 3);

            var featuresClasName = "features list-unstyled collapse" + (expanded ? " in" : "");
            WriteTagOpen("ol", sb, 3, featuresClasName, false, "area-" + areaCounter + "-features", style, String.Format(" aria-expanded=\"{0}\"", expandedText));
        }
        void WriteAreaClose(StringBuilder sb)
        {
            WriteTagClose("ol", sb, 3);
            WriteTagClose("li", sb, 2);
        }
        void WriteFeatureOpen(Scenario scenario, StringBuilder sb)
        {
            string style = null;
            string className = null;
            switch (scenario.Feature.Outcome)
            {
                case Outcome.NotRun:
                    style = "#949494";
                    className = "text-muted";
                    break;
                case Outcome.Passed:
                    style = "#5A8B5B";
                    className = "text-success";
                    break;
                case Outcome.Failed:
                    style = "#AD4D4B";
                    className = "text-danger";
                    break;
                case Outcome.Skipped:
                    style = "#917545";
                    className = "text-warning";
                    break;
                default:
                    break;
            }
            style = "box-shadow: 1px 1px 8px 1px "+style+";";
            featureCounter++;
            var expanded = scenario.Feature.Outcome == Outcome.Failed;
            var expandedText = expanded ? "true" : "false";
            WriteTagOpen("li", sb, 4, "feature", false, "feature-" + featureCounter, style);

            var titleAttributes = String.Format(" data-toggle=\"collapse\" href=\"#feature-{0}-scenarios\" aria-expanded=\"{1}\" aria-controls=\"feature-{0}-scenarios\" ", featureCounter, expandedText);
            WriteTagOpen("h3", sb, 5, className, true, "vertical-align: top !important;", null, titleAttributes);
            WriteTag("small", sb, 6,null, "Feature", true);
            WriteTag("span", sb, 6, "name pointer", scenario.Feature.Name.HtmlEncode(), true);
            WriteTag("span", sb, 6, "badge pull-right total", scenario.Feature.ScenarioStats.Total.ToString(), true, null, null, " title=\"Scenarios\"");
            WriteTagClose("h3", sb, 5);

            WriteStatsTableStart(sb, 5);
            WriteStats(sb, scenario.Feature.ScenarioStats, 5, "feature-"+featureCounter+"-scenario-stats", "Scenarios");
            WriteStatsTableClose(sb, 5);
            
            WriteFeatureStatement(scenario, sb);

            var scenariosClassName = "scenarios list-unstyled collapse" + (expanded ? " in" : "");
            WriteTagOpen("ol", sb, 5, scenariosClassName, false, "feature-" + featureCounter + "-scenarios", null, String.Format(" aria-expanded=\"{0}\"", expandedText));
        }
        void WriteFeatureStatement(Scenario scenario, StringBuilder sb)
        {
            if(scenario.Feature.Actor != null || scenario.Feature.Value != null || scenario.Feature.Capability != null)
            {
                var statement = $"In order to {scenario.Feature.Value??"[Missing!]"}{System.Environment.NewLine}As a {scenario.Feature.Actor??"[Missing!]"}{System.Environment.NewLine}I would like to {scenario.Feature.Capability??"[Missing!]"}";
                WriteTag("pre", sb, 5, "feature-statement", statement, true, $"feature-{featureCounter}-statement");
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
            var panelClassName = "panel ";
            switch (scenario.Outcome)
            {
                case Outcome.NotRun:
                    break;
                case Outcome.Passed:
                    panelClassName = panelClassName + " panel-success";
                    break;
                case Outcome.Failed:
                    panelClassName = panelClassName + " panel-danger";
                    break;
                case Outcome.Skipped:
                    panelClassName = panelClassName + " panel-warning";
                    break;
                default:
                    break;
            }
            scenarioCounter++;
            WriteTagOpen("li", sb, 6, className, false, "scenario-" + scenarioCounter);
            WriteTagOpen("div", sb, 7, panelClassName, false);
        }
        void WriteScenarioClose(StringBuilder sb)
        {
            WriteTagClose("div", sb, 7);
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
            var expanded = scenario.Outcome == Outcome.Failed;
            var expandedText = expanded ? "true" : "false";

            var titleAttributes = String.Format(" data-toggle=\"collapse\" href=\"#scenario-{0}-steps\" aria-expanded=\"{1}\" aria-controls=\"scenario-{0}-steps\" ", scenarioCounter, expandedText);
            WriteTagOpen("div", sb, 7, "panel-heading", true, null, null, titleAttributes);
            WriteTag("span", sb, 0, "name pointer", scenario.Name.HtmlEncode(), true);
            if (scenario.Outcome != Outcome.Passed)
            {
                WriteScenarioStatus(scenario, sb);
            }

            WriteTag("span", sb, 8, "badge pull-right total", scenario.StepStats.Total.ToString(), true, null, null, " title=\"Steps\"");

            WriteTagClose("div", sb, 0);
        }
        void WriteSteps(Scenario scenario, StringBuilder sb)
        {
            var expanded = scenario.Outcome == Outcome.Failed;
            var expandedText = expanded ? "true" : "false";

            var scenariosClassName = "panel-body collapse" + (expanded ? " in" : "");
            WriteTagOpen("div", sb, 7, scenariosClassName, false, "scenario-" + scenarioCounter + "-steps", null, String.Format(" aria-expanded=\"{0}\"", expandedText));
            WriteTagOpen("ol", sb, 7, "steps list-unstyled", false);
            foreach(Step step in scenario.Steps)
            {
                stepCounter++;
                WriteStep(step, sb, stepCounter);
            }
            WriteTagClose("ol", sb, 7);
            WriteTagClose("div", sb, 7);
        }
        void WriteStep(Step step, StringBuilder sb, int stepNumber)
        {
            var className = "step " + Enum.GetName(typeof(Outcome), step.Outcome).ToLower();
            switch (step.Outcome)
            {
                case Outcome.NotRun:
                    className = className + " text-info";
                    break;
                case Outcome.Passed:
                    className = className + " text-success";
                    break;
                case Outcome.Failed:
                    className = className + " text-danger";
                    break;
                case Outcome.Skipped:
                    className = className + " text-warning";
                    break;
                default:
                    break;
            }
            WriteTagOpen("li", sb, 8, className, false, "step-" + stepNumber);

            WriteTagOpen("h5", sb, 9, null, true);
            WriteTag("span", sb, 0, "name", step.FullName.HtmlEncode(), true);
            
            if (!String.IsNullOrEmpty(step.Output))
            {
                sb.Append(String.Format("<a class=\"step-output-link\" data-toggle=\"collapse\" href=\"#step-{0}-output\" aria-expanded=\"false\" aria-controls=\"step-{0}-output\">[Output]</a>", stepNumber));
            }
            
            if (step.Scenario.Outcome == Outcome.Failed && step.Outcome != Outcome.Passed)
            {
                WriteTagOpen("span", sb, 0, "status", true);
                sb.Append("[");
                sb.Append(Enum.GetName(typeof(Outcome), step.Outcome));
                if (step.Reason != null && (step.Outcome != Outcome.Failed || step.Reason == "Not Implemented"))
                {
                    sb.Append(" - ");
                    sb.Append(step.Reason.HtmlEncode());
                }
                sb.Append("]");
                WriteTagClose("span", sb, 0);
            }

            WriteTagClose("h5", sb, 0);
            if (!String.IsNullOrEmpty(step.MultilineParameter))
            {
                WriteMultilineParameter(step, sb, stepNumber);
            }
            if (step.Exception != null && !(step.Exception is NotImplementedException) && step.Outcome != Outcome.Skipped)
                WriteException(step.Exception, sb);

            if (!String.IsNullOrEmpty(step.Output))
            {
                WriteOutput(step, sb, stepNumber);
            }
            WriteTagClose("li", sb, 8);
        }
        void WriteException(Exception exception, StringBuilder sb, int level = 0)
        {
            WriteTagOpen("dl", sb, 9 + level, "exception dl-horizontal", false);
            WriteTag("dt", sb, 10 + level, null, "Error Type", true);
            WriteTag("dd", sb, 10 + level, "error-type", exception.GetType().Name.HtmlEncode(), true);
            WriteTag("dt", sb, 10 + level, null, "Message", true);
            WriteTag("dd", sb, 10 + level, "error-message", "<pre>" + exception.Message.HtmlEncode() + "</pre>", true);
            WriteTag("dt", sb, 10 + level, null, "Stack", true);
            WriteTag("dd", sb, 10 + level, "error-stack", "<pre>" + exception.StackTrace.HtmlEncode() + "</pre>", true);
            if(exception.InnerException != null)
            {
                WriteTag("dt", sb, 10 + level, null, "Inner Exception", true);
                WriteTagOpen("dd", sb, 10 + level, "inner-exception", true);
                WriteException(exception.InnerException, sb,  level++);
                WriteTagClose("dd", sb, 10 + level);
            }
            WriteTagClose("dl", sb, 9 + level);
        }
        void WriteMultilineParameter(Step step, StringBuilder sb, int stepNumber)
        {
            if(step.MultilineParameterFormat == TextFormat.htmlpreview)
            {
                WriteMultilineParameterWithHtmlPreview(step, sb, stepNumber);
            }
            else
            {
                var className = "mp";
                if (step.MultilineParameterFormat != TextFormat.text)
                {
                    className = className + " prettyprint";
                    if (step.MultilineParameterFormat != TextFormat.code)
                        className = className + " lang-" + Enum.GetName(typeof(TextFormat), step.MultilineParameterFormat);
                }
                WriteTagOpen("div", sb, 9, "mp", true);
                WriteTagOpen("pre", sb, 10, className, true);
                sb.Append(step.MultilineParameter.HtmlEncode());
                WriteTagClose("pre", sb, 10);
                WriteTagClose("div", sb, 0);
            }
        }

        void WriteMultilineParameterWithHtmlPreview(Step step, StringBuilder sb, int stepNumber)
        {
            var html = @"                                    <div class=""mp"">
                                        <ul class=""nav nav-tabs"" role=""tablist"">
                                            <li role=""presentation"" class=""active""><a href=""#preview{0}"" aria-controls=""preview{0}"" role=""tab"" data-toggle=""tab"">Preview</a></li>
                                            <li role=""presentation""><a href=""#code{0}"" aria-controls=""code{0}"" role=""tab"" data-toggle=""tab"">Code</a></li>
                                        </ul>
                                        <div class=""tab-content"">
                                            <div role=""tabpanel"" class=""tab-pane active"" id=""preview{0}"">
                                                <iframe width=""100%"" id=""iframe{0}""></iframe>
                                                <script type=""text/javascript"">
                                                    var iframe{0}doc = document.getElementById('iframe{0}').contentWindow.document;
                                                    iframe{0}doc.open();
                                                    var html{0} = ""{2}"";
                                                    iframe{0}doc.write(html{0});
                                                    resizeIframe(document.getElementById('iframe{0}'));
                                                    iframe{0}doc.close();
                                                </script>
                                            </div>
                                            <div role=""tabpanel"" class=""tab-pane"" id=""code{0}"">
                                                <pre class=""mp prettyprint lang-html"">{1}</pre>
                                            </div>
                                        </div>
                                    </div>";
            sb.AppendLine(String.Format(html,
                stepNumber, 
                step.MultilineParameter.HtmlEncode(), 
                step.MultilineParameter
                .Replace(System.Environment.NewLine, " \\" + System.Environment.NewLine)
                .Replace(":", "\\:")
                .Replace("/", "\\/")
                .Replace("!", "\\!")
                .Replace("\"", "\\\"")));
        }

        void WriteOutput(Step step, StringBuilder sb, int stepNumber)
        {
            WriteTagOpen("div", sb, 9, "output collapse", false, "step-" + stepNumber + "-output", null, " aria-expanded=\"false\"");
            if(step.OutputFormat == TextFormat.htmlpreview)
            {
                WriteOutputWithHtmlPreview(step, sb, stepNumber);
            }
            else
            {
                var className = "text";
                if (step.OutputFormat != TextFormat.text)
                {
                    className = Enum.GetName(typeof(TextFormat), step.OutputFormat) + " prettyprint";
                    if (step.OutputFormat != TextFormat.code)
                        className = className + " lang-" + Enum.GetName(typeof(TextFormat), step.OutputFormat);
                }
                WriteTagOpen("pre", sb, 10, className, true, "output-" + stepNumber);
                sb.Append(step.Output.HtmlEncode());
                WriteTagClose("pre", sb, 0);
            }
            WriteTagClose("div", sb, 0);
        }

        void WriteOutputWithHtmlPreview(Step step, StringBuilder sb, int stepNumber)
        {
            var html = @"                                        <strong><h5>Output</h5></strong>
                                        <ul class=""nav nav-tabs"" role=""tablist"">
                                            <li role=""presentation"" class=""active""><a href=""#output-preview-{0}"" aria-controls=""output-preview-{0}"" role=""tab"" data-toggle=""tab"">Preview</a></li>
                                            <li role=""presentation""><a href=""#output-code-{0}"" aria-controls=""output-code-{0}"" role=""tab"" data-toggle=""tab"">Code</a></li>
                                        </ul>
                                        <div class=""tab-content"">
                                            <div role=""tabpanel"" class=""tab-pane active"" id=""output-preview-{0}"">
                                                <iframe width=""100%"" height=""400px"" id=""iframe{0}""></iframe>
                                                <script type=""text/javascript"">
                                                    var iframe{0}doc = document.getElementById('iframe{0}').contentWindow.document;
                                                    iframe{0}doc.open();
                                                    var html{0} = ""{2}"";
                                                    iframe{0}doc.write(html{0});
                                                    iframe{0}doc.close();
                                                </script>
                                            </div>
                                            <div role=""tabpanel"" class=""tab-pane"" id=""output-code-{0}"">
                                                <pre class=""mp prettyprint lang-html"">{1}</pre>
                                            </div>
                                        </div>";
            sb.AppendLine(String.Format(html,
                stepNumber, 
                step.Output.HtmlEncode(), 
                step.Output
                .Replace(System.Environment.NewLine, " \\"+System.Environment.NewLine)
                .Replace(":", "\\:")
                .Replace("/", "\\/")
                .Replace("!", "\\!")
                .Replace("\"", "\\\"")));
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
