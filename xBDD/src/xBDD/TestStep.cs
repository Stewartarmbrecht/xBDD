using System;

namespace xBDD
{
    public class TestStep : ITestStep
    {
        public Action<ITestStep> Action { get; set; }
        public ActionType ActionType { get; set; }
        public string Name { get; set; }
    }
}