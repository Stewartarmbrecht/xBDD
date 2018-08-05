using System;
using System.Collections.Generic;

namespace xBDD.Model
{

	/// <summary>
	/// Contains metadata about a feature executed during a test run.
	/// </summary>
	public class Feature
	{
		internal Feature()
		{
			Scenarios = new List<Scenario>();
		}

		/// <summary>
		/// The area the feature is a part of.
		/// </summary>
		/// <value><see cref="Area"/></value>
		public Area Area { get; internal set; }

		/// <summary>
		/// Name of the feature.
		/// Built from the name of the class.
		/// </summary>
		/// <value><see cref="String"/></value>
		public string Name { get; internal set; }

		/// <summary>
		/// The actor name who executes the feature.
		/// As a [BLANK]
		/// </summary>
		/// <value><see cref="String"/></value>
		public string Actor { get; set; }

		/// <summary>
		/// The statment that covers what the user can do.
		/// I would like to [BLANK]
		/// </summary>
		/// <value><see cref="String"/></value>
		public string Capability { get; set; }

		/// <summary>
		/// The statement that explains why the user wants the feature.
		/// In order to [BLANK]
		/// </summary>
		/// <value><see cref="String"/></value>
		public string Value { get; set; }

		/// <summary>
		/// The testing outcome for the feature.
		/// </summary>
		/// <value><see cref="Outcome"/></value>
        public Outcome Outcome { get; internal set; }

		/// <summary>
		/// The start time for the first step.
		/// </summary>
		/// <value><see cref="DateTime"/></value>
        public DateTime StartTime { get; internal set; }

		/// <summary>
		/// The end time of the last step.
		/// </summary>
		/// <value><see cref="DateTime"/></value>
        public DateTime EndTime { get; internal set; }

		/// <summary>
		/// The duration for executing the scenario.
		/// </summary>
		/// <value><see cref="TimeSpan"/></value>
        public TimeSpan Time { get; internal set; }

		/// <summary>
		/// The scenarios executed as part of the feature.
		/// </summary>
		/// <value><see cref="List{Scenario}"/></value>
		public List<Scenario> Scenarios { get; internal set; }

		/// <summary>
		/// Statistics about the steps that were executed.
		/// </summary>
		/// <value><see cref="OutcomeStats"/></value>
		public OutcomeStats StepStats { get; internal set; }

		/// <summary>
		/// Statistics about the scenarios that were executed.
		/// </summary>
		/// <value><see cref="OutcomeStats"/></value>
		public OutcomeStats ScenarioStats { get; internal set; }
	}
}