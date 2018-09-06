namespace MySample.Features.TestRun1Passing
{
	using System;
	using System.Collections.Generic;
	using xBDD;

	public partial class xBDDSorting: ISorting
	{
		public List<string> GetGeneratedSortedFeatureNames() {
			return new List<string>() {
				typeof(MySample.Features.TestRun1Passing.Area1PassingWithAllFeaturesExercised.Feature1Passing).FullName,
			};
		}
		public List<string> GetGeneratedReasons() {
			return new List<string>() {
				"Defining",
			};
		}
	}
}