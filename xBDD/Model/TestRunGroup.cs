using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace xBDD.Model
{
    /// <summary>
    /// Has meta-data and statistics about a single test run.
    /// </summary>
    [DataContract]
    public class TestRunGroup
    {

        /// <summary>
        /// Creates a new test run.
        /// </summary>
        public TestRunGroup()
        {
            TestRuns = new List<TestRun>();
        }

        /// <summary>
        /// Name of the test run group.
        /// </summary>
        /// <value></value>
		[DataMember(EmitDefaultValue=false)]
		public string Name { get; set; }
        
        /// <summary>
        /// Highest level outcome of the test run group.
        /// </summary>
        /// <value>Passed, Failed, Skipped, or Not Run <see cref="Outcome"/></value>
        public Outcome Outcome { get; set; }
        
        /// <summary>
        /// The reason the test run group had a skipped outcome.
        /// </summary>
        /// <value><see cref="String"/></value>
		[DataMember(EmitDefaultValue=false)]
        public string Reason { get; internal set; }

        /// <summary>
        /// The time the first test run was started.
        /// </summary>
        /// <value></value>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// The time the last test run was completed.
        /// </summary>
        /// <value>Date and time</value>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// The total elapsed time of the test run grouop.
        /// </summary>
        /// <value>Date and time</value>
        public TimeSpan Time { get; set; }
        /// <summary>
        /// The test runs covered by the test run group.
        /// </summary>
        /// <value>List of capabilities <see cref="List{Capability}" /></value>
        [DataMember]
		public List<TestRun> TestRuns { get; set; }

        /// <summary>
        /// Statistics about the steps executed in the test run group.
        /// </summary>
        /// <value></value>
		public OutcomeStats StepStats { get; set; }
		
        /// <summary>
        /// Statistics about the scenarios executed in the test run group.
        /// </summary>
        /// <value></value>
        public OutcomeStats ScenarioStats { get; set; }

        /// <summary>
        /// Statistics about the features executed in the test run group.
        /// </summary>
        /// <value></value>
		public OutcomeStats FeatureStats { get; set; }

        /// <summary>
        /// Statistics about the capabilities executed in the test run group.
        /// </summary>
        /// <value></value>
		public OutcomeStats CapabilityStats { get; set; }

        /// <summary>
        /// Statistics about the test runs executed in the test run group.
        /// </summary>
        /// <value></value>
		public OutcomeStats TestRunStats { get; set; }

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

		/// <summary>
		/// Stores the count of capabilities for each reason.
		/// </summary>
		/// <value>Dictionary of reasons and capability counts.</value>
		public Dictionary<string, int> CapabilityReasonStats { get; internal set; }
		/// <summary>
		/// Stores the count of test runs for each reason.
		/// </summary>
		/// <value>Dictionary of reasons and test run counts.</value>
		public Dictionary<string, int> TestRunReasonStats { get; internal set; }
    }
}
