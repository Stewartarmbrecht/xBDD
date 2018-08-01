using System;
using System.Collections.Generic;

namespace xBDD.Model
{
	public class Area
	{
		public Area()
		{
			Features = new List<Feature>();
		}
		public TestRun TestRun { get; set; }
		public string Name { get; set; }
        public Outcome Outcome { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Time { get; set; }
		public List<Feature> Features { get; set; }

		public OutcomeStats StepStats { get; set; }
		public OutcomeStats ScenarioStats { get; set; }
		public OutcomeStats FeatureStats { get; set; }
	}
}