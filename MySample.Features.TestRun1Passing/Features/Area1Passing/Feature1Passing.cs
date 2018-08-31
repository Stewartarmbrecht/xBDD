namespace MySample.Features.TestRun1Passing.Area1Passing
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	[AsA("User")]
	[YouCan("derive some value")]
	[By("doing something")]
	[Explanation(@"
		# Feature 1 Explanation
		This is my feature 1 explanation.",2)]
	public partial class Feature1Passing: xBDDFeatureBase
	{

    }
}
