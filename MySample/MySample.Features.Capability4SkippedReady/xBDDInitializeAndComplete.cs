namespace MySample.Features.Capability4SkippedReady
{
	using System.Collections.Generic;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
	using xBDD;

	[TestClass]
	public class TestSetupAndBreakdown
	{

		[AssemblyInitialize]
		public static void CapabilityStart(TestContext context)
		{
			xB.Initialize();
		}
		[AssemblyCleanup()]
		public static void CapabilityComplete()
		{
			var features = new List<string>() {
				typeof(MySample.Features.Capability4SkippedReady.SubCapability1Passing.Feature1Passing).FullName,
				typeof(MySample.Features.Capability4SkippedReady.SubCapability2SkippedUntested.Feature1Passing).FullName,
				typeof(MySample.Features.Capability4SkippedReady.SubCapability2SkippedUntested.Feature2SkippedUntested).FullName,
				typeof(MySample.Features.Capability4SkippedReady.SubCapability3SkippedCommitted.Feature1Passing).FullName,
				typeof(MySample.Features.Capability4SkippedReady.SubCapability3SkippedCommitted.Feature2SkippedUntested).FullName,
				typeof(MySample.Features.Capability4SkippedReady.SubCapability3SkippedCommitted.Feature3SkippedCommitted).FullName,
				typeof(MySample.Features.Capability4SkippedReady.SubCapability4SkippedReady.Feature1Passing).FullName,
				typeof(MySample.Features.Capability4SkippedReady.SubCapability4SkippedReady.Feature2SkippedUntested).FullName,
				typeof(MySample.Features.Capability4SkippedReady.SubCapability4SkippedReady.Feature3SkippedCommitted).FullName,
				typeof(MySample.Features.Capability4SkippedReady.SubCapability4SkippedReady.Feature4SkippedReady).FullName,
			};
			xB.Complete("xBDDConfig.json", features, (message) => { Logger.LogMessage(message); });
		}
	}
}