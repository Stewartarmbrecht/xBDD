namespace MyGeneratedSample.Features
{
	using System;
	using System.Collections.Generic;
	using xBDD;

	public partial class xBDDSorting: ISorting
	{
		public List<string> GetGeneratedSortedFeatureNames() {
			return new List<string>() {
				typeof(MyGeneratedSample.Features.MyArea.MyFeature).FullName,
			};
		}
		public List<string> GetGeneratedReasons() {
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