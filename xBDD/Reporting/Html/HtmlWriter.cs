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
		public HtmlWriter(List<ReportReasonConfiguration> sortedReasons) {
			this.sortedReasons = sortedReasons;
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
        internal void WriteHeader(StringBuilder sb, ITestRunReportConfiguration config)
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

										.container {{ padding: 0rem; margin: 0rem; }}

										span.badge-distro {{ display: inline-block; vertical-align: bottom; }}
										span.badge {{ margin-left: .25rem; background-color: gray; position: absolute; border: 1px white solid; }}
										span.name {{ vertical-align: top; }}
										span.distro {{ display: inline-block; border: 1px solid white; }}
										span.status {{ font-size: 1rem; color: gray; vertical-align: text-top; }}
										span.reason {{ font-size: 1rem; color: gray; vertical-align: text-top; }}
										span.duration {{ font-size: 1rem; color: gray; vertical-align: text-top; }}

										.pointer {{ cursor: pointer }}
										span.oi.oi-info {{ font-size: 80% }}

										h2 {{ margin: 1rem 0rem 0rem 0rem; font-size: 1.5rem; font-weight: 400; border-top: rgb(68,114,198) solid 1px; padding: 1rem 0rem 0rem 0rem; }}
										h3 {{ margin: .75rem 0rem 0rem 0rem; font-size: 1.25rem; font-weight: 400; }}
										h4 {{ margin: .5rem 0rem 0rem 0rem; font-size: 1.25rem; font-weight: 400; }}
										h5 {{ margin: .25rem 0rem 0rem 0rem; font-size: 1rem; }}

										/* Stats */

										.table {{ margin: 0px !important; }}
										.table th, .table td {{ border-top: none !important; line-height: 1 !important; padding: 0px 2px !important; }}
										td.graph td {{ padding: 0px !important; }}
										.table td.bar {{ padding: 0px !important; }}
			
								   		/* Report */
										
										h1.report-name {{ margin: .5rem 0rem 0rem 0rem; }}
										span.report.badge-distro {{ width: 6rem; height: 3rem; }}
										span.report.badge {{ width: 4.5rem; height: 3rem; }}
										span.report.distro {{ width: 3rem; height: 3rem; margin-left: 3rem; }}
										span.report.name {{ margin-left: .75rem; }}

										div#report-dates {{ margin: 0rem 0rem .5rem 5rem; }}

										/* Test Run */

										ol.testruns {{ margin: 1rem 0rem 1rem 0rem; }}
										span.testrun.badge-distro {{ width: 6rem; height: 2rem; }}
										span.testrun.badge {{ width: 4.5rem; height: 2rem; }}
										span.testrun.distro {{ width: 3rem; height: 2rem; margin-left: 3rem; }}
										span.testrun.name {{ margin-left: .75rem; }}

										/* Area */

										ol.areas {{ margin: 1rem 0rem 1rem 0rem; }}
										span.area.badge-distro {{ width: 6rem; height: 2rem; }}
										span.area.badge {{ width: 4.5rem; height: 2rem; }}
										span.area.distro {{ width: 3rem; height: 2rem; margin-left: 3rem; }}
										span.area.name {{ color: rgb(68,114,198); }}

										/* Feature */

										ol.features {{ margin: 1rem 0rem 1rem 0rem; }}
										span.feature.badge-distro {{ width: 6rem; height: 2rem; }}
										span.feature.badge {{ width: 4.5rem; height: 1.5rem; }}
										span.feature-statement-link.badge {{ position: inherit; width: 1.5rem; height: 1.5rem; vertical-align: top; }}
										span.feature.distro {{ width: 3rem; height: 1.5rem; margin-left: 3rem; }}
										span.feature.name {{ margin-left: .75rem; color: rgb(68,114,198); }}
										pre.feature-statement {{ margin: 0rem 0rem 1rem 3rem; padding: .5rem; }}

										/* Scenario */

										ol.scenarios {{ margin: 1rem 0rem 1rem 0rem; }}
										span.scenario.badge {{ width: 3rem; margin-left: 3rem; position: inherit; }}
										span.scenario.name {{ margin-left: .75rem; vertical-align: middle; font-style: italic; color: rgb(68,114,198) }}
										span.scenario.reason {{ vertical-align: middle; }}
										span.scenario.duration {{ vertical-align: middle; }}

										/* Step */

										ol.steps {{ margin: 1rem 0rem 1rem 0rem;}}
										span.step.badge {{ width: 2rem; margin-left: 4rem; position: inherit; }}
										span.step.name {{ margin-left: .75rem; font-weight: 400; }}
										span.step.reason {{ font-size: 1rem; color: gray; font-weight: 100; }}
										span.step.duration {{ font-size: 1rem; color: gray; font-weight: 100; }}
										a.step-input-link {{ font-size: 1rem; color: gray !important; vertical-align: text-top; font-weight: 100; }}
										a.step-output-link {{ font-size: 1rem; color: gray !important; vertical-align: text-top; font-weight: 100; }}
										a.step-error-link {{ font-size: 1rem; color: gray !important; vertical-align: text-top; font-weight: 100; }}

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
										.badge.{reason.Reason} {{ background-color: {reason.BackgroundColor}; color: {reason.FontColor};}}".RemoveIndentation(5,true));
			});
			sb.AppendLine(@"
									</style>
								</header>".RemoveIndentation(4,true));
        }

        internal void WriteBodyStart(StringBuilder sb)
        {
            WriteTagOpen("body", sb, 0, "container-fluid", false);
        }

        internal void WriteBodyEnd(StringBuilder sb)
		{
			//            sb.AppendLine("    <script src=\"https://code.jquery.com/jquery-3.3.1.slim.min.js\" integrity=\"sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo\" crossorigin=\"anonymous\"></script>");
			//            sb.AppendLine("    <script src=\"https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js\" integrity=\"sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49\" crossorigin=\"anonymous\"></script>");
			//            sb.AppendLine("    <script src=\"https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js\" integrity=\"sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy\" crossorigin=\"anonymous\"></script>");
			sb.AppendLine(@"
					<script>
						function toggleVisibility(elementId) {{
							var x = document.getElementById(elementId);
							if (x.style.display === ""none"") {{
								x.style.display = ""block"";
							}} else {{
								x.style.display = ""none"";
							}}
						}}
					</script>
					<script src=""https://cdn.rawgit.com/google/code-prettify/master/loader/run_prettify.js""></script>
					<script language=""javascript"" type=""text/javascript"">
						function resizeIframe(obj) { 
							obj.style.height = obj.contentWindow.document.body.scrollHeight + 'px'; 
						}
					</script>
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

		internal void WriteDuration(StringBuilder sb, DateTime endTime, DateTime startTime, string objectTypeName) {
            var duration = endTime - startTime;
            var formattedDuration = duration.TotalMilliseconds.ToString("N", System.Globalization.CultureInfo.InvariantCulture);
            formattedDuration = formattedDuration.Substring(0, formattedDuration.Length-3);
			sb.Append($@"
				<span class=""{objectTypeName} duration"">[{formattedDuration} ms]</span>".RemoveIndentation(4,true));
		}

		internal void WriteReason(StringBuilder sb, string objectType, string reason) {
            if(reason != null) {
                sb.AppendLine($@"
								<span class=""{objectType} reason col-1"">[{reason.HtmlEncode()}]</span>".RemoveIndentation(5,true));
            } else {
				sb.AppendLine($@"<span class=""col-1""></span>");
			}
		}

		internal void WriteStartTime(StringBuilder sb, DateTime startTime) {
            if(startTime != DateTime.MinValue) {
				sb.AppendLine($@"
						<div id=""report-dates"" style=""margin-top: 0px !important;"">
							<span id=""report-start-date"" title=""Start Time"">{startTime.ToString("yyyy-MM-dd hh:mm tt \"GMT\"zzz")}</span>
						</div>
				".RemoveIndentation(5,true));
            }
		}

        internal void WriteBanner(
			StringBuilder sb, 
			string objectType,
			string name, 
			Outcome outcome, 
			string reason, 
			DateTime startTime, 
			DateTime endTime, 
			Dictionary<string, OutcomeStats> statistics,
			Dictionary<string, Dictionary<string,int>> reasonStats) 
		{
			WritePageHeader(sb, objectType, name, outcome, reason, endTime, startTime, reasonStats["Scenarios"]);

			WriteStartTime(sb, startTime);

			WriteStats(sb, objectType.ToLower(), 0, 1, statistics, reasonStats, false);
            
        }

		internal void WritePageHeader(
			StringBuilder sb, 
			string objectType, 
			string name, 
			Outcome outcome, 
			string reason, 
			DateTime endTime, 
			DateTime startTime, 
			Dictionary<string, int> scenarioReasonStats) 
		{
            WriteTagOpen("div", sb, 1, "page-header", false, null, "margin-top: 0px !important;");
            WriteTagOpen("h1", sb, 2, "report-name", false);

			// Badge
			WriteBadge(sb, objectType, 0, outcome, reason, scenarioReasonStats, false);

			WritePageTitle(sb, name);

			WriteReason(sb, "report", reason);
			
			WriteDuration(sb, endTime, startTime, "report");

            WriteTagClose("h1", sb, 2);
            WriteTagClose("div", sb, 1);
		}
		internal void WritePageTitle(StringBuilder sb, string name){
            WriteTag("span", sb, 3, "name", name.HtmlEncode(), false, true);
		}
        internal void WriteStatsTableStart(StringBuilder sb, int baseIndent, string id = null, Boolean collapsed = true) {
			var style = "width: 100%; empty-cells: show;";
			if(collapsed) {
				style = $"{style} display: none;"; 
			} else {
				style = $"{style} display: block;"; 
			}
            var collapse = (collapsed ? "collapse":"");
            WriteTagOpen("table", sb, baseIndent, $"table table-condensed {collapse}", false, id, style);
        }

		internal void WriteStats(
			StringBuilder sb, 
			string objectType, 
			int position, 
			int indentation, Dictionary<string, OutcomeStats> statistics, 
			Dictionary<string, Dictionary<string, int>> reasonStats, 
			bool collapsed = true) 
		{
			WriteStatsTableStart(sb, indentation, $"{objectType.ToLower()}-{position}-stats", collapsed);
			//foreach(string statsKey in statistics.Keys) {
			//	WriteStatsLine(sb, statistics[statsKey], 1, $"report-{statsKey.ToLower()}-stats", statsKey);
			//}
			WriteReasonStatsHeaderLine(sb, 1, $"report-header-reason-stats");
			foreach(string statsKey in reasonStats.Keys) {
				WriteReasonStatsLine(sb, reasonStats[statsKey], 1, $"report-{statsKey.ToLower()}-reason-stats", statsKey);
			}
            WriteStatsTableClose(sb, indentation);
		}

        internal void WriteStatsLine(StringBuilder sb, OutcomeStats stats, int baseIndent, string id, string label) {
            WriteTagOpen("tr", sb, baseIndent + 1, null, false, id);
            WriteTag("td", sb, baseIndent + 2, "stats-label text-muted text-right", label, false, true, null, "width: 0%; padding-left: 0px !important;");
            WriteTag("td", sb, baseIndent + 2, "passed success text-center", stats.Passed.ToString(), false, true, null, "width: 3.3333333333333%;");
            WriteTag("td", sb, baseIndent + 2, "skipped warning text-center", stats.Skipped.ToString(), false, true, null, "width: 3.3333333333333%;");
            WriteTag("td", sb, baseIndent + 2, "failed danger text-center", stats.Failed.ToString(), false, true, null, "width: 3.3333333333333%;");
            WriteTagOpen("td", sb, baseIndent + 2, "outcome-bar-chart", false, null, "width: 90%;");
            WriteTagOpen("table", sb, baseIndent, "table", false, null, "width: 100%; empty-cells: show; height: 14px;");
            WriteTagOpen("tr", sb, baseIndent + 1, null, false);
            
            if(stats.Total == 0)
            {
                WriteTag("td", sb, baseIndent + 2, "empty-bar", null, false, true, null, "width: 100%;");
            }
            else
            {
                double passedPercent = stats.Total == 0 ? 0 : (((double)stats.Passed / (double)stats.Total) * 100);
                var passedStyle = String.Format("width: {0}%", passedPercent);
                WriteTag("td", sb, baseIndent + 2, "bar passed-bar bg-success text-center", null, false, true, null, passedStyle);
                
                double skippedPercent = stats.Total == 0 ? 0 : (((double)stats.Skipped / (double)stats.Total) * 100);
                var skippedStyle = String.Format("width: {0}%", skippedPercent);
                WriteTag("td", sb, baseIndent + 2, "bar skipped-bar bg-warning text-center", null, false, true, null, skippedStyle);
                
                double failedPercent = stats.Total == 0 ? 0 : (((double)stats.Failed / (double)stats.Total) * 100);
                var failedStyle = String.Format("width: {0}%", failedPercent);
                WriteTag("td", sb, baseIndent + 2, "bar failed-bar bg-danger text-center", null, false, true, null, failedStyle);
            }

            WriteTagClose("tr", sb, baseIndent + 1);
            WriteTagClose("table", sb, baseIndent);
            WriteTagClose("td", sb, baseIndent + 1);
            WriteTagClose("tr", sb, baseIndent);
        }

        internal void WriteReasonStatsHeaderLine(StringBuilder sb, int baseIndent, string id) {
            WriteTagOpen("tr", sb, baseIndent + 1, null, false, id);
			WriteTag("td", sb, baseIndent + 2, "stats-label text-muted text-right", "&nbsp;", false, true, null, "width: 0%; padding-left: 0px !important;");
			foreach(string key in this.sortedReasons.Select(x => x.Reason)) {
				WriteTag("td", sb, baseIndent + 2, "text-center", key, false, true, null, "width: 3.3333333333333%;");
			}
            WriteTagOpen("td", sb, baseIndent + 2, "outcome-bar-chart", false, null, "width: 90%;");
            WriteTagOpen("table", sb, baseIndent, "table", false, null, "width: 100%; empty-cells: show; height: 14px;");
            WriteTagOpen("tr", sb, baseIndent + 1, null, false);
			WriteTag("td", sb, baseIndent + 2, "empty-bar", null, false, true, null, "width: 100%;");
            
            WriteTagClose("tr", sb, baseIndent + 1);
            WriteTagClose("table", sb, baseIndent);
            WriteTagClose("td", sb, baseIndent + 1);
            WriteTagClose("tr", sb, baseIndent);
        }
        internal void WriteReasonStatsLine(StringBuilder sb, Dictionary<string, int> stats, int baseIndent, string id, string label) {
            WriteTagOpen("tr", sb, baseIndent + 1, null, false, id);
			WriteTag("td", sb, baseIndent + 2, "stats-label text-muted text-right", label, false, true, null, "width: 0%; padding-left: 0px !important;");
			var total = 0;
			foreach(string key in this.sortedReasons.Select(x => x.Reason)) {
				if(stats.ContainsKey(key)) {
					WriteTag("td", sb, baseIndent + 2, "text-center", stats[key].ToString(), false, true, null, "width: 3.3333333333333%;");
					total = total + stats[key];
				} else {
					WriteTag("td", sb, baseIndent + 2, "text-center", 0.ToString(), false, true, null, "width: 3.3333333333333%;");
				}
			}
            WriteTagOpen("td", sb, baseIndent + 2, "outcome-bar-chart", false, null, "width: 90%;");
            WriteTagOpen("table", sb, baseIndent, "table", false, null, "width: 100%; empty-cells: show; height: 14px;");
            WriteTagOpen("tr", sb, baseIndent + 1, null, false);
            if(total == 0)
            {
                WriteTag("td", sb, baseIndent + 2, "empty-bar", null, false, true, null, "width: 100%;");
            }
            else
            {
				foreach(string key in this.sortedReasons.Select(x => x.Reason)) {
					if(stats.ContainsKey(key)) {
						var reasonConfig = this.sortedReasons.Where(x => x.Reason == key).FirstOrDefault();
						var styleBackground = "";
						if(reasonConfig != null) {
							styleBackground = reasonConfig.BackgroundColor;
						}
						double percent = stats[key] == 0 ? 0 : (((double)stats[key] / (double)total) * 100);
						var style = $"width: {percent}%; background-color: {styleBackground};";
						WriteTag("td", sb, baseIndent + 2, "bar text-center", null, false, true, null, style);
					} else {
						var style = $"width: 0%;";
						WriteTag("td", sb, baseIndent + 2, "bar text-center", null, false, true, null, style);
					}
				}
			}
            
            WriteTagClose("tr", sb, baseIndent + 1);
            WriteTagClose("table", sb, baseIndent);
            WriteTagClose("td", sb, baseIndent + 1);
            WriteTagClose("tr", sb, baseIndent);
        }

        internal void WriteStatsTableClose(StringBuilder sb, int baseIndent) {
            WriteTagClose("table", sb, baseIndent);
        }

        internal void WriteBadge(
			StringBuilder sb, 
			string objectType, 
			int position, 
			Outcome outcome,
			string reason,
			Dictionary<string, int> scenarioReasonStats,
			bool toggleStats) 
		{
			var baseClass = objectType;
			if(toggleStats == false)
				baseClass = "report";

            WriteTagOpen("span", sb, 0, $"{baseClass} badge-distro", true, $"{objectType}-{position}-badge-distro", null, " title=\"Scenarios\"", $"{objectType}-{position}-stats");

			var total = 0;
			foreach(var reasonStat in scenarioReasonStats.Values) {
				total = total + reasonStat;
			}
            //Create Badge with distribution 
            WriteTag("span", sb, 0, $"{baseClass} badge badge-pill pointer total {reason}",total.ToString(), true, true, $"{objectType}-{position}-badge", null, null, $"{objectType}-{position}-stats");
            WriteTagOpen("span", sb, 0, $"{baseClass} distro pointer", true, $"{objectType}-{position}-distro");
			foreach(var sortedReason in this.sortedReasons) {
				double stat = 0;
				if(scenarioReasonStats.ContainsKey(sortedReason.Reason)) {
					stat = ((double)scenarioReasonStats[sortedReason.Reason]/(double)total)*100;
	                WriteTag("div", sb, 0, "distro", null, true,  true, null, $"background-color: {sortedReason.BackgroundColor}; height: {stat}%; width: 100%;");
				}
			}
            WriteTagClose("span", sb, 0);//distribution graph
            WriteTagClose("span", sb, 0);//badge and distro graph
        }

        internal void WriteLineItemOpen(
			StringBuilder sb, 
			string typeName, 
			int itemNumber, 
			string name, 
			string filePath,
			Outcome outcome, 
			string reason, 
			DateTime startTime,
			DateTime endTime,
			int scenarioCount,
			string childType, 
			OutcomeStats childStats,
			Dictionary<string, OutcomeStats> statistics,
			Dictionary<string, Dictionary<string, int>> reasonStats,
			bool failuresOnly) 
		{
            WriteTagOpen("li", sb, 2, typeName.ToLower(), false, $"{typeName.ToLower()}-" + itemNumber);

			WriteLineItemTitleLine(sb, typeName, name, itemNumber, startTime, endTime, outcome, reason, reasonStats["Scenarios"], filePath, childType);

			WriteStats(sb, typeName, itemNumber, 3, statistics, reasonStats);

			WriteLineItemChildList(sb, typeName, itemNumber, outcome, failuresOnly, childType);
        }

		internal void WriteLineItemTitleLine(
			StringBuilder sb, 
			string typeName, 
			string name, 
			int itemNumber, 
			DateTime startTime, 
			DateTime endTime, 
			Outcome outcome,
			string reason, 
			Dictionary<string, int> scenarioReasonStats, 
			string filePath, 
			string childType) 
		{
            WriteTagOpen("h2", sb, 3, "title", true);

            WriteBadge(sb, typeName.ToLower(), itemNumber, outcome, reason, scenarioReasonStats, true);

			WriteLineItemName(sb, name, filePath, itemNumber, typeName, childType);

			WriteReason(sb, typeName.ToLower(), reason);
            
			WriteDuration(sb, endTime, startTime, typeName.ToLower());

            WriteTagClose("h2", sb, 3);
		}

		internal void WriteLineItemChildList(
			StringBuilder sb,
			string typeName,
			int itemNumber,
			Outcome outcome,
			bool failuresOnly,
			string childType
		) {
            var expanded = outcome == Outcome.Failed && failuresOnly;
            var display = expanded ? "block" : "none";
            var childClassName = $"{childType.ToLower()} list-unstyled";
            //var style = $"border-left: 2px solid lightGray; display: {display};";
            var style = $"display: {display};";
            WriteTagOpen("ol", sb, 3, childClassName, false, $"{typeName.ToLower()}-{itemNumber}-{childType.ToLower()}", style);
		}

		internal void WriteLineItemName(StringBuilder sb, string name, string filePath, int itemNumber, string typeName, string childType){
            if(name.Length == 0) {
                name = "[Missing! (or Full Name Skipped)]";
            }
			if(filePath != null) {
				var titleAttributes = $" href=\"{filePath}\"";
	            WriteTag("a", sb, 4, $"{typeName} name pointer", name.HtmlEncode(), false, true,  $"area-{itemNumber}-name", null, titleAttributes);
			} else {
	            WriteTag("span", sb, 4, $"{typeName} name pointer", name.HtmlEncode(), false, true,  $"area-{itemNumber}-name", null, null, $"{typeName.ToLower()}-{itemNumber}-{childType.ToLower()}");
			}
		}
        internal void WriteLineItemClose(StringBuilder sb) {
            WriteTagClose("ol", sb, 3);
            WriteTagClose("li", sb, 2);
        }
        internal void WriteTag(string tag, StringBuilder sb, 
            int indentation, string className, string text, 
            bool inline, bool singleLine, string id = null, string style = null, string attributes = null, string toggleVisibility = null)
        {
            WriteTagOpen(tag, sb, indentation, className, singleLine, id, style, attributes, toggleVisibility);
            sb.Append(text);
            WriteTagClose(tag, sb, singleLine?0:indentation, inline);
        }
        internal void WriteTagOpen(string tag, StringBuilder sb, int indentation, 
            string className, bool inline, string id = null, 
            string style = "", string attributes = null, string toggleVisibility = null)
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
            if(toggleVisibility != null)
                sb.Append($" onclick=\"toggleVisibility('{toggleVisibility}')\"");
            if (inline)
                sb.Append(">");
            else
                sb.AppendLine(">");
        }
        internal void WriteTagClose(string tag, StringBuilder sb, int indentation, bool inline = false)
        {
            WriteIndentation(sb, indentation);
            sb.Append("</");
            sb.Append(tag);
			if(inline) {
	            sb.Append(">");
			} else {
	            sb.AppendLine(">");
			}
        }
        internal void WriteIndentation(StringBuilder sb, int indentation)
        {
            for (int i = 0; i < indentation; i++)
            {
                sb.Append("\t");
            }
        }

	}
}