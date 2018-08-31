using System;
using xBDD.Model;

namespace xBDD.Reporting.Database.Core
{
    internal class Step
    {
        internal int Id { get; set; }
        internal int ScenarioId { get; set; }
        internal virtual Scenario Scenario { get; set; }
        internal string Name { get; set; }
        internal DateTime StartTime { get; set; }
        internal DateTime EndTime { get; set; }
        internal Outcome Outcome { get; set; }
        internal string Reason { get; set; }
        internal string Exception { get; set; }
        internal string MultilineParameter { get; set; }
    }
}
