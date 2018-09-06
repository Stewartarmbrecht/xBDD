namespace MySample.Features.TestRun5SkippedDefining
{
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
			xB.Complete("MySample.Features.TestRun5SkippedDefining", new xBDDSorting(), (message) => { Logger.LogMessage(message); });
		}
	}
}