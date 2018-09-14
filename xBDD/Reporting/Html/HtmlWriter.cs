using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Markdig;
using xBDD.Model;
using xBDD.Utility;

namespace xBDD.Reporting.Html
{
	/// <summary>
	/// Writes the results of a test run to an HTML represenation.
	/// </summary>
	public class HtmlWriter
	{
		List<ReportReasonConfiguration> sortedReasons;
		ITestRunReportConfiguration config;
		int lineItemNumber = 0;
		public HtmlWriter(List<ReportReasonConfiguration> sortedReasons, ITestRunReportConfiguration config) {
			this.sortedReasons = sortedReasons;
			this.config = config;
		}
		internal void WriteHeader(StringBuilder sb, bool failuresOnly, string navBarOptions)
		{
			sb.AppendLine($@"
				<!DOCTYPE html>
				<html>
					<head>
						<meta charset=""utf-8"" />
						<meta name=""viewport"" content=""width=device-width, initial-scale=1"" />
						<title>{config.ReportName.HtmlEncode()}</title>
						<link rel=""stylesheet"" 
							href=""https://use.fontawesome.com/releases/v5.3.1/css/all.css"" 
							integrity=""sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU"" 
							crossorigin=""anonymous"">
						<!--
						<link rel=""stylesheet"" 
							href=""https://cdnjs.cloudflare.com/ajax/libs/open-iconic/1.1.1/font/css/open-iconic-bootstrap.min.css"" 
							integrity=""sha256-BJ/G+e+y7bQdrYkS2RBTyNfBHpA9IuGaPmf9htub5MQ=\"" 
							crossorigin=""anonymous"" />
						-->
						<link rel=""stylesheet"" 
							href=""https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css"" 
							integrity=""sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO"" 
							crossorigin=""anonymous"">".RemoveIndentation(4,true));
			WriteStyles(sb);
			sb.AppendLine($@"
					</header>
					<body>
						<script language=""javascript"" type=""text/javascript"">
							function resizeIframe(obj) {{ 
								obj.style.height = obj.contentWindow.document.body.scrollHeight + 'px'; 
							}}
						</script>".RemoveIndentation(4,true));
			WriteNavBar(sb, failuresOnly, navBarOptions);
		}
		internal void WriteStyles(StringBuilder sb) {
			sb.AppendLine($@"
						<style>

							/* General */

							.container-fluid {{ padding: 0rem; margin: 0rem; }}
							.flip {{-moz-transform: scaleX(-1); -o-transform: scaleX(-1); -webkit-transform: scaleX(-1); transform: scaleX(-1); filter: FlipH; -ms-filter: ""FlipH"";}}

							.pointer {{ cursor: pointer }}

							/* Child Lists */

							ol.testruns {{ margin: 1rem 0rem 1rem 0rem; }}
							ol.areas {{ margin: 1rem 0rem 1rem 0rem; }}
							ol.features {{ margin: 0rem 0rem 1rem 0rem; }}
							ol.scenarios {{ margin: 0rem 0rem 1rem 0rem; }}
							ol.steps {{ margin: 0rem 0rem 1rem 0rem;}}

							/* Line Item Rows */

							li.header {{ margin: 1rem 0rem 0rem 0rem; padding: 1rem 0rem 0rem 0rem; }}
							li.testrun {{ margin: .75rem 0rem 0rem 0rem; border-top: rgb(183, 207, 248) solid 1px; padding: .75rem 0rem 0rem 0rem; }}
							li.area {{ margin: .75rem 0rem 0rem 0rem; border-top: rgb(183, 207, 248) solid 1px; padding: .75rem 0rem 0rem 0rem; }}
							li.feature {{ margin: 0rem 0rem 0rem 0rem; }}
							li.scenario {{ margin: 0rem 0rem 0rem 0rem; }}
							li.step {{ margin: 0rem 0rem 0rem 0rem; }}

							/* Badge Distros */

							div.badge-distro {{ display: inline-block; vertical-align: middle; }}
							div.badge-distro.header {{ width: 6rem; height: 2rem; }}
							div.badge-distro.testrun {{ width: 6rem; height: 2rem; }}
							div.badge-distro.area {{ width: 6rem; height: 2rem; }}
							div.badge-distro.feature {{ width: 6rem; height: 2rem; }}
							div.badge-distro.scenario {{ width: 6rem; height: 1.5rem; }}
							div.badge-distro.step {{ width: 6rem; height: 1rem; }}

							/* Badges */

							div.badges {{ flex: 0 0 3rem; }}
							div.badge {{ background-color: #80808029; border: 1px white solid; width: 1.5rem; height: 1.5rem; vertical-align: middle; }}
							div.badge:hover {{ background-color: #4343af }}
							div.badge.label {{ width: 100%; height: 100%; vertical-align: middle; }}
							div.header.badge {{ width: 4.5rem; height: 2rem; position: absolute; font-size: 1.25rem; }}
							div.badge.testrun {{ width: 4.5rem; height: 2rem; position: absolute; font-size: 1.25rem; }}
							div.badge.area {{ width: 4.5rem; height: 2rem; position: absolute; font-size: 1.25rem;  }}
							div.badge.feature {{ width: 3rem; margin-left: 1.5rem; height: 1.75rem; position: absolute; font-size: 1rem;  }}
							div.badge.scenario {{ width: 2rem; margin-left: 4rem; position: inherit; }}
							div.badge.step {{ width: 1rem; margin-left: 5rem; position: inherit; height: 1rem; }}
							div.badge.step.label {{ width: 6rem; display: inline-block }}
							div.badge.step.reason-PreviousError {{ background-color: gray; }}
							div.badge.step.reason-ScenarioSkipped {{ background-color: gray; }}

							span.step.reason {{ font-size: 1rem; color: gray; font-weight: 100; }}

							div.distro {{ display: inline-block; border: 1px solid white; }}
							div.distro.header {{ width: 3rem; height: 2rem; margin-left: 3rem; }}
							div.distro.testrun {{ width: 3rem; height: 2rem; margin-left: 3rem; }}
							div.distro.area {{ width: 3rem; height: 2rem; margin-left: 3rem; }}
							div.distro.feature {{ width: 3rem; height: 1.75rem; margin-left: 3rem; }}

							div.badge.feature-statement-link {{ position: inherit; width: 1.5rem; height: 1.5rem; vertical-align: top; }}

							div.name.feature {{ margin-left: 1rem; }}
							div.name.scenario {{ margin-left: 2rem;  }}
							div.name.step {{ margin-left: 3rem; }}

							span.name {{ vertical-align: top; }}
							span.name.header {{ font-size: 2rem; font-weight: 400; margin-left: .75rem; }}
							span.name.testrun {{ font-size: 2rem; font-weight: 400; margin-left: .75rem; }}
							a.name.testrun {{ font-size: 1.5rem; font-weight: 400; color: rgb(68,114,198); }}
							span.name.area {{ font-size: 1.5rem; font-weight: 400; color: rgb(68,114,198); }}
							span.name.feature {{ font-size: 1.25rem; font-weight: 400; color: rgb(68,114,198); }}
							span.name.scenario {{ font-size: 1.125rem; font-weight: 400; vertical-align: middle; font-style: italic; color: rgb(68,114,198); }}
							span.name.step {{ font-size: 1rem;  font-weight: 400; }}

							span.assignments {{ float: right; color: Gray; font-size: 1rem; }}
							span.tags {{ float: right; margin-right: .5rem; color: Gray; font-size: 1rem; }}

							div.reason-duration {{ flex: 0 0 6rem; font-size: 1rem; color: gray; vertical-align: text-top; white-space: nowrap; }}
							span.reason-duration.step {{ font-size: 1rem; color: gray; font-weight: 100; }}

							span.duration.step {{ font-size: 1rem; color: gray; font-weight: 100; }}

							/* Stats */

							.stats-graph-tables {{ border-top: 0.5rem; }}
							.table {{ margin: 2px !important; }}
							.table th, .table td {{ border-top: none !important; line-height: 1 !important; padding: 0px 10px !important; }}
							td.graph td {{ padding: 0px !important; }}
							.table td.bar {{ padding: 0px !important; }}
							div.distro-corner-tr {{ position: absolute; margin-left: 5.35rem; width: 10px; height: 10px; background: url(""data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABQAAAATCAMAAAHQVe0RAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAVUExURQAAAP///////////////////////0jPbQQAAAAGdFJOUwC81uLs9S3UunwAAAAJcEhZcwAAEk0AABJNAfOXxKcAAABZSURBVBhXlY7bDsAgCEOdSv//k22RLZjx4jFKabjYwCP0miuyrQ215fxl8LJZQVQlIvmALzCwLUkJMnJlxEuOYcc2TLeDSaOhR/bR0Z6QicK6o5xZbv//E1gwYwFZkRA8AQAAAABJRU5ErkJggg=="") no-repeat top right; }}
							div.distro-corner-br {{ position: absolute; margin-left: 5.35rem; width: 10px; height: 10px; background: url(""data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABQAAAATCAMAAAHQVe0RAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAVUExURQAAAP///////////////////////0jPbQQAAAAGdFJOUwC81uLs9S3UunwAAAAJcEhZcwAAEk0AABJNAfOXxKcAAABZSURBVBhXlY7bDsAgCEOdSv//k22RLZjx4jFKabjYwCP0miuyrQ215fxl8LJZQVQlIvmALzCwLUkJMnJlxEuOYcc2TLeDSaOhR/bR0Z6QicK6o5xZbv//E1gwYwFZkRA8AQAAAABJRU5ErkJggg=="") no-repeat bottom right; }}
							div.distro-corner-tr.header {{ margin-top: .05rem; }}
							div.distro-corner-br.header {{ margin-top: 1.32rem; }}
							div.distro-corner-tr.testrun {{ margin-top: .05rem; }}
							div.distro-corner-br.testrun {{ margin-top: 1.32rem; }}
							div.distro-corner-tr.area {{ margin-top: .05rem; }}
							div.distro-corner-br.area {{ margin-top: 1.32rem; }}
							div.distro-corner-tr.feature {{ margin-top: .06rem; }}
							div.distro-corner-br.feature {{ margin-top: 1.1rem; }}

							div#report-dates {{ margin: 0rem 0rem .5rem 5rem; }}

							/* Statement */

							div.statement-title {{ margin-bottom: 1rem; }}
							div.statement-content {{ margin: 1rem 0rem; border: lightgray solid 1px; padding: 1rem; }}

							/* Step Details */

							div.step-details {{ margin: .5rem 0rem; }}
							div.step-exception-link.button {{ width: 6rem !important; }}
							div.step-output-link.button {{ width: 6rem; background-color: gray; color: white; }}
							div.step-input-link.button {{ width: 6rem; background-color: gray; color: white; }}
							div.step-statement-link {{ width: 6rem; background-color: gray; color: white; }}

							/* Exceptions */

							div.exception {{ margin-bottom: 1rem; }}
							div.exception-details {{ margin: 1rem 0rem; border: #dc3545 solid 1px; padding: 1rem; }}
							dl.exception dt {{ margin-bottom: .25rem; }}
							dl.exception-type, dl.exception-message, dl.exception-stack {{ padding: .5rem; }}
							dl.exception-type pre, dl.exception-message pre, dl.exception-stack pre {{ padding: .5rem; }}

							/* Input, Output, Explanation */

							div.input {{ margin-bottom: 1rem; }}
							div.output {{ margin-bottom: 1rem; }}
							div.explanation {{ margin-bottom: 1rem; }}

							div.input-title {{ margin-bottom: 1rem; }}
							div.output-title {{ margin-bottom: 1rem; }}
							div.explanation-title {{ margin-bottom: 1rem; }}

							div.input.markdown {{ border: 1px solid gray; padding: 1rem; }}
							div.output.markdown {{ border: 1px solid gray; padding: 1rem; }}
							div.explanation.markdown {{ border: 1px solid gray; padding: 1rem; }}

							pre {{ white-space: pre !important; }}
							pre.input {{ margin-bottom: 1rem; }}
							pre.output {{ margin-bottom: 1rem; }}
							pre.explanation {{ margin-bottom: 1rem; }}

							iframe {{ border: 1px solid gray; resize: both; overflow: auto; }}
							pre.prettyprint {{  background-color: #eee; }}
							.linenums li {{ list-style-type: decimal !important; }}
							
							".RemoveIndentation(4,true));
			this.sortedReasons.ForEach(reason => {
				sb.AppendLine($@"
							.reason-{reason.Reason.EncodeCSSClassName()} {{ background-color: {reason.BackgroundColor} !important; color: {reason.FontColor} !important;}}".RemoveIndentation(4,true));
			});
			sb.AppendLine(@"
						</style>".RemoveIndentation(4,true));
		}
		internal void WriteFooter(StringBuilder sb)
		{
			sb.AppendLine(@"					
						<script>
							function toggleVisibility(elementId, iframeIdInput, iframeIdOutput) {{
								var x = document.getElementById(elementId);
								if (x.style.display === ""none"") {{
									x.style.display = ""block"";
									if(iframeIdInput) {
										resizeIframe(document.getElementById(iframeIdInput));
									}
									if(iframeIdOutput) {
										resizeIframe(document.getElementById(iframeIdOutput));
									}
								}} else {{
									x.style.display = ""none"";
								}}
							}}
						</script>
						<script src=""https://cdn.rawgit.com/google/code-prettify/master/loader/run_prettify.js""></script>
					</body>
				</html>");
		}
		void WriteNavBar(StringBuilder sb, bool failuresOnly, string navbarOptions)
		{
			var failuresOnlyText = "";
			if(failuresOnly) {
				failuresOnlyText = " [Failures Only]";
			}
			sb.Append($@"
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
							<div class=""navbar-nav"">".RemoveIndentation(4, true));
			sb.AppendLine(navbarOptions);
			sb.Append($@"
							</div>
						</div>
					</nav>".RemoveIndentation(4, true));
		}
		internal void WriteLineItem(StringBuilder sb, HtmlReportLineItem lineItem, bool failuresOnly, bool statsExpanded, bool childrenExpanded, bool header) 
		{
			this.lineItemNumber++;
			var statementAndExplanationLink = lineItem.Statement != null || lineItem.Explanation != null;
			var inputLink = lineItem.Input != null;
			var outputLink = lineItem.Output != null;
			var explanationLink = lineItem.Explanation != null;
			var inputHtmlPreviewLink = (inputLink && lineItem.InputFormat == TextFormat.htmlpreview ? $"'iframe{lineItemNumber}input'" : "null" );
			var outputHtmlPreviewLink = (outputLink && lineItem.OutputFormat == TextFormat.htmlpreview ? $"'iframe{lineItemNumber}output'" : "null" );
			var explanationHtmlPreviewLink = (explanationLink && lineItem.ExplanationFormat == TextFormat.htmlpreview ? $"'iframe{lineItemNumber}explanation'" : "null" );

			var lineItemType = lineItem.TypeName.ToLower();
			if(header)
				lineItemType = "header";

			sb.AppendLine($@"
				<li class=""lineitem {lineItemType} row align-items-center"" id=""{lineItemType}-{this.lineItemNumber}"">".RemoveIndentation(4,true));

			WriteBadge(sb, lineItem, header);

			if(String.IsNullOrEmpty(lineItem.Name)) {
				lineItem.Name = "[Missing! (or Full Name Skipped)]";
			}

			sb.AppendLine($@"
					<div class=""col"">
						<div class=""{lineItemType} name"">".RemoveIndentation(4));
			var name = lineItem.Name;
			if(lineItemType == "area" || lineItemType == "testrun") {
				name = name.Replace(config.RootNameSkip, "");
			}
			if(lineItem.FilePath != null) {
				sb.AppendLine($@"
						<a class=""{lineItemType} name pointer"" 
							id=""{lineItemType}-{this.lineItemNumber}-name""
							href=""{lineItem.FilePath}"">{name}</a>".RemoveIndentation(4, true));
			} else {
				sb.AppendLine($@"
						<span class=""{lineItemType} name pointer"" 
							id=""{lineItemType}-{this.lineItemNumber}-name""
							onclick=""toggleVisibility('{lineItemType}-{this.lineItemNumber}-{lineItem.ChildTypeName.ToLower()}', {inputHtmlPreviewLink}, {outputHtmlPreviewLink})""
							href=""{lineItemType}-{this.lineItemNumber}-{lineItem.ChildTypeName.ToLower()}"">{name}</span>".RemoveIndentation(4, true));
			}
			if(lineItem.Assignments != null && lineItem.Assignments.Count > 0) {
				sb.Append($@"
						<span class=""{lineItemType} assignments"" 
							id=""{lineItemType}-{this.lineItemNumber}-assignments"">[".RemoveIndentation(6, true));
				lineItem.Assignments.ForEach(assignment => {
						sb.Append($@"{(lineItem.Assignments.IndexOf(assignment)==0?"":", ")}{assignment.HtmlEncode()}");
				});
				sb.AppendLine($@"
						]</span>".RemoveIndentation(6, true));
			}
			if(lineItem.Tags != null && lineItem.Tags.Count > 0) {
				sb.Append($@"
						<span class=""{lineItemType} tags"" 
							id=""{lineItemType}-{this.lineItemNumber}-tags"">[".RemoveIndentation(6, true));
				lineItem.Tags.ForEach(tag => {
						sb.Append($@"{(lineItem.Tags.IndexOf(tag)==0?"":", ")}{tag.HtmlEncode()}");
				});
				sb.AppendLine($@"
						]</span>".RemoveIndentation(6, true));
			}
			if(lineItemType != "step" && (!string.IsNullOrEmpty(lineItem.Explanation)||!string.IsNullOrEmpty(lineItem.Statement))) {
				sb.AppendLine($@"
						<div class=""{lineItem.TypeName}-statement-link badge pointer badge-secondary"" 
							id=""{lineItem.TypeName}-{this.lineItemNumber}-statement-link"" 
							onclick=""toggleVisibility('{lineItem.TypeName}-{this.lineItemNumber}-statement'); toggleVisibility('{lineItem.TypeName}-{this.lineItemNumber}-explanation', {explanationHtmlPreviewLink})"">
							<i class=""fas fa-info""></i>
						</div>".RemoveIndentation(4,true));
			}
			sb.AppendLine($@"
						</div>
					</div>".RemoveIndentation(4));

			WriteDuration(sb, lineItemType, lineItem.EndTime, lineItem.StartTime);

			sb.AppendLine($@"
				</li>".RemoveIndentation(4));

			if(lineItemType != "step") {
				WriteStats(sb, lineItemType, lineItem.ReasonStats, statsExpanded);

				WriteStatement(sb, lineItem);
			}

			if(lineItem.ChildTypeName != null) {
				var expanded = (lineItem.Outcome == Outcome.Failed && failuresOnly) || childrenExpanded;
				var display = expanded ? "block" : "none";
				var childClassName = $"{lineItem.ChildTypeName.ToLower()} list-unstyled";
				sb.AppendLine($@"
					<li class=""row children"">
						<div class=""col-12"">
							<ol class=""{childClassName} container-fluid""
								id=""{lineItemType}-{this.lineItemNumber}-{lineItem.ChildTypeName.ToLower()}""
								style=""display: {display}"">".RemoveIndentation(4));
				foreach(var item in lineItem.ChildItems) {
					WriteLineItem(sb, item, failuresOnly, false, false, false);
				}
				if(lineItem.Exception != null || !string.IsNullOrEmpty(lineItem.Input) || !string.IsNullOrEmpty(lineItem.Output)) {
					WriteStepDetails(sb, lineItem);
					
					WriteStatement(sb, lineItem);

					WriteException(sb, lineItem, lineItem.Exception, false);

					WriteLineItemContent(sb, lineItem, "input");
					
					WriteLineItemContent(sb, lineItem, "output");
				}
				sb.AppendLine($@"
							</ol>
						</div>
					</li>".RemoveIndentation(4));
				}
		}
		void WriteBadge(StringBuilder sb, HtmlReportLineItem lineItem, bool header) 
		{
			var lineItemType = lineItem.TypeName.ToLower();
			if(header)
				lineItemType = "header";

			var statementAndExplanationLink = lineItem.Statement != null || lineItem.Explanation != null;
			var total = 0;
			if(lineItem.ReasonStats.ContainsKey("Scenarios")) {
				foreach(var reasonStat in lineItem.ReasonStats["Scenarios"].Values) {
					total = total + reasonStat;
				}
			}
			sb.AppendLine($@"
				<div class=""col-2 badges"">".RemoveIndentation(4,true));

			if(lineItemType == "testrun" || lineItemType == "area" || lineItemType == "feature" || lineItemType == "header") {
				sb.AppendLine($@"
					<div class=""{lineItemType} badge-distro""
						id=""{lineItemType}-{this.lineItemNumber}-badge-distro""
						title=""{lineItem.Reason} Count: Scenarios""
						onclick=""toggleVisibility('{lineItemType}-{this.lineItemNumber}-stats')"">
						<div class=""{lineItemType} badge badge-pill pointer total reason-{lineItem.Reason.EncodeCSSClassName()}""
							id=""{lineItemType}-{this.lineItemNumber}-badge"">{(lineItemType == "step" ? " " : total.ToString())}</div>".RemoveIndentation(4,true));
				if(lineItemType != "scemario" && lineItemType != "step") {
					sb.AppendLine($@"
						<div class=""{lineItemType} distro-corner-tr"">
						</div>
						<div class=""{lineItemType} distro-corner-br"">
						</div>
						<div class=""{lineItemType} distro pointer""
							id=""{lineItemType}-{this.lineItemNumber}-distro"">".RemoveIndentation(4,true));

					foreach(var sortedReason in this.sortedReasons.Select(x => x).Reverse()) {
						double stat = 0;
						if(lineItem.ReasonStats.ContainsKey("Scenarios") && lineItem.ReasonStats["Scenarios"].ContainsKey(sortedReason.Reason)) {
							stat = ((double)lineItem.ReasonStats["Scenarios"][sortedReason.Reason]/(double)total)*100;
							sb.AppendLine($@"
							<div class=""reason-{sortedReason.Reason.EncodeCSSClassName()}"" style=""height: {stat}%; width: 100%;""></div>".RemoveIndentation(4,true));
						}
					}
					sb.AppendLine($@"
						</div>
					</div>".RemoveIndentation(4,true));
				}
			} else {
				if(lineItemType == "scenario" || lineItem.Exception == null) {
					var childTotal = lineItem.ChildItems.Count;
					sb.AppendLine($@"
						<div class=""{lineItemType} badge badge-pill pointer total reason-{lineItem.Reason.EncodeCSSClassName()}""
							id=""{lineItemType}-{this.lineItemNumber}-badge"">{(lineItemType == "step" ? " " : childTotal.ToString())}</div>".RemoveIndentation(4,true));
				} else {
					sb.AppendLine($@"
						<div class=""{lineItemType} badge badge-pill pointer exception-link reason-{lineItem.Reason.EncodeCSSClassName()}"" 
							id=""{lineItemType}-{this.lineItemNumber}-exception-link"" 
							onclick=""toggleVisibility('{lineItemType}-{this.lineItemNumber}-exception')"">&nbsp;</div>".RemoveIndentation(4,true));
				}
			}

			sb.AppendLine($@"
				</div>".RemoveIndentation(4,true));
		}
		void WriteStats(StringBuilder sb, string objectType, Dictionary<string, Dictionary<string, int>> reasonStats, bool expanded = true) 
		{
			sb.AppendLine($@"
				<li class=""row stats"">
					<div class=""col-2 badges""></div>
					<div class=""col-11"">
						<div class=""stats-graph-tables"" id=""{objectType.ToLower()}-{this.lineItemNumber}-stats"" style=""width: 100%; empty-cells: show; display: {(expanded ? "block" : "none" )};"">
							<table class=""table table-condensed stats-table"">
								<tr id=""{objectType.ToLower()}-header-reason-stats"">
									<td class=""stats-label text-muted text-right"">&nbsp;</td>
									<td class=""text-center"" >Total</td>".RemoveIndentation(4,true));
			foreach(string key in this.sortedReasons.Select(x => x.Reason).Reverse()) {
				sb.AppendLine($@"
									<td class=""text-center""><div class=""badge label reason-{key.EncodeCSSClassName()}"">{key}</div></td>".RemoveIndentation(4,true));
			}
			foreach(string statsKey in reasonStats.Keys) {
				WriteReasonStatsLine(sb, reasonStats[statsKey], 1, $"report-{statsKey.ToLower()}-reason-stats", statsKey);
			}
			sb.AppendLine($@"
							</table>".RemoveIndentation(4,true));
			sb.AppendLine($@"
							<table class=""table table-condensed bargraph-table"">
								<tr id=""{objectType.ToLower()}-header-reason-stats"">
									<td class=""stats-label text-muted text-right"" style=""width: 0%; padding-left: 0px !important;"">&nbsp;</td>".RemoveIndentation(4,true));
				sb.AppendLine($@"
									<td class=""outcome-bar-chart"" style=""width: 90%;"">&nbsp;</td>
								</tr>".RemoveIndentation(4,true));
			foreach(string statsKey in reasonStats.Keys) {
				WriteReasonGraphLine(sb, reasonStats[statsKey], 1, $"report-{statsKey.ToLower()}-reason-stats", statsKey);
			}
			sb.AppendLine($@"
							</table>".RemoveIndentation(4,true));
			sb.AppendLine($@"
						</div>
					</div>
				</li>".RemoveIndentation(4,true));
		}
		void WriteReasonStatsLine(StringBuilder sb, Dictionary<string, int> stats, int baseIndent, string id, string label) {
			sb.AppendLine($@"
					<tr id=""{id}"">
						<td class=""stats-label text-muted text-right"" style=""width: 0%; padding-left: 0px !important;"">{label}</td>".RemoveIndentation(4,true));
			var total = stats.Values.Sum();
			var percentWidth = 100 / (this.sortedReasons.Count() + 1);
			sb.AppendLine($@"
						<td class=""text-center"" style=""width: {percentWidth}%;"">{total.ToString()}</td>".RemoveIndentation(4,true));
			foreach(string key in this.sortedReasons.Select(x => x.Reason).Reverse()) {
				var stat = 0;
				if(stats.ContainsKey(key)) {
					stat = stats[key];
				}
				sb.AppendLine($@"
						<td class=""text-center"" style=""width: {percentWidth}%;"">{stat.ToString()}</td>".RemoveIndentation(4,true));
			}
			sb.AppendLine($@"
					</tr>".RemoveIndentation(4,true));
		}
		void WriteReasonGraphLine(StringBuilder sb, Dictionary<string, int> stats, int baseIndent, string id, string label) {
			sb.AppendLine($@"
					<tr id=""{id}"">
						<td class=""stats-label text-muted text-right"" style=""width: 0%; padding-left: 0px !important;"">{label}</td>".RemoveIndentation(4,true));
			var total = stats.Values.Sum();
			sb.AppendLine($@"
						<td class=""outcome-bar-chart"" style=""width: 100%;"">
							<table class=""table"" style=""width: 100%; empty-cells: show; height: 14px;"">
								<tr>".RemoveIndentation(4,true));
			if(total == 0)
			{
				sb.AppendLine($@"
									<td class=""empty-bar"" style=""width: 100%;""></td>".RemoveIndentation(4,true));
			}
			else
			{
				foreach(string key in this.sortedReasons.Select(x => x.Reason).Reverse()) {
					var style = "";
					if(stats.ContainsKey(key)) {
						var reasonConfig = this.sortedReasons.Where(x => x.Reason == key).FirstOrDefault();
						double percent = stats[key] == 0 ? 0 : (((double)stats[key] / (double)total) * 100);
						style = $"width: {percent}%;";
						sb.AppendLine($@"
									<td class=""bar text-center reason-{reasonConfig.Reason.EncodeCSSClassName()}"" style=""{style}""></td>".RemoveIndentation(4,true));
					}
				}
			}
			sb.AppendLine($@"
								</tr>
							</table>
						</td>
					</tr>".RemoveIndentation(4,true));
		}
		void WriteStatement(StringBuilder sb, HtmlReportLineItem lineItem) {
			var lineItemType = lineItem.TypeName.ToLower();

			if(lineItem.Statement != null || lineItem.Explanation != null)
			{
				sb.AppendLine($@"
					<li class=""row statement"">
						<div class=""col-2 badges""></div>
						<div class=""col-11"">
							<div class=""{lineItemType} statement"" 
								id=""{lineItemType}-{this.lineItemNumber}-statement""
								style=""display: none;"">".RemoveIndentation(4,true));
				if(lineItem.Statement != null) {
					sb.AppendLine($@"
									<div class=""statement-title"">Statement</div>
									<div class=""{lineItemType} statement-content rounded""
										id=""{lineItemType}-{this.lineItemNumber}-statement"">{lineItem.Statement.AddIndentation(4)}</div>".RemoveIndentation(4,true));
				}
				sb.AppendLine($@"
							</div>
						</div>
					</li>".RemoveIndentation(4, true));
				if(lineItem.Explanation != null) {
					WriteLineItemContent(sb, lineItem, "explanation");
					// sb.AppendLine($@"
					// 				<div class=""explanation-title"">Explanation</div>
					// 				<div class=""{lineItemType} explanation rounded""
					// 				id=""{lineItemType}-{this.lineItemNumber}-explanation"">{Markdown.ToHtml(lineItem.Explanation).AddIndentation(4)}</div>".RemoveIndentation(4,true));
				}
			}
		}
		void WriteStepDetails(StringBuilder sb, HtmlReportLineItem lineItem) {
			var inputLink = lineItem.Input != null;
			var outputLink = lineItem.Output != null;
			var explanationLink = lineItem.Explanation != null;
			var inputHtmlPreviewLink = (inputLink && lineItem.InputFormat == TextFormat.htmlpreview ? $"'iframe{lineItemNumber}input'" : "null" );
			var outputHtmlPreviewLink = (outputLink && lineItem.OutputFormat == TextFormat.htmlpreview ? $"'iframe{lineItemNumber}output'" : "null" );
			var explanationHtmlPreviewLink = (explanationLink && lineItem.ExplanationFormat == TextFormat.htmlpreview ? $"'iframe{lineItemNumber}explanation'" : "null" );
			sb.AppendLine($@"
					<li class=""row"">
						<div class=""col-2 badges""></div>
						<div class=""col-11"">
							<div class=""step-details"">".RemoveIndentation(4));
			if(lineItem.Exception != null) {
				sb.AppendLine($@"
								<div class=""{lineItem.TypeName}-exception-link reason-Failed badge pointer button"" 
									id=""{lineItem.TypeName}-{this.lineItemNumber}-exception-link"" 
									onclick=""toggleVisibility('{lineItem.TypeName}-{this.lineItemNumber}-exception')"">
									<i class=""fas fa-bug""></i>&nbsp;<span>Exception</span>
								</div>".RemoveIndentation(4,true));
			}
			if(!string.IsNullOrEmpty(lineItem.Input)) {
				sb.AppendLine($@"
								<div class=""{lineItem.TypeName}-input-link badge pointer button"" 
									id=""{lineItem.TypeName}-{this.lineItemNumber}-input-link"" 
									onclick=""toggleVisibility('{lineItem.TypeName}-{this.lineItemNumber}-input', {inputHtmlPreviewLink})"">
									<i class=""fas fa-sign-in-alt""></i>&nbsp;<span>Input</span>
								</div>".RemoveIndentation(4,true));
			}
			if(!string.IsNullOrEmpty(lineItem.Output)) {
				sb.AppendLine($@"
								<div class=""{lineItem.TypeName}-output-link badge pointer button"" 
									id=""{lineItem.TypeName}-{this.lineItemNumber}-output-link"" 
									onclick=""toggleVisibility('{lineItem.TypeName}-{this.lineItemNumber}-output', {outputHtmlPreviewLink})"">
									<i class=""fas fa-sign-out-alt""></i>&nbsp;<span>Output</span>
								</div>".RemoveIndentation(4,true));
			}
			if(!string.IsNullOrEmpty(lineItem.Explanation)||!string.IsNullOrEmpty(lineItem.Statement)) {
				sb.AppendLine($@"
								<div class=""{lineItem.TypeName}-statement-link badge pointer badge-secondary"" 
									id=""{lineItem.TypeName}-{this.lineItemNumber}-statement-link"" 
									onclick=""toggleVisibility('{lineItem.TypeName}-{this.lineItemNumber}-statement'); toggleVisibility('{lineItem.TypeName}-{this.lineItemNumber}-explanation', {explanationHtmlPreviewLink})"">
									<i class=""fas fa-info""></i>&nbsp;<span>Explanation</span>
								</div>".RemoveIndentation(4,true));
			}
			sb.AppendLine($@"
							</div>
						</div>
					</li>".RemoveIndentation(4));

		}
		void WriteException(StringBuilder sb, HtmlReportLineItem lineItem, Exception exception, bool innerException = false) {
			var lineItemType = lineItem.TypeName.ToLower();

			if (exception != null && lineItem.Outcome != Outcome.Skipped) {
				if(!innerException)
				{
					sb.AppendLine($@"
					<li class=""row exception"">
						<div class=""col-2 badges""></div>
						<div class=""col-11"">
							<div class=""exception""
								id=""{lineItemType}-{this.lineItemNumber}-exception""
								style=""display: block;"">
								<div class=""exception-title"" 
									id=""step-{this.lineItemNumber}-exception-title"">Exception<div>
									<div class=""exception-details rounded"">
								".RemoveIndentation(4, true));
				}
					sb.AppendLine($@"
										<dl class=""exception dl-horizontal rounded"">
											<dt>Error Type</dt><dd class=""exception-type"">{exception.GetType().Name.HtmlEncode()}</dd>
											<dt>Message</dt><dd class=""exception-message bg-light""><pre><code>{exception.Message.AddIndentation(4).HtmlEncode()}</code></pre></dd>
											<dt>Stack</dt><dd class=""exception-stack bg-light""><pre><code>{exception.StackTrace.AddIndentation(4).HtmlEncode()}</code></pre></dd>
											".RemoveIndentation(4, true));
				if(exception.InnerException != null)
				{
					sb.AppendLine($@"
										<dt>Inner Exception</dt>
										<dd class=""inner-exception"">".RemoveIndentation(4, true));
					WriteException(sb, lineItem, exception.InnerException, true);
					sb.AppendLine($@"
										</dd>".RemoveIndentation(4, true));
				}
					sb.AppendLine($@"
									</dl>".RemoveIndentation(4, true));
				if(!innerException)
				{
					sb.AppendLine($@"
								</div>
							</div>
						</div>
					</li>".RemoveIndentation(4, true));
				}
			}
		}
		void WriteLineItemContent(StringBuilder sb, HtmlReportLineItem lineItem, string contentType) {
			var lineItemType = lineItem.TypeName.ToLower();

			var text = "";
			TextFormat format = new TextFormat();
			var title = "";
			var display = "block";
			switch(contentType) {
				case "input":
					text = lineItem.Input;
					format = lineItem.InputFormat;
					title = "Input";
				break;
				case "output":
					text = lineItem.Output;
					format = lineItem.OutputFormat;
					title = "Output";
				break;
				case "explanation":
					text = lineItem.Explanation;
					format = lineItem.ExplanationFormat;
					title = "Explanation";
					display = "none";
				break;
			}
			if (!String.IsNullOrEmpty(text))
			{
				sb.AppendLine($@"
					<li class=""row {contentType}"">
						<div class=""col-2 badges""></div>
						<div class=""col-11"">
							<div class=""{contentType}"" 
								id=""{lineItemType}-{this.lineItemNumber}-{contentType}""
								style=""display: {display};"">
								<div class=""{contentType}-title"" 
									id=""step-{this.lineItemNumber}-{contentType}-title"">{title}</div>".RemoveIndentation(4, true));
				if(format == TextFormat.htmlpreview) {
					WriteInputOrOutputWithHtmlPreview(sb, lineItem, contentType);
				}
				else if(format == TextFormat.markdown) {
					text = Markdig.Markdown.ToHtml(text, new MarkdownPipelineBuilder().UseAdvancedExtensions().Build());
					sb.AppendLine($@"
									<div class=""{contentType} markdown"" id=""{contentType}-{this.lineItemNumber}"">{text.AddIndentation(4)}</div>".RemoveIndentation(4, true));
				}
				else {
					var className = $"{contentType} prettyprint linenums rounded";
					if (format != TextFormat.code)
						className = className + " lang-" + Enum.GetName(typeof(TextFormat), format);
					if(format == TextFormat.markdown)
						text = Markdig.Markdown.ToHtml(text);
					sb.AppendLine($@"
									<pre class=""{className}"" id=""{contentType}-{this.lineItemNumber}"">{text.HtmlEncode().AddIndentation(4)}</pre>".RemoveIndentation(4, true));
				}
				sb.AppendLine($@"
							</div>
						</div>
					</li>".RemoveIndentation(4, true));
			}
		}
		void WriteInputOrOutputWithHtmlPreview(StringBuilder sb, HtmlReportLineItem lineItem, string contentType) {
			string previewCode = null;
			string previewHtml = null;
			switch(contentType) {
				case "input":
					previewCode = lineItem.Input.HtmlEncode();
					previewHtml = lineItem.Input;
				break;
				case "output":
					previewCode = lineItem.Output.HtmlEncode();
					previewHtml = lineItem.Output;
				break;
				case "explanation":
					previewCode = lineItem.Explanation.HtmlEncode();
					previewHtml = lineItem.Explanation;
				break;
			}
			previewHtml = previewHtml
				.Replace(System.Environment.NewLine, " \\" + System.Environment.NewLine)
				.Replace(":", "\\:")
				.Replace("/", "\\/")
				.Replace("!", "\\!")
				.Replace("\"", "\\\"");
			var html = $@"
				<div class=""{contentType} rounded"">
					<div class=""nav nav-tabs"" role=""tablist"" style=""display: {(contentType=="explanation"?"none":"flex")};"">
						<a
							id=""preview{this.lineItemNumber}-tab""
							class=""nav-item nav-link active pointer"" 
							onclick=""toggleVisibility('preview{this.lineItemNumber}{contentType}', true, 'iframe{this.lineItemNumber}{contentType}'); toggleVisibility('code{this.lineItemNumber}{contentType}')"">Preview</a>
						<a
							id=""code{this.lineItemNumber}-tab""
							class=""nav-item nav-link pointer"" 
							onclick=""toggleVisibility('preview{this.lineItemNumber}{contentType}', true, 'iframe{this.lineItemNumber}{contentType}'); toggleVisibility('code{this.lineItemNumber}{contentType}')"">Code</a>
					</div>
					<div class=""tab-content"">
						<div role=""tabpanel"" 
							class=""tab-pane active"" 
							style=""display: block;""
							id=""preview{this.lineItemNumber}{contentType}"">
							<iframe width=""100%"" id=""iframe{this.lineItemNumber}{contentType}""></iframe>
							<script type=""text/javascript"">
								var iframe{this.lineItemNumber}{contentType}doc = document.getElementById('iframe{this.lineItemNumber}{contentType}').contentWindow.document;
								iframe{this.lineItemNumber}{contentType}doc.open();
								var html{this.lineItemNumber}{contentType} = ""{previewHtml.AddIndentation(4)}"";
								iframe{this.lineItemNumber}{contentType}doc.write(html{this.lineItemNumber}{contentType});
								resizeIframe(document.getElementById('iframe{this.lineItemNumber}{contentType}'));
								iframe{this.lineItemNumber}{contentType}doc.close();
							</script>
						</div>
						<div role=""tabpanel"" 
							class=""tab-pane"" 
							style=""display: none;""
							id=""code{this.lineItemNumber}{contentType}"">
							<pre class=""{contentType} prettyprint linenums lang-html"">{previewCode.AddIndentation(4)}</pre>
						</div>
					</div>
				</div>".RemoveIndentation(4, true);
			sb.AppendLine(html);
		}
		void WriteDuration(StringBuilder sb, string objectType, DateTime endTime, DateTime startTime, string reasonReplacement = null) {
			var duration = endTime - startTime;
			var formattedDuration = duration.TotalMilliseconds.ToString("N", System.Globalization.CultureInfo.InvariantCulture);
			formattedDuration = formattedDuration.Substring(0, formattedDuration.Length-3);
			sb.Append($@"
				<div class=""col-2 {objectType} reason-duration text-right"">
					<span class=""{objectType} duration"">[{formattedDuration} ms]</span>
				</div>".RemoveIndentation(4, true));
		}
		void WriteStartTime(StringBuilder sb, DateTime startTime) {
			if(startTime != DateTime.MinValue) {
				sb.AppendLine($@"
						<div id=""report-dates"" style=""margin-top: 0px !important;"">
							<div id=""report-start-date"" title=""Start Time"">{startTime.ToString("yyyy-MM-dd hh:mm tt \"GMT\"zzz")}</div>
						</div>
				".RemoveIndentation(4,true));
			}
		}
	}
}