namespace MySample.Features.TestRun1Passing
{
	using System;
	using System.Collections.Generic;
	using xBDD;
	public partial class xBDDSorting: ISorting
	{
		public List<string> GetSortedFeatureNames() {
			return new List<string>() {
				typeof(MySample.Features.TestRun1Passing.Area1Passing.Feature1Passing).FullName,
			};
		}
		public List<string> GetSortedReasons() {
			return new List<string>() {
				"Defining",
			};
		}
	}
}