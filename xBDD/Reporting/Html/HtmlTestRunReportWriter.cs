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
		TestRunReportConfiguration config;
		List<ReportReasonConfiguration> sortedReasonConfigurations;
		HtmlWriter hW;
        internal HtmlTestRunReportWriter(TestRunReportConfiguration config, List<ReportReasonConfiguration> sortedReasonConfigurations) {
			this.config = config;
			this.sortedReasonConfigurations = sortedReasonConfigurations;
			this.hW = new HtmlWriter(this.sortedReasonConfigurations);
        }

        /// <summary>
        /// Writes the results of a test run to an HTML represenation.
        /// </summary>
        /// <param name="testRun">The test run to write to HTML.</param>
        /// <returns>The HTML string representation of the test run results.</returns>
        public string WriteToHtmlTestRunReport(TestRun testRun) 
		{
            testRun.CalculateStartAndEndTimes();
            StringBuilder sb = new StringBuilder();
            
			hW.WriteHeader(sb, this.config);
			hW.WriteBodyStart(sb);
            hW.WriteNavBarStart(sb, this.config.FailuresOnly);
            WriteNavBarOptions(sb);
            hW.WriteNavBarEnd(sb);
			Dictionary<string, OutcomeStats> testRunStatistics = new Dictionary<string, OutcomeStats>();
			testRunStatistics.Add("Areas", testRun.AreaStats);
			testRunStatistics.Add("Features", testRun.FeatureStats);
			testRunStatistics.Add("Scenarios", testRun.ScenarioStats);
			Dictionary<string, Dictionary<string,int>> testRunReasonStatistics = new Dictionary<string, Dictionary<string, int>>();
			testRunReasonStatistics.Add("Areas", testRun.AreaReasonStats);
			testRunReasonStatistics.Add("Features", testRun.FeatureReasonStats);
			testRunReasonStatistics.Add("Scenarios", testRun.ScenarioReasonStats);
			hW.WriteBanner(sb, "testrun", this.config.ReportName, testRun.Outcome, testRun.Reason, testRun.StartTime, testRun.EndTime, testRunStatistics, testRunReasonStatistics);
			WriteAreas(sb, testRun);
			hW.WriteBodyEnd(sb);
            hW.WriteHtmlEnd(sb);
            return sb.ToString();
        }
        private void WriteNavBarOptions(StringBuilder sb) {
            var html = $@"
	                            <a class=""nav-item nav-link active"" href=""javascript: $('ol.features').collapse('show');"" id=""expand-all-areas-button"">Expand All Areas <span class=""sr-only"">(current)</span></a>".RemoveIndentation(4, true);

            sb.Append(html);
        }
        void WriteAreas(StringBuilder sb, TestRun testRun) {
            var areasOpenWritten = false;
            var scenarioWritten = false;
            Scenario lastScenario = null;
            var sortedScenarios = testRun.Scenarios.OrderBy(x => x.Feature.Area.Name).ThenBy(x => x.Feature.Name).ThenBy(x => x.Name);
            if(testRun.Sorted)
                sortedScenarios = testRun.Scenarios.OrderBy(x => x.Feature.Sort).ThenBy(x => x.Sort);
            foreach (var scenario in sortedScenarios)
            {
                if(!this.config.FailuresOnly || this.config.FailuresOnly && scenario.Outcome == Outcome.Failed)
                {
                    if(!areasOpenWritten) {
						WriteAreasListOpen(sb);
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
                WriteAreasListClose(sb);
            }
        }

		void WriteAreasListOpen(StringBuilder sb) {
            hW.WriteTagOpen("ol", sb, 1, "areas list-unstyled", false);
		}
		void WriteAreasListClose(StringBuilder sb) {
			hW.WriteTagClose("ol", sb, 1);//areas
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
				if(this.config.AreaNameSkip != null && this.config.AreaNameSkip.Length > 0) {
					name = name.Replace(this.config.AreaNameSkip, "");
				}
				var area = scenario.Feature.Area;
				var areaStatistics = new Dictionary<string, OutcomeStats>();
				areaStatistics.Add("Features", area.FeatureStats);
				areaStatistics.Add("Scenarios", area.ScenarioStats);

				var areaReasonStatistics = new Dictionary<string, Dictionary<string, int>>();
				areaReasonStatistics.Add("Features", area.FeatureReasonStats);
				areaReasonStatistics.Add("Scenarios", area.ScenarioReasonStats);

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
					areaReasonStatistics,
					this.config.FailuresOnly);

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
            featureCounter++;

            var expanded = scenario.Feature.Outcome == Outcome.Failed && this.config.FailuresOnly;
            var display = expanded ? "block" : "none";

            hW.WriteTagOpen("li", sb, 4, "feature", false, $"feature-{featureCounter}");

            hW.WriteTagOpen("h3", sb, 5, "title", true, "vertical-align: top !important;", null, null);

            hW.WriteBadge(sb, "feature", featureCounter, scenario.Feature.Outcome, scenario.Feature.Reason, scenario.Feature.ScenarioReasonStats, true);

            hW.WriteTag("span", sb, 6, "feature name pointer", scenario.Feature.Name.HtmlEncode(), false, true, null, null, null, $"feature-{featureCounter}-scenarios");

			WriteFeatureStatementLink(sb, scenario);

            hW.WriteReason(sb, "feature", scenario.Feature.Reason);

			hW.WriteDuration(sb, scenario.Feature.EndTime, scenario.Feature.StartTime, "feature");

            hW.WriteTagClose("h3", sb, 5);

			var scenarioStatsDictionary = new Dictionary<string, OutcomeStats>();
			scenarioStatsDictionary.Add("Scenarios", scenario.Feature.ScenarioStats);

			var reasonStatsDictionary = new Dictionary<string, Dictionary<string, int>>();
			reasonStatsDictionary.Add("Scenarios", scenario.Feature.ScenarioReasonStats);

			hW.WriteStats(sb, "feature", featureCounter, 5, scenarioStatsDictionary, reasonStatsDictionary);

            WriteFeatureStatement(scenario, sb, featureCounter);

			var scenariosListClassName = $"scenarios list-unstyled collapse{(expanded ? " show" : "")}";
			var scenariosListStyle = $"border-left: 2px solid lightgray; display: {display};";
			var scenariosListId = $"feature-{featureCounter}-scenarios";
            hW.WriteTagOpen("ol", sb, 5, scenariosListClassName, false, scenariosListId, scenariosListStyle);
        }

		void WriteFeatureStatementLink(StringBuilder sb, Scenario scenario){
            if (scenario.Feature.Actor != null || scenario.Feature.Value != null || scenario.Feature.Capability != null)
            {
                sb.Append($"<span class=\"feature-statement-link badge pointer badge-secondary\" id=\"feature-{featureCounter}-statement-link\" onclick=\"toggleVisibilit('feature-{featureCounter}-statement')\"><span class=\"oi oi-info\" aria-hidden=\"true\"></span></span>");
            }
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
            scenarioCounter++;

            var className = "scenario " + Enum.GetName(typeof(Outcome), scenario.Outcome).ToLower();
            hW.WriteTagOpen("li", sb, 6, className, false, "scenario-" + scenarioCounter);

            hW.WriteTagOpen("h4", sb, 7, "panel-heading", true, null, null, null, $"scenario-{scenarioCounter}-steps");

			var scenarioBadgeClass = $"scenario badge pointer total {Enum.GetName(typeof(Outcome), scenario.Outcome)}";
			var scenarioStepsId = $"scenario-{scenarioCounter}-steps";
            hW.WriteTag("span", sb, 8, scenarioBadgeClass, scenario.StepStats.Total.ToString(), false, true, null, null, " title=\"Steps\"", scenarioStepsId);

            hW.WriteTag("span", sb, 8, "scenario name pointer", scenario.Name.HtmlEncode(), false, true);

            hW.WriteReason(sb, "scenario", scenario.Reason);
			hW.WriteDuration(sb, scenario.EndTime, scenario.StartTime, "scenario");
            
            hW.WriteTagClose("h4", sb, 7);

            var stepsClassName = "steps list-unstyled";
            var expanded = scenario.Outcome == Outcome.Failed && this.config.FailuresOnly;
            var display = expanded ? "block" : "none";
            hW.WriteTagOpen("ol", sb, 7, stepsClassName, false, scenarioStepsId, $"display: {display};");
        }
        void WriteScenarioClose(StringBuilder sb) {
            hW.WriteTagClose("ol", sb, 7);
            hW.WriteTagClose("li", sb, 6);
        }
        void WriteSteps(Scenario scenario, StringBuilder sb) {
            var expanded = scenario.Outcome == Outcome.Failed && this.config.FailuresOnly;
            var expandedText = expanded ? "true" : "false";

            foreach(Step step in scenario.Steps)
            {
                stepCounter++;
                WriteStep(step, sb, stepCounter);
            }
        }
        void WriteStep(Step step, StringBuilder sb, int stepNumber) {

            hW.WriteTagOpen("li", sb, 8, "container", false, $"step-{stepNumber}");

			WriteStepTitleLine(sb, step, stepNumber);

			WriteInputParameter(sb, step, stepNumber);

			WriteException(step.Exception, step.Outcome, sb, 0, stepNumber);

			WriteOutput(sb, step, stepNumber);
			
            hW.WriteTagClose("li", sb, 8);
        }

		void WriteStepTitleLine(StringBuilder sb, Step step, int stepNumber) {
            
			hW.WriteTagOpen("h5", sb, 9, "title row", true);
            
			WriteStepBadge(sb, step, stepNumber); //col-1
            
			WriteStepName(sb, step); //col-7 (8)

			WriteStepInputLink(sb, step, stepNumber); //col-1 (9)

			WriteStepOutputLink(sb, step, stepNumber); //col-1 (10)

			WriteStepStatus(sb, step, stepNumber); //col-1 (11)

			hW.WriteDuration(sb, step.EndTime, step.StartTime, "step"); //col-1 (12)

            hW.WriteTagClose("h5", sb, 0);
		}

		void WriteStepName(StringBuilder sb, Step step) {
			hW.WriteTag("span", sb, 10, "step name col-sm-6", step.FullName.HtmlEncode(), false, true);
		}

		void WriteStepBadge(StringBuilder sb, Step step, int stepNumber) {
			var outcomeName = Enum.GetName(typeof(Outcome), step.Outcome).ToLower();
			sb.Append("<div class=\"col-sm-1\">");
            hW.WriteTag("span", sb, 10, $"step badge pointer total badge-pill {outcomeName}", " ", false, true, $"step-{stepNumber}-badge");
			sb.Append("</div>");
		}

		void WriteStepStatus(StringBuilder sb, Step step, int stepNumber){
            //if (step.Scenario.Outcome == Outcome.Failed && step.Outcome != Outcome.Passed)
            //{
                if(step.Exception != null)
                {
					WriteStepErrorLink(sb, stepNumber);
                } else 
                {
					hW.WriteReason(sb, "step", step.Reason);
                    // hW.WriteTagOpen("span", sb, 10, "status", true);
                    // sb.Append(" [");
                    // sb.Append(Enum.GetName(typeof(Outcome), step.Outcome));
                    // if (step.Reason != null && (step.Outcome != Outcome.Failed || step.Reason == "Not Implemented"))
                    // {
                    //     sb.Append(" - ");
                    //     sb.Append(step.Reason.HtmlEncode());
                    // }
                    // sb.Append("]");
                }
                //hW.WriteTagClose("span", sb, 0);
            //}
		}

		void WriteStepErrorLink(StringBuilder sb, int stepNumber) {
			sb.Append($"<a class=\"step-error-link col-1\" onclick=\"toggleVisibility('step-{stepNumber}-error')\">[Error!]</a>");
		}

		void WriteStepInputLink(StringBuilder sb, Step step, int stepNumber) {
            if (!String.IsNullOrEmpty(step.Input))
            {
                sb.Append($"<a class=\"step-input-link col-sm-1\" onclick=\"toggleVisibility('step-{stepNumber}-input')\">[Input]</a>");
            } else {
				sb.AppendLine($@"<span class=""col-sm-1""></span>");
			}
		}

		void WriteStepOutputLink(StringBuilder sb, Step step, int stepNumber) {
            if (!String.IsNullOrEmpty(step.Output))
            {
                sb.Append($"<a class=\"step-output-link col-sm-1\" onclick=\"toggleVisibility('step-{stepNumber}-output')\">[Output]</a>");
            } else {
				sb.AppendLine($@"<span class=""col-sm-1""></span>");
			}
		}
        void WriteException(Exception exception, Outcome outcome, StringBuilder sb, int level, int stepNumber, bool innerException = false) {
            if (exception != null && outcome != Outcome.Skipped) {
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
					WriteException(exception.InnerException, outcome, sb,  level++, stepNumber, true);
					hW.WriteTagClose("dd", sb, 10 + level);
				}
				hW.WriteTagClose("dl", sb, 9 + level);
				if(!innerException)
				{
					hW.WriteTagClose("div", sb, 0);
				}
			}
        }
        void WriteInputParameter(StringBuilder sb, Step step, int stepNumber) {
            if (!String.IsNullOrEmpty(step.Input))
            {
				hW.WriteTagOpen("div", sb, 9, "input collapse", false, "step-" + stepNumber + "-input", null, " aria-expanded=\"false\"");
				hW.WriteTag("div", sb, 10, "input title", "Input", false, false, "step-" + stepNumber + "-input-title");
				if(step.InputFormat == TextFormat.htmlpreview)
				{
					WriteInputParameterWithHtmlPreview(sb, step, stepNumber);
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
        }

        void WriteInputParameterWithHtmlPreview(StringBuilder sb, Step step, int stepNumber) {
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

        void WriteOutput(StringBuilder sb, Step step, int stepNumber) {
            if (!String.IsNullOrEmpty(step.Output))
            {
				hW.WriteTagOpen("div", sb, 9, "output collapse", false, "step-" + stepNumber + "-output", null, " aria-expanded=\"false\"");
				hW.WriteTag("div", sb, 10, "output title", "Output", false, false, "step-" + stepNumber + "-output-title");

				if(step.OutputFormat == TextFormat.htmlpreview)
				{
					WriteOutputWithHtmlPreview(sb, step, stepNumber);
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
        }

        void WriteOutputWithHtmlPreview(StringBuilder sb, Step step, int stepNumber) {
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
