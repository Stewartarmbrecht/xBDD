namespace xBDD.Features.DefiningFeatures
{
    using System;
    using System.Collections.Generic;
    public class FeatureSort
    {
        public string[] SortedFeatureNames { get; private set; }

        public FeatureSort()
        {
            List<string> SortedFeatureNames = new List<string>() {
                typeof(xBDD.Features.DefiningFeatures.InitialSetup.GeneratingANewProject).FullName,
                typeof(xBDD.Features.DefiningFeatures.InitialSetup.AddingToAnExistingProject).FullName,
                typeof(xBDD.Features.DefiningFeatures.InitialSetup.RunningScenarios).FullName,
                typeof(xBDD.Features.DefiningFeatures.InitialSetup.SettingTheScenarioOutcome).FullName,
                typeof(xBDD.Features.DefiningFeatures.InitialSetup.InstallingVscodeSnippets).FullName,
                typeof(xBDD.Features.DefiningFeatures.DefiningSteps.AddingStepsToAScenario).FullName,
                typeof(xBDD.Features.DefiningFeatures.DefiningSteps.SettingAMultilineInputForAStep).FullName,
                typeof(xBDD.Features.DefiningFeatures.DefiningSteps.SharingValuesBetweenSteps).FullName,
                typeof(xBDD.Features.DefiningFeatures.DefiningSteps.SettingTheOutputForAStep).FullName,
                typeof(xBDD.Features.DefiningFeatures.DefiningScenarios.AddingScenarios).FullName,
                typeof(xBDD.Features.DefiningFeatures.DefiningScenarios.SettingAnOutputWriterForAScenario).FullName,
                typeof(xBDD.Features.DefiningFeatures.DefiningScenarios.SettingTheDefaultReportingSortForAScenario).FullName,
                typeof(xBDD.Features.DefiningFeatures.DefiningFeatures.AddingFeatures).FullName,
                typeof(xBDD.Features.DefiningFeatures.DefiningFeatures.SettingTheFeatureStatement).FullName,
                typeof(xBDD.Features.DefiningFeatures.DefiningFeatures.OverridingAFeatureName).FullName,
                typeof(xBDD.Features.DefiningFeatures.DefiningAreas.OverridingAnAreaName).FullName,
                typeof(xBDD.Features.DefiningFeatures.DefiningATestRun.SettingTheTestRunName).FullName,
                typeof(xBDD.Features.DefiningFeatures.SettingIds.SettingAnIDForAScenario).FullName,
                typeof(xBDD.Features.DefiningFeatures.SettingIds.SettingAnIDForAFeature).FullName,
                typeof(xBDD.Features.DefiningFeatures.SettingStatus.SettingTheStatusOfAScenario).FullName,
                typeof(xBDD.Features.DefiningFeatures.SettingStatus.SettingTheStatusOfAFeature).FullName,
                typeof(xBDD.Features.DefiningFeatures.AddingEstimates.SettingAFeatureScenarioEstimate).FullName,
                typeof(xBDD.Features.DefiningFeatures.AddingEstimates.SettingAFeatureValueEstimate).FullName,
                typeof(xBDD.Features.DefiningFeatures.AddingEstimates.SettingAFeatureLevelOfEffortEstimate).FullName,
                typeof(xBDD.Features.DefiningFeatures.AddingEstimates.SettingAAreaEstimatesUsingAPlaceholderFeature).FullName,
                typeof(xBDD.Features.DefiningFeatures.AddingTags.AddingTagsToAScenario).FullName,
                typeof(xBDD.Features.DefiningFeatures.AddingTags.AddingTagsToAFeature).FullName,
                typeof(xBDD.Features.DefiningFeatures.AddingTags.AddingTagsToAnArea).FullName,
                typeof(xBDD.Features.DefiningFeatures.AddingTags.AddingTagsToATestRun).FullName,
                typeof(xBDD.Features.DefiningFeatures.AddingExplanations.AddingAnExplanationToAStep).FullName,
                typeof(xBDD.Features.DefiningFeatures.AddingExplanations.AddingAnExplanationToAScenario).FullName,
                typeof(xBDD.Features.DefiningFeatures.AddingExplanations.AddingAnExplanationToAFeature).FullName,
                typeof(xBDD.Features.DefiningFeatures.AddingExplanations.AddingAnExplanationToAnArea).FullName,
                typeof(xBDD.Features.DefiningFeatures.AddingExplanations.AddingAnExplanationToATestRun).FullName,
                typeof(xBDD.Features.DefiningFeatures.SettingOwnership.SettingAnOwnerForAScenario).FullName,
                typeof(xBDD.Features.DefiningFeatures.SettingOwnership.SettingAnOwnerForAFeature).FullName,
            };

            this.SortedFeatureNames = SortedFeatureNames.ToArray();

        }
    }
}
