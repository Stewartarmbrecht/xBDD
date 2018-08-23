namespace xBDD.Features.GeneratingReports
{
    using System;
    using System.Collections.Generic;
    public class FeatureSort
    {
        public string[] SortedFeatureNames { get; private set; }

        public FeatureSort()
        {
            List<string> SortedFeatureNames = new List<string>() {
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.Generating.GenerateAReport).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.Generating.GenerateAFailuresOnlyReport).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.Generating.ViewAReport).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewTestRunInformation.ReviewTestRunName).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewTestRunInformation.ReviewTestRunExplanation).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewTestRunInformation.ReviewTestRunStatus).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewTestRunInformation.ReviewTestRunAreaStatusDistribution).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewTestRunInformation.ReviewTestRunFeatureStatusDistribution).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewTestRunInformation.ReviewTestRunScenarioStatusDistribution).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewTestRunInformation.ReviewTestRunAreaStatusStatistics).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewTestRunInformation.ReviewTestRunFeatureStatusStatistics).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewTestRunInformation.ReviewTestRunScenarioStatusStatistics).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewTestRunInformation.ReviewTestRunAreas).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewAreaInformation.ReviewAreaName).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewAreaInformation.ReviewAreaStatus).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewAreaInformation.ReviewAreaFeatureStatusDistribution).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewAreaInformation.ReviewAreaScenarioStatusDistribution).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewAreaInformation.ReviewAreaFeatureStatusStatistics).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewAreaInformation.ReviewAreaScenarioStatusStatistics).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewAreaInformation.ReviewAreaExplanation).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewAreaInformation.ReviewAreaFeatures).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewFeatureInformation.ReviewFeatureInformation).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewFeatureInformation.ReviewFeatureStatus).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewFeatureInformation.ReviewFeatureStatement).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewFeatureInformation.ReviewFeatureScenarioStatusDistribution).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewFeatureInformation.ReviewFeatureExplanation).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewFeatureInformation.ReviewFeatureScenarioStatusStatistics).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewFeatureInformation.ReviewFeatureScenarios).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewScenarioInformation.ReviewScenarioInformation).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewScenarioInformation.ReviewScenarioExplanation).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewScenarioInformation.ReviewScenarioStatus).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewScenarioInformation.ReviewScenarioSteps).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewStepInformation.ReviewStepInformation).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewStepInformation.ReviewStepStatus).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewStepInformation.ReviewStepInput).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewStepInformation.ReviewStepOutput).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewStepInformation.ReviewStepError).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.GeneratingaJSONTestRunReport.GenerateAJsonReportWithGeneralScenarios).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.GeneratingaJSONTestRunReport.GenerateAJsonReportWithTestRunScenarios).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.GeneratingaJSONTestRunReport.GenerateAJsonReportWithAreaScenarios).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.GeneratingaJSONTestRunReport.GenerateAJsonReportWithFeatureScenarios).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.GeneratingaJSONTestRunReport.GenerateAJsonReportWithScenarioScenarios).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.GeneratingaJSONTestRunReport.GenerateAJsonReportWithStepScenarios).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.GeneratinganOutlineTestRunReport.GenerateAnOutlineReportWithGeneralScenarios).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.GeneratinganOutlineTestRunReport.GenerateAnOutlineReportWithTestRunScenarios).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.GeneratinganOutlineTestRunReport.GenerateAnOutlineReportWithAreaScenarios).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.GeneratinganOutlineTestRunReport.GenerateAnOutlineReportWithFeatureScenarios).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.GeneratinganOutlineTestRunReport.GenerateAnOutlineReportWithScenarioScenarios).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.GeneratinganOutlineTestRunReport.GenerateAnOutlineReportWithStepScenarios).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.GeneratingaTextTestRunReport.GenerateATextReportWithGeneralScenarios).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.GeneratingaTextTestRunReport.GenerateATextReportWithTestRunScenarios).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.GeneratingaTextTestRunReport.GenerateATextReportWithAreaScenarios).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.GeneratingaTextTestRunReport.GenerateATextReportWithFeatureScenarios).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.GeneratingaTextTestRunReport.GenerateATextReportWithScenarioScenarios).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.GeneratingaTextTestRunReport.GenerateATextReportWithStepScenarios).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.GeneratingaTextTestRunOutlineReport.GenerateATextOutlineReportWithGeneralScenarios).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.GeneratingaTextTestRunOutlineReport.GenerateATextOutlineReportWithTestRunScenarios).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.GeneratingaTextTestRunOutlineReport.GenerateATextOutlineReportWithAreaScenarios).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.GeneratingaTextTestRunOutlineReport.GenerateATextOutlineReportWithFeatureScenarios).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.GeneratingaTextTestRunOutlineReport.GenerateATextOutlineReportWithScenarioScenarios).FullName,
                typeof(xBDD.Features.GeneratingReports.GeneratingReports.GeneratingaTextTestRunOutlineReport.GenerateATextOutlineReportWithStepScenarios).FullName,
            };

            this.SortedFeatureNames = SortedFeatureNames.ToArray();

        }
    }
}
