namespace MySample.Features.TestRun2SkippedUntested
{
	using System.Collections.Generic;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
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
			var features = new List<string>() {
				typeof(MySample.Features.TestRun2SkippedUntested.Capability1Passing.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun2SkippedUntested.Capability2SkippedUntested.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun2SkippedUntested.Capability2SkippedUntested.Feature2SkippedUntested).FullName,
			};
			xB.Complete("xBDDConfig.json", features, (message) => { Logger.LogMessage(message); });
		}
	}
}