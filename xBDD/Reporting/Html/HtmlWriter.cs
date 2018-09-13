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
							href=""https://cdnjs.cloudflare.com/ajax/libs/open-iconic/1.1.1/font/css/open-iconic-bootstrap.min.css"" 
							integrity=""sha256-BJ/G+e+y7bQdrYkS2RBTyNfBHpA9IuGaPmf9htub5MQ=\"" 
							crossorigin=""anonymous"" />
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
										ol.features {{ margin: 1rem 0rem 1rem 0rem; }}
										ol.scenarios {{ margin: 1rem 0rem 1rem 0rem; }}
										ol.steps {{ margin: 1rem 0rem 1rem 0rem;}}

										li.testrun {{ margin: 1rem 0rem 0rem 0rem; padding: 1rem 0rem 0rem 0rem; }}
										li.area {{ margin: 1rem 0rem 0rem 0rem; border-top: rgb(68,114,198) solid 1px; padding: 1rem 0rem 0rem 0rem; }}
										li.feature {{ margin: .75rem 0rem 0rem 0rem; }}
										li.scenario {{ margin: .5rem 0rem 0rem 0rem; }}
										li.step {{ margin: .25rem 0rem 0rem 0rem; }}

										div.badge-distro {{ display: inline-block; vertical-align: middle; }}
										div.testrun.badge-distro {{ width: 6rem; height: 2rem; }}
										div.area.badge-distro {{ width: 6rem; height: 2rem; }}
										div.feature.badge-distro {{ width: 6rem; height: 2rem; }}
										div.scenario.badge-distro {{ width: 6rem; height: 1.5rem; }}
										div.step.badge-distro {{ width: 6rem; height: 1rem; }}

										div.badge {{ background-color: #80808029; border: 1px white solid; width: 1.5rem; height: 1.5rem; vertical-align: middle; }}
										div.badge:hover {{ background-color: #4343af }}
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
										a.step-error-link {{ font-size: 1rem; color: gray !important; vertical-align: text-top; font-weight: 100; }}

										span.name {{ vertical-align: top; }}
										span.testrun.name {{ font-size: 2rem; font-weight: 400; margin-left: .75rem; }}
										span.area.name {{ font-size: 1.5rem; font-weight: 400; color: rgb(68,114,198); }}
										span.feature.name {{ font-size: 1.25rem; font-weight: 400; color: rgb(68,114,198); }}
										span.scenario.name {{ font-size: 1.25rem; font-weight: 400; vertical-align: middle; font-style: italic; color: rgb(68,114,198) }}
										span.step.name {{ font-size: 1rem;  font-weight: 400; }}

										span.assignments {{ vertical-align: sub; color: Gray; font-size: .75rem; }}
										span.tags {{ vertical-align: sub; color: Gray; font-size: .75rem; }}

										div.reason-duration {{ font-size: 1rem; color: gray; vertical-align: text-top; white-space: nowrap; }}
										span.step.reason-duration {{ font-size: 1rem; color: gray; font-weight: 100; }}

										span.step.duration {{ font-size: 1rem; color: gray; font-weight: 100; }}

										/* Stats */

										.table {{ margin: 2px !important; }}
										.table th, .table td {{ border-top: none !important; line-height: 1 !important; padding: 0px 10px !important; }}
										td.graph td {{ padding: 0px !important; }}
										.table td.bar {{ padding: 0px !important; }}
										li.stats {{ margin-top: .5rem; }}
			
										div#report-dates {{ margin: 0rem 0rem .5rem 5rem; }}

										/* Exceptions */

										dl.exception {{ margin: 1rem 3rem; padding: 1rem; }}
										dl.exception dt {{ margin-bottom: .25rem; }}
										dl.error-type, dl.error-message, dl.error-stack {{ padding: .5rem; }}
										dl.error-type pre, dl.error-message pre, dl.error-stack pre {{ padding: .5rem; }}

										/* Input, and Output */

										iframe {{ border: 1px solid gray; resize: both; overflow: auto; }}
										pre {{ white-space: pre !important; }}
										pre.input {{ margin: 1rem auto; width: 95%; }}
										pre.output {{ margin: 1rem auto; width: 95%; }}
										pre.prettyprint {{  background-color: #eee; }}
										.linenums li {{ list-style-type: decimal !iinputortant;}}".RemoveIndentation(4,true));
			this.sortedReasons.ForEach(reason => {
				sb.AppendLine($@"
										.badge.{reason.Reason} {{ background-color: {reason.BackgroundColor}; color: {reason.FontColor};}}".RemoveIndentation(4,true));
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
							href=""{lineItem.FilePath}"">{name.HtmlEncode()}</a>".RemoveIndentation(4, true));
			} else {
				if(lineItem.ChildTypeName != null) {
					sb.AppendLine($@"
						<span class=""{lineItem.TypeName} name pointer"" 
							id=""{lineItem.TypeName}-{this.lineItemNumber}-name""
							onclick=""toggleVisibility('{lineItem.TypeName.ToLower()}-{this.lineItemNumber}-{lineItem.ChildTypeName.ToLower()}')""
							href=""#{lineItem.TypeName.ToLower()}-{this.lineItemNumber}-{lineItem.ChildTypeName.ToLower()}"">{name.HtmlEncode()}</span>".RemoveIndentation(4, true));
				} else {
					sb.AppendLine($@"
						<span class=""{lineItem.TypeName} name pointer"" 
							id=""{lineItem.TypeName}-{this.lineItemNumber}-name"">{name.HtmlEncode()}</span>".RemoveIndentation(4, true));
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
						<div class=""{lineItem.TypeName} badge badge-pill pointer total {lineItem.Reason}""
							id=""{lineItem.TypeName}-{this.lineItemNumber}-badge"">{(lineItem.TypeName == "step" ? " " : total.ToString())}</div>".RemoveIndentation(4,true));
				if(lineItem.TypeName != "scemario" && lineItem.TypeName != "step") {
					sb.AppendLine($@"
						<div class=""{lineItem.TypeName} distro pointer""
							id=""{lineItem.TypeName}-{this.lineItemNumber}-distro"">".RemoveIndentation(4,true));

					foreach(var sortedReason in this.sortedReasons) {
						double stat = 0;
						if(lineItem.ReasonStats.ContainsKey("Scenarios") && lineItem.ReasonStats["Scenarios"].ContainsKey(sortedReason.Reason)) {
							stat = ((double)lineItem.ReasonStats["Scenarios"][sortedReason.Reason]/(double)total)*100;
							sb.AppendLine($@"
							<div style=""background-color: {sortedReason.BackgroundColor}; height: {stat}%; width: 100%;""></div>".RemoveIndentation(4,true));
						}
					}
					sb.AppendLine($@"
						</div>
					</div>".RemoveIndentation(4,true));
				}
			} else {
				if(lineItem.TypeName == "scenario" || lineItem.Exception == null) {
					sb.AppendLine($@"
						<div class=""{lineItem.TypeName} badge badge-pill pointer total {lineItem.Reason}""
							id=""{lineItem.TypeName}-{this.lineItemNumber}-badge"">{(lineItem.TypeName == "step" ? " " : total.ToString())}</div>".RemoveIndentation(4,true));
				} else {
					sb.AppendLine($@"
						<div class=""{lineItem.TypeName} badge badge-pill pointer error {lineItem.Reason}"" 
							id=""{lineItem.TypeName}-{this.lineItemNumber}-badge"" 
							onclick=""toggleVisibility('{lineItem.TypeName}-{this.lineItemNumber}-error')"">
							<div class=""oi oi-bug"" aria-hidden=""true""></div>
						</div>".RemoveIndentation(4,true));
				}
			}

			if(statementAndExplanationLink) {
				sb.AppendLine($@"
					<div class=""{lineItem.TypeName}-statement-link badge pointer badge-secondary"" 
						id=""{lineItem.TypeName}-{this.lineItemNumber}-statement-link"" 
						onclick=""toggleVisibility('{lineItem.TypeName}-{this.lineItemNumber}-statement')"">
						<div class=""oi oi-info"" aria-hidden=""true""></div>
					</div>".RemoveIndentation(4,true));
			}
			if(lineItem.Input != null) {
				sb.AppendLine($@"
					<div class=""{lineItem.TypeName}-input-link badge pointer badge-secondary"" 
						id=""{lineItem.TypeName}-{this.lineItemNumber}-input-link"" 
						onclick=""toggleVisibility('{lineItem.TypeName}-{this.lineItemNumber}-input', true, 'iframe{this.lineItemNumber}')"">
						<div class=""oi oi-account-login"" aria-hidden=""true""></div>
					</div>".RemoveIndentation(4,true));
			}
			if(lineItem.Output != null) {
				sb.AppendLine($@"
					<div class=""{lineItem.TypeName}-output-link badge pointer badge-secondary"" 
						id=""{lineItem.TypeName}-{this.lineItemNumber}-output-link"" 
						onclick=""toggleVisibility('{lineItem.TypeName}-{this.lineItemNumber}-output', true, 'iframe{this.lineItemNumber}')"">
						<div class=""oi oi-account-logout flip"" aria-hidden=""true""></div>
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
									<td class=""text-center"">{key}</td>".RemoveIndentation(4,true));
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
						var styleBackground = "";
						if(reasonConfig != null) {
							styleBackground = reasonConfig.BackgroundColor;
						}
						double percent = stats[key] == 0 ? 0 : (((double)stats[key] / (double)total) * 100);
						style = $"width: {percent}%; background-color: {styleBackground};";
					} else {
						style = $"width: 0%;";
					}
					sb.AppendLine($@"
									<td class=""bar text-center"" style=""{style}""></td>".RemoveIndentation(4,true));
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
					<li class=""row statement explanation"">
						<div class=""col-10 offset-1"">
							<div class=""{lineItem.TypeName}-statement"" 
								id=""{lineItem.TypeName}-{this.lineItemNumber}-statement""
								style=""display: none;"">".RemoveIndentation(4,true));
				if(lineItem.Statement != null) {
					sb.AppendLine($@"<pre class=""{lineItem.TypeName}-statement bg-light rounded""
									id=""{lineItem.TypeName}-{this.lineItemNumber}-statement"">{lineItem.Statement}</pre>");
				}
				if(lineItem.Explanation != null) {
					sb.AppendLine($@"<pre class=""{lineItem.TypeName}-explanation bg-light rounded""
									id=""{lineItem.TypeName}-{this.lineItemNumber}-explanation"">{lineItem.Explanation}</pre>");
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
						<div class=""col-10 offset-1"">
							<div class=""error"" 
								id=""{lineItem.TypeName}-{this.lineItemNumber}-error""
								style=""display: none;"">".RemoveIndentation(4, true));
				}
					sb.AppendLine($@"
								<dl class=""exception dl-horizontal border border-danger rounded"">
									<dt>Error Type</dt><dd class=""error-type"">{exception.GetType().Name.HtmlEncode()}</dd>
									<dt>Message</dt><dd class=""error-message bg-light""><pre><code>{exception.Message.HtmlEncode()}</code></pre></dd>
									<dt>Stack</dt><dd class=""error-stack bg-light""><pre><code>{exception.StackTrace.AddIndentation(4).HtmlEncode()}</code></pre></dd>
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
						<div class=""col-10 offset-1"">
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