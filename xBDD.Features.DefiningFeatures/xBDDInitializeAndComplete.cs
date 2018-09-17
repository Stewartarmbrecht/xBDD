namespace xBDD.Features.DefiningFeatures
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
	using System.Collections.Generic;
	using xBDD;

	[TestClass]
	public class TestSetupAndBreakdown
	{

		[AssemblyInitialize]
		public static void TestRunStart(TestContext context)
		{
			xB.Initialize();
		}
		[AssemblyCleanup()]
		public static void TestRunComplete()
		{
			var sortedFeatureNames = new List<string>() {
				typeof(xBDD.Features.DefiningFeatures.DefiningSteps.AddingStepsToAScenario).FullName,
				typeof(xBDD.Features.DefiningFeatures.DefiningSteps.SettingAnInputForAStep).FullName,
				typeof(xBDD.Features.DefiningFeatures.DefiningSteps.SharingValuesBetweenSteps).FullName,
				typeof(xBDD.Features.DefiningFeatures.DefiningSteps.SettingTheOutputForAStep).FullName,
				typeof(xBDD.Features.DefiningFeatures.DefiningScenarios.AddingScenarios).FullName,
				typeof(xBDD.Features.DefiningFeatures.DefiningScenarios.SettingAnOutputWriterForAScenario).FullName,
				typeof(xBDD.Features.DefiningFeatures.DefiningScenarios.SettingTheDefaultReportingSortForAScenario).FullName,
				typeof(xBDD.Features.DefiningFeatures.DefiningFeatures.AddingFeatures).FullName,
				typeof(xBDD.Features.DefiningFeatures.DefiningFeatures.SettingTheFeatureStatement).FullName,
				typeof(xBDD.Features.DefiningFeatures.DefiningFeatures.OverridingAFeatureName).FullName,
				typeof(xBDD.Features.DefiningFeatures.DefiningCapabilities.OverridingACapabilityName).FullName,
				typeof(xBDD.Features.DefiningFeatures.DefiningATestRun.SettingTheTestRunName).FullName,
				typeof(xBDD.Features.DefiningFeatures.SettingIds.SettingAnIDForAScenario).FullName,
				typeof(xBDD.Features.DefiningFeatures.SettingIds.SettingAnIDForAFeature).FullName,
				typeof(xBDD.Features.DefiningFeatures.SettingStatus.SettingTheStatusOfAScenario).FullName,
				typeof(xBDD.Features.DefiningFeatures.SettingStatus.SettingTheStatusOfAFeature).FullName,
				typeof(xBDD.Features.DefiningFeatures.AddingEstimates.SettingAFeatureScenarioEstimate).FullName,
				typeof(xBDD.Features.DefiningFeatures.AddingEstimates.SettingAFeatureValueEstimate).FullName,
				typeof(xBDD.Features.DefiningFeatures.AddingEstimates.SettingAFeatureLevelOfEffortEstimate).FullName,
				typeof(xBDD.Features.DefiningFeatures.AddingEstimates.SettingACapabilityEstimatesUsingAPlaceholderFeature).FullName,
				typeof(xBDD.Features.DefiningFeatures.AddingTags.AddingTagsToAScenario).FullName,
				typeof(xBDD.Features.DefiningFeatures.AddingTags.AddingTagsToAFeature).FullName,
				typeof(xBDD.Features.DefiningFeatures.AddingTags.AddingTagsToACapability).FullName,
				typeof(xBDD.Features.DefiningFeatures.AddingTags.AddingTagsToATestRun).FullName,
				typeof(xBDD.Features.DefiningFeatures.AddingExplanations.AddingAnExplanationToAStep).FullName,
				typeof(xBDD.Features.DefiningFeatures.AddingExplanations.AddingAnExplanationToAScenario).FullName,
				typeof(xBDD.Features.DefiningFeatures.AddingExplanations.AddingAnExplanationToAFeature).FullName,
				typeof(xBDD.Features.DefiningFeatures.AddingExplanations.AddingAnExplanationToACapability).FullName,
				typeof(xBDD.Features.DefiningFeatures.AddingExplanations.AddingAnExplanationToATestRun).FullName,
				typeof(xBDD.Features.DefiningFeatures.SettingOwnership.SettingAnOwnerForAScenario).FullName,
				typeof(xBDD.Features.DefiningFeatures.SettingOwnership.SettingAnOwnerForAFeature).FullName,
			};
			xB.Complete("xBDDConfig.json", sortedFeatureNames, (message) => { Logger.LogMessage(message); });
		}
	}
}