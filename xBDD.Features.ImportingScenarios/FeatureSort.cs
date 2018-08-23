namespace xBDD.Features.ImportingScenarios
{
    using System;
    using System.Collections.Generic;
    public class FeatureSort
    {
        public string[] SortedFeatureNames { get; private set; }

        public FeatureSort()
        {
            List<string> SortedFeatureNames = new List<string>() {
                typeof(xBDD.Features.ImportingScenarios.ImportingScenariosImportingFromATextOutline.FromATextOutlineWithGeneralScenarios).FullName,
                typeof(xBDD.Features.ImportingScenarios.ImportingScenariosImportingFromATextOutline.FromATextOutlineWithAreaScenarios).FullName,
                typeof(xBDD.Features.ImportingScenarios.ImportingScenariosImportingFromATextOutline.FromATextOutlineWithFeatureScenarios).FullName,
                typeof(xBDD.Features.ImportingScenarios.ImportingScenariosImportingFromATextOutline.FromATextOutlineWithScenarioScenarios).FullName,
                typeof(xBDD.Features.ImportingScenarios.ImportingScenariosImportingFromATextOutline.FromATextOutlineWithStepScenarios).FullName,
            };

            this.SortedFeatureNames = SortedFeatureNames.ToArray();

        }
    }
}
