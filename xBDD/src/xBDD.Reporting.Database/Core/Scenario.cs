using System;
using System.Collections.Generic;

namespace xBDD.Reporting.Database.Core
{
    public class Scenario
    {
        public int Id { get; set; }
        public int TestRunId { get; set; }
        public virtual TestRun TestRun { get; set; }
        public string Name { get; set; }
        public string FeatureName { get; set; }
        public string AreaPath { get; set; }
        public Outcome Outcome { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Time { get; set; }
        public virtual ICollection<Step> Steps { get; set; }
    }
}
