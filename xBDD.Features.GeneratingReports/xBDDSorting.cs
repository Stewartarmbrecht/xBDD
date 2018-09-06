namespace xBDD.Features.GeneratingReports
{
	using System;
	using System.Collections.Generic;
	using xBDD;

	public partial class xBDDSorting: ISorting
	{
		public List<string> GetSortedFeatureNames() {
			return new List<string>() {
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.Generating.GenerateAReport).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestSummaryInformation.ReviewTestSummaryName).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestSummaryInformation.ReviewTestSummaryExplanation).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestSummaryInformation.ReviewTestSummaryStatus).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestSummaryInformation.ReviewTestSummaryTestRunStatusDistribution).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestSummaryInformation.ReviewTestSummaryAreaStatusDistribution).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestSummaryInformation.ReviewTestSummaryFeatureStatusDistribution).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestSummaryInformation.ReviewTestSummaryScenarioStatusDistribution).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestSummaryInformation.ReviewTestSummaryTestRunStatusStatistics).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestSummaryInformation.ReviewTestSummaryAreaStatusStatistics).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestSummaryInformation.ReviewTestSummaryFeatureStatusStatistics).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestSummaryInformation.ReviewTestSummaryScenarioStatusStatistics).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestSummaryInformation.ReviewTestSummaryAreas).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestRunInformation.ReviewTestRunName).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestRunInformation.ReviewTestRunStatus).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestRunInformation.ReviewTestRunFeatureStatusDistribution).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestRunInformation.ReviewTestRunScenarioStatusDistribution).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestRunInformation.ReviewTestRunFeatureStatusStatistics).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestRunInformation.ReviewTestRunScenarioStatusStatistics).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestRunInformation.ReviewTestRunExplanation).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestRunInformation.ReviewTestRunFeatures).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.Generating.GenerateAReport).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.Generating.GenerateAFailuresOnlyReport).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.Generating.ViewAReport).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewTestRunInformation.ReviewTestRunName).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewTestRunInformation.ReviewTestRunExplanation).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewTestRunInformation.ReviewTestRunStatus).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewTestRunInformation.ReviewTestRunAreaStatusDistribution).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewTestRunInformation.ReviewTestRunFeatureStatusDistribution).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewTestRunInformation.ReviewTestRunScenarioStatusDistribution).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewTestRunInformation.ReviewTestRunAreaStatusStatistics).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewTestRunInformation.ReviewTestRunFeatureStatusStatistics).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewTestRunInformation.ReviewTestRunScenarioStatusStatistics).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewTestRunInformation.ReviewTestRunAreas).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewAreaInformation.ReviewAreaName).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewAreaInformation.ReviewAreaStatus).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewAreaInformation.ReviewAreaFeatureStatusDistribution).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewAreaInformation.ReviewAreaScenarioStatusDistribution).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewAreaInformation.ReviewAreaFeatureStatusStatistics).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewAreaInformation.ReviewAreaScenarioStatusStatistics).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewAreaInformation.ReviewAreaExplanation).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewAreaInformation.ReviewAreaFeatures).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewFeatureInformation.ReviewFeatureInformation).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewFeatureInformation.ReviewFeatureStatus).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewFeatureInformation.ReviewFeatureStatement).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewFeatureInformation.ReviewFeatureScenarioStatusDistribution).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewFeatureInformation.ReviewFeatureExplanation).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewFeatureInformation.ReviewFeatureScenarioStatusStatistics).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewFeatureInformation.ReviewFeatureScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewScenarioInformation.ReviewScenarioInformation).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewScenarioInformation.ReviewScenarioExplanation).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewScenarioInformation.ReviewScenarioStatus).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewScenarioInformation.ReviewScenarioSteps).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewStepInformation.ReviewStepInformation).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewStepInformation.ReviewStepStatus).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewStepInformation.ReviewStepInput).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewStepInformation.ReviewStepOutput).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewStepInformation.ReviewStepError).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewStepInformation.ReviewStepExplanation).FullName,
				typeof(xBDD.Features.GeneratingReports.JSONTestRunReport.GenerateAJsonReportWithGeneralScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.JSONTestRunReport.GenerateAJsonReportWithTestRunScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.JSONTestRunReport.GenerateAJsonReportWithAreaScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.JSONTestRunReport.GenerateAJsonReportWithFeatureScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.JSONTestRunReport.GenerateAJsonReportWithScenarioScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.JSONTestRunReport.GenerateAJsonReportWithStepScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.OutlineTestRunReport.GenerateAnOutlineReportWithGeneralScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.OutlineTestRunReport.GenerateAnOutlineReportWithTestRunScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.OutlineTestRunReport.GenerateAnOutlineReportWithAreaScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.OutlineTestRunReport.GenerateAnOutlineReportWithFeatureScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.OutlineTestRunReport.GenerateAnOutlineReportWithScenarioScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.OutlineTestRunReport.GenerateAnOutlineReportWithStepScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.TextTestRunReport.GenerateATextReportWithGeneralScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.TextTestRunReport.GenerateATextReportWithTestRunScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.TextTestRunReport.GenerateATextReportWithAreaScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.TextTestRunReport.GenerateATextReportWithFeatureScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.TextTestRunReport.GenerateATextReportWithScenarioScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.TextTestRunReport.GenerateATextReportWithStepScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.TextOutlineTestRunReport.GenerateATextOutlineReportWithGeneralScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.TextOutlineTestRunReport.GenerateATextOutlineReportWithTestRunScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.TextOutlineTestRunReport.GenerateATextOutlineReportWithAreaScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.TextOutlineTestRunReport.GenerateATextOutlineReportWithFeatureScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.TextOutlineTestRunReport.GenerateATextOutlineReportWithScenarioScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.TextOutlineTestRunReport.GenerateATextOutlineReportWithStepScenarios).FullName,
			};
		}
		public List<string> GetSortedReasons() {
			return new List<string>() {
				"Committed",
				"Defining",
				"Committed",
				"Untested",
			};
		}
	}
}