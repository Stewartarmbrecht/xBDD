namespace xBDD.Features.AutomatingUITesting
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
				typeof(xBDD.Features.AutomatingUITesting.Setup.SetupATestProject).FullName,
				typeof(xBDD.Features.AutomatingUITesting.Navigating.NavigateAsAUser).FullName,
				typeof(xBDD.Features.AutomatingUITesting.EnteringText.SendingStandardKeys).FullName,
				typeof(xBDD.Features.AutomatingUITesting.EnteringText.SendingSpecialKeys).FullName,
				typeof(xBDD.Features.AutomatingUITesting.EnteringText.PastingText).FullName,
				typeof(xBDD.Features.AutomatingUITesting.Clicking.LeftClickImmediate).FullName,
				typeof(xBDD.Features.AutomatingUITesting.Clicking.LeftClickWhenVisible).FullName,
				typeof(xBDD.Features.AutomatingUITesting.Clicking.LeftClickWhenOtherCondition).FullName,
				typeof(xBDD.Features.AutomatingUITesting.ValidatingThePage.ValidateElementIsVisible).FullName,
				typeof(xBDD.Features.AutomatingUITesting.ValidatingThePage.ValidateElementIsNotVisible).FullName,
				typeof(xBDD.Features.AutomatingUITesting.ValidatingThePage.ValidateElementHasText).FullName,
				typeof(xBDD.Features.AutomatingUITesting.ValidatingThePage.ValidateElementHasStyle).FullName,
				typeof(xBDD.Features.AutomatingUITesting.ValidatingThePage.ValidateElementHasTitle).FullName,
				typeof(xBDD.Features.AutomatingUITesting.ValidatingThePage.ValidateElementHasAttribute).FullName,
				typeof(xBDD.Features.AutomatingUITesting.CustomSteps.CreatingACustomStep).FullName,
				typeof(xBDD.Features.AutomatingUITesting.CustomSteps.LoadingAPage).FullName,
				typeof(xBDD.Features.AutomatingUITesting.CustomSteps.SendingKeysToAnElement).FullName,
				typeof(xBDD.Features.AutomatingUITesting.CustomSteps.ClickingAnElement).FullName,
				typeof(xBDD.Features.AutomatingUITesting.CustomSteps.GettingThePageSource).FullName,
				typeof(xBDD.Features.AutomatingUITesting.CustomSteps.AccessingTheWebDriver).FullName,
				typeof(xBDD.Features.AutomatingUITesting.CustomSteps.ValidatingAPagesTitle).FullName,
				typeof(xBDD.Features.AutomatingUITesting.CustomSteps.ValidatingAnElementsText).FullName,
				typeof(xBDD.Features.AutomatingUITesting.CustomSteps.ValidatingAnElementsStyle).FullName,
				typeof(xBDD.Features.AutomatingUITesting.CustomSteps.ValidatingAnElementsTitle).FullName,
				typeof(xBDD.Features.AutomatingUITesting.CustomSteps.WaitingTillAnElementIsVisible).FullName,
				typeof(xBDD.Features.AutomatingUITesting.CustomSteps.WaitingTillAnElementIsNotVisible).FullName,
				typeof(xBDD.Features.AutomatingUITesting.CustomSteps.ValidateAnElementDoesNotExist).FullName,
				typeof(xBDD.Features.AutomatingUITesting.UploadingAndDownloadFiles.UploadAFile).FullName,
				typeof(xBDD.Features.AutomatingUITesting.UploadingAndDownloadFiles.DownloadAFile).FullName,
				typeof(xBDD.Features.AutomatingUITesting.AdvancedClicking.RightClickImmediate).FullName,
				typeof(xBDD.Features.AutomatingUITesting.AdvancedClicking.RightClickWhenVisible).FullName,
				typeof(xBDD.Features.AutomatingUITesting.AdvancedClicking.DoubleClickImmediate).FullName,
				typeof(xBDD.Features.AutomatingUITesting.AdvancedClicking.DoubleClickWhenVisible).FullName,
				typeof(xBDD.Features.AutomatingUITesting.AdvancedClicking.DropDowns).FullName,
				typeof(xBDD.Features.AutomatingUITesting.AdvancedClicking.Scrolling).FullName,
				typeof(xBDD.Features.AutomatingUITesting.AdvancedClicking.Hovering).FullName,
				typeof(xBDD.Features.AutomatingUITesting.AdvancedClicking.Dragging).FullName,
				typeof(xBDD.Features.AutomatingUITesting.AdvancedActions.PlayAVideo).FullName,
				typeof(xBDD.Features.AutomatingUITesting.AdvancedActions.CaptureScreenImage).FullName,
				typeof(xBDD.Features.AutomatingUITesting.AdvancedActions.CaptureVideo).FullName,
				typeof(xBDD.Features.AutomatingUITesting.AdvancedActions.ToggleThinkTimes).FullName,
				typeof(xBDD.Features.AutomatingUITesting.AdvancedActions.SetDefaultWaitTime).FullName,
			};
			xB.Complete("xBDDConfig.json", sortedFeatureNames, (message) => { Logger.LogMessage(message); });
		}
	}
}