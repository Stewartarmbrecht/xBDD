using System;
using System.Linq;
using System.Text;
using xBDD.Model;

namespace xBDD.Reporting.Html
{
    public class HtmlWriter
    {
        int areaCounter = 0;
        int featureCounter = 0;
        int scenarioCounter = 0;
        int stepCounter = 0;
        public string WriteToString(TestRun testRun)
        {
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
            sb.AppendLine("    <link rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css\">");
            sb.AppendLine("    <link rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap-theme.min.css\">");
            WriteStyles(sb);
            sb.AppendLine("    <script src=\"https://code.jquery.com/jquery-2.1.4.min.js\"></script>");
            sb.AppendLine("    <script src=\"https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js\"></script>");
            sb.AppendLine("    <script src=\"https://google-code-prettify.googlecode.com/svn/loader/run_prettify.js?skin=sunburst\"></script>");
            sb.AppendLine("    <script language=\"javascript\" type=\"text/javascript\">function resizeIframe(obj) { obj.style.height = obj.contentWindow.document.body.scrollHeight + 'px'; }</script>");
            sb.AppendLine("</head>");
        }

        private void WriteStyles(StringBuilder sb)
        {
            sb.Append("    <style>");
            sb.Append(" ul.steps, div.output, div.mp, dl.exception { margin-left: 2em }");
            sb.Append(" iframe { border: 1px solid gray; resize: both; overflow: auto; }");
            sb.Append(" li.scenario h4 { margin: .5em; }");
            sb.Append(" ol.features { padding: .5em; }");
            sb.Append(" li.feature { margin: 1.5em; padding: .1em 2em; box-shadow: 1px 1px 8px 1px rgb(202, 202, 202); }");
            sb.Append(" li.scenario .panel { margin: 2em; }");
            sb.AppendLine("</style>");  
        }

        void WriteBody(TestRun testRun, StringBuilder sb)
        {
            WriteTagOpen("body", sb, 0, "container-fluid", false);
            WriteTagOpen("nav", sb, 1, "navbar navbar-default", false, "menu");
            WriteTagOpen("div", sb, 2, "container-fluid", false);
            WriteTagOpen("div", sb, 3, "navbar-header", false);
            WriteTagOpen("button", sb, 4, "navbar-toggle collapsed", false, "menu-button", null, 
                "type=\"button\" data-toggle=\"collapse\" data-target=\"#menu-body\" aria-expanded=\"false\"");
            WriteTag("span", sb, 5, "sr-only", "Toggle Navigation", true);
            WriteTag("span", sb, 5, "icon-bar", null, true);
            WriteTag("span", sb, 5, "icon-bar", null, true);
            WriteTag("span", sb, 5, "icon-bar", null, true);
            WriteTagClose("button", sb, 4);
            WriteTagClose("div", sb, 3);

            WriteTagOpen("div", sb, 3, "collapse navbar-collapse", false, "menu-body");
            WriteTagOpen("ul", sb, 4, "nav navbar-nav", false);
            WriteTagOpen("li", sb, 5, null, false);
            WriteTag("a", sb, 5, null, "Expand All Areas", true, "expand-all-areas-button", null, "href=\"javascript: $('ol.features').collapse('show');\"");
            WriteTagClose("li", sb, 5);
            WriteTagClose("ul", sb, 4);
            WriteTagClose("div", sb, 3);
            WriteTagClose("div", sb, 2);
            WriteTagClose("nav", sb, 1);
            WriteTestRun(testRun, sb);
            WriteTagClose("body", sb, 0);
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
            WriteTagOpen("div", sb, 1, "page-header", false);
            WriteTag("h1", sb, 2, cssClass, testRun.Name.HtmlEncode(), true);
            WriteTagClose("div", sb, 1);
            if (scenarioCount > 0)
            {
                WriteAreas(testRun, sb);
            }
        }

        void WriteAreas(TestRun testRun, StringBuilder sb)
        {
            WriteTagOpen("ol", sb, 1, "areas list-unstyled", false);
            Scenario lastScenario = null;
            foreach (var scenario in testRun.Scenarios.OrderBy(x => x.Feature.Area.Name).ThenBy(x => x.Feature.Name).ThenBy(x => x.Name))
            {
                WriteScenario(lastScenario, scenario, sb);
                lastScenario = scenario;
            }

            WriteFeatureClose(sb);
            WriteAreaClose(sb);
            WriteTagClose("ol", sb, 1);//areas
        }
        void WriteScenario(Scenario lastScenario, Scenario scenario, StringBuilder sb)
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

