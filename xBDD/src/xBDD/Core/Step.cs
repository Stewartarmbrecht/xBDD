using System;

namespace xBDD.Core
{
    public class Step : IStep
    {
        public Action<IStep> Action { get; set; }
        public ActionType ActionType { get; set; }
        public string Name { get; set; }
    }
}