namespace xBDD.Features.GeneratingCode
{
	using System;
	using System.Collections.Generic;
	using xBDD;

	public partial class xBDDSorting: ISorting
	{
		public List<string> GetSortedFeatureNames() {
			return new List<string>() {
				typeof(xBDD.Features.GeneratingCode.GeneratingProjectFiles.ForAnMSTestProject).FullName,
				typeof(xBDD.Features.GeneratingCode.GeneratingFeatureFiles.UsingAnXbddFeatureImportFile.WithAnInvalidOutline).FullName,
				typeof(xBDD.Features.GeneratingCode.GeneratingFeatureFiles.UsingAnXbddFeatureImportFile.ForAnMSTestProject).FullName,
				typeof(xBDD.Features.GeneratingCode.GeneratingSolutionFiles.UsingAnXbddFeatureImportFile.ForAnMSTestProject).FullName,
			};
		}
		public List<string> GetSortedReasons() {
			return new List<string>() {
				"Removing",
				"Untested",
				"Committed",
				"Ready",
				"Defining",
			};
		}
	}
}