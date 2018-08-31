namespace xBDD.Features.GeneratingCode
{
	using System;
	using System.Collections.Generic;
	using xBDD;

	public partial class xBDDSorting: ISorting
	{
		public List<string> GetSortedFeatureNames() {
			return new List<string>() {
				typeof(xBDD.Features.GeneratingCode.GeneratingProjectFiles.GeneratingANewMSTestProject).FullName,
				typeof(xBDD.Features.GeneratingCode.GeneratingFeatureFiles.GenerateMSTestFeatureFilesFromAValidFeatureImportFile).FullName,
				typeof(xBDD.Features.GeneratingCode.GeneratingFeatureFiles.GenerateMSTestFeatureFilesFromAnInvalidFeatureImportFile).FullName,
				typeof(xBDD.Features.GeneratingCode.GeneratingSolutionFiles.GenerateCodeFromASolutionLevelFeatureImportFile).FullName,
			};
		}
		public List<string> GetSortedReasons() {
			return new List<string>() {
				"Defining",
			};
		}
	}
}