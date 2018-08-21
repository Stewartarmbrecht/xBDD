namespace MySample.Generated
{
    using System;
    using System.Collections.Generic;
    public class FeatureSort
    {
        public string[] SortedFeatureNames { get; private set; }

        public FeatureSort()
        {
            List<string> SortedFeatureNames = new List<string>() {
                typeof(MySample.Generated.MyArea.MyFeature).FullName,
            };

            this.SortedFeatureNames = SortedFeatureNames.ToArray();

        }
    }
}