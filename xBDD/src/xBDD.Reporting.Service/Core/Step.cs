using System;
using xBDD.Model;

namespace xBDD.Reporting.Service.Core
{
    public class Step
    {
        public Guid Id { get; set; }
        public Guid ScenarioId { get; set; }
        public string Name { get; set; }
        public string ActionType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Outcome Outcome { get; set; }
        public string Reason { get; set; }
        public string Exception { get; set; }
        public string MultilineParameter { get; set; }
    }
}
