using System;
using System.Collections.Generic;

namespace xBDD.Model
{

	/// <summary>
	/// Contains metadata about an area.
	/// </summary>
	public class Area
	{
		internal Area()
		{
			Features = new List<Feature>();
		}

		/// <summary>
		/// The parent test run.
		/// </summary>
		/// <value><see cref="TestRun"/></value>
		public TestRun TestRun { get; set; }

		/// <summary>
		/// The name of the area.
		/// Built from the code's namespace.
		/// </summary>
		/// <value></value>
		public string Name { get; set; }

		/// <summary>
		/// The testing outcome for the area.
		/// </summary>
		/// <value><see cref="Outcome"/></value>
        public Outcome Outcome { get; set; }

		/// <summary>
		/// The start time for the first step.
		/// </summary>
		/// <value><see cref="DateTime"/></value>
        public DateTime StartTime { get; set; }

		/// <summary>
		/// The end time of the last step.
		/// </summary>
		/// <value><see cref="DateTime"/></value>
        public DateTime EndTime { get; set; }

		/// <summary>
		/// The duration for executing the area.
		/// </summary>
		/// <value><see cref="TimeSpan"/></value>
        public TimeSpan Time { get; set; }

		/// <summary>
		/// The features executed within the area.
		/// </summary>
		/// <value><see cref="List{Feature}"/></value>
		public List<Feature> Features { get; set; }

		/// <summary>
		/// Statistics about the steps that were executed.
		/// </summary>
		/// <value><see cref="OutcomeStats"/></value>
		public OutcomeStats StepStats { get; set; }

		/// <summary>
		/// Statistics about the scenarios that were executed.
		/// </summary>
		/// <value><see cref="OutcomeStats"/></value>
		public OutcomeStats ScenarioStats { get; set; }

		/// <summary>
		/// Statistics about the features that were executed.
		/// </summary>
		/// <value><see cref="OutcomeStats"/></value>
		public OutcomeStats FeatureStats { get; set; }
	}
}