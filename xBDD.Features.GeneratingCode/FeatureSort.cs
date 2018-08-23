namespace xBDD.Features.GeneratingCode
{
    using System;
    using System.Collections.Generic;
    public class FeatureSort
    {
        public string[] SortedFeatureNames { get; private set; }

        public FeatureSort()
        {
            List<string> SortedFeatureNames = new List<string>() {
                typeof(xBDD.Features.GeneratingCode.GenerateProjectFiles.GeneratingANewMSTestProject).FullName,
                typeof(xBDD.Features.GeneratingCode.GenerateProjectFiles.GenerateCodeFromATestRunWithGeneralScenarios).FullName,
                typeof(xBDD.Features.GeneratingCode.GenerateProjectFiles.GenerateCodeFromATestRunWithTestRunScenarios).FullName,
                typeof(xBDD.Features.GeneratingCode.GenerateProjectFiles.GenerateCodeFromATestRunWithAreaScenarios).FullName,
                typeof(xBDD.Features.GeneratingCode.GenerateProjectFiles.GenerateCodeFromATestRunWithFeatureScenarios).FullName,
                typeof(xBDD.Features.GeneratingCode.GenerateProjectFiles.GenerateCodeFromATestRunWithScenarioScenarios).FullName,
                typeof(xBDD.Features.GeneratingCode.GenerateProjectFiles.GenerateCodeFromATestRunWithStepScenarios).FullName,
            };

            this.SortedFeatureNames = SortedFeatureNames.ToArray();

        }
    }
}
