namespace MySample.Features.TestRun6Failed
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
				typeof(MySample.Features.TestRun6Failed.Capability1Passing.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun6Failed.Capability2SkippedUntested.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun6Failed.Capability2SkippedUntested.Feature2SkippedUntested).FullName,
				typeof(MySample.Features.TestRun6Failed.Capability3SkippedCommitted.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun6Failed.Capability3SkippedCommitted.Feature2SkippedUntested).FullName,
				typeof(MySample.Features.TestRun6Failed.Capability3SkippedCommitted.Feature3SkippedCommitted).FullName,
				typeof(MySample.Features.TestRun6Failed.Capability4SkippedReady.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun6Failed.Capability4SkippedReady.Feature2SkippedUntested).FullName,
				typeof(MySample.Features.TestRun6Failed.Capability4SkippedReady.Feature3SkippedCommitted).FullName,
				typeof(MySample.Features.TestRun6Failed.Capability4SkippedReady.Feature4SkippedReady).FullName,
				typeof(MySample.Features.TestRun6Failed.Capability5SkippedDefining.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun6Failed.Capability5SkippedDefining.Feature2SkippedUntested).FullName,
				typeof(MySample.Features.TestRun6Failed.Capability5SkippedDefining.Feature3SkippedCommitted).FullName,
				typeof(MySample.Features.TestRun6Failed.Capability5SkippedDefining.Feature4SkippedReady).FullName,
				typeof(MySample.Features.TestRun6Failed.Capability5SkippedDefining.Feature5SkippedDefining).FullName,
				typeof(MySample.Features.TestRun6Failed.Capability6Failed.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun6Failed.Capability6Failed.Feature2SkippedUntested).FullName,
				typeof(MySample.Features.TestRun6Failed.Capability6Failed.Feature3SkippedCommitted).FullName,
				typeof(MySample.Features.TestRun6Failed.Capability6Failed.Feature4SkippedReady).FullName,
				typeof(MySample.Features.TestRun6Failed.Capability6Failed.Feature5SkippedDefining).FullName,
				typeof(MySample.Features.TestRun6Failed.Capability6Failed.Feature6Failed).FullName,
			};
			xB.Complete("xBDDConfig.json", features, (message) => { Logger.LogMessage(message); });
		}
	}
}