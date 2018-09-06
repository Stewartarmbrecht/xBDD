namespace MySample.Features.TestRun4SkippedReady
{
	using System;
	using System.Collections.Generic;
	using xBDD;

	public partial class xBDDSorting: ISorting
	{
		public List<string> GetSortedFeatureNames() {
			return new List<string>() {
				typeof(MySample.Features.TestRun4SkippedReady.Area1Passing.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun4SkippedReady.Area2SkippedUntested.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun4SkippedReady.Area2SkippedUntested.Feature2SkippedUntested).FullName,
				typeof(MySample.Features.TestRun4SkippedReady.Area3SkippedCommitted.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun4SkippedReady.Area3SkippedCommitted.Feature2SkippedUntested).FullName,
				typeof(MySample.Features.TestRun4SkippedReady.Area3SkippedCommitted.Feature3SkippedCommitted).FullName,
				typeof(MySample.Features.TestRun4SkippedReady.Area4SkippedReady.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun4SkippedReady.Area4SkippedReady.Feature2SkippedUntested).FullName,
				typeof(MySample.Features.TestRun4SkippedReady.Area4SkippedReady.Feature3SkippedCommitted).FullName,
				typeof(MySample.Features.TestRun4SkippedReady.Area4SkippedReady.Feature4SkippedReady).FullName,
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