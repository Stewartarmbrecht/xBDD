using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace xBDD.Model
{

	/// <summary>
	/// Contains metadata about an capability.
	/// </summary>
	[DataContract]
	public class Capability
	{
		internal Capability()
		{
			Features = new List<Feature>();
		}

		/// <summary>
		/// The parent test run.
		/// </summary>
		/// <value><see cref="TestRun"/></value>
		public TestRun TestRun { get; set; }

		/// <summary>
		/// The name of the capability.
		/// Built from the code's namespace.
		/// </summary>
		/// <value></value>
		[DataMember(EmitDefaultValue=false)]
		public string Name { get; set; }

		/// <summary>
		/// The testing outcome for the capability.
		/// </summary>
		/// <value><see cref="Outcome"/></value>
        public Outcome Outcome { get; set; }

        /// <summary>
        /// The reason the capability had a skipped outcome.
        /// </summary>
        /// <value><see cref="String"/></value>
		[DataMember(EmitDefaultValue=false)]
        public string Reason { get; internal set; }

		/// <summary>
		/// Markdown formtted explanation of the capability.
		/// </summary>
		/// <value><see cref="String"/></value>
		[DataMember(EmitDefaultValue=false)]
		public string Explanation { get; set; }

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
		/// The duration for executing the capability.
		/// </summary>
		/// <value><see cref="TimeSpan"/></value>
        public TimeSpan Time { get; set; }

		/// <summary>
		/// The features executed within the capability.
		/// </summary>
		/// <value><see cref="List{Feature}"/></value>
		[DataMember]
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

		/// <summary>
		/// Stores the count of scenarios for each reason.
		/// </summary>
		/// <value>Dictionary of reasons and scenario counts.</value>
		public Dictionary<string, int> ScenarioReasonStats { get; internal set; }

		/// <summary>
		/// Stores the count of features for each reason.
		/// </summary>
		/// <value>Dictionary of reasons and feature counts.</value>
		public Dictionary<string, int> FeatureReasonStats { get; internal set; }
	}
}