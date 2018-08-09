namespace SampleApp.Features
{
    using System;
    using System.Collections.Generic;
    public static class SampleFeatureSort
    {
        public static string[] SortedFeatureNames = new List<string>() {
                typeof(SampleApp.Features.SampleTestRunFeatures.SamplePassingFeature).FullName,
                typeof(SampleApp.Features.SampleTestRunFeatures.SampleSkippedFeature).FullName,
                typeof(SampleApp.Features.SampleTestRunFeatures.SampleAllOutcomeFeature).FullName,
            }.ToArray();
    }
}