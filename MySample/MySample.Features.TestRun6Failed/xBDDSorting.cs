namespace MySample.Features.TestRun6Failed
{
	using System;
	using System.Collections.Generic;
	using xBDD;

	public partial class xBDDSorting: ISorting
	{
		public List<string> GetSortedFeatureNames() {
			return new List<string>() {
				typeof(MySample.Features.TestRun6Failed.Area1Passing.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun6Failed.Area2SkippedUntested.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun6Failed.Area2SkippedUntested.Feature2SkippedUntested).FullName,
				typeof(MySample.Features.TestRun6Failed.Area3SkippedCommitted.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun6Failed.Area3SkippedCommitted.Feature2SkippedUntested).FullName,
				typeof(MySample.Features.TestRun6Failed.Area3SkippedCommitted.Feature3SkippedCommitted).FullName,
				typeof(MySample.Features.TestRun6Failed.Area4SkippedReady.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun6Failed.Area4SkippedReady.Feature2SkippedUntested).FullName,
				typeof(MySample.Features.TestRun6Failed.Area4SkippedReady.Feature3SkippedCommitted).FullName,
				typeof(MySample.Features.TestRun6Failed.Area4SkippedReady.Feature4SkippedReady).FullName,
				typeof(MySample.Features.TestRun6Failed.Area5SkippedDefining.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun6Failed.Area5SkippedDefining.Feature2SkippedUntested).FullName,
				typeof(MySample.Features.TestRun6Failed.Area5SkippedDefining.Feature3SkippedCommitted).FullName,
				typeof(MySample.Features.TestRun6Failed.Area5SkippedDefining.Feature4SkippedReady).FullName,
				typeof(MySample.Features.TestRun6Failed.Area5SkippedDefining.Feature5SkippedDefining).FullName,
				typeof(MySample.Features.TestRun6Failed.Area6Failed.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun6Failed.Area6Failed.Feature2SkippedUntested).FullName,
				typeof(MySample.Features.TestRun6Failed.Area6Failed.Feature3SkippedCommitted).FullName,
				typeof(MySample.Features.TestRun6Failed.Area6Failed.Feature4SkippedReady).FullName,
				typeof(MySample.Features.TestRun6Failed.Area6Failed.Feature5SkippedDefining).FullName,
				typeof(MySample.Features.TestRun6Failed.Area6Failed.Feature6Failed).FullName,
			};
		}
		public List<string> GetSortedReasons() {
			return new List<string>() {
				"Defining",
				"Untested",
				"Committed",
				"Ready",
			};
		}
	}
}