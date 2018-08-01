using System;
using System.Collections.Generic;

namespace xBDD.Model
{
    public class Scenario
    {
        public Scenario()
        {
            Steps = new List<Step>();
        }
        public Feature Feature { get; set; }
        public string Name { get; set; }
        public Outcome Outcome { get; set; }
        public string Reason { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Time { get; set; }
        public List<Step> Steps { get; private set; }

        public OutcomeStats StepStats { get; set; }
    }
}