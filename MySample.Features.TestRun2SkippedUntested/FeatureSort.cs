namespace MySample.Features.TestRun2SkippedUntested
{
    using System;
    using System.Collections.Generic;
    public class FeatureSort
    {
        public string[] SortedFeatureNames { get; private set; }

        public FeatureSort()
        {
            List<string> SortedFeatureNames = new List<string>() {
                typeof(MySample.Features.TestRun2SkippedUntested.Area1Passing.Feature1Passing).FullName,
                typeof(MySample.Features.TestRun2SkippedUntested.Area2SkippedUntested.Feature1Passing).FullName,
                typeof(MySample.Features.TestRun2SkippedUntested.Area2SkippedUntested.Feature2SkippedUntested).FullName,
            };

            this.SortedFeatureNames = SortedFeatureNames.ToArray();

        }
    }
}
