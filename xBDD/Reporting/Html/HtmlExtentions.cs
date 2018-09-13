namespace xBDD
{
	using System;
    using System.Globalization;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using System.Threading;
	using System.Collections.Generic;
	using xBDD.Utility;
    using xBDD.Model;
    using xBDD.Reporting;
    using xBDD.Reporting.Html;
    using xBDD.Reporting.Text;
    using xBDD.Reporting.Database;
    using xBDD.Reporting.Database.Core;
    using xBDD.Reporting.Code;
    using xBDD.Reporting.Outline;

    internal static class HtmlExtensions
    {
		internal static HtmlReportLineItem GetHtmlReportLineItem(this xBDD.Model.TestRunGroup testRunGroup, bool includeChildren) {
			var li = new HtmlReportLineItem();
			li.ChildItems = new List<HtmlReportLineItem>();
			li.ChildStats = testRunGroup.AreaStats;
			li.ChildTypeName = "areas";
			li.EndTime = testRunGroup.EndTime;
			li.StartTime = testRunGroup.StartTime;
			li.Name = testRunGroup.Name;
			li.Outcome = testRunGroup.Outcome;
			li.Reason = testRunGroup.Reason;
			Dictionary<string, Dictionary<string,int>> testRunReasonStatistics = new Dictionary<string, Dictionary<string, int>>();
			testRunReasonStatistics.Add("Areas", testRunGroup.AreaReasonStats);
			testRunReasonStatistics.Add("Features", testRunGroup.FeatureReasonStats);
			testRunReasonStatistics.Add("Scenarios", testRunGroup.ScenarioReasonStats);
			li.ReasonStats = testRunReasonStatistics;
			li.TypeName = "testrun";
			if(includeChildren) {
				foreach(var testRun in testRunGroup.TestRuns) {
					li.ChildItems.Add(testRun.GetHtmlReportLineItem(false));
				}
			}
			return li;
		}
		internal static HtmlReportLineItem GetHtmlReportLineItem(this xBDD.Model.TestRun testRun, bool includeChildren) {
			var li = new HtmlReportLineItem();
			li.ChildItems = new List<HtmlReportLineItem>();
			li.ChildStats = testRun.AreaStats;
			li.ChildTypeName = "areas";
			li.EndTime = testRun.EndTime;
			li.StartTime = testRun.StartTime;
			li.Name = testRun.Name;
			li.Outcome = testRun.Outcome;
			li.Reason = testRun.Reason;
			li.FilePath = testRun.FilePath;
			Dictionary<string, Dictionary<string,int>> testRunReasonStatistics = new Dictionary<string, Dictionary<string, int>>();
			testRunReasonStatistics.Add("Areas", testRun.AreaReasonStats);
			testRunReasonStatistics.Add("Features", testRun.FeatureReasonStats);
			testRunReasonStatistics.Add("Scenarios", testRun.ScenarioReasonStats);
			li.ReasonStats = testRunReasonStatistics;
			li.TypeName = "testrun";
			if(includeChildren) {
				var areas = testRun.Areas.SelectMany(x => x.Features).OrderBy(x => x.Sort).Select(x => x.Area).Distinct().ToList();
				foreach(var area in areas) {
					li.ChildItems.Add(area.GetHtmlReportLineItem());
				}
			}
			return li;
		}
		internal static HtmlReportLineItem GetHtmlReportLineItem(this xBDD.Model.Area area) {
			var li = new HtmlReportLineItem();
			li.ChildItems = new List<HtmlReportLineItem>();
			li.ChildStats = area.FeatureStats;
			li.ChildTypeName = "features";
			li.EndTime = area.EndTime;
			li.StartTime = area.StartTime;
			li.Name = area.Name;
			li.Outcome = area.Outcome;
			li.Reason = area.Reason;
			Dictionary<string, Dictionary<string,int>> reasonStats = new Dictionary<string, Dictionary<string, int>>();
			reasonStats.Add("Features", area.FeatureReasonStats);
			reasonStats.Add("Scenarios", area.ScenarioReasonStats);
			li.ReasonStats = reasonStats;
			li.TypeName = "area";
			var features = area.Features.OrderBy(feature => feature.Sort).ToList();
			foreach(var feature in features) {
				li.ChildItems.Add(feature.GetHtmlReportLineItem());
			}
			return li;
		}
		internal static HtmlReportLineItem GetHtmlReportLineItem(this xBDD.Model.Feature feature) {
			var li = new HtmlReportLineItem();
			li.ChildItems = new List<HtmlReportLineItem>();
			li.ChildStats = feature.ScenarioStats;
			li.ChildTypeName = "scenarios";
			li.EndTime = feature.EndTime;
			li.StartTime = feature.StartTime;
			li.Name = feature.Name;
			li.Outcome = feature.Outcome;
			li.Reason = feature.Reason;
			li.Assignments = feature.Assignments.ToList();
			li.Tags = feature.Tags.ToList();
			Dictionary<string, Dictionary<string,int>> reasonStats = new Dictionary<string, Dictionary<string, int>>();
			reasonStats.Add("Scenarios", feature.ScenarioReasonStats);
			li.ReasonStats = reasonStats;
			li.TypeName = "feature";
			var scenarios = feature.Scenarios.OrderBy(x => x.Sort).ToList();
			foreach(var scenario in scenarios) {
				li.ChildItems.Add(scenario.GetHtmlReportLineItem());
			}
			if(feature.Actor != null || feature.Capability != null || feature.Value != null) {
				var nl = System.Environment.NewLine;
				li.Statement = $@"
					As A {(feature.Actor != null ? feature.Actor : "[Missing Name!]")}
					You can {(feature.Value != null ? feature.Value : "[Missing Value!]")}
					By {(feature.Capability != null ? feature.Capability : "[Missing Capability!]")}".RemoveIndentation(5, true);
			}
			li.Explanation = feature.Explanation;
			return li;
		}
		internal static HtmlReportLineItem GetHtmlReportLineItem(this xBDD.Model.Scenario scenario) {
			var li = new HtmlReportLineItem();
			li.ChildItems = new List<HtmlReportLineItem>();
			li.ChildStats = scenario.StepStats;
			li.ChildTypeName = "scenarios";
			li.EndTime = scenario.EndTime;
			li.StartTime = scenario.StartTime;
			li.Name = scenario.Name;
			li.Outcome = scenario.Outcome;
			li.Reason = scenario.Reason;
			li.Assignments = scenario.Assignments.ToList();
			li.Tags = scenario.Tags.ToList();
			Dictionary<string, Dictionary<string,int>> reasonStats = new Dictionary<string, Dictionary<string, int>>();
			li.ReasonStats = reasonStats;
			li.TypeName = "scenario";
			foreach(var step in scenario.Steps) {
				li.ChildItems.Add(step.GetHtmlReportLineItem());
			}
			li.Explanation = scenario.Explanation;
			return li;
		}
		internal static HtmlReportLineItem GetHtmlReportLineItem(this xBDD.Model.Step step) {
			var li = new HtmlReportLineItem();
			li.ChildItems = new List<HtmlReportLineItem>();
			li.ChildStats = null;
			li.ChildTypeName = null;
			li.EndTime = step.EndTime;
			li.StartTime = step.StartTime;
			li.Name = step.Name;
			li.Outcome = step.Outcome;
			li.Reason = step.Reason;
			Dictionary<string, Dictionary<string,int>> reasonStats = new Dictionary<string, Dictionary<string, int>>();
			li.ReasonStats = reasonStats;
			li.TypeName = "step";
			li.Explanation = step.Explanation;
			li.Input = step.Input;
			li.InputFormat = step.InputFormat;
			li.Output = step.Output;
			li.OutputFormat = step.OutputFormat;
			li.Exception = step.Exception;
			return li;
		}
    }
}
