namespace xBDD.Reporting.Html {
	using xBDD.Model;
	using System;
	using System.Collections.Generic;
	internal class HtmlReportLineItem {
		internal string TypeName { get; set; }
		internal string Name { get; set; }
		internal List<string> Assignments { get; set; }
		internal List<string> Tags { get; set; }
		internal string FilePath { get; set; }
		internal Outcome Outcome { get; set; }
		internal string Reason { get; set; }
		internal Dictionary<string, Dictionary<string, int>> ReasonStats { get; set; }
		internal DateTime StartTime { get; set; }
		internal DateTime EndTime { get; set; }
		internal string ChildTypeName { get; set; }
		internal List<HtmlReportLineItem> ChildItems { get; set; }
		internal OutcomeStats ChildStats { get; set; }
		internal string Statement { get; set; }
		internal string Explanation { get; set; }
		internal string Input { get; set; }
		internal TextFormat InputFormat { get; set; }
		internal string Output { get; set; }
		internal TextFormat OutputFormat { get; set; }

		internal Exception Exception { get; set; }
	}
}