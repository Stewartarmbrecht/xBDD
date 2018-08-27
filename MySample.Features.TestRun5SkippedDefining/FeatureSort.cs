namespace MySample.Features.TestRun5SkippedDefining
{
    using System;
    using System.Collections.Generic;
    public class FeatureSort
    {
        public string[] SortedFeatureNames { get; private set; }

        public FeatureSort()
        {
            List<string> SortedFeatureNames = new List<string>() {
                typeof(MySample.Features.TestRun5SkippedDefining.Area1Passing.Feature1Passing).FullName,
                typeof(MySample.Features.TestRun5SkippedDefining.Area2SkippedUntested.Feature1Passing).FullName,
                typeof(MySample.Features.TestRun5SkippedDefining.Area2SkippedUntested.Feature2SkippedUntested).FullName,
                typeof(MySample.Features.TestRun5SkippedDefining.Area3SkippedBuilding.Feature1Passing).FullName,
                typeof(MySample.Features.TestRun5SkippedDefining.Area3SkippedBuilding.Feature2SkippedUntested).FullName,
                typeof(MySample.Features.TestRun5SkippedDefining.Area3SkippedBuilding.Feature3SkippedBuilding).FullName,
                typeof(MySample.Features.TestRun5SkippedDefining.Area4SkippedReady.Feature1Passing).FullName,
                typeof(MySample.Features.TestRun5SkippedDefining.Area4SkippedReady.Feature2SkippedUntested).FullName,
                typeof(MySample.Features.TestRun5SkippedDefining.Area4SkippedReady.Feature3SkippedBuilding).FullName,
                typeof(MySample.Features.TestRun5SkippedDefining.Area4SkippedReady.Feature4SkippedReady).FullName,
                typeof(MySample.Features.TestRun5SkippedDefining.Area5SkippedDefining.Feature1Passing).FullName,
                typeof(MySample.Features.TestRun5SkippedDefining.Area5SkippedDefining.Feature2SkippedUntested).FullName,
                typeof(MySample.Features.TestRun5SkippedDefining.Area5SkippedDefining.Feature3SkippedBuilding).FullName,
                typeof(MySample.Features.TestRun5SkippedDefining.Area5SkippedDefining.Feature4SkippedReady).FullName,
                typeof(MySample.Features.TestRun5SkippedDefining.Area5SkippedDefining.Feature5SkippedDefining).FullName,
            };

            this.SortedFeatureNames = SortedFeatureNames.ToArray();

        }
    }
}
