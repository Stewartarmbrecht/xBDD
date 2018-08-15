namespace xBDD.Features
{
    using System;
    using System.Collections.Generic;
    public class FeatureSort
    {
        public string[] SortedFeatureNames { get; private set; }

        public FeatureSort()
        {
            List<string> SortedFeatureNames = new List<string>() {
                typeof(xBDD.Features.GettingStarted.InstallingTheFramework).FullName,
                typeof(xBDD.Features.GettingStarted.ExecutingYourFirstScenario).FullName,
                typeof(xBDD.Features.GettingStarted.SkippingAScenario).FullName,
                typeof(xBDD.Features.GettingStarted.UseAScenarioToCreateDocumentation).FullName,
                typeof(xBDD.Features.GettingStarted.DefineAScenarioWithReusableSteps).FullName,
                typeof(xBDD.Features.GettingStarted.FindingThexBDDProjectSite).FullName,
                typeof(xBDD.Features.GenerateReports.GenerateHtmlReport.WriteToHtml).FullName,
                typeof(xBDD.Features.GenerateReports.BrowseHtmlReport.ReviewTestRun).FullName,
                typeof(xBDD.Features.GenerateReports.BrowseHtmlReport.ReviewTestRunStats).FullName,
                typeof(xBDD.Features.GenerateReports.BrowseHtmlReport.ReviewArea).FullName,
                typeof(xBDD.Features.GenerateReports.BrowseHtmlReport.ReviewAreaFeatureDistribution).FullName,
                typeof(xBDD.Features.GenerateReports.BrowseHtmlReport.ReviewAreaDescription).FullName,
                typeof(xBDD.Features.GenerateReports.BrowseHtmlReport.ReviewAreaFeatures).FullName,
                typeof(xBDD.Features.GenerateReports.BrowseHtmlReport.ReviewAreaStats).FullName,
                typeof(xBDD.Features.GenerateReports.BrowseHtmlReport.ReviewFeature).FullName,
                typeof(xBDD.Features.GenerateReports.BrowseHtmlReport.ReviewFeatureScenarioDistribution).FullName,
                typeof(xBDD.Features.GenerateReports.BrowseHtmlReport.ReviewFeatureStatement).FullName,
                typeof(xBDD.Features.GenerateReports.BrowseHtmlReport.ReviewFeatureStats).FullName,
                typeof(xBDD.Features.GenerateReports.BrowseHtmlReport.ReviewScenario).FullName,
                typeof(xBDD.Features.GenerateReports.BrowseHtmlReport.ReviewScenarioStats).FullName,
                typeof(xBDD.Features.GenerateReports.BrowseHtmlReport.ReviewStep).FullName,
                typeof(xBDD.Features.GenerateReports.BrowseHtmlReport.ReviewStepStats).FullName,
                typeof(xBDD.Features.GenerateReports.BrowseHtmlReport.ReviewStepException).FullName,
                typeof(xBDD.Features.GenerateReports.BrowseHtmlReport.ReviewStepMultilineParameter).FullName,
                typeof(xBDD.Features.GenerateReports.BrowseHtmlReport.ReviewStepOutput).FullName,
                typeof(xBDD.Features.GenerateReports.CustomizeHtmlReport.WriteFailuresOnly).FullName,
                typeof(xBDD.Features.GenerateReports.CustomizeHtmlReport.ShortenAreaName).FullName,
                typeof(xBDD.Features.GenerateReports.CustomizeHtmlReport.SortTestRunResults).FullName,
                typeof(xBDD.Features.GenerateReports.GenerateTextReport.WriteToText).FullName,
                typeof(xBDD.Features.GenerateReports.GenerateJsonReport.WriteToJson).FullName,
            };

            this.SortedFeatureNames = SortedFeatureNames.ToArray();

        }
    }
}