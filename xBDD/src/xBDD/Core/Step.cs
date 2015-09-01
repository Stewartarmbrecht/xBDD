using System;

namespace xBDD.Core
{
    public class Step : IStep
    {
        public Step(IScenario scenario)
        {
            this.Scenario = scenario;
        }
        public IScenario Scenario { get; private set; }
        public Action<IStep> Action { get; set; }
        public ActionType ActionType { get; set; }
        public string Name { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime StartTime { get; set; }
        public Outcome Outcome { get; set; }
    }
}