namespace xBDD.Features.GeneratingCode
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
				typeof(xBDD.Features.GeneratingCode.GeneratingProjectFiles.ForAnMSTestProject).FullName,
				typeof(xBDD.Features.GeneratingCode.GeneratingFeatureFiles.UsingAnXbddFeatureImportFile.WithAnInvalidOutline).FullName,
				typeof(xBDD.Features.GeneratingCode.GeneratingFeatureFiles.UsingAnXbddFeatureImportFile.ForAnMSTestProject).FullName,
				typeof(xBDD.Features.GeneratingCode.GeneratingSolutionFiles.UsingAnXbddFeatureImportFile.ForAnMSTestProject).FullName,
			};
			xB.Complete("xBDDConfig.json", sortedFeatureNames, (message) => { Logger.LogMessage(message); });
		}
	}
}