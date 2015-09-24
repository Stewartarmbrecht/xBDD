using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xBDD.Fluid.Tests.Steps;

namespace xBDD.Fluid
{
    public class Scenario
    {
        public Step Given(Func<Step> builder)
        {
            return builder();
        }
        public Step<TState> Given<TState>(Func<Step<TState>> builder)
        {
            return builder();
        }
        public Step When(Func<Step> builder)
        {
            return builder();
        }
        public Step<TState> When<TState>(Func<Step<TState>> builder)
        {
            return builder();
        }

        public Scenario Given(string stepName, Action state)
        {
            throw new NotImplementedException();
        }
        public Scenario When(string stepName, Action state)
        {
            throw new NotImplementedException();
        }
        public Scenario Then(string stepName, Action state)
        {
            throw new NotImplementedException();
        }
        public Scenario And(string stepName, Action state)
        {
            throw new NotImplementedException();
        }

        public Scenario Given(Step step)
        {
            return this;
        }
        public Scenario When(Step step)
        {
            return this;
        }
        public Scenario Then(Step step)
        {
            return this;
        }
        public Scenario And(Step step)
        {
            return this;
        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
