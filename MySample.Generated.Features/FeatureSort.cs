namespace MySample.Generated.Features
{
    using System;
    using System.Collections.Generic;
    public class FeatureSort
    {
        public string[] SortedFeatureNames { get; private set; }

        public FeatureSort()
        {
            List<string> SortedFeatureNames = new List<string>() {
                typeof(MySample.Generated.Features.MyArea.MyFeature).FullName,
            };

            this.SortedFeatureNames = SortedFeatureNames.ToArray();

        }
    }
}