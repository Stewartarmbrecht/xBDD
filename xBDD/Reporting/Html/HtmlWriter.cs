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
        internal void WriteHtmlStart(StringBuilder sb)
        {
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html>");
        }
        internal void WriteHtmlEnd(StringBuilder sb)
        {
            sb.Append("</html>");
        }
        internal void WriteHeaderStart(string title, StringBuilder sb)
        {
            sb.AppendLine("<head>");
            sb.AppendLine("    <meta charset=\"utf-8\" />");
            sb.AppendLine("    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\" />");
            WriteTag("title", sb, 1, null, title.HtmlEncode(), false, true);
            sb.AppendLine("    <link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/open-iconic/1.1.1/font/css/open-iconic-bootstrap.min.css\" integrity=\"sha256-BJ/G+e+y7bQdrYkS2RBTyNfBHpA9IuGaPmf9htub5MQ=\" crossorigin=\"anonymous\" />");
            sb.AppendLine("    <link rel=\"stylesheet\" href=\"https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css\" integrity=\"sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO\" crossorigin=\"anonymous\">");
        }

        internal void WriteHeaderEnd(StringBuilder sb)
        {
            sb.AppendLine("</head>");
        }

        internal void WriteStyles(StringBuilder sb)
        {

            sb.Append("    <style>");
            sb.Append(" div#report-dates { margin: 0rem 0rem .5rem 5rem; }");
            sb.Append(" h1.report-name { margin: .5rem 0rem 0rem 0rem; }");
            sb.Append(" span.area.badge { width: 2.5rem; height: 1.5rem; position: absolute; border: 1px white solid; }");
            sb.Append(" span.badge-distro { width: 3.5rem; display: inline-block; height: 1.5rem; vertical-align: bottom; }");
            sb.Append(" span.area.stats { font-size: 75%; font-weight: 700; line-height: 1; text-align: center; white-space: nowrap; border-radius: .25rem; height: 1.5em; display: inline-block; width: 1.75rem; position: absolute; margin-left: 2rem; z-index: -1; vertical-align: middle; }");
            sb.Append(" span.feature.badge { width: 2.5rem; height: 1.5rem; position: absolute; border: 1px white solid; }");
            sb.Append(" span.scenario.badge { width: 2rem }");
            sb.Append(" span.duration { font-size: 1rem; color: gray; }");
            sb.Append(" span.reason { font-size: 1rem; color: gray; }");
            sb.Append(" span.status { font-size: 1rem; color: gray; }");
            sb.Append(" span.step.duration { font-size: .75rem; color: gray; }");
            sb.Append(" span.oi.oi-info { font-size: 80% }");
            sb.Append(" ol.areas { margin: .5rem 0rem; }");
            sb.Append(" ol.areas, ol.features, ol.scenarios, ol.steps { margin-left: 3rem; }");
            sb.Append(" span.badge { margin-left: .25rem; }");
            sb.Append(" span.distro { width: 1.5rem; height: 1.5rem; display: inline-block; margin-left: 2rem; border: 1px solid white; }");
            sb.Append(" span.name { margin-left: .75rem; }");
            sb.Append(" dl.exception { margin: 1rem 3rem; padding: 1rem; }");
            sb.Append(" dl.exception dt { margin-bottom: .25rem; }");
            sb.Append(" ol.features { margin-bottom: 2rem; }");
            sb.Append(" ol.scenarios { margin-bottom: 1.5rem; }");
            sb.Append(" ol.steps { margin-bottom: 1rem; }");
            sb.Append(" iframe { border: 1px solid gray; resize: both; overflow: auto; }");
            sb.Append(" h2, h3, h4, h5 { font-size: 1.25rem; margin: .5rem; font-weight: 400; }");
            sb.Append(" h5 { font-size: 1rem; margin: .25rem .75rem; }");
            sb.Append(" dl.error-type, dl.error-message, dl.error-stack { padding: .5rem; }");
            sb.Append(" dl.error-type pre, dl.error-message pre, dl.error-stack pre { padding: .5rem; }");
            sb.Append(" pre.feature-statement { margin: 0rem 0rem 1rem 3rem; padding: .5rem; }");
            sb.Append(" .table th, .table td { border-top: none !important; line-height: 1 !important; padding: 2px 10px !important; }");
            sb.Append(" td.graph td { padding: 0px !important; }");
            sb.Append(" .table { margin: 0px !important; }");
            sb.Append(" .table td.bar { padding: 0px !important; }");
            sb.Append(" .report-percent-bar { background-color: #56C1F7; }");
            sb.Append(" .area-percent-bar { background-color: #A4DEFB; }");
            sb.Append(" .pointer { cursor: pointer }");
            sb.Append(" pre { white-space: pre !important; }");
            sb.Append(" pre.input { margin: 1rem auto; width: 95%; }");
            sb.Append(" pre.output { margin: 1rem auto; width: 95%; }");
            sb.Append(" .collapsing { -webkit-transition: none; transition: none; display: none; }");
            sb.Append(" pre.prettyprint {  background-color: #eee; }");
            sb.Append(" .linenums li { list-style-type: decimal !iinputortant;}");
            sb.AppendLine("</style>");  
        }

        internal void WriteBodyStart(StringBuilder sb)
        {
            WriteTagOpen("body", sb, 0, "container-fluid", false);
        }

        internal void WriteBodyEnd(StringBuilder sb)
        {
            sb.AppendLine("    <script src=\"https://code.jquery.com/jquery-3.3.1.slim.min.js\" integrity=\"sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo\" crossorigin=\"anonymous\"></script>");
            sb.AppendLine("    <script src=\"https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js\" integrity=\"sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49\" crossorigin=\"anonymous\"></script>");
            sb.AppendLine("    <script src=\"https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js\" integrity=\"sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy\" crossorigin=\"anonymous\"></script>");
            sb.AppendLine("    <script src=\"https://cdn.rawgit.com/google/code-prettify/master/loader/run_prettify.js\"></script>");
            sb.AppendLine("    <script language=\"javascript\" type=\"text/javascript\">function resizeIframe(obj) { obj.style.height = obj.contentWindow.document.body.scrollHeight + 'px'; }</script>");
            WriteTagClose("body", sb, 0);
        }

        internal void WriteNavBarStart(StringBuilder sb, bool failuresOnly)
        {
            var failuresOnlyText = "";
            if(failuresOnly) {
                failuresOnlyText = " [Failures Only]";
            }
            var html = $@"
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
                            <div class=""navbar-nav"">".RemoveIndentation(4, true);

            sb.Append(html);
        }

        internal void WriteNavBarEnd(StringBuilder sb)
        {
            var html = $@"
                            </div>
                        </div>
                    </nav>".RemoveIndentation(4, true);

            sb.Append(html);
        }

        internal void WriteBanner(
			StringBuilder sb, 
			int childCount, 
			Outcome outcome, 
			string reason, 
			string name, 
			string childTitle, 
			DateTime startTime, 
			DateTime endTime, 
			Dictionary<string, OutcomeStats> statistics) 
		{
            var cssClass = "report-name";
            var badgeClass = "";
            if (childCount == 0)
            {
                badgeClass = "badge-secondary";
            }
            else
            {
                switch (outcome)
                {
                    case Outcome.Failed:
                        badgeClass = "badge-danger";
                        break;
                    case Outcome.NotRun:
                        badgeClass = "badge-info";
                        break;
                    case Outcome.Passed:
                        badgeClass = "badge-success";
                        break;
                    case Outcome.Skipped:
                        badgeClass = "badge-warning";
                        break;
                }
            }
            WriteTagOpen("div", sb, 1, "page-header", false, null, "margin-top: 0px !important;");
            WriteTagOpen("h1", sb, 2, cssClass, false);

            WriteTag("span", sb, 3, $"report badge pointer badge-pill total {badgeClass}", childCount.ToString(), false, true, null, null, $" title=\"{childTitle}\"");
            WriteTag("span", sb, 3, "name", name.HtmlEncode(), false, true);

            if(reason != null) {
                WriteTag("span", sb, 3, "report reason", $" [{reason.HtmlEncode()}]",false, true);
            }

            var duration = endTime - startTime;
            var formattedDuration = duration.TotalMilliseconds.ToString("N", System.Globalization.CultureInfo.InvariantCulture);
            formattedDuration = formattedDuration.Substring(0, formattedDuration.Length-3);
            WriteTag("span", sb, 3, "report duration", $" [{formattedDuration} ms]",false, true);

            WriteTagClose("h1", sb, 2);
            WriteTagClose("div", sb, 1);
            if(startTime != DateTime.MinValue) {
                WriteTagOpen("div", sb, 1, null, false, "report-dates", "margin-top: 0px !important;");
                WriteTag("span", sb, 0, null, startTime.ToString("yyyy-MM-dd hh:mm tt \"GMT\"zzz"), true, true, "report-start-date", null, " title=\"Start\"");
                WriteTagClose("div", sb, 1);
            }
            WriteStatsTableStart(sb, 1, null, false);
			foreach(string statsKey in statistics.Keys) {
				WriteStats(sb, statistics[statsKey], 1, $"report-{statsKey.ToLower()}-stats", statsKey);
			}
            WriteStatsTableClose(sb, 1);
        }
        internal void WriteStatsTableStart(StringBuilder sb, int baseIndent, string id = null, Boolean collapsed = true) {
            var collapse = (collapsed ? "collapse":"");
            WriteTagOpen("table", sb, baseIndent, $"table table-condensed {collapse}", false, id, "width: 100%; empty-cells: show;");
        }

        internal void WriteStats(StringBuilder sb, OutcomeStats stats, int baseIndent, string id, string label) {
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

        internal void WriteStatsTableClose(StringBuilder sb, int baseIndent) {
            WriteTagClose("table", sb, baseIndent);
        }

        internal void WriteBadge(string type, string title, int count, OutcomeStats stats, StringBuilder sb, string badgeAttributes, string badgeClassName) {
            WriteTagOpen("span", sb, 0, $"{type} badge-distro", true, $"{type}-{count}-badge-distro", null, $"{badgeAttributes} title=\"{title}\"");

            //Create Badge with distribution 
            WriteTag("span", sb, 0, $"{type} badge badge-pill pointer total {badgeClassName}", stats.Total.ToString(), true, true, $"{type}-{count}-badge", null);
            WriteTagOpen("span", sb, 0, $"{type} distro pointer", true, $"{type}-{count}-distro");
            double totalCount = stats.Total;
            double passedPercent = ((double)stats.Passed/totalCount)*100;
            double skippedPercent = ((double)stats.Skipped/totalCount)*100;
            double failedPercent = ((double)stats.Failed/totalCount)*100;
            var skippedRadius = "";
            if(skippedPercent > 0) {
                if(passedPercent == 0) {
                    skippedRadius = "border-top-right-radius: .25em;";
                }
                if(failedPercent == 0) {
                    skippedRadius = $"{skippedRadius} border-bottom-right-radius: .25em;";
                }
            }
            var passedRadius = "border-top-right-radius: .25em;";
            if(skippedPercent == 0 && failedPercent == 0) {
                passedRadius = $"{passedRadius} border-bottom-right-radius: .25em;";
            }
            var failedRadius = "border-bottom-right-radius: .25em;";
            if(passedPercent == 0 && skippedPercent == 0) {
                failedRadius = $"{failedRadius} border-top-right-radius: .25em;";
            }
            if(passedPercent > 0) {
                WriteTag("div", sb, 0, "distro bg-success", null, true,  true, null, $"height: {passedPercent}%; width: 100%; {passedRadius}");
            }
            if(skippedPercent > 0) {
                WriteTag("div", sb, 0, "distro bg-warning", null, true,  true, null, $"height: {skippedPercent}%; width: 100%; {skippedRadius}");
            }
            if(failedPercent > 0) {
                WriteTag("div", sb, 0, "distro bg-danger", null, true,  true, null, $"height: {failedPercent}%; width: 100%; {failedRadius}");
            }
            WriteTagClose("span", sb, 0);//distribution graph
            WriteTagClose("span", sb, 0);//badge and distro graph
        }

        internal void WriteLineItemOpen(
			StringBuilder sb, 
			string typeName, 
			int itemNumber, 
			string name, 
			Outcome outcome, 
			string reason, 
			DateTime startTime,
			DateTime endTime,
			string childType, 
			OutcomeStats childStats,
			Dictionary<string, OutcomeStats> statistics,
			bool failuresOnly) 
		{
            string style = null;
            string className = null;
            string badgeClassName = null;
            switch (outcome)
            {
                case Outcome.NotRun:
                    style = "#949494";
                    badgeClassName = "badge-secondary";
                    break;
                case Outcome.Passed:
                    style = "#5A8B5B";
                    className = "collapsed";
                    badgeClassName = "badge-success";
                    break;
                case Outcome.Failed:
                    style = "#AD4D4B";
                    badgeClassName = "badge-danger";
                    break;
                case Outcome.Skipped:
                    style = "#917545";
                    //className = "text-warning";
                    badgeClassName = "badge-warning";
                    break;
                default:
                    break;
            }
            style = "border-left: 2px solid "+style+";";
            //  style = "box-shadow: inset 1px 1px 8px 1px "+style+";";
            var expanded = outcome == Outcome.Failed && failuresOnly;
            var expandedText = expanded ? "true" : "false";
            WriteTagOpen("li", sb, 2, typeName.ToLower(), false, $"{typeName.ToLower()}-" + itemNumber);

            var titleAttributes = $" data-toggle=\"collapse\" href=\"#{typeName.ToLower()}-{itemNumber}-{childType.ToLower()}\" aria-expanded=\"{expandedText}\" aria-controls=\"{typeName.ToLower()}-{itemNumber}-{childType.ToLower()}\" ";
            var badgeAttributes = $" data-toggle=\"collapse\" href=\"#{typeName.ToLower()}-{itemNumber}-stats\" aria-expanded=\"false\" aria-controls=\"{typeName.ToLower()}-{itemNumber}-stats\" ";
            WriteTagOpen("h2", sb, 3, className, true, null, null, null);

            WriteBadge(typeName.ToLower(), childType, itemNumber, childStats, sb, badgeAttributes, badgeClassName);

            if(name.Length == 0) {
                name = "[Missing! (or Full Name Skipped)]";
            }
            WriteTag("span", sb, 4, "name pointer", name.HtmlEncode(), false, true,  $"area-{itemNumber}-name", null, titleAttributes);
            
            if(reason != null) {
                WriteTag("span", sb, 4, $"{typeName.ToLower()} reason", $" [{reason.HtmlEncode()}]", false, true);
            }
            
            var duration = endTime - startTime;
            var formattedDuration = duration.TotalMilliseconds.ToString("N", System.Globalization.CultureInfo.InvariantCulture);
            formattedDuration = formattedDuration.Substring(0, formattedDuration.Length-3);
            WriteTag("span", sb, 4, $"{typeName.ToLower()} duration", $" [{formattedDuration} ms]", false, true);

            WriteTagClose("h2", sb, 3);

            WriteStatsTableStart(sb, 3, $"{typeName.ToLower()}-{itemNumber}-stats");
			foreach(string statsKey in statistics.Keys) {
				WriteStats(sb, statistics[statsKey], 4, $"report-{statsKey.ToLower()}-stats", statsKey);
			}
            WriteStatsTableClose(sb, 3);

            var childClassName = $"{childType.ToLower()} list-unstyled collapse" + (expanded ? " show" : "");
            WriteTagOpen("ol", sb, 3, childClassName, false, $"{typeName.ToLower()}-{itemNumber}-{childType.ToLower()}", style, $" aria-expanded=\"{expandedText}\"");
        }
        internal void WriteLineItemClose(StringBuilder sb) {
            WriteTagClose("ol", sb, 3);
            WriteTagClose("li", sb, 2);
        }
        internal void WriteTag(string tag, StringBuilder sb, 
            int indentation, string className, string text, 
            bool inline, bool singleLine, string id = null, string style = null, string attributes = null)
        {
            WriteTagOpen(tag, sb, indentation, className, singleLine, id, style, attributes);
            sb.Append(text);
            WriteTagClose(tag, sb, singleLine?0:indentation, inline);
        }
        internal void WriteTagOpen(string tag, StringBuilder sb, int indentation, 
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