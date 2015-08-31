using System;

namespace xBDD
{
    public class TestStep
    {
        public Action<TestStep> Action { get; internal set; }
        public ActionType ActionType { get; internal set; }
        public string Name { get; set; }
    }
}