            var areaTitleAttributes = String.Format("data-toggle=\"collapse\" href=\"#area-{0}-features\" aria-expanded=\"{1}\" aria-controls=\"area-{0}-features\" ", areaCounter, expandedText);
            WriteTag("h2", sb, 3, className, scenario.Feature.Area.Name.Replace('.',' ').HtmlEncode(), true, null, null, areaTitleAttributes);

            var featuresClasName = "features list-unstyled collapse" + (expanded ? " in" : "");
            WriteTagOpen("ol", sb, 3, featuresClasName, false, "area-" + areaCounter + "-features", style, String.Format("aria-expanded=\"{0}\"", expandedText));
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

            var titleAttributes = String.Format("data-toggle=\"collapse\" href=\"#feature-{0}-scenarios\" aria-expanded=\"{1}\" aria-controls=\"feature-{0}-scenarios\" ", featureCounter, expandedText);
            WriteTag("h3", sb, 5, className, scenario.Feature.Name.HtmlEncode(), true, null, null, titleAttributes);

            var scenariosClassName = "scenarios list-unstyled collapse" + (expanded ? " in" : "");
            WriteTagOpen("ol", sb, 5, scenariosClassName, false, "feature-" + areaCounter + "-scenarios", null, String.Format("aria-expanded=\"{0}\"", expandedText));
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
                    panelClassName = panelClassName + " panel-default";
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
            sb.Append(" [");
            sb.Append(Enum.GetName(typeof(Outcome), scenario.Outcome));
            if (scenario.Reason != null && scenario.Reason != "Failed Step")
            {
                sb.Append(" - ");
                sb.Append(scenario.Reason.HtmlEncode());
            }
            sb.Append("]");
        }
        void WriteScenarioTitleLine(Scenario scenario, StringBuilder sb)
        {
            WriteTagOpen("div", sb, 7, "panel-heading", true);
            sb.Append(scenario.Name.HtmlEncode());
            if (scenario.Outcome != Outcome.Passed)
            {
                WriteScenarioStatus(scenario, sb);
            }
            WriteTagClose("div", sb, 0);
        }
        void WriteSteps(Scenario scenario, StringBuilder sb)
        {
            WriteTagOpen("div", sb, 7, "panel-body", false);
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
            sb.Append(step.FullName.HtmlEncode());

            if (step.Scenario.Outcome == Outcome.Failed && step.Outcome != Outcome.Passed)
            {
                sb.Append(" [");
                sb.Append(Enum.GetName(typeof(Outcome), step.Outcome));
                if (step.Reason != null && (step.Outcome != Outcome.Failed || step.Reason == "Not Implemented"))
                {
                    sb.Append(" - ");
                    sb.Append(step.Reason.HtmlEncode());
                }
                sb.Append("]");
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
                .Replace("\r\n", " \\\r\n")
                .Replace(":", "\\:")
                .Replace("/", "\\/")
                .Replace("!", "\\!")
                .Replace("\"", "\\\"")));
        }

        void WriteOutput(Step step, StringBuilder sb, int stepNumber)
        {
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
                WriteTagOpen("div", sb, 9, "output", true);
                WriteTagOpen("pre", sb, 10, className, true, "output-" + stepNumber);
                sb.Append(step.Output.HtmlEncode());
                WriteTagClose("pre", sb, 0);
                WriteTagClose("div", sb, 0);
            }
        }

        void WriteOutputWithHtmlPreview(Step step, StringBuilder sb, int stepNumber)
        {
            var html = @"                                    <div class=""output"">
                                        <strong><h5>Output</h5></strong>
                                        <ul class=""nav nav-tabs"" role=""tablist"">
                                            <li role=""presentation"" class=""active""><a href=""#output-preview-{0}"" aria-controls=""output-preview-{0}"" role=""tab"" data-toggle=""tab"">Preview</a></li>
                                            <li role=""presentation""><a href=""#output-code-{0}"" aria-controls=""output-code-{0}"" role=""tab"" data-toggle=""tab"">Code</a></li>
                                        </ul>
                                        <div class=""tab-content"">
                                            <div role=""tabpanel"" class=""tab-pane active"" id=""output-preview-{0}"">
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
                                            <div role=""tabpanel"" class=""tab-pane"" id=""output-code-{0}"">
                                                <pre class=""mp prettyprint lang-html"">{1}</pre>
                                            </div>
                                        </div>
                                    </div>";
            sb.AppendLine(String.Format(html,
                stepNumber, 
                step.Output.HtmlEncode(), 
                step.Output
                .Replace("\r\n", " \\\r\n")
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
