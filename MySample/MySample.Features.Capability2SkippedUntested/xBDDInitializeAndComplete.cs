namespace MySample.Features.Capability2SkippedUntested
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
				typeof(MySample.Features.Capability2SkippedUntested.SubCapability1Passing.Feature1Passing).FullName,
				typeof(MySample.Features.Capability2SkippedUntested.SubCapability2SkippedUntested.Feature1Passing).FullName,
				typeof(MySample.Features.Capability2SkippedUntested.SubCapability2SkippedUntested.Feature2SkippedUntested).FullName,
			};
			xB.Complete("xBDDConfig.json", features, (message) => { Logger.LogMessage(message); });
		}
	}
}