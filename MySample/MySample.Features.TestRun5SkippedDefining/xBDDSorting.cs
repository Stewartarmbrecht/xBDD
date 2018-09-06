namespace MySample.Features.TestRun5SkippedDefining
{
	using System;
	using System.Collections.Generic;
	using xBDD;

	public partial class xBDDSorting: ISorting
	{
		public List<string> GetSortedFeatureNames() {
			return new List<string>() {
				typeof(MySample.Features.TestRun5SkippedDefining.Area1Passing.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun5SkippedDefining.Area2SkippedUntested.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun5SkippedDefining.Area2SkippedUntested.Feature2SkippedUntested).FullName,
				typeof(MySample.Features.TestRun5SkippedDefining.Area3SkippedCommitted.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun5SkippedDefining.Area3SkippedCommitted.Feature2SkippedUntested).FullName,
				typeof(MySample.Features.TestRun5SkippedDefining.Area3SkippedCommitted.Feature3SkippedCommitted).FullName,
				typeof(MySample.Features.TestRun5SkippedDefining.Area4SkippedReady.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun5SkippedDefining.Area4SkippedReady.Feature2SkippedUntested).FullName,
				typeof(MySample.Features.TestRun5SkippedDefining.Area4SkippedReady.Feature3SkippedCommitted).FullName,
				typeof(MySample.Features.TestRun5SkippedDefining.Area4SkippedReady.Feature4SkippedReady).FullName,
				typeof(MySample.Features.TestRun5SkippedDefining.Area5SkippedDefining.Feature1Passing).FullName,
				typeof(MySample.Features.TestRun5SkippedDefining.Area5SkippedDefining.Feature2SkippedUntested).FullName,
				typeof(MySample.Features.TestRun5SkippedDefining.Area5SkippedDefining.Feature3SkippedCommitted).FullName,
				typeof(MySample.Features.TestRun5SkippedDefining.Area5SkippedDefining.Feature4SkippedReady).FullName,
				typeof(MySample.Features.TestRun5SkippedDefining.Area5SkippedDefining.Feature5SkippedDefining).FullName,
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