namespace xBDD.Features.GeneratingCode
{
	using System;
	using System.Collections.Generic;
	using xBDD;

	public partial class xBDDSorting: ISorting
	{
		public List<string> GetGeneratedSortedFeatureNames() {
			return new List<string>() {
				typeof(xBDD.Features.GeneratingCode.GeneratingProjectFiles.GeneratingANewMSTestProject).FullName,
				typeof(xBDD.Features.GeneratingCode.GeneratingFeatureFiles.GenerateMSTestFeatureFilesFromAValidFeatureImportFile).FullName,
				typeof(xBDD.Features.GeneratingCode.GeneratingFeatureFiles.GenerateMSTestFeatureFilesFromAnInvalidFeatureImportFile).FullName,
				typeof(xBDD.Features.GeneratingCode.GeneratingSolutionFiles.GenerateCodeFromASolutionLevelFeatureImportFile).FullName,
			};
		}
		public List<string> GetGeneratedReasons() {
			return new List<string>() {
				"Committed",
				"Defining",
			};
		}
	}
}