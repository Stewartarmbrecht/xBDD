namespace MyGeneratedSample.Features
{
	using System;
	using System.Collections.Generic;
	using xBDD;

	public partial class xBDDSorting: ISorting
	{
		public List<string> GetSortedFeatureNames() {
			return new List<string>() {
				typeof(MyGeneratedSample.Features.MyArea.MyFeature).FullName,
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