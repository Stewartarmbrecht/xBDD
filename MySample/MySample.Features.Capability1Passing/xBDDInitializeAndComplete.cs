namespace MySample.Features.Capability1Passing
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
				typeof(MySample.Features.Capability1Passing.SubCapability1PassingWithAllFeaturesExercised.Feature1Passing).FullName,
			};
			xB.Complete("xBDDConfig.json", features, (message) => { Logger.LogMessage(message); });
		}
	}
}