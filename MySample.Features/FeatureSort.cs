namespace MySample.Features
{
    using System;
    using System.Collections.Generic;
    public class FeatureSort
    {
        public string[] SortedFeatureNames { get; private set; }

        public FeatureSort()
        {
            List<string> SortedFeatureNames = new List<string>() {
                typeof(MySample.Features.MyArea_1.MyFeature_1).FullName,
                typeof(MySample.Features.MyArea_1.MyFeature_2).FullName,
                typeof(MySample.Features.MyArea_1.MyFeature_3).FullName,
                typeof(MySample.Features.MyArea_2.MyFeature_4).FullName,
                typeof(MySample.Features.MyArea_2.MyFeature_5).FullName,
                typeof(MySample.Features.MyArea_2.MyFeature_6).FullName,
                typeof(MySample.Features.MyArea_3.MyFeature_7).FullName,
                typeof(MySample.Features.MyArea_3.MyFeature_8).FullName,
                typeof(MySample.Features.MyArea_3.MyFeature_9).FullName,
            };

            this.SortedFeatureNames = SortedFeatureNames.ToArray();

        }
    }
}
