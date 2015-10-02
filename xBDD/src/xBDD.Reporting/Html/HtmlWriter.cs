﻿using System;
using System.Linq;
using System.Text;
using xBDD.Model;

namespace xBDD.Reporting.Html
{
    public class HtmlWriter
    {
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

        private static void WriteStyles(StringBuilder sb)
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
            WriteTagOpener("body", sb, 0, "container-fluid", false);
            var scenarioCount = testRun.Areas.Count;
            var cssClass = "testrun-name";
            if(scenarioCount == 0)
            {
                cssClass = cssClass + " text-muted";
            }
            else
            {
                switch(testRun.Outcome)
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
            WriteTagOpener("div", sb, 1, "page-header", false);
            WriteTag("h1", sb, 2, cssClass, testRun.Name.HtmlEncode(), true);
            WriteTagClose("div", sb, 1);
            if (scenarioCount > 0)
            {
                WriteAreas(testRun, sb);
            }
            WriteTagClose("body", sb, 0);
        }
        void WriteAreas(TestRun testRun, StringBuilder sb)
        {
            WriteTagOpener("ol", sb, 1, "areas list-unstyled", false);
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
            style = "box-shadow: inset 1px 1px 8px 1px "+style+";";
            WriteTagOpener("li", sb, 2, "area", false);
            WriteTag("h2", sb, 3, className, scenario.Feature.Area.Name.Replace('.',' ').HtmlEncode(), true);
            WriteTagOpener("ol", sb, 3, "features list-unstyled", false, null, style);
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
            WriteTagOpener("li", sb, 4, "feature", false, null, style);
            WriteTag("h3", sb, 5, className, scenario.Feature.Name.HtmlEncode(), true);
            WriteTagOpener("ol", sb, 5, "scenarios list-unstyled", false);
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
            WriteTagOpener("li", sb, 6, className, false);
            WriteTagOpener("div", sb, 7, panelClassName, false);
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
            WriteTagOpener("div", sb, 7, "panel-heading", true);
            sb.Append(scenario.Name.HtmlEncode());
            if (scenario.Outcome != Outcome.Passed)
            {
                WriteScenarioStatus(scenario, sb);
            }
            WriteTagClose("div", sb, 0);
        }
        void WriteSteps(Scenario scenario, StringBuilder sb)
        {
            WriteTagOpener("div", sb, 7, "panel-body", false);
            WriteTagOpener("ol", sb, 7, "steps list-unstyled", false);
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
            WriteTagOpener("li", sb, 8, className, false);

            WriteTagOpener("h5", sb, 9, null, true);
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
        void WriteException(Exception exception, StringBuilder sb)
        {
            WriteTagOpener("dl", sb, 9, "exception dl-horizontal", false);
            WriteTag("dt", sb, 10, null, "Error Type", true);
            WriteTag("dd", sb, 10, null, exception.GetType().Name.HtmlEncode(), true);
            WriteTag("dt", sb, 10, null, "Message", true);
            WriteTag("dd", sb, 10, null, "<pre>" + exception.Message.HtmlEncode() + "</pre>", true);
            WriteTag("dt", sb, 10, null, "Stack", true);
            WriteTag("dd", sb, 10, null, "<pre>" + exception.StackTrace.HtmlEncode() + "</pre>", true);
            WriteTagClose("dl", sb, 9);
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
                WriteTagOpener("div", sb, 9, "mp", true);
                WriteTagOpener("pre", sb, 10, className, true);
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
                WriteTagOpener("div", sb, 9, "output", true);
                WriteTagOpener("pre", sb, 10, className, true, "output-" + stepNumber);
                sb.Append(step.Output.HtmlEncode());
                WriteTagClose("pre", sb, 0);
                WriteTagClose("div", sb, 0);
            }
        }

        void WriteOutputWithHtmlPreview(Step step, StringBuilder sb, int stepNumber)
        {
            var html = @"                                    <div class=""output"">
                                        <strong><h5>Output</h5></stong>
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

        void WriteTag(string tag, StringBuilder sb, int indentation, string className, string text, bool inline)
        {
            WriteTagOpener(tag, sb, indentation, className, inline);
            sb.Append(text);
            WriteTagClose(tag, sb, inline?0:indentation);
        }
        void WriteTagOpener(string tag, StringBuilder sb, int indentation, string className, bool inline, string id = null, string style = "")
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
            if (style != null)
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
