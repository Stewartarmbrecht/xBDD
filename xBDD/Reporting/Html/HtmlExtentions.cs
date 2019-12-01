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
			li.ChildStats = testRunGroup.CapabilityStats;
			li.ChildTypeName = "testruns";
			li.EndTime = testRunGroup.EndTime;
			li.StartTime = testRunGroup.StartTime;
			li.Name = testRunGroup.Name.HtmlEncode();
			li.Outcome = testRunGroup.Outcome;
			li.Reason = testRunGroup.Reason;
			Dictionary<string, Dictionary<string,int>> testRunReasonStatistics = new Dictionary<string, Dictionary<string, int>>();
			testRunReasonStatistics.Add("Test Runs", testRunGroup.CapabilityReasonStats);
			testRunReasonStatistics.Add("Capabilities", testRunGroup.CapabilityReasonStats);
			testRunReasonStatistics.Add("Features", testRunGroup.FeatureReasonStats);
			testRunReasonStatistics.Add("Scenarios", testRunGroup.ScenarioReasonStats);
			li.ReasonStats = testRunReasonStatistics;
			li.TypeName = "testrungroup";
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
			li.ChildStats = testRun.CapabilityStats;
			li.ChildTypeName = "capabilities";
			li.EndTime = testRun.EndTime;
			li.StartTime = testRun.StartTime;
			li.Name = testRun.Name.HtmlEncode();
			li.Outcome = testRun.Outcome;
			li.Reason = testRun.Reason;
			li.FilePath = testRun.FilePath;
			Dictionary<string, Dictionary<string,int>> testRunReasonStatistics = new Dictionary<string, Dictionary<string, int>>();
			testRunReasonStatistics.Add("Capabilities", testRun.CapabilityReasonStats);
			testRunReasonStatistics.Add("Features", testRun.FeatureReasonStats);
			testRunReasonStatistics.Add("Scenarios", testRun.ScenarioReasonStats);
			li.ReasonStats = testRunReasonStatistics;
			li.TypeName = "testrun";
			if(includeChildren) {
				var capabilities = testRun.Capabilities.SelectMany(x => x.Features).OrderBy(x => x.Sort).Select(x => x.Capability).Distinct().ToList();
				foreach(var capability in capabilities) {
					li.ChildItems.Add(capability.GetHtmlReportLineItem());
				}
			}
			return li;
		}
		internal static HtmlReportLineItem GetHtmlReportLineItem(this xBDD.Model.Capability capability) {
			var li = new HtmlReportLineItem();
			li.ChildItems = new List<HtmlReportLineItem>();
			li.ChildStats = capability.FeatureStats;
			li.ChildTypeName = "features";
			li.EndTime = capability.EndTime;
			li.StartTime = capability.StartTime;
			li.Name = capability.Name.HtmlEncode();
			li.Outcome = capability.Outcome;
			li.Reason = capability.Reason;
			Dictionary<string, Dictionary<string,int>> reasonStats = new Dictionary<string, Dictionary<string, int>>();
			reasonStats.Add("Features", capability.FeatureReasonStats);
			reasonStats.Add("Scenarios", capability.ScenarioReasonStats);
			li.ReasonStats = reasonStats;
			li.TypeName = "capability";
			var features = capability.Features.OrderBy(feature => feature.Sort).ToList();
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
			li.Name = feature.Name.HtmlEncode();
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
			if(feature.AsA != null || feature.Capability != null || feature.SoThat != null) {
				var nl = System.Environment.NewLine;
				li.Statement = $@"
					<strong>As a</strong> {(feature.AsA != null ? feature.AsA : "[Missing Name!]")}<br/>
					<strong>You can </strong> {(feature.YouCan != null ? feature.YouCan : "[Missing Capability!]")}<br/>
					<strong>So that </strong> {(feature.SoThat != null ? feature.SoThat : "[Missing Value!]")}<br/>".RemoveIndentation(5, true);
			}
			li.Explanation = feature.Explanation;
			li.ExplanationFormat = feature.ExplanationFormat;
			return li;
		}
		internal static HtmlReportLineItem GetHtmlReportLineItem(this xBDD.Model.Scenario scenario) {
			var li = new HtmlReportLineItem();
			li.ChildItems = new List<HtmlReportLineItem>();
			li.ChildStats = scenario.StepStats;
			li.ChildTypeName = "scenarios";
			li.EndTime = scenario.EndTime;
			li.StartTime = scenario.StartTime;
			li.Name = scenario.Name.HtmlEncode();
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
			li.ExplanationFormat = scenario.ExplanationFormat;
			return li;
		}
		internal static HtmlReportLineItem GetHtmlReportLineItem(this xBDD.Model.Step step) {
			var li = new HtmlReportLineItem();
			li.ChildItems = new List<HtmlReportLineItem>();
			li.ChildStats = null;
			li.ChildTypeName = null;
			li.EndTime = step.EndTime;
			li.StartTime = step.StartTime;
			var action = "";
			switch(step.ActionType) {
				case ActionType.Given:
					action = "<strong>Given</strong> ";
				break;
				case ActionType.When:
					action = "<strong>When</strong> ";
				break;
				case ActionType.Then:
					action = "<strong>Then</strong> ";
				break;
				case ActionType.And:
					action = "<strong>And</strong> ";
				break;
			}
			li.Name = $"{action} {step.Name.HtmlEncode()}";
			li.Outcome = step.Outcome;
			li.Reason = step.Reason;
			Dictionary<string, Dictionary<string,int>> reasonStats = new Dictionary<string, Dictionary<string, int>>();
			li.ReasonStats = reasonStats;
			li.TypeName = "step";
			li.ChildTypeName = "details";
			li.ChildItems = new List<HtmlReportLineItem>();
			li.Explanation = step.Explanation;
			li.ExplanationFormat = step.ExplanationFormat;
			li.Input = step.Input;
			li.InputFormat = step.InputFormat;
			li.Output = step.Output;
			li.OutputFormat = step.OutputFormat;
			li.Exception = step.Exception;
			return li;
		}

		internal static string EncodeCSSClassName(this string name) {
			return name.Replace(" ", "");
		}
    }
}
