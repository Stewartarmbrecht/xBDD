namespace xBDD.Features.GeneratingReports
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
	using System.Collections.Generic;
	using xBDD;

	[TestClass]
	public class TestSetupAndBreakdown
	{

		[AssemblyInitialize]
		public static void TestRunStart(TestContext context)
		{
			xB.Initialize();
		}
		[AssemblyCleanup()]
		public static void TestRunComplete()
		{
			var sortedFeatureNams = new List<string>() {
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.Generating.GenerateAReport).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestSummaryInformation.ReviewTestSummaryName).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestSummaryInformation.ReviewTestSummaryExplanation).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestSummaryInformation.ReviewTestSummaryStatus).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestSummaryInformation.ReviewTestSummaryTestRunStatusDistribution).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestSummaryInformation.ReviewTestSummaryCapabilityStatusDistribution).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestSummaryInformation.ReviewTestSummaryFeatureStatusDistribution).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestSummaryInformation.ReviewTestSummaryScenarioStatusDistribution).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestSummaryInformation.ReviewTestSummaryTestRunStatusStatistics).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestSummaryInformation.ReviewTestSummaryCapabilityStatusStatistics).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestSummaryInformation.ReviewTestSummaryFeatureStatusStatistics).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestSummaryInformation.ReviewTestSummaryScenarioStatusStatistics).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestSummaryInformation.ReviewTestSummaryCapabilities).FullName,
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
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewTestRunInformation.ReviewTestRunCapabilityStatusDistribution).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewTestRunInformation.ReviewTestRunFeatureStatusDistribution).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewTestRunInformation.ReviewTestRunScenarioStatusDistribution).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewTestRunInformation.ReviewTestRunCapabilityStatusStatistics).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewTestRunInformation.ReviewTestRunFeatureStatusStatistics).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewTestRunInformation.ReviewTestRunScenarioStatusStatistics).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewTestRunInformation.ReviewTestRunCapabilities).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewCapabilityInformation.ReviewCapabilityName).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewCapabilityInformation.ReviewCapabilityStatus).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewCapabilityInformation.ReviewCapabilityFeatureStatusDistribution).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewCapabilityInformation.ReviewCapabilityScenarioStatusDistribution).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewCapabilityInformation.ReviewCapabilityFeatureStatusStatistics).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewCapabilityInformation.ReviewCapabilityScenarioStatusStatistics).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewCapabilityInformation.ReviewCapabilityExplanation).FullName,
				typeof(xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewCapabilityInformation.ReviewCapabilityFeatures).FullName,
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
				typeof(xBDD.Features.GeneratingReports.JSONTestRunReport.GenerateAJsonReportWithCapabilityScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.JSONTestRunReport.GenerateAJsonReportWithFeatureScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.JSONTestRunReport.GenerateAJsonReportWithScenarioScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.JSONTestRunReport.GenerateAJsonReportWithStepScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.OutlineTestRunReport.GenerateAnOutlineReportWithGeneralScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.OutlineTestRunReport.GenerateAnOutlineReportWithTestRunScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.OutlineTestRunReport.GenerateAnOutlineReportWithCapabilityScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.OutlineTestRunReport.GenerateAnOutlineReportWithFeatureScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.OutlineTestRunReport.GenerateAnOutlineReportWithScenarioScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.OutlineTestRunReport.GenerateAnOutlineReportWithStepScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.TextTestRunReport.GenerateATextReportWithGeneralScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.TextTestRunReport.GenerateATextReportWithTestRunScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.TextTestRunReport.GenerateATextReportWithCapabilityScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.TextTestRunReport.GenerateATextReportWithFeatureScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.TextTestRunReport.GenerateATextReportWithScenarioScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.TextTestRunReport.GenerateATextReportWithStepScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.TextOutlineTestRunReport.GenerateATextOutlineReportWithGeneralScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.TextOutlineTestRunReport.GenerateATextOutlineReportWithTestRunScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.TextOutlineTestRunReport.GenerateATextOutlineReportWithCapabilityScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.TextOutlineTestRunReport.GenerateATextOutlineReportWithFeatureScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.TextOutlineTestRunReport.GenerateATextOutlineReportWithScenarioScenarios).FullName,
				typeof(xBDD.Features.GeneratingReports.TextOutlineTestRunReport.GenerateATextOutlineReportWithStepScenarios).FullName,
			};

			xB.Complete("xBDDConfig.json", sortedFeatureNams, (message) => { Logger.LogMessage(message); });
		}
	}
}