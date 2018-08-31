namespace xBDD.Features.GeneratingCode.GeneratingFeatureFiles
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	[AsA("Developer")]
	[YouCan("generate a new MS Test Project")]
	[By("executing the 'dotnet xbdd project generate MSTest' command")]
	public partial class GenerateMSTestFeatureFilesFromAValidFeatureImportFile: xBDDFeatureBase
	{

    }
}
