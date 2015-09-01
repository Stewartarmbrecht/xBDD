﻿using System;
using System.Collections.Generic;

namespace xBDD.Core
{
    public class Step : IStep
    {
        IFactory factory;
        public Step(IScenario scenario, IFactory factory)
        {
            this.Scenario = scenario;
            this.factory = factory;
        }
        public IScenario Scenario { get; private set; }
        public Action<IStep> Action { get; set; }
        public ActionType ActionType { get; set; }
        public string Name { get; private set; }
        public void SetName(string name)
        {
            Name = Enum.GetName(typeof(ActionType), ActionType) + " " + name;
        }
        public DateTime EndTime { get; set; }
        public DateTime StartTime { get; set; }
        public Outcome Outcome { get; set; }

        public void SetNameWithReplacement(string key, string value)
        {
            var replacements = new Dictionary<string, string>();
            replacements.Add(key, value);
            var method = factory.GetMethodRetriever().GetCallingMethod();
            SetName(factory.GetStepNameReader().ReadStepNameWithReplacement(this, null, method, replacements));
        }
    }
}