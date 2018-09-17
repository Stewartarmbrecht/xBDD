namespace MySample.Features.TestRun4SkippedReady
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
				typeof(MySample.Features.TestRun4SkippedReady.Capability1Passing.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun4SkippedReady.Capability2SkippedUntested.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun4SkippedReady.Capability2SkippedUntested.Feature2SkippedUntested).FullName,
				typeof(MySample.Features.TestRun4SkippedReady.Capability3SkippedCommitted.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun4SkippedReady.Capability3SkippedCommitted.Feature2SkippedUntested).FullName,
				typeof(MySample.Features.TestRun4SkippedReady.Capability3SkippedCommitted.Feature3SkippedCommitted).FullName,
				typeof(MySample.Features.TestRun4SkippedReady.Capability4SkippedReady.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun4SkippedReady.Capability4SkippedReady.Feature2SkippedUntested).FullName,
				typeof(MySample.Features.TestRun4SkippedReady.Capability4SkippedReady.Feature3SkippedCommitted).FullName,
				typeof(MySample.Features.TestRun4SkippedReady.Capability4SkippedReady.Feature4SkippedReady).FullName,
			};
			xB.Complete("xBDDConfig.json", features, (message) => { Logger.LogMessage(message); });
		}
	}
}