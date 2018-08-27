namespace MySample.Features.TestRun6Failed
{
    using System;
    using System.Collections.Generic;
    public class FeatureSort
    {
        public string[] SortedFeatureNames { get; private set; }

        public FeatureSort()
        {
            List<string> SortedFeatureNames = new List<string>() {
                typeof(MySample.Features.TestRun6Failed.Area1Passing.Feature1Passing).FullName,
                typeof(MySample.Features.TestRun6Failed.Area2SkippedUntested.Feature1Passing).FullName,
                typeof(MySample.Features.TestRun6Failed.Area2SkippedUntested.Feature2SkippedUntested).FullName,
                typeof(MySample.Features.TestRun6Failed.Area3SkippedBuilding.Feature1Passing).FullName,
                typeof(MySample.Features.TestRun6Failed.Area3SkippedBuilding.Feature2SkippedUntested).FullName,
                typeof(MySample.Features.TestRun6Failed.Area3SkippedBuilding.Feature3SkippedBuilding).FullName,
                typeof(MySample.Features.TestRun6Failed.Area4SkippedReady.Feature1Passing).FullName,
                typeof(MySample.Features.TestRun6Failed.Area4SkippedReady.Feature2SkippedUntested).FullName,
                typeof(MySample.Features.TestRun6Failed.Area4SkippedReady.Feature3SkippedBuilding).FullName,
                typeof(MySample.Features.TestRun6Failed.Area4SkippedReady.Feature4SkippedReady).FullName,
                typeof(MySample.Features.TestRun6Failed.Area5SkippedDefining.Feature1Passing).FullName,
                typeof(MySample.Features.TestRun6Failed.Area5SkippedDefining.Feature2SkippedUntested).FullName,
                typeof(MySample.Features.TestRun6Failed.Area5SkippedDefining.Feature3SkippedBuilding).FullName,
                typeof(MySample.Features.TestRun6Failed.Area5SkippedDefining.Feature4SkippedReady).FullName,
                typeof(MySample.Features.TestRun6Failed.Area5SkippedDefining.Feature5SkippedDefining).FullName,
                typeof(MySample.Features.TestRun6Failed.Area6Failed.Feature1Passing).FullName,
                typeof(MySample.Features.TestRun6Failed.Area6Failed.Feature2SkippedUntested).FullName,
                typeof(MySample.Features.TestRun6Failed.Area6Failed.Feature3SkippedBuilding).FullName,
                typeof(MySample.Features.TestRun6Failed.Area6Failed.Feature4SkippedReady).FullName,
                typeof(MySample.Features.TestRun6Failed.Area6Failed.Feature5SkippedDefining).FullName,
                typeof(MySample.Features.TestRun6Failed.Area6Failed.Feature6Failed).FullName,
            };

            this.SortedFeatureNames = SortedFeatureNames.ToArray();

        }
    }
}
