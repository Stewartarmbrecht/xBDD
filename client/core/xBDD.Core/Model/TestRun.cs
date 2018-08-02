using System;
using System.Collections.Generic;
using System.Linq;

namespace xBDD.Model
{
    public class TestRun
    {
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

        public TestRun()
        {
            Areas = new List<Area>();
        }

		public string Name { get; set; }
        public Outcome Outcome { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Time { get; set; }
		public List<Area> Areas { get; set; }

		public OutcomeStats StepStats { get; set; }
		public OutcomeStats ScenarioStats { get; set; }
		public OutcomeStats FeatureStats { get; set; }
		public OutcomeStats AreaStats { get; set; }
    }
}
