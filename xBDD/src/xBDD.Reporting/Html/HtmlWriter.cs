using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace xBDD.Reporting.Html
{
    public class HtmlWriter
    {
        public string WriteToText(TestRun testRun)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html>");
            WriteHtml(testRun, sb);
            return sb.ToString();
        }
        private static void WriteHtml(TestRun testRun, StringBuilder sb)
        {
            sb.AppendLine("<html>");
            WriteHeader(testRun, sb);
            WriteBody(testRun, sb);
            sb.Append("</html>");
        }
        private static void WriteHeader(TestRun testRun, StringBuilder sb)
        {
            sb.AppendLine("<head>");
            sb.AppendLine("    <meta charset=\"utf-8\" />");
            WriteTag("title", sb, 1, null, testRun.Name, true);
            sb.AppendLine("    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">");
            sb.AppendLine("    <link rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css\">");
            sb.AppendLine("    <link rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap-theme.min.css\">");
            sb.AppendLine("    <script src=\"https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js\"></script>");
            sb.AppendLine("    <script src=\"https://google-code-prettify.googlecode.com/svn/loader/run_prettify.js?skin=sunburst\"></script>");
            sb.AppendLine("    <style>.mp { margin-left: 2em }</style>");
            sb.AppendLine("</head>");
        }
        private static void WriteBody(TestRun testRun, StringBuilder sb)
        {
            WriteTagOpener("body", sb, 0, "container-fluid", false);
            WriteTag("h1", sb, 1, "testrun-name", testRun.Name, true);
            if (testRun.Scenarios.Count > 0)
            {
                WriteAreas(testRun, sb);
            }
            WriteTagClose("body", sb, 0);
        }
        private static void WriteAreas(TestRun testRun, StringBuilder sb)
        {
            WriteTagOpener("ol", sb, 1, "areas", false);
            Scenario lastScenario = null;
            foreach (var scenario in testRun.Scenarios.OrderBy(x => x.AreaPath).ThenBy(x => x.FeatureName).ThenBy(x => x.Name))
            {
                WriteScenario(lastScenario, scenario, sb);
                lastScenario = scenario;
            }

            WriteFeatureClose(sb);
            WriteAreaClose(sb);
            WriteTagClose("ol", sb, 1);//areas
        }
        private static void WriteScenario(Scenario lastScenario, Scenario scenario, StringBuilder sb)
        {
            if (lastScenario == null || (lastScenario != null && lastScenario.AreaPath != scenario.AreaPath))
            {
                if (lastScenario != null)
                {
                    WriteFeatureClose(sb);
                    WriteAreaClose(sb);
                }
                WriteAreaOpen(scenario, sb);
                WriteFeatureOpen(scenario, sb);
            }
            else if (lastScenario == null || (lastScenario != null && lastScenario.FeatureName != scenario.FeatureName))
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
        private static void WriteAreaOpen(Scenario scenario, StringBuilder sb)
        {
            WriteTagOpener("li", sb, 2, "area", false);
            WriteTag("h2", sb, 3, null, scenario.AreaPath, true);
            WriteTagOpener("ol", sb, 3, "features", false);
        }
        private static void WriteAreaClose(StringBuilder sb)
        {
            WriteTagClose("ol", sb, 3);
            WriteTagClose("li", sb, 2);
        }
        private static void WriteFeatureOpen(Scenario scenario, StringBuilder sb)
        {
            WriteTagOpener("li", sb, 4, "feature", false);
            WriteTag("h3", sb, 5, null, scenario.FeatureName, true);
            WriteTagOpener("ol", sb, 5, "scenarios", false);
        }
        private static void WriteFeatureClose(StringBuilder sb)
        {
            WriteTagClose("ol", sb, 5);
            WriteTagClose("li", sb, 4);
        }
        private static void WriteScenarioOpen(Scenario scenario, StringBuilder sb)
        {
            var className = "scenario " + Enum.GetName(typeof(Outcome), scenario.Outcome).ToLower();
            switch (scenario.Outcome)
            {
                case Outcome.NotRun:
                    break;
                case Outcome.Passed:
                    className = className + " bg-success";
                    break;
                case Outcome.Failed:
                    className = className + " bg-danger";
                    break;
                case Outcome.Skipped:
                    className = className + " bg-warning";
                    break;
                default:
                    break;
            }
            WriteTagOpener("li", sb, 6, className, false);
        }
        private static void WriteScenarioClose(StringBuilder sb)
        {
            WriteTagClose("li", sb, 6);
        }
        private static void WriteScenarioStatus(Scenario scenario, StringBuilder sb)
        {
            sb.Append(" [");
            sb.Append(Enum.GetName(typeof(Outcome), scenario.Outcome));
            if (scenario.Reason != null && scenario.Reason != "Failed Step")
            {
                sb.Append(" - ");
                sb.Append(scenario.Reason);
            }
            sb.Append("]");
        }
        private static void WriteScenarioTitleLine(Scenario scenario, StringBuilder sb)
        {
            string className = null;
            switch (scenario.Outcome)
            {
                case Outcome.NotRun:
                    className = "text-info";
                    break;
                case Outcome.Passed:
                    className = "text-success";
                    break;
                case Outcome.Failed:
                    className = "text-danger";
                    break;
                case Outcome.Skipped:
                    className = "text-warning";
                    break;
                default:
                    break;
            }
            WriteTagOpener("h4", sb, 7, className, true);
            sb.Append(scenario.Name);
            if (scenario.Outcome != Outcome.Passed)
            {
                WriteScenarioStatus(scenario, sb);
            }
            WriteTagClose("h4", sb, 0);
        }
        private static void WriteSteps(Scenario scenario, StringBuilder sb)
        {
            WriteTagOpener("ul", sb, 7, "steps list-unstyled", false);
            foreach (var step in scenario.Steps)
            {
                WriteStep(step, sb);
            }
            WriteTagClose("ul", sb, 7);
        }
        private static void WriteStep(Step step, StringBuilder sb)
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
            sb.Append(step.FullName);

            if (step.Scenario.Outcome == Outcome.Failed && step.Outcome != Outcome.Passed)
            {
                sb.Append(" [");
                sb.Append(Enum.GetName(typeof(Outcome), step.Outcome));
                if (step.Reason != null && (step.Outcome != Outcome.Failed || step.Reason == "Not Implemented"))
                {
                    sb.Append(" - ");
                    sb.Append(step.Reason);
                }
                sb.Append("]");
            }

            WriteTagClose("h5", sb, 0);
            if (!String.IsNullOrEmpty(step.MultilineParameter))
            {
                WriteMultilineParameter(step, sb);
            }
            if (step.Exception != null && !(step.Exception is NotImplementedException) && step.Outcome != Outcome.Skipped)
                WriteException(step.Exception, sb);

            WriteTagClose("li", sb, 8);
        }
        private static void WriteException(Exception exception, StringBuilder sb)
        {
            WriteTagOpener("dl", sb, 9, "exception dl-horizontal", false);
            WriteTag("dt", sb, 10, null, "Error Type", true);
            WriteTag("dd", sb, 10, null, exception.GetType().Name, true);
            WriteTag("dt", sb, 10, null, "Message", true);
            WriteTag("dd", sb, 10, null, exception.Message, true);
            WriteTag("dt", sb, 10, null, "Stack", true);
            WriteTag("dd", sb, 10, null, "<pre>" + exception.StackTrace.HtmlEncode() + "</pre>", true);
            WriteTagClose("dl", sb, 9);
        }
        private static void WriteMultilineParameter(Step step, StringBuilder sb)
        {
            var className = "mp";
            if(step.MultilineParameterFormat != MultilineParameterFormat.literal)
            {
                className = className + " prettyprint";
                if (step.MultilineParameterFormat != MultilineParameterFormat.code)
                    className = className + " lang-" + Enum.GetName(typeof(MultilineParameterFormat), step.MultilineParameterFormat);
            }
            WriteTagOpener("pre", sb, 9, className, true);
            sb.Append(step.MultilineParameter.HtmlEncode());
            WriteTagClose("pre", sb, 0);
        }
        private static void WriteTag(string tag, StringBuilder sb, int indentation, string className, string text, bool inline)
        {
            WriteTagOpener(tag, sb, indentation, className, inline);
            sb.Append(text);
            WriteTagClose(tag, sb, inline?0:indentation);
        }
        private static void WriteTagOpener(string tag, StringBuilder sb, int indentation, string className, bool inline)
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
            if (inline)
                sb.Append(">");
            else
                sb.AppendLine(">");
        }
        private static void WriteTagClose(string tag, StringBuilder sb, int indentation)
        {
            WriteIndentation(sb, indentation);
            sb.Append("</");
            sb.Append(tag);
            sb.AppendLine(">");
        }
        private static void WriteIndentation(StringBuilder sb, int indentation)
        {
            for (int i = 0; i < indentation; i++)
            {
                sb.Append("    ");
            }
        }

    }
}
