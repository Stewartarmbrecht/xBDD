namespace xBDD.Features.RunningScenarios
{
	using System;
	using System.Collections.Generic;
	using xBDD;

	public partial class xBDDSorting: ISorting
	{
		public List<string> GetGeneratedSortedFeatureNames() {
			return new List<string>() {
				typeof(xBDD.Features.RunningScenarios.InitialSetup.RunningMSTestProjectScenarios).FullName,
			};
		}
		public List<string> GetGeneratedReasons() {
			return new List<string>() {
				"Untested",
				"Defining",
			};
		}
	}
}