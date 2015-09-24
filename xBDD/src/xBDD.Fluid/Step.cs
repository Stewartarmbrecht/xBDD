using System;

namespace xBDD.Fluid
{
    public class Step
    {

        public Step()
        {

        }
        public Step(string title, Action action)
        {
            Title = title;
            Action = action;
        }

        public string Title { get; private set; }
        public Action Action { get; internal set; }

        public Step<TOutput> When<TOutput>(string stepName, Action action) where TOutput : new()
        {
            TOutput state = new TOutput();
            var step = new Step<TOutput>(state);
            step.AppendTitle("When ");
            step.AppendTitle(stepName);
            step.Action = action;
            return step;
        }

        public Step<TOutput> When<TOutput>(Func<Step, Step<TOutput>> builder)
        {
            return builder(this);
        }
        public Step<TOutput> Then<TOutput>(Func<Step, Step<TOutput>> builder)
        {
            return builder(this);
        }
        public Step<TOutput> And<TOutput>(Func<Step, Step<TOutput>> builder)
        {
            return builder(this);
        }
        public Step<TNextState> GetNextStep<TNextState>(TNextState result)
        {
            return new Step<TNextState>(result);
        }

        internal void AppendTitle(object p)
        {
            throw new NotImplementedException();
        }
    }

    public class Step<TState> : Step
    {
        public Step(Scenario scenario)
        {
            Scenario = scenario;
        }
        public Scenario Scenario { get; private set; }
        public Step(TState state)
        {
            State = state;
        }
        public TState State { get; set; }
        public Step<TOutput> When<TOutput>(Func<Step<TState>, Step<TOutput>> builder)
        {
            return builder(this);
        }
        public Step<TOutput> Then<TOutput>(Func<Step<TState>, Step<TOutput>> builder)
        {
            return builder(this);
        }
        public Step<TOutput> And<TOutput>(Func<Step<TState>, Step<TOutput>> builder)
        {
            return builder(this);
        }

        internal void Run()
        {
            throw new NotImplementedException();
        }
    }
}