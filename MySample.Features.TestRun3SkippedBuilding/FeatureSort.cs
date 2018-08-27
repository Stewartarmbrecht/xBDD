namespace MySample.Features.TestRun3SkippedBuilding
{
    using System;
    using System.Collections.Generic;
    public class FeatureSort
    {
        public string[] SortedFeatureNames { get; private set; }

        public FeatureSort()
        {
            List<string> SortedFeatureNames = new List<string>() {
                typeof(MySample.Features.TestRun3SkippedBuilding.Area1Passing.Feature1Passing).FullName,
                typeof(MySample.Features.TestRun3SkippedBuilding.Area2SkippedUntested.Feature1Passing).FullName,
                typeof(MySample.Features.TestRun3SkippedBuilding.Area2SkippedUntested.Feature2SkippedUntested).FullName,
                typeof(MySample.Features.TestRun3SkippedBuilding.Area3SkippedBuilding.Feature1Passing).FullName,
                typeof(MySample.Features.TestRun3SkippedBuilding.Area3SkippedBuilding.Feature2SkippedUntested).FullName,
                typeof(MySample.Features.TestRun3SkippedBuilding.Area3SkippedBuilding.Feature3SkippedBuilding).FullName,
            };

            this.SortedFeatureNames = SortedFeatureNames.ToArray();

        }
    }
}
