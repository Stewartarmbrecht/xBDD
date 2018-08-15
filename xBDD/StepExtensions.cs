namespace xBDD 
{
    using xBDD.Model;
    public static class StepExtensions
    {
        public static Step Because(this Step step, string explanation)
        {
            step.AppendToName($" because {explanation}");
            return step;
        }
    }
}

