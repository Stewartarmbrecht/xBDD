using System;
using System.Collections.Generic;
using xBDD.Model;

namespace xBDD.Reporting.Database.Core
{
    internal class Scenario
    {
        internal int Id { get; set; }
        internal int TestRunId { get; set; }
        internal virtual TestRun TestRun { get; set; }
        internal string Name { get; set; }
        internal string FeatureName { get; set; }
        internal string CapabilityPath { get; set; }
        internal Outcome Outcome { get; set; }
        internal string Reason { get; set; }
        internal DateTime StartTime { get; set; }
        internal DateTime EndTime { get; set; }
        internal TimeSpan Time { get; set; }
        internal virtual ICollection<Step> Steps { get; set; }
    }
}
