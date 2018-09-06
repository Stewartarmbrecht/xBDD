namespace MySample.Features.TestRun2SkippedUntested
{
	using System;
	using System.Collections.Generic;
	using xBDD;

	public partial class xBDDSorting: ISorting
	{
		public List<string> GetSortedFeatureNames() {
			return new List<string>() {
				typeof(MySample.Features.TestRun2SkippedUntested.Area1Passing.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun2SkippedUntested.Area2SkippedUntested.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun2SkippedUntested.Area2SkippedUntested.Feature2SkippedUntested).FullName,
			};
		}
		public List<string> GetSortedReasons() {
			return new List<string>() {
				"Defining",
				"Untested",
			};
		}
	}
}