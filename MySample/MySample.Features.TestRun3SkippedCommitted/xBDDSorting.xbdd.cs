namespace MySample.Features.TestRun3SkippedCommitted
{
	using System;
	using System.Collections.Generic;
	using xBDD;

	public partial class xBDDSorting: ISorting
	{
		public List<string> GetGeneratedSortedFeatureNames() {
			return new List<string>() {
				typeof(MySample.Features.TestRun3SkippedCommitted.Area1Passing.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun3SkippedCommitted.Area2SkippedUntested.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun3SkippedCommitted.Area2SkippedUntested.Feature2SkippedUntested).FullName,
				typeof(MySample.Features.TestRun3SkippedCommitted.Area3SkippedCommitted.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun3SkippedCommitted.Area3SkippedCommitted.Feature2SkippedUntested).FullName,
				typeof(MySample.Features.TestRun3SkippedCommitted.Area3SkippedCommitted.Feature3SkippedCommitted).FullName,
			};
		}
		public List<string> GetGeneratedReasons() {
			return new List<string>() {
				"Defining",
				"Untested",
				"Committed",
			};
		}
	}
}