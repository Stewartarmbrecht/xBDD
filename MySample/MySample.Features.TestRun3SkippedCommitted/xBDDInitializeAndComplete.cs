namespace MySample.Features.TestRun3SkippedCommitted
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
				typeof(MySample.Features.TestRun3SkippedCommitted.Area1Passing.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun3SkippedCommitted.Area2SkippedUntested.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun3SkippedCommitted.Area2SkippedUntested.Feature2SkippedUntested).FullName,
				typeof(MySample.Features.TestRun3SkippedCommitted.Area3SkippedCommitted.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun3SkippedCommitted.Area3SkippedCommitted.Feature2SkippedUntested).FullName,
				typeof(MySample.Features.TestRun3SkippedCommitted.Area3SkippedCommitted.Feature3SkippedCommitted).FullName,
			};
			xB.Complete("xBDDConfig.json", features, (message) => { Logger.LogMessage(message); });
		}
	}
}