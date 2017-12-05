using System;
using System.Collections.Generic;

namespace xBDD.API.Model.Entities
{
    public class Scenario
    {
        public Guid Id { get; set; }
        public Guid TestRunId { get; set; }
        public string Name { get; set; }
        public string FeatureName { get; set; }
        public string AreaPath { get; set; }
        public Outcome Outcome { get; set; }
        public string Reason { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Time { get; set; }
        public List<Step> Steps = new List<Step>();
    }
}
