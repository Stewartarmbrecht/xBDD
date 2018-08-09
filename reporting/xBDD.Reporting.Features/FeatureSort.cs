namespace xBDD.Reporting.Features
{
    using System;
    using System.Collections.Generic;
    public class FeatureSort
    {
        public string[] SortedFeatureNames { get; private set; }

        public FeatureSort()
        {
            List<string> SortedFeatureNames = new List<string>() {
                typeof(xBDD.Reporting.Features.GenerateHtmlReport.WriteToHtml).FullName,
                typeof(xBDD.Reporting.Features.BrowseHtmlReport.ReviewTestRun).FullName,
                typeof(xBDD.Reporting.Features.BrowseHtmlReport.ReviewTestRunStats).FullName,
                typeof(xBDD.Reporting.Features.BrowseHtmlReport.ReviewArea).FullName,
                typeof(xBDD.Reporting.Features.BrowseHtmlReport.ReviewAreaDescription).FullName,
                typeof(xBDD.Reporting.Features.BrowseHtmlReport.ReviewAreaFeatures).FullName,
                typeof(xBDD.Reporting.Features.BrowseHtmlReport.ReviewAreaStats).FullName,
                typeof(xBDD.Reporting.Features.BrowseHtmlReport.ReviewFeature).FullName,
                typeof(xBDD.Reporting.Features.BrowseHtmlReport.ReviewFeatureStatement).FullName,
                typeof(xBDD.Reporting.Features.BrowseHtmlReport.ReviewFeatureStats).FullName,
                typeof(xBDD.Reporting.Features.BrowseHtmlReport.ReviewScenario).FullName,
                typeof(xBDD.Reporting.Features.BrowseHtmlReport.ReviewScenarioStats).FullName,
                typeof(xBDD.Reporting.Features.BrowseHtmlReport.ReviewStep).FullName,
                typeof(xBDD.Reporting.Features.BrowseHtmlReport.ReviewStepException).FullName,
                typeof(xBDD.Reporting.Features.BrowseHtmlReport.ReviewStepOutput).FullName,
                typeof(xBDD.Reporting.Features.CustomizeHtmlReport.WriteFailuresOnly).FullName,
                typeof(xBDD.Reporting.Features.CustomizeHtmlReport.ShortenAreaName).FullName,
                typeof(xBDD.Reporting.Features.CustomizeHtmlReport.SortAreas).FullName,
                typeof(xBDD.Reporting.Features.GenerateTextReport.WriteToText).FullName,
            };

        }
    }
}