namespace MySample.Features
{
    using System;
    using System.Collections.Generic;
    public class FeatureSortFull
    {
        public string[] SortedFeatureNames { get; private set; }

        public FeatureSortFull()
        {
            List<string> SortedFeatureNames = new List<string>() {
                typeof(MySample.Features.MyArea_0_Unsorted.MyFeature_0_Unsorted).FullName,
                typeof(MySample.Features.MyArea_1_AllPassing.MyFeature_1_Passing).FullName,
                typeof(MySample.Features.MyArea_1_AllPassing.MyFeature_2_Passing_PartialStatement).FullName,
                typeof(MySample.Features.MyArea_1_AllPassing.MyFeature_3_Passing_MissingStatement).FullName,
                typeof(MySample.Features.MyArea_1_AllPassing.MyFeature_4_Passing_ReusableSteps).FullName,
                typeof(MySample.Features.MyArea_2_SomeSkipped.MyFeature_5_SomeSkipped).FullName,
                typeof(MySample.Features.MyArea_2_SomeSkipped.MyFeature_6_SomeSkipped).FullName,
                typeof(MySample.Features.MyArea_2_SomeSkipped.MyFeature_7_NoneSkipped).FullName,
                typeof(MySample.Features.MyArea_3_SomeFailed.MyFeature_8_SomeFailed).FullName,
                typeof(MySample.Features.MyArea_3_SomeFailed.MyFeature_9_SomeSkipped).FullName,
                typeof(MySample.Features.MyArea_3_SomeFailed.MyFeature_10_AllPassed).FullName,
                typeof(MySample.Features.MyArea_4_CompleteFailure.MyFeature_11_CompleteFailure).FullName,
                typeof(MySample.Features.MyArea_5_SortFlip.MyFeature_13_First).FullName,
                typeof(MySample.Features.MyArea_5_SortFlip.MyFeature_14_Second).FullName,
                typeof(MySample.Features.MyArea_5_SortFlip.MyFeature_12_Third).FullName,
                typeof(MySample.Features.MyArea_6_AllSkipped.MyFeature_15_AllSkipped).FullName,
                typeof(MySample.Features.MyArea_7_AllFailed.MyFeature_16_AllFailed).FullName,
                typeof(MySample.Features.MyFirstArea.MyFirstFeature).FullName,
                typeof(MySample.Features.MyFirstArea.MyFirstFailingFeature).FullName,
            };

            this.SortedFeatureNames = SortedFeatureNames.ToArray();

        }
    }
}
