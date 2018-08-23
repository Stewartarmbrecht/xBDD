using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace xBDD.Model
{

	/// <summary>
	/// Contains metadata about a feature executed during a test run.
	/// </summary>
	[DataContract]
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
		[DataMember(EmitDefaultValue=false)]
		public string Name { get; internal set; }

		/// <summary>
		/// Name of the feature class.
		/// </summary>
		/// <value><see cref="String"/></value>
		[DataMember(EmitDefaultValue=false)]
		public string ClassName { get; internal set; }

		/// <summary>
		/// Value used to sort the features.
		/// </summary>
		/// <value>Int value used to sort the feature.</value>
		[DataMember(EmitDefaultValue=false)]
		public int Sort { get; set; }

		/// <summary>
		/// The actor name who executes the feature.
		/// As a [BLANK]
		/// </summary>
		/// <value><see cref="String"/></value>
		[DataMember(EmitDefaultValue=false)]
		public string Actor { get; set; }

		/// <summary>
		/// The statment that covers what the user can do.
		/// I would like to [BLANK]
		/// </summary>
		/// <value><see cref="String"/></value>
		[DataMember(EmitDefaultValue=false)]
		public string Capability { get; set; }

		/// <summary>
		/// The statement that explains why the user wants the feature.
		/// In order to [BLANK]
		/// </summary>
		/// <value><see cref="String"/></value>
		[DataMember(EmitDefaultValue=false)]
		public string Value { get; set; }

		/// <summary>
		/// The testing outcome for the feature.
		/// </summary>
		/// <value><see cref="Outcome"/></value>
        public Outcome Outcome { get; internal set; }

        /// <summary>
        /// The reason the feature had a skipped outcome.
        /// </summary>
        /// <value><see cref="String"/></value>
		[DataMember(EmitDefaultValue=false)]
        public string Reason { get; internal set; }

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
        [DataMember]
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

		/// <summary>
		/// Stores the count of scenarios for each reason.
		/// </summary>
		/// <value>Dictionary of reasons and scenario counts.</value>
		public Dictionary<string, int> ScenarioReasonStats { get; internal set; }
	}
}