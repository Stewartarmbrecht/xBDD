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
    public class TestRun
    {
        /// <summary>
        /// The scenarios included in the test run.
        /// </summary>
        /// <value>Returns a list of scenarios <see cref="List{Scenario}"/></value>
        public List<Scenario> Scenarios
        {
            get
            {
                return  (from area in this.Areas
                        from feature in area.Features
                        from scenario in feature.Scenarios
                        select scenario).ToList(); 
    
            }
        }

        /// <summary>
        /// Creates a new test run.
        /// </summary>
        public TestRun()
        {
            Areas = new List<Area>();
        }

        /// <summary>
        /// Name of the test run.
        /// </summary>
        /// <value></value>
		[DataMember(EmitDefaultValue=false)]
		public string Name { get; set; }
        
        /// <summary>
        /// Indicates whether the test run has been explicitly
        /// </summary>
        /// <value>Boolean value indicating whether the test run has been explicitly sorted.</value>
        public bool Sorted { get; set; }

        /// <summary>
        /// Highest level outcome of the test run.
        /// </summary>
        /// <value>Passed, Failed, Skipped, or Not Run <see cref="Outcome"/></value>
        public Outcome Outcome { get; set; }
        
        /// <summary>
        /// The time the test run was started.
        /// </summary>
        /// <value></value>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// The time the test run was completed.
        /// </summary>
        /// <value>Date and time</value>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// The total elapsed time of the test run.
        /// </summary>
        /// <value>Date and time</value>
        public TimeSpan Time { get; set; }
        /// <summary>
        /// The areas covered by the test run.
        /// </summary>
        /// <value>List of areas <see cref="List{Area}" /></value>
        [DataMember]
		public List<Area> Areas { get; set; }

        /// <summary>
        /// Statistics about the steps executed in the test run.
        /// </summary>
        /// <value></value>
		public OutcomeStats StepStats { get; set; }
		
        /// <summary>
        /// Statistics about the scenarios executed in the test run.
        /// </summary>
        /// <value></value>
        public OutcomeStats ScenarioStats { get; set; }

        /// <summary>
        /// Statistics about the features executed in the test run.
        /// </summary>
        /// <value></value>
		public OutcomeStats FeatureStats { get; set; }

        /// <summary>
        /// Statistics about the features executed in the test run.
        /// </summary>
        /// <value></value>
		public OutcomeStats AreaStats { get; set; }
    }
}
