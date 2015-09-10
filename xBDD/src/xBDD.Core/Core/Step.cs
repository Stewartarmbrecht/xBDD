using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace xBDD.Core
{
    public class Step : IStep
    {
        ICoreFactory factory;
        public Step(IScenario scenario, ICoreFactory factory)
        {
            this.Scenario = scenario;
            this.factory = factory;
        }
        public IScenario Scenario { get; private set; }
        public Action<IStep> Action { get; set; }
        public Func<IStep, Task> ActionAsync { get; set; }
        public ActionType ActionType { get; set; }
        public string Name { get; private set; }
        public void SetName(string name)
        {
            var lowerName = name.ToLower();
            if (name != null && lowerName.EndsWith(" async"))
                name = name.Substring(0, name.Length - 6);
            if(!lowerName.StartsWith("given") && !lowerName.StartsWith("when") && !lowerName.StartsWith("then") && !lowerName.StartsWith("and"))
            {
                Name = Enum.GetName(typeof(ActionType), ActionType) + " " + name;
            }
        }
        public DateTime EndTime { get; set; }
        public DateTime StartTime { get; set; }
        public Outcome Outcome { get; set; }
        public string Reason { get; set; }

        public dynamic State
        {
            get
            {
                return Scenario.State;
            }
        }

        public Exception Exception { get; set; }
        public string MultilineParameter { get; private set; }

        public void ReplaceNameParameters(params string[] keyValue)
        {
            if(Name == null)
            {
                var method = factory.UtilityFactory.GetMethodRetriever().GetCallingStepMethod();
                SetName(factory.UtilityFactory.GetStepNameReader().ReadStepName(method));
            }
            var replacements = new Dictionary<string, string>();
            string key = null;
            foreach(string param in keyValue)
            {
                if (key == null)
                {
                    key = param;
                }
                else
                {
                    replacements.Add(key, param);
                    key = null;
                }
            }

            foreach(var pair in replacements)
            {
                Name = Name.Replace(pair.Key, pair.Value);
            }
        }

        public void ReturnIfPreviousError()
        {
            if(Scenario.Outcome == Outcome.Skipped || Scenario.Outcome == Outcome.Failed)
                throw new SkipStepException("Previous Error");
        }

        public void SetMultilineParameter(string multilineParameter)
        {
            MultilineParameter = multilineParameter;
        }
    }
}