using System;
using System.Collections.Generic;

namespace xBDD.Model
{

    /// <summary>
    /// Tracks metadata about a scenario.
    /// </summary>
    public class Scenario
    {
        /// <summary>
        /// Creates a new scenario.
        /// </summary>
        internal Scenario()
        {
            Steps = new List<Step>();
        }

        /// <summary>
        /// The feature the scenario is a part of.
        /// </summary>
        /// <value><see cref="Feature"/></value>
        public Feature Feature { get; internal set; }

        /// <summary>
        /// The name of the scenario.
        /// Built from the name of the test method.
        /// </summary>
        /// <value><see cref="String"/></value>
        public string Name { get; internal set; }

        /// <summary>
        /// The name of the scenario test method.
        /// If one is not provided it will match the scenario name.
        /// </summary>
        /// <value><see cref="String"/></value>
        public string MethodName { get; internal set; }

		/// <summary>
		/// String value used to sort the scenario.
		/// </summary>
		/// <value>String value used to sort the scenario.</value>
		public int Sort { get; set; }

        /// <summary>
        /// The outcome of executing the scenario.
        /// </summary>
        /// <value><see cref="Outcome"/></value>
        public Outcome Outcome { get; internal set; }

        /// <summary>
        /// The reason for the outcome.
        /// </summary>
        /// <value><see cref="String"/></value>
        public string Reason { get; internal set; }

        /// <summary>
        /// The start time for executing the scenario.
        /// </summary>
        /// <value><see cref="DateTime"/></value>
        public DateTime StartTime { get; internal set; }

        /// <summary>
        /// The end time for executing the scenario.
        /// </summary>
        /// <value><see cref="DateTime"/></value>
        public DateTime EndTime { get; internal set; }

        /// <summary>
        /// The duration of the scenario execution.
        /// </summary>
        /// <value><see cref="TimeSpan"/></value>
        public TimeSpan Time { get; internal set; }

        /// <summary>
        /// The steps executed for the scenario.
        /// </summary>
        /// <value><see cref="List{Step}"/></value>
        public List<Step> Steps { get; private set; }

        /// <summary>
        /// The step level statistics for the scenario.
        /// </summary>
        /// <value><see cref="OutcomeStats"/></value>
        public OutcomeStats StepStats { get; internal set; }
    }
}