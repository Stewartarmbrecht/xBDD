using System;
using System.Collections.Generic;

namespace xBDD.Model

{
	public class Feature
	{
		public Feature()
		{
			Scenarios = new List<Scenario>();
		}
		public Area Area { get; set; }
		public string Name { get; set; }
		public string Actor { get; set; }
		public string Capability { get; set; }
		public string Value { get; set; }
        public Outcome Outcome { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Time { get; set; }
		public List<Scenario> Scenarios { get; set; }

		public OutcomeStats StepStats { get; set; }
		public OutcomeStats ScenarioStats { get; set; }
	}
}