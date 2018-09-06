namespace MySample.Features.TestRun3SkippedCommitted
{
	using System;
	using System.Collections.Generic;
	using xBDD;

	public partial class xBDDSorting: ISorting
	{
		public List<string> GetSortedFeatureNames() {
			return new List<string>() {
				typeof(MySample.Features.TestRun3SkippedCommitted.Area1Passing.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun3SkippedCommitted.Area2SkippedUntested.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun3SkippedCommitted.Area2SkippedUntested.Feature2SkippedUntested).FullName,
				typeof(MySample.Features.TestRun3SkippedCommitted.Area3SkippedBuilding.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun3SkippedCommitted.Area3SkippedBuilding.Feature2SkippedUntested).FullName,
				typeof(MySample.Features.TestRun3SkippedCommitted.Area3SkippedBuilding.Feature3SkippedBuilding).FullName,
			};
		}
		public List<string> GetSortedReasons() {
			return new List<string>() {
				"Defining",
				"Untested",
				"Committed",
			};
		}
	}
}