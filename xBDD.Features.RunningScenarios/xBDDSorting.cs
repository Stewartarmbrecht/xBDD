namespace xBDD.Features.RunningScenarios
{
	using System;
	using System.Collections.Generic;
	using xBDD;

	public partial class xBDDSorting: ISorting
	{
		public List<string> GetSortedFeatureNames() {
			return new List<string>() {
				typeof(xBDD.Features.RunningScenarios.InitialSetup.RunningMSTestProjectScenarios).FullName,
			};
		}
		public List<string> GetSortedReasons() {
			return new List<string>() {
				"Untested",
				"Defining",
			};
		}
	}
}