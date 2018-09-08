using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using xBDD.Model;
using xBDD.Utility;

namespace xBDD.Reporting.Html
{
    /// <summary>
    /// Writes the results of a test run to an HTML represenation.
    /// </summary>
    public class HtmlTestRunReportWriter
    {
        int areaCounter = 0;
        int featureCounter = 0;
        int scenarioCounter = 0;
        int stepCounter = 0;
        string areaNameSkip = "";
        bool failuresOnly = false;
		HtmlWriter hW = new HtmlWriter();
        internal HtmlTestRunReportWriter(string areaNameSkip, bool failuresOnly) {
            this.areaNameSkip = areaNameSkip;
            this.failuresOnly = failuresOnly;
        }

        /// <summary>
        /// Writes the results of a test run to an HTML represenation.
        /// </summary>
        /// <param name="testRun">The test run to write to HTML.</param>
        /// <returns>The HTML string representation of the test run results.</returns>
        public string WriteToHtmlTestRunReport(TestRun testRun) {
            testRun.CalculateStartAndEndTimes();
            StringBuilder sb = new StringBuilder();
            
			hW.WriteHeaderStart(testRun.Name, sb);
            hW.WriteStyles(sb);
            hW.WriteHeaderEnd(sb);
			hW.WriteBodyStart(sb);
            hW.WriteNavBarStart(sb, this.failuresOnly);
            WriteNavBarOptions(sb);
            hW.WriteNavBarEnd(sb);
			Dictionary<string, OutcomeStats> statistics = new Dictionary<string, OutcomeStats>();
			statistics.Add("Areas", testRun.AreaStats);
			statistics.Add("Features", testRun.FeatureStats);
			statistics.Add("Scenarios", testRun.ScenarioStats);
			hW.WriteBanner(sb, testRun.ScenarioStats.Total, testRun.Outcome, testRun.Reason, testRun.Name, "Areas", testRun.StartTime, testRun.EndTime, statistics);
			WriteAreas(testRun, sb);
			hW.WriteBodyEnd(sb);
            hW.WriteHtmlEnd(sb);
            return sb.ToString();
        }
        private void WriteNavBarOptions(StringBuilder sb) {
            var html = $@"
	                            <a class=""nav-item nav-link active"" href=""javascript: $('ol.features').collapse('show');"" id=""expand-all-areas-button"">Expand All Areas <span class=""sr-only"">(current)</span></a>".RemoveIndentation(4, true);

            sb.Append(html);
        }
        void WriteAreas(TestRun testRun, StringBuilder sb) {
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
                        hW.WriteTagOpen("ol", sb, 1, "areas list-unstyled", false);
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
                hW.WriteLineItemClose(sb);
                hW.WriteTagClose("ol", sb, 1);//areas
            }
        }
        void WriteAreaFeatureAndScenario(Scenario lastScenario, Scenario scenario, StringBuilder sb) {
            if (lastScenario == null || (lastScenario != null && lastScenario.Feature.Area.Name != scenario.Feature.Area.Name))
            {
                if (lastScenario != null)
                {
                    WriteFeatureClose(sb);
                    hW.WriteLineItemClose(sb);
                }
				this.areaCounter++;
				var name = scenario.Feature.Area.Name;
				if(this.areaNameSkip != null && this.areaNameSkip.Length > 0) {
					name = name.Replace(this.areaNameSkip, "");
				}
				var area = scenario.Feature.Area;
				var areaStatistics = new Dictionary<string, OutcomeStats>();
				areaStatistics.Add("Features", area.FeatureStats);
				areaStatistics.Add("Scenarios", area.ScenarioStats);

                hW.WriteLineItemOpen(
					sb, 
					"Area", 
					this.areaCounter, 
					name, 
					null,
					area.Outcome, 
					area.Reason, 
					area.StartTime,
					area.EndTime,
					area.ScenarioStats.Total,
					"Features",
					area.FeatureStats,
					areaStatistics,
					this.failuresOnly);

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

        private void WriteScenario(Scenario scenario, StringBuilder sb) {
            WriteScenarioOpen(scenario, sb);
            //WriteScenarioTitleLine(scenario, sb);
            if (scenario.Steps.Count > 0)
            {
                WriteSteps(scenario, sb);
            }
            WriteScenarioClose(sb);
        }

        void WriteFeatureOpen(Scenario scenario, StringBuilder sb) {
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

            hW.WriteTagOpen("li", sb, 4, "feature", false, "feature-" + featureCounter);

            var titleAttributes = $" data-toggle=\"collapse\" href=\"#feature-{featureCounter}-scenarios\" aria-expanded=\"{expandedText}\" aria-controls=\"feature-{featureCounter}-scenarios\" ";
            var badgeAttributes = $" data-toggle=\"collapse\" href=\"#feature-{featureCounter}-stats\" aria-expanded=\"false\" aria-controls=\"feature-{featureCounter}-stats\" ";
            hW.WriteTagOpen("h3", sb, 5, null, true, "vertical-align: top !important;", null, null);

            hW.WriteBadge("feature", "Scenarios", featureCounter, scenario.Feature.ScenarioStats, scenario.Feature.ScenarioStats.Total, sb, badgeAttributes, badgeClassName);

            //hW.WriteTag("span", sb, 6, $"feature badge pointer total {badgeClassName}", scenario.Feature.ScenarioStats.Total.ToString(), true, null, null, $"{badgeAttributes} title=\"Scenarios\"");
            if (scenario.Feature.Actor != null || scenario.Feature.Value != null || scenario.Feature.Capability != null)
            {
                sb.Append($"<span class=\"feature-statement-link badge pointer badge-secondary\" id=\"feature-{featureCounter}-statement-link\" data-toggle=\"collapse\" href=\"#feature-{featureCounter}-statement\" aria-expanded=\"false\" aria-controls=\"feature-{featureCounter}-statement\"><span class=\"oi oi-info\" aria-hidden=\"true\"></span></span>");
            }
            hW.WriteTag("span", sb, 6, "name pointer", scenario.Feature.Name.HtmlEncode(), false, true, null, null, titleAttributes);

            if(scenario.Feature.Reason != null) {
                hW.WriteTag("span", sb, 6, "feature reason", $" [{scenario.Feature.Reason.HtmlEncode()}]", false, true);
            }

            var duration = scenario.Feature.EndTime - scenario.Feature.StartTime;
            var formattedDuration = duration.TotalMilliseconds.ToString("N", System.Globalization.CultureInfo.InvariantCulture);
            formattedDuration = formattedDuration.Substring(0, formattedDuration.Length-3);
            hW.WriteTag("span", sb, 6, "feature duration", $" [{formattedDuration} ms]",false, true);

            hW.WriteTagClose("h3", sb, 5);

            hW.WriteStatsTableStart(sb, 5, "feature-"+featureCounter+"-stats");
            hW.WriteStats(sb, scenario.Feature.ScenarioStats, 5, "feature-"+featureCounter+"-scenario-stats", "Scenarios");
            hW.WriteStatsTableClose(sb, 5);
            
            WriteFeatureStatement(scenario, sb, featureCounter);

            var scenariosClassName = "scenarios list-unstyled collapse" + (expanded ? " show" : "");
            hW.WriteTagOpen("ol", sb, 5, scenariosClassName, false, "feature-" + featureCounter + "-scenarios", borderStyle, $" aria-expanded=\"{expandedText}\"");
        }
        void WriteFeatureStatement(Scenario scenario, StringBuilder sb, int featureNumber) {
            if(scenario.Feature.Actor != null || scenario.Feature.Value != null || scenario.Feature.Capability != null)
            {
                hW.WriteTagOpen("div", sb, 5, "output collapse", false, "feature-" + featureNumber + "-statement", null, " aria-expanded=\"false\"");
                var statement = $"As a {scenario.Feature.Actor??"[Missing!]"}{System.Environment.NewLine}You can {scenario.Feature.Value??"[Missing!]"}{System.Environment.NewLine}By {scenario.Feature.Capability??"[Missing!]"}";
                hW.WriteTag("pre", sb, 6, "feature-statement bg-light rounded", statement, false, true, $"feature-{featureCounter}-statement");
                hW.WriteTagClose("div", sb, 0);
            }
        }
        void WriteFeatureClose(StringBuilder sb) {
            hW.WriteTagClose("ol", sb, 5);
            hW.WriteTagClose("li", sb, 4);
        }
        void WriteScenarioOpen(Scenario scenario, StringBuilder sb) {
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
            hW.WriteTagOpen("li", sb, 6, className, false, "scenario-" + scenarioCounter);

            var expanded = scenario.Outcome == Outcome.Failed && this.failuresOnly;
            var expandedText = expanded ? "true" : "false";

            var titleAttributes = $" data-toggle=\"collapse\" href=\"#scenario-{scenarioCounter}-steps\" aria-expanded=\"{expandedText}\" aria-controls=\"scenario-{scenarioCounter}-steps\" ";
            hW.WriteTagOpen("h4", sb, 7, "panel-heading", true, null, null, titleAttributes);

            hW.WriteTag("span", sb, 8, $"scenario badge pointer total {badgeClassName}", scenario.StepStats.Total.ToString(), false, true, null, null, " title=\"Steps\"");

            hW.WriteTag("span", sb, 8, "name pointer", scenario.Name.HtmlEncode(), false, true);

            if(scenario.Reason != null) {
                hW.WriteTag("span", sb, 8, "scenario reason", $" [{scenario.Reason.HtmlEncode()}]", false, true);
            }
            
            var duration = scenario.EndTime - scenario.StartTime;
            var formattedDuration = duration.TotalMilliseconds.ToString("N", System.Globalization.CultureInfo.InvariantCulture);
            formattedDuration = formattedDuration.Substring(0, formattedDuration.Length-3);
            hW.WriteTag("span", sb, 8, "scenario duration", $" [{formattedDuration} ms]", false, true);

            hW.WriteTagClose("h4", sb, 7);

            var stepsClassName = "steps list-unstyled collapse" + (expanded ? " show" : "");
            hW.WriteTagOpen("ol", sb, 7, stepsClassName, false, "scenario-" + scenarioCounter + "-steps", null, String.Format(" aria-expanded=\"{0}\"", expandedText));
        }
        void WriteScenarioClose(StringBuilder sb) {
            hW.WriteTagClose("ol", sb, 7);
            hW.WriteTagClose("li", sb, 6);
        }
        void WriteScenarioStatus(Scenario scenario, StringBuilder sb) {
            hW.WriteTagOpen("span",sb, 0, "status", true);
            sb.Append("[");
            sb.Append(Enum.GetName(typeof(Outcome), scenario.Outcome));
            if (scenario.Reason != null && scenario.Reason != "Failed Step")
            {
                sb.Append(" - ");
                sb.Append(scenario.Reason.HtmlEncode());
            }
            sb.Append("]");
            hW.WriteTagClose("span", sb, 0);
        }
        void WriteSteps(Scenario scenario, StringBuilder sb) {
            var expanded = scenario.Outcome == Outcome.Failed && failuresOnly;
            var expandedText = expanded ? "true" : "false";

            var stepsClassName = "steps list-unstyled collapse" + (expanded ? " in" : "");
            foreach(Step step in scenario.Steps)
            {
                stepCounter++;
                WriteStep(step, sb, stepCounter);
            }
        }
        void WriteStep(Step step, StringBuilder sb, int stepNumber) {
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
            hW.WriteTagOpen("li", sb, 8, null, false, "step-" + stepNumber);

            hW.WriteTagOpen("h5", sb, 9, null, true);
            hW.WriteTag("span", sb, 10, $"step badge pointer total badge-pill {badgeClassName}", " ", false, true, $"step-{stepNumber}-badge");
            hW.WriteTag("span", sb, 10, "name", step.FullName.HtmlEncode(), false, true);
            
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
                    hW.WriteTagOpen("span", sb, 10, "status", true);
                    sb.Append(" [");
                    sb.Append(Enum.GetName(typeof(Outcome), step.Outcome));
                    if (step.Reason != null && (step.Outcome != Outcome.Failed || step.Reason == "Not Implemented"))
                    {
                        sb.Append(" - ");
                        sb.Append(step.Reason.HtmlEncode());
                    }
                    sb.Append("]");
                }
                hW.WriteTagClose("span", sb, 0);
            }

            var duration = step.EndTime - step.StartTime;
            var formattedDuration = duration.TotalMilliseconds.ToString("N", System.Globalization.CultureInfo.InvariantCulture);
            formattedDuration = formattedDuration.Substring(0, formattedDuration.Length-3);
            hW.WriteTag("span", sb, 0, "step duration", $" [{formattedDuration} ms]", false, true);
            hW.WriteTagClose("h5", sb, 0);
            if (!String.IsNullOrEmpty(step.Input))
            {
                WriteInputParameter(step, sb, stepNumber);
            }
            if (step.Exception != null && step.Outcome != Outcome.Skipped)
                WriteException(step.Exception, sb, 0, stepNumber);

            if (!String.IsNullOrEmpty(step.Output))
            {
                WriteOutput(step, sb, stepNumber);
            }
            hW.WriteTagClose("li", sb, 8);
        }
        void WriteException(Exception exception, StringBuilder sb, int level, int stepNumber, bool innerException = false) {
            if(!innerException)
            {
                hW.WriteTagOpen("div", sb, 9, "error collapse", false, "step-" + stepNumber + "-error", null, " aria-expanded=\"false\"");
            }
            hW.WriteTagOpen("dl", sb, 9 + level, "exception dl-horizontal border border-danger rounded", false);
            hW.WriteTag("dt", sb, 10 + level, null, "Error Type", false, true);
            hW.WriteTag("dd", sb, 10 + level, "error-type", exception.GetType().Name.HtmlEncode(), false, true);
            hW.WriteTag("dt", sb, 10 + level, null, "Message", false, true);
            hW.WriteTag("dd", sb, 10 + level, "error-message bg-light", "<pre><code>" + exception.Message.HtmlEncode() + "</code></pre>", false, true);
            hW.WriteTag("dt", sb, 10 + level, null, "Stack", false, true);
            hW.WriteTag("dd", sb, 10 + level, "error-stack bg-light", "<pre><code>" + exception.StackTrace.HtmlEncode() + "</code></pre>", false, true);
            if(exception.InnerException != null)
            {
                hW.WriteTag("dt", sb, 10 + level, null, "Inner Exception", false, true);
                hW.WriteTagOpen("dd", sb, 10 + level, "inner-exception", true);
                WriteException(exception.InnerException, sb,  level++, stepNumber, true);
                hW.WriteTagClose("dd", sb, 10 + level);
            }
            hW.WriteTagClose("dl", sb, 9 + level);
            if(!innerException)
            {
                hW.WriteTagClose("div", sb, 0);
            }
        }
        void WriteInputParameter(Step step, StringBuilder sb, int stepNumber) {
            hW.WriteTagOpen("div", sb, 9, "input collapse", false, "step-" + stepNumber + "-input", null, " aria-expanded=\"false\"");
            hW.WriteTag("div", sb, 10, "input title", "Input", false, false, "step-" + stepNumber + "-input-title");
            if(step.InputFormat == TextFormat.htmlpreview)
            {
                WriteInputParameterWithHtmlPreview(step, sb, stepNumber);
            }
            else
            {
                var className = "input prettyprint linenums rounded";
                if (step.InputFormat != TextFormat.code)
                    className = className + " lang-" + Enum.GetName(typeof(TextFormat), step.InputFormat);
                hW.WriteTagOpen("pre", sb, 10, className, true, $"input-{stepNumber}");
                sb.Append(step.Input.HtmlEncode());
                hW.WriteTagClose("pre", sb, 0);
            }
            hW.WriteTagClose("div", sb, 0);
        }

        void WriteInputParameterWithHtmlPreview(Step step, StringBuilder sb, int stepNumber) {
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

        void WriteOutput(Step step, StringBuilder sb, int stepNumber) {
            hW.WriteTagOpen("div", sb, 9, "output collapse", false, "step-" + stepNumber + "-output", null, " aria-expanded=\"false\"");
            hW.WriteTag("div", sb, 10, "output title", "Output", false, false, "step-" + stepNumber + "-output-title");

            if(step.OutputFormat == TextFormat.htmlpreview)
            {
                WriteOutputWithHtmlPreview(step, sb, stepNumber);
            }
            else
            {
                var className = "output prettyprint linenums rounded";
                if (step.OutputFormat != TextFormat.code)
                    className = className + " lang-" + Enum.GetName(typeof(TextFormat), step.OutputFormat);
                hW.WriteTagOpen("pre", sb, 10, className, true, "output-" + stepNumber);
                sb.Append(step.Output.HtmlEncode());
                hW.WriteTagClose("pre", sb, 0);
            }
            hW.WriteTagClose("div", sb, 0);
        }

        void WriteOutputWithHtmlPreview(Step step, StringBuilder sb, int stepNumber) {
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

    }
}
