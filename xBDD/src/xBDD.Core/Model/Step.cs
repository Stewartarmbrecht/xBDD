using System;
using System.Threading.Tasks;

namespace xBDD.Model
{
    public class Step
    {
        public Scenario Scenario { get; set; }
        public string Name { get; set; }
        public string FullName { get { return Enum.GetName(typeof(ActionType), ActionType) + " " + Name; } }
        public string MultilineParameter { get; set; }
        public TextFormat MultilineParameterFormat { get; set; }
        public Action<Step> Action { get; set; }
        public Func<Step, Task> ActionAsync { get; set; }
        public ActionType ActionType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Time { get; set; }
        public Outcome Outcome { get; set; }
        public string Reason { get; set; }
        public Exception Exception { get; set; }
        public string Output { get; set; }
        public TextFormat OutputFormat { get; set; }
    }
}