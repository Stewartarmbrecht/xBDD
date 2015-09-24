using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xBDD.Fluid.Tests.Steps;

namespace xBDD.Fluid
{
    public class NewScenario
    {
        public NewScenario Given(Step step)
        {
            return this;
        }
        public NewScenario When(Step step)
        {
            return this;
        }
        public NewScenario Then(Step step)
        {
            return this;
        }
        public NewScenario And(Step step)
        {
            return this;
        }

        public NewScenario Given(string stepName, Action state)
        {
            throw new NotImplementedException();
        }
        public NewScenario When(string stepName, Action state)
        {
            throw new NotImplementedException();
        }
        public NewScenario Then(string stepName, Action state)
        {
            throw new NotImplementedException();
        }
        public NewScenario And(string stepName, Action state)
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
