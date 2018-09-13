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
		internal void WriteHtmlStart(StringBuilder sb)
		{
			sb.AppendLine(@"
				<!DOCTYPE html>
					<html>".RemoveIndentation(4, true));
		}
		internal void WriteHtmlEnd(StringBuilder sb)
		{
			sb.Append("</html>");
		}
		internal void WriteHeader(StringBuilder sb)
		{
			sb.AppendLine($@"
					<head>
						<meta charset=""utf-8"" />
						<meta name=""viewport"" content=""width=device-width, initial-scale=1"" />
						<title>{config.ReportName.HtmlEncode()}</title>
						<link rel=""stylesheet"" 
							href=""https://use.fontawesome.com/releases/v5.3.1/css/all.css"" 
							integrity=""sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU"" crossorigin=""anonymous"">
						<!--
						<link rel=""stylesheet"" 
							href=""https://cdnjs.cloudflare.com/ajax/libs/open-iconic/1.1.1/font/css/open-iconic-bootstrap.min.css"" 
							integrity=""sha256-BJ/G+e+y7bQdrYkS2RBTyNfBHpA9IuGaPmf9htub5MQ=\"" 
							crossorigin=""anonymous"" />
						-->
						<link rel=""stylesheet"" 
							href=""https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css"" 
							integrity=""sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO"" crossorigin=""anonymous"">
								   <style>

										/* General */

										.container-fluid {{ padding: 0rem; margin: 0rem; }}
										.flip {{-moz-transform: scaleX(-1); -o-transform: scaleX(-1); -webkit-transform: scaleX(-1); transform: scaleX(-1); filter: FlipH; -ms-filter: ""FlipH"";}}

										.pointer {{ cursor: pointer }}

										ol.testruns {{ margin: 1rem 0rem 1rem 0rem; }}
										ol.areas {{ margin: 1rem 0rem 1rem 0rem; }}
										ol.features {{ margin: 0rem 0rem 1rem 0rem; }}
										ol.scenarios {{ margin: 0rem 0rem 1rem 0rem; }}
										ol.steps {{ margin: 0rem 0rem 1rem 0rem;}}

										li.testrun {{ margin: 1rem 0rem 0rem 0rem; padding: 1rem 0rem 0rem 0rem; }}
										li.area {{ margin: .75rem 0rem 0rem 0rem; border-top: rgb(183, 207, 248) solid 1px; padding: .75rem 0rem 0rem 0rem; }}
										li.feature {{ margin: 0rem 0rem 0rem 0rem; }}
										li.scenario {{ margin: 0rem 0rem 0rem 0rem; }}
										li.step {{ margin: 0rem 0rem 0rem 0rem; }}

										div.badge-distro {{ display: inline-block; vertical-align: middle; }}
										div.testrun.badge-distro {{ width: 6rem; height: 2rem; }}
										div.area.badge-distro {{ width: 6rem; height: 2rem; }}
										div.feature.badge-distro {{ width: 6rem; height: 2rem; }}
										div.scenario.badge-distro {{ width: 6rem; height: 1.5rem; }}
										div.step.badge-distro {{ width: 6rem; height: 1rem; }}

										div.badges {{ flex: 0 0 11rem; }}
										div.badge {{ background-color: #80808029; border: 1px white solid; width: 1.5rem; height: 1.5rem; vertical-align: middle; }}
										div.badge:hover {{ background-color: #4343af }}
										div.badge.label {{ width: 100%; height: 100%; vertical-align: middle; }}
										div.testrun.badge {{ width: 4.5rem; height: 2rem; position: absolute; font-size: 1.25rem; }}
										div.area.badge {{ width: 4.5rem; height: 2rem; position: absolute; font-size: 1.25rem;  }}
										div.feature.badge {{ width: 4rem; margin-left: .25rem; height: 1.75rem; position: absolute; font-size: 1rem;  }}
										div.scenario.badge {{ width: 3rem; margin-left: .75rem; position: inherit; }}
										div.step.badge {{ width: 2rem; margin-left: 1.25rem; position: inherit; }}

										span.step.reason {{ font-size: 1rem; color: gray; font-weight: 100; }}

										div.distro {{ display: inline-block; border: 1px solid white; }}
										div.testrun.distro {{ width: 3rem; height: 2rem; margin-left: 3rem; }}
										div.area.distro {{ width: 3rem; height: 2rem; margin-left: 3rem; }}
										div.feature.distro {{ width: 3rem; height: 1.75rem; margin-left: 3rem; }}

										div.feature-statement-link.badge {{ position: inherit; width: 1.5rem; height: 1.5rem; vertical-align: top; }}
										a.step-input-link {{ font-size: 1rem; color: gray !important; vertical-align: text-top; font-weight: 100; }}
										a.step-output-link {{ font-size: 1rem; color: gray !important; vertical-align: text-top; font-weight: 100; }}
										a.step-exception-link {{ font-size: 1rem; color: gray !important; vertical-align: text-top; font-weight: 100; }}

										span.name {{ vertical-align: top; }}
										span.testrun.name {{ font-size: 2rem; font-weight: 400; margin-left: .75rem; }}
										span.area.name {{ font-size: 1.5rem; font-weight: 400; color: rgb(68,114,198); }}
										span.feature.name {{ font-size: 1.25rem; font-weight: 400; color: rgb(68,114,198); }}
										span.scenario.name {{ font-size: 1.25rem; font-weight: 400; vertical-align: middle; font-style: italic; color: rgb(68,114,198) }}
										span.step.name {{ font-size: 1rem;  font-weight: 400; }}

										span.assignments {{ float: right; color: Gray; font-size: 1rem; }}
										span.tags {{ float: right; margin-right: .5rem; color: Gray; font-size: 1rem; }}

										div.reason-duration {{ flex: 0 0 6rem; font-size: 1rem; color: gray; vertical-align: text-top; white-space: nowrap; }}
										span.step.reason-duration {{ font-size: 1rem; color: gray; font-weight: 100; }}

										span.step.duration {{ font-size: 1rem; color: gray; font-weight: 100; }}

										/* Stats */

										.stats-graph-tables {{ border-top: 0.5rem; }}
										.table {{ margin: 2px !important; }}
										.table th, .table td {{ border-top: none !important; line-height: 1 !important; padding: 0px 10px !important; }}
										td.graph td {{ padding: 0px !important; }}
										.table td.bar {{ padding: 0px !important; }}
										div.distro-corner-tr {{ position: absolute; margin-left: 5.35rem; width: 10px; height: 10px; background: url(""data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABQAAAATCAMAAAHQVe0RAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAVUExURQAAAP///////////////////////0jPbQQAAAAGdFJOUwC81uLs9S3UunwAAAAJcEhZcwAAEk0AABJNAfOXxKcAAABZSURBVBhXlY7bDsAgCEOdSv//k22RLZjx4jFKabjYwCP0miuyrQ215fxl8LJZQVQlIvmALzCwLUkJMnJlxEuOYcc2TLeDSaOhR/bR0Z6QicK6o5xZbv//E1gwYwFZkRA8AQAAAABJRU5ErkJggg=="") no-repeat top right; }}
										div.distro-corner-br {{ position: absolute; margin-left: 5.35rem; width: 10px; height: 10px; background: url(""data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABQAAAATCAMAAAHQVe0RAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAVUExURQAAAP///////////////////////0jPbQQAAAAGdFJOUwC81uLs9S3UunwAAAAJcEhZcwAAEk0AABJNAfOXxKcAAABZSURBVBhXlY7bDsAgCEOdSv//k22RLZjx4jFKabjYwCP0miuyrQ215fxl8LJZQVQlIvmALzCwLUkJMnJlxEuOYcc2TLeDSaOhR/bR0Z6QicK6o5xZbv//E1gwYwFZkRA8AQAAAABJRU5ErkJggg=="") no-repeat bottom right; }}
										div.testrun.distro-corner-tr {{ margin-top: .05rem; }}
										div.testrun.distro-corner-br {{ margin-top: 1.32rem; }}
										div.area.distro-corner-tr {{ margin-top: .05rem; }}
										div.area.distro-corner-br {{ margin-top: 1.32rem; }}
										div.feature.distro-corner-tr {{ margin-top: .06rem; }}
										div.feature.distro-corner-br {{ margin-top: 1.1rem; }}
			
										div#report-dates {{ margin: 0rem 0rem .5rem 5rem; }}

										/* Statements and Explanation */
										div.statement {{ margin: 1rem 0rem; border: lightgray solid 1px; padding: 1rem; }}
										div.explanation {{ margin: 1rem 0rem; border: lightgray solid 1px; padding: 1rem; }}

										/* Exceptions */

										div.exception {{ margin: 1rem 0rem; border: #dc3545 solid 1px; padding: 1rem; }}
										dl.exception dt {{ margin-bottom: .25rem; }}
										dl.exception-type, dl.exception-message, dl.exception-stack {{ padding: .5rem; }}
										dl.exception-type pre, dl.exception-message pre, dl.exception-stack pre {{ padding: .5rem; }}

										/* Input, and Output */

										div.output {{ margin: 1rem 0rem; }}
										iframe {{ border: 1px solid gray; resize: both; overflow: auto; }}
										pre {{ white-space: pre !important; }}
										pre.input {{ margin: 1rem 0rem; }}
										pre.output {{ margin: 1rem 0rem; }}
										pre.prettyprint {{  background-color: #eee; }}
										.linenums li {{ list-style-type: decimal !important; }}".RemoveIndentation(4,true));
			this.sortedReasons.ForEach(reason => {
				sb.AppendLine($@"
										.reason-{reason.Reason.EncodeCSSClassName()} {{ background-color: {reason.BackgroundColor} !important; color: {reason.FontColor} !important;}}".RemoveIndentation(4,true));
			});
			sb.AppendLine(@"
									</style>
								</header>".RemoveIndentation(4,true));
		}

		internal void WriteBodyStart(StringBuilder sb)
		{
			sb.AppendLine($@"
				<body>
					<script language=""javascript"" type=""text/javascript"">
						function resizeIframe(obj) {{ 
							obj.style.height = obj.contentWindow.document.body.scrollHeight + 'px'; 
						}}
					</script>".RemoveIndentation(4,true));
		}

		internal void WriteBodyEnd(StringBuilder sb)
		{
			sb.AppendLine(@"
					<script>
						function toggleVisibility(elementId, resize, iFrameId) {{
							var x = document.getElementById(elementId);
							if (x.style.display === ""none"") {{
								x.style.display = ""block"";
								if(resize) {
									resizeIframe(document.getElementById(iFrameId));
								}
							}} else {{
								x.style.display = ""none"";
							}}
						}}
					</script>
					<script src=""https://cdn.rawgit.com/google/code-prettify/master/loader/run_prettify.js""></script>
				</body>".RemoveIndentation(4, true));
		}

		internal void WriteNavBarStart(StringBuilder sb, bool failuresOnly)
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
		}

		internal void WriteNavBarEnd(StringBuilder sb)
		{
			sb.Append($@"
							</div>
						</div>
					</nav>".RemoveIndentation(4, true));
		}
		internal void WriteDuration(
			StringBuilder sb, 
			string objectType, 
			DateTime endTime, 
			DateTime startTime, 
			string reasonReplacement = null
		) {
			var duration = endTime - startTime;
			var formattedDuration = duration.TotalMilliseconds.ToString("N", System.Globalization.CultureInfo.InvariantCulture);
			formattedDuration = formattedDuration.Substring(0, formattedDuration.Length-3);
			sb.Append($@"
				<div class=""col-2 {objectType} reason-duration text-right"">
					<span class=""{objectType} duration"">[{formattedDuration} ms]</span>
				</div>".RemoveIndentation(4, true));
		}

		internal void WriteStartTime(StringBuilder sb, DateTime startTime) {
			if(startTime != DateTime.MinValue) {
				sb.AppendLine($@"
						<div id=""report-dates"" style=""margin-top: 0px !important;"">
							<div id=""report-start-date"" title=""Start Time"">{startTime.ToString("yyyy-MM-dd hh:mm tt \"GMT\"zzz")}</div>
						</div>
				".RemoveIndentation(4,true));
			}
		}

		internal void WriteLineItem(
			StringBuilder sb, 
			HtmlReportLineItem lineItem,
			bool failuresOnly,
			bool statsExpanded,
			bool childrenExpanded) 
		{
			this.lineItemNumber++;
			var statementAndExplanationLink = lineItem.Statement != null || lineItem.Explanation != null;
			var inputLink = lineItem.Input != null;
			var outputLink = lineItem.Output != null;

			sb.AppendLine($@"
				<li class=""lineitem {lineItem.TypeName.ToLower()} row align-items-center"" id=""{lineItem.TypeName.ToLower()}-{this.lineItemNumber}"">".RemoveIndentation(4,true));

			WriteBadge(sb, lineItem);

			if(String.IsNullOrEmpty(lineItem.Name)) {
				lineItem.Name = "[Missing! (or Full Name Skipped)]";
			}

			sb.AppendLine($@"
					<div class=""col"">".RemoveIndentation(4));
			var name = lineItem.Name;
			if(lineItem.TypeName == "area") {
				name = name.Replace(config.RootNameSkip, "");
			}
			if(lineItem.FilePath != null) {
				sb.AppendLine($@"
						<a class=""{lineItem.TypeName} name pointer"" 
							id=""area-{this.lineItemNumber}-name""
							href=""{lineItem.FilePath}"">{name}</a>".RemoveIndentation(4, true));
			} else {
				if(lineItem.ChildTypeName != null) {
					sb.AppendLine($@"
						<span class=""{lineItem.TypeName} name pointer"" 
							id=""{lineItem.TypeName}-{this.lineItemNumber}-name""
							onclick=""toggleVisibility('{lineItem.TypeName.ToLower()}-{this.lineItemNumber}-{lineItem.ChildTypeName.ToLower()}')""
							href=""#{lineItem.TypeName.ToLower()}-{this.lineItemNumber}-{lineItem.ChildTypeName.ToLower()}"">{name}</span>".RemoveIndentation(4, true));
				} else {
					sb.AppendLine($@"
						<span class=""{lineItem.TypeName} name pointer"" 
							id=""{lineItem.TypeName}-{this.lineItemNumber}-name"">{name}</span>".RemoveIndentation(4, true));
				}
			}
			if(lineItem.Assignments != null && lineItem.Assignments.Count > 0) {
				sb.Append($@"
						<span class=""{lineItem.TypeName} assignments"" 
							id=""{lineItem.TypeName}-{this.lineItemNumber}-assignments"">[".RemoveIndentation(6, true));
				lineItem.Assignments.ForEach(assignment => {
						sb.Append($@"{(lineItem.Assignments.IndexOf(assignment)==0?"":", ")}{assignment.HtmlEncode()}");
				});
				sb.AppendLine($@"
						]</span>".RemoveIndentation(6, true));
			}
			if(lineItem.Tags != null && lineItem.Tags.Count > 0) {
				sb.Append($@"
						<span class=""{lineItem.TypeName} tags"" 
							id=""{lineItem.TypeName}-{this.lineItemNumber}-tags"">[".RemoveIndentation(6, true));
				lineItem.Tags.ForEach(tag => {
						sb.Append($@"{(lineItem.Tags.IndexOf(tag)==0?"":", ")}{tag.HtmlEncode()}");
				});
				sb.AppendLine($@"
						]</span>".RemoveIndentation(6, true));
			}
			sb.AppendLine($@"
					</div>".RemoveIndentation(4));

			WriteDuration(sb, lineItem.TypeName.ToLower(), lineItem.EndTime, lineItem.StartTime);

			sb.AppendLine($@"
				</li>".RemoveIndentation(4));

			if(lineItem.TypeName != "step") {
				WriteStats(sb, lineItem.TypeName, lineItem.ReasonStats, statsExpanded);
			}

			WriteStatement(sb, lineItem);

			WriteException(sb, lineItem, lineItem.Exception, false);

			WriteInputOrOutput(sb, lineItem, true);
			
			WriteInputOrOutput(sb, lineItem, false);

			if(lineItem.ChildTypeName != null) {
				var expanded = (lineItem.Outcome == Outcome.Failed && failuresOnly) || childrenExpanded;
				var display = expanded ? "block" : "none";
				var childClassName = $"{lineItem.ChildTypeName.ToLower()} list-unstyled";
				sb.AppendLine($@"
					<li class=""row children"">
						<div class=""col-12"">
							<ol class=""{childClassName} container-fluid""
								id=""{lineItem.TypeName.ToLower()}-{this.lineItemNumber}-{lineItem.ChildTypeName.ToLower()}""
								style=""display: {display}"">".RemoveIndentation(4));
				foreach(var item in lineItem.ChildItems) {
					WriteLineItem(sb, item, failuresOnly, false, false);
				}
				sb.AppendLine($@"
							</ol>
						</div>
					</li>".RemoveIndentation(4));
				}
		}
		internal void WriteBadge(
			StringBuilder sb, 
			HtmlReportLineItem lineItem) 
		{
			var statementAndExplanationLink = lineItem.Statement != null || lineItem.Explanation != null;
			var total = 0;
			if(lineItem.ReasonStats.ContainsKey("Scenarios")) {
				foreach(var reasonStat in lineItem.ReasonStats["Scenarios"].Values) {
					total = total + reasonStat;
				}
			}
			sb.AppendLine($@"
				<div class=""col-2 badges"">".RemoveIndentation(4,true));

			if(lineItem.TypeName == "testrun" || lineItem.TypeName == "area" || lineItem.TypeName == "feature" ) {
				sb.AppendLine($@"
					<div class=""{lineItem.TypeName} badge-distro""
						id=""{lineItem.TypeName}-{this.lineItemNumber}-badge-distro""
						title=""{lineItem.Reason} Count: Scenarios""
						onclick=""toggleVisibility('{lineItem.TypeName}-{this.lineItemNumber}-stats')"">
						<div class=""{lineItem.TypeName} badge badge-pill pointer total reason-{lineItem.Reason.EncodeCSSClassName()}""
							id=""{lineItem.TypeName}-{this.lineItemNumber}-badge"">{(lineItem.TypeName == "step" ? " " : total.ToString())}</div>".RemoveIndentation(4,true));
				if(lineItem.TypeName != "scemario" && lineItem.TypeName != "step") {
					sb.AppendLine($@"
						<div class=""{lineItem.TypeName} distro-corner-tr"">
						</div>
						<div class=""{lineItem.TypeName} distro-corner-br"">
						</div>
						<div class=""{lineItem.TypeName} distro pointer""
							id=""{lineItem.TypeName}-{this.lineItemNumber}-distro"">".RemoveIndentation(4,true));

					foreach(var sortedReason in this.sortedReasons) {
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
				if(lineItem.TypeName == "scenario" || lineItem.Exception == null) {
					var childTotal = lineItem.ChildItems.Count;
					sb.AppendLine($@"
						<div class=""{lineItem.TypeName} badge badge-pill pointer total reason-{lineItem.Reason.EncodeCSSClassName()}""
							id=""{lineItem.TypeName}-{this.lineItemNumber}-badge"">{(lineItem.TypeName == "step" ? " " : childTotal.ToString())}</div>".RemoveIndentation(4,true));
				} else {
					sb.AppendLine($@"
						<div class=""{lineItem.TypeName} badge badge-pill pointer exception-link reason-{lineItem.Reason.EncodeCSSClassName()}"" 
							id=""{lineItem.TypeName}-{this.lineItemNumber}-exception-link"" 
							onclick=""toggleVisibility('{lineItem.TypeName}-{this.lineItemNumber}-exception')"">
							<i class=""fas fa-bug""></i>
						</div>".RemoveIndentation(4,true));
				}
			}

			if(statementAndExplanationLink) {
				sb.AppendLine($@"
					<div class=""{lineItem.TypeName}-statement-link badge pointer badge-secondary"" 
						id=""{lineItem.TypeName}-{this.lineItemNumber}-statement-link"" 
						onclick=""toggleVisibility('{lineItem.TypeName}-{this.lineItemNumber}-statement-explanation')"">
						<i class=""fas fa-info""></i>
					</div>".RemoveIndentation(4,true));
			}
			if(!string.IsNullOrEmpty(lineItem.Input)) {
				sb.AppendLine($@"
					<div class=""{lineItem.TypeName}-input-link badge pointer badge-secondary"" 
						id=""{lineItem.TypeName}-{this.lineItemNumber}-input-link"" 
						onclick=""toggleVisibility('{lineItem.TypeName}-{this.lineItemNumber}-input', true, 'iframe{this.lineItemNumber}')"">
						<i class=""fas fa-sign-in-alt""></i>
					</div>".RemoveIndentation(4,true));
			}
			if(!string.IsNullOrEmpty(lineItem.Output)) {
				sb.AppendLine($@"
					<div class=""{lineItem.TypeName}-output-link badge pointer badge-secondary"" 
						id=""{lineItem.TypeName}-{this.lineItemNumber}-output-link"" 
						onclick=""toggleVisibility('{lineItem.TypeName}-{this.lineItemNumber}-output', true, 'iframe{this.lineItemNumber}')"">
						<i class=""fas fa-sign-out-alt""></i>
					</div>".RemoveIndentation(4,true));
			}
			sb.AppendLine($@"
				</div>".RemoveIndentation(4,true));
		}

		internal void WriteStats(
			StringBuilder sb, 
			string objectType, 
			Dictionary<string, Dictionary<string, int>> reasonStats, 
			bool expanded = true) 
		{
			sb.AppendLine($@"
				<li class=""row stats"">
					<div class=""col-10 offset-1"">
						<div class=""stats-graph-tables"" id=""{objectType.ToLower()}-{this.lineItemNumber}-stats"" style=""width: 100%; empty-cells: show; display: {(expanded ? "block" : "none" )};"">
							<table class=""table table-condensed stats-table"">
								<tr id=""{objectType.ToLower()}-header-reason-stats"">
									<td class=""stats-label text-muted text-right"">&nbsp;</td>
									<td class=""text-center"" >Total</td>".RemoveIndentation(4,true));
			foreach(string key in this.sortedReasons.Select(x => x.Reason)) {
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

		internal void WriteReasonStatsLine(StringBuilder sb, Dictionary<string, int> stats, int baseIndent, string id, string label) {
			sb.AppendLine($@"
					<tr id=""{id}"">
						<td class=""stats-label text-muted text-right"" style=""width: 0%; padding-left: 0px !important;"">{label}</td>".RemoveIndentation(4,true));
			var total = stats.Values.Sum();
			var percentWidth = 100 / (this.sortedReasons.Count() + 1);
			sb.AppendLine($@"
						<td class=""text-center"" style=""width: {percentWidth}%;"">{total.ToString()}</td>".RemoveIndentation(4,true));
			foreach(string key in this.sortedReasons.Select(x => x.Reason)) {
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
		internal void WriteReasonGraphLine(StringBuilder sb, Dictionary<string, int> stats, int baseIndent, string id, string label) {
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
				foreach(string key in this.sortedReasons.Select(x => x.Reason)) {
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
			if(lineItem.Statement != null || lineItem.Explanation != null)
			{
				sb.AppendLine($@"
					<li class=""row statement-explanation"">
						<div class=""col-9 offset-2"">
							<div class=""{lineItem.TypeName} statement-explanation"" 
								id=""{lineItem.TypeName}-{this.lineItemNumber}-statement-explanation""
								style=""display: none;"">".RemoveIndentation(4,true));
				if(lineItem.Statement != null) {
					sb.AppendLine($@"<div class=""{lineItem.TypeName} statement rounded""
									id=""{lineItem.TypeName}-{this.lineItemNumber}-statement"">{lineItem.Statement}</div>");
				}
				if(lineItem.Explanation != null) {
					sb.AppendLine($@"<div class=""{lineItem.TypeName} explanation rounded""
									id=""{lineItem.TypeName}-{this.lineItemNumber}-explanation"">{Markdown.ToHtml(lineItem.Explanation)}</div>");
				}
				sb.AppendLine($@"
							</div>
						</div>
					</li>".RemoveIndentation(4, true));
			}
		}
		void WriteException(StringBuilder sb, HtmlReportLineItem lineItem, Exception exception, bool innerException = false) {
			if (exception != null && lineItem.Outcome != Outcome.Skipped) {
				if(!innerException)
				{
					sb.AppendLine($@"
					<li class=""row exception"">
						<div class=""col-9 offset-2"">
							<div class=""exception"" 
								id=""{lineItem.TypeName}-{this.lineItemNumber}-exception""
								style=""display: none;"">".RemoveIndentation(4, true));
				}
					sb.AppendLine($@"
								<dl class=""exception dl-horizontal rounded"">
									<dt>Error Type</dt><dd class=""exception-type"">{exception.GetType().Name.HtmlEncode()}</dd>
									<dt>Message</dt><dd class=""exception-message bg-light""><pre><code>{exception.Message.HtmlEncode()}</code></pre></dd>
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
					</li>".RemoveIndentation(4, true));
				}
			}
		}
		void WriteInputOrOutput(StringBuilder sb, HtmlReportLineItem lineItem, bool input) {
			var text = "";
			TextFormat format = new TextFormat();
			if(input) {
				text = lineItem.Input;
				format = lineItem.InputFormat;
			} else {
				text = lineItem.Output;
				format = lineItem.OutputFormat;
			}
			if (!String.IsNullOrEmpty(text))
			{
				sb.AppendLine($@"
					<li class=""row {(input ? "input" : "output" )}"">
						<div class=""col-9 offset-2"">
							<div class=""{(input ? "input" : "output" )}"" 
								id=""{lineItem.TypeName}-{this.lineItemNumber}-{(input ? "input" : "output" )}""
								style=""display: none;"">
								<div class=""{(input ? "input" : "output" )} title"" 
									id=""step-{this.lineItemNumber}-{(input ? "input" : "output" )}-title"">{(input ? "Input" : "Output" )}<div>".RemoveIndentation(4, true));
				if(format == TextFormat.htmlpreview)
				{
					WriteInputOrOutputWithHtmlPreview(sb, lineItem, input);
				}
				else
				{
					var className = $"{(input ? "input" : "output" )} prettyprint linenums rounded";
					if (format != TextFormat.code)
						className = className + " lang-" + Enum.GetName(typeof(TextFormat), format);
					sb.AppendLine($@"
									<pre class=""{className}"" id=""{(input ? "input" : "output" )}-{this.lineItemNumber}"">{text.HtmlEncode().AddIndentation(4)}</pre>".RemoveIndentation(4, true));
				}
				sb.AppendLine($@"
							</div>
						</div>
					</li>".RemoveIndentation(4, true));
			}
		}

		void WriteInputOrOutputWithHtmlPreview(StringBuilder sb, HtmlReportLineItem lineItem, bool input) {
			var function = (input? "input": "output");
			var previewCode = (input? lineItem.Input.HtmlEncode() : lineItem.Output.HtmlEncode());
			var previewHtml = (input? lineItem.Input : lineItem.Output)
				.Replace(System.Environment.NewLine, " \\" + System.Environment.NewLine)
				.Replace(":", "\\:")
				.Replace("/", "\\/")
				.Replace("!", "\\!")
				.Replace("\"", "\\\"");
			var html = $@"
				<div class=""{function} rounded"">
					<div class=""nav nav-tabs"" role=""tablist"">
						<a
							id=""preview{this.lineItemNumber}-tab""
							class=""nav-item nav-link active pointer"" 
							onclick=""toggleVisibility('preview{this.lineItemNumber}', true, 'iframe{this.lineItemNumber}'); toggleVisibility('code{this.lineItemNumber}')"">Preview</a>
						<a
							id=""code{this.lineItemNumber}-tab""
							class=""nav-item nav-link pointer"" 
							onclick=""toggleVisibility('preview{this.lineItemNumber}', true, 'iframe{this.lineItemNumber}'); toggleVisibility('code{this.lineItemNumber}')"">Code</a>
					</div>
					<div class=""tab-content"">
						<div role=""tabpanel"" 
							class=""tab-pane active"" 
							style=""display: block;""
							id=""preview{this.lineItemNumber}"">
							<iframe width=""100%"" id=""iframe{this.lineItemNumber}""></iframe>
							<script type=""text/javascript"">
								var iframe{this.lineItemNumber}doc = document.getElementById('iframe{this.lineItemNumber}').contentWindow.document;
								iframe{this.lineItemNumber}doc.open();
								var html{this.lineItemNumber} = ""{previewHtml.AddIndentation(4)}"";
								iframe{this.lineItemNumber}doc.write(html{this.lineItemNumber});
								resizeIframe(document.getElementById('iframe{this.lineItemNumber}'));
								iframe{this.lineItemNumber}doc.close();
							</script>
						</div>
						<div role=""tabpanel"" 
							class=""tab-pane"" 
							style=""display: none;""
							id=""code{this.lineItemNumber}"">
							<pre class=""{function} prettyprint linenums lang-html"">{previewCode.AddIndentation(4)}</pre>
						</div>
					</div>
				</div>".RemoveIndentation(4, true);
			sb.AppendLine(html);
		}
	}
